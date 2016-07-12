using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static class Globals
        {
            public static string[] img_path = { "", "", "", "", "", "" }; // Modifiable in Code
            public static string[] imgocr_text = { "", "", "", "", "", "" };
            public static string[] TextboxStringMatch = new string[1000];
            public static Int32 count = 0;
        }
        public int Length { get; }
        string Loadingif = "..\\..\\spinner.gif";
        public static JObject template, templateDetail;
        public static List<String> listTemplate = new List<String>();
        RichTextBox[] txt = new RichTextBox[5];
        Bitmap bit1;
        async Task PutTaskDelay()
        {
            await Task.Delay(1000);
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            SaveData.Enabled = false;
            panel1.Controls.Add(pictureBox1);

            template = new JObject();
            templateDetail = new JObject();
            string json;
            using (StreamReader r = new StreamReader("..\\..\\JSON\\LISTTEMPLATE.json"))
            {
                json = r.ReadToEnd();
            }

            if (new FileInfo("..\\..\\JSON\\LISTTEMPLATE.json").Length != 0)
                listTemplate = json.Split(',').ToList();
            using (StreamReader r = new StreamReader("..\\..\\JSON\\TEMPLATE.json"))
            {
                json = r.ReadToEnd();
            }
            if (new FileInfo("..\\..\\JSON\\TEMPLATE.json").Length != 0)
                template = JObject.Parse(json);
            for (int i = 0; i < listTemplate.Count; i++)
                Template.Items.Add(listTemplate[i]);
            bit1 = new Bitmap(Loadingif);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = bit1;
            await PutTaskDelay();
            Uploadimages(0);
        }
        public void Uploadimages(int index)
        {
            string temppath1 = TemplateCreator.Globals.img_path[index];
            if (temppath1 == "")
                return;
            Bitmap image1 = new Bitmap(temppath1);
            bit1 = new Bitmap(TemplateCreator.Globals.img_path[index]);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = bit1;

            int i = 0;
            while (Globals.TextboxStringMatch[i] != null)
            {
                Globals.TextboxStringMatch[i] = null;
                i++;
            }
            i = 0;
            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
            ocr.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
            ocr.Init(@"..\\..\\tessdata_eng\", "eng", false); // To use correct tessdata
            richTextBox1.Text = "";
            List<tessnet2.Word> result1 = ocr.DoOCR(image1, Rectangle.Empty);
            foreach (tessnet2.Word word in result1)
            {
                Globals.TextboxStringMatch[i] = word.Text;
                i++;
                richTextBox1.Text += word.Text;
                richTextBox1.Text += " ";
            }
        }


        private void Template_TextChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            if (template[Template.Text] == null)
                return;
            foreach (string item in template[Template.Text])
            {
                checkedListBox1.Items.Add(item);
            }
        }
        private void ValidateOutput(string value)
        {
            var myDictionary = new Dictionary<string, IList<string>>();

            myDictionary["Invoice"] = new List<string> { "Inv..ce", "I.vo.c.", "Inv..c." };
            myDictionary["Total"] = new List<string> { "Tota.", "To.al", "To..l" };
            myDictionary["Time"] = new List<string> { "Time", "Ti.e", "Tim." };
            myDictionary["Number"] = new List<string> { "Num...", "No", "Non" };
            myDictionary["Date"] = new List<string> { "Date", "D.t.", "D..e", };
            myDictionary["Name"] = new List<string> { "Name", "N.m.", "Na.." };            
        }
        string value2;
        private void GetOCR(object sender, EventArgs e)
        {
            SaveData.Enabled = true;
            int m = 0;
            txt[0] = templatetextbox1; txt[1] = templatetextbox2; txt[2] = templatetextbox3; txt[3] = templatetextbox4; txt[4] = templatetextbox5;
            txt[0].Text = txt[1].Text = txt[2].Text = txt[3].Text = txt[4].Text = "";
            string json;
            templateDetail = new JObject();
            if (new FileInfo("..\\..\\JSON\\" + Template.Text + ".json").Length != 0)
            {
                using (StreamReader r = new StreamReader("..\\..\\JSON\\" + Template.Text + ".json"))
                {
                    json = r.ReadToEnd();
                }
                templateDetail = JObject.Parse(json);
            }
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                value2 = itemChecked.ToString();
                if (value2 == null || value2 == "")
                    return;
                
                if (templateDetail[value2][1].ToString() == "" || templateDetail[value2][0].ToString() == "" || templateDetail[value2][2].ToString() == "" || templateDetail[value2][3].ToString() == "")
                    return;
                Rectangle rect = new Rectangle(Int32.Parse(templateDetail[value2][0].ToString()), Int32.Parse(templateDetail[value2][1].ToString()), Int32.Parse(templateDetail[value2][2].ToString()), Int32.Parse(templateDetail[value2][3].ToString()));
                Bitmap bit = new Bitmap(bit1, pictureBox1.Width, pictureBox1.Height);
                Bitmap crop = new Bitmap(Int32.Parse(templateDetail[value2][2].ToString()), Int32.Parse(templateDetail[value2][3].ToString()));
                Graphics gfx = Graphics.FromImage(crop);
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.CompositingQuality = CompositingQuality.HighQuality;
                gfx.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel);
                tessnet2.Tesseract ocr = new tessnet2.Tesseract();
                ocr.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
                ocr.Init(@"..\\..\\tessdata_eng\", "eng", false); // To use correct tessdata
                List<tessnet2.Word> result1 = ocr.DoOCR(crop, Rectangle.Empty);
                txt[m].Text = "";
                foreach (tessnet2.Word word in result1)
                {
                    if (word.Text != "~")
                        txt[m].Text += word.Text + " ";
                }
                m++;
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            JArray array1 = new JArray();
            array1.Add(DateTime.Now.ToString("h:mm:ss tt") + " " + DateTime.Now.ToString("M/d/yyyy"));
            int p = 0;
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                array1.Add(itemChecked.ToString() + " : " +txt[p].Text);p++;
            }
            array1.Add("OCR: " + richTextBox1.Text);
            JObject ocr = new JObject();
            ocr[Template.Text] = array1;
            File.WriteAllText(@"..\\..\\JSON\\" + Template.Text + "ocrOutput.json", ocr.ToString());
            MessageBox.Show("Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TemplateCreator.Globals.index < TemplateCreator.Globals.length - 1)
                TemplateCreator.Globals.index += 1;

            Uploadimages(TemplateCreator.Globals.index);
        }

        private void templateCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu temp = new MainMenu();
            temp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TemplateCreator.Globals.index > 0)
                TemplateCreator.Globals.index -= 1;

            Uploadimages(TemplateCreator.Globals.index);
        }



        private void Reset(object sender, EventArgs e)
        {
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string sPattern = comboBox1.Text;
            comboBox1.Items.Add(sPattern);
            richTextBox1.Text = "";
            foreach (string s in Globals.TextboxStringMatch)
            {
                if (s == null || sPattern == null)
                    break;

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
                    richTextBox1.AppendText(s + " ");
                }
                else
                {
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Arial", 9, FontStyle.Regular);
                    richTextBox1.AppendText(s + " ");
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sPattern = comboBox1.Text;
                comboBox1.Items.Add(sPattern);
                richTextBox1.Text = "";
                foreach (string s in Globals.TextboxStringMatch)
                {
                    if (s == null || sPattern == null)
                        break;

                    if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
                        richTextBox1.AppendText(s + " ");
                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectionFont = new Font("Arial", 9, FontStyle.Regular);
                        richTextBox1.AppendText(s + " ");
                    }
                }
            }
        }


    }
}


