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

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        int cropX, cropY, cropWidth, cropHeight;
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
        string Loadingif = "C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\spinner.gif";
        string json2;
        Bitmap bit1;
        async Task PutTaskDelay()
        {
            await Task.Delay(1000);
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            panel1.Controls.Add(pictureBox1);
            for(int i=0;i < TemplateCreator.listTemplate.Count; i++)
               Template.Items.Add(TemplateCreator.listTemplate[i]);
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
            ocr.Init(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\tessdata_eng\", "eng", false); // To use correct tessdata
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
        private void ocrUpload(Int32 index)
        {
            string temppath1 = Globals.img_path[index];
            if (temppath1 == "")
                return;
            Bitmap image1 = new Bitmap(temppath1);

            bit1 = new Bitmap(Globals.img_path[index]);

            string[] lines = { "" };
            string curFile = @"C:\Users\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\ocrOutput.txt";
            if (File.Exists(curFile) == false)
            {
                File.WriteAllLines(@"C:\Users\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\ocrOutput.txt", lines);
            }
            int i = 0;
            while (Globals.TextboxStringMatch[i] != null)
            {
                Globals.TextboxStringMatch[i] = null;
                i++;
            }

            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
            ocr.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
            ocr.Init(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\tessdata_eng\", "eng", false); // To use correct tessdata

            richTextBox1.Text = "";

            i = 0;
            List<tessnet2.Word> result1 = ocr.DoOCR(image1, Rectangle.Empty);
            foreach (tessnet2.Word word in result1)
            {
                richTextBox1.Text += word.Text;
                Globals.TextboxStringMatch[i] = word.Text;
                using (StreamWriter file = new StreamWriter(@"C:\Users\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\ocrOutput.txt", true))
                {
                    file.WriteLine(word.Text);
                }
                richTextBox1.Text += " ";
                i++;
            }
            Globals.imgocr_text[index] = richTextBox1.Text;
            JArray array2 = new JArray();
            array2.Add(Globals.imgocr_text[TemplateCreator.Globals.index]);
            JObject o = new JObject();
            o["JSON2"] = array2;
            json2 = o.ToString();

        }

        private void RegexSearch(string sPattern)
        {
            comboBox1.Items.Add(sPattern);
            richTextBox1.Text = "";
            foreach (string s in Globals.TextboxStringMatch)
            {
                if (s == null || sPattern == null)
                    break;

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.AppendText(s + " ");
                }
                else
                {
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.AppendText(s + " ");
                }
            }
        }

        private void upload(object sender, EventArgs e)
        {            
            if (TemplateCreator.Globals.length == 0)
            {
                string[] customText = new string[] { "Invoice Number", "Invoice Date", "Invoice Name", "Address", "Telephone", "Name", "Amount", "DOCTOR" };
                comboBox1.Items.AddRange(customText);
            }
        }

        private void Template_TextChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            if (TemplateCreator.template[Template.Text] == null)
                return;
            foreach (string item in TemplateCreator.template[Template.Text])
            {
                checkedListBox1.Items.Add(item);
            }
        }
        private string ValidateOutput(string value)
        {
            var myDictionary = new Dictionary<string, IList<string>>();

            myDictionary["Invoice"] = new List<string> { "Inv..ce", "I.vo.c.", "Inv..c." };
            myDictionary["Total"] = new List<string> { "Tota.", "To.al", "To..l" };
            myDictionary["Time"] = new List<string> { "Time", "Ti.e", "Tim." };
            myDictionary["Number"] = new List<string> { "Num...", "No", "Non" };
            myDictionary["Date"] = new List<string> { "Date", "D.t.", "D..e", };
            myDictionary["Name"] = new List<string> { "Name", "N.m.", "Na.." };
            
            for (int i = 0; i < Globals.TextboxStringMatch.Length; i++)
            {
                int j = 0, m = 0;
                string s = Globals.TextboxStringMatch[i];
                if (s == null)
                    break;

                while (m < 3)
                {

                    if (System.Text.RegularExpressions.Regex.IsMatch(s, myDictionary["Invoice"][m], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        j = 0;
                        int k = i;
                        k++;
                        s = Globals.TextboxStringMatch[k];
                        k++;
                        while (j < 3)
                        {
                            if (value == "Invoice Number")
                                if (System.Text.RegularExpressions.Regex.IsMatch(s, myDictionary["Number"][j], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                    return Globals.TextboxStringMatch[k];

                            if (value == "Invoice Date")
                                if (System.Text.RegularExpressions.Regex.IsMatch(s, myDictionary["Date"][j], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                    return Globals.TextboxStringMatch[k];

                            if (value == "Invoice Name")
                                if (System.Text.RegularExpressions.Regex.IsMatch(s, myDictionary["Name"][j], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                    return Globals.TextboxStringMatch[k];
                            j++;
                        }

                        break;
                    }
                    else
                    {
                        int n = i;
                        n++;

                        if (value == "Receipt Total")
                            if (System.Text.RegularExpressions.Regex.IsMatch(s, myDictionary["Total"][m], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                return Globals.TextboxStringMatch[n];

                        if (value == "Receipt Date")
                        {
                            Debug.WriteLine(value + " : " + s);
                            if (System.Text.RegularExpressions.Regex.IsMatch(s, myDictionary["Date"][m], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                return Globals.TextboxStringMatch[n];
                        }

                        if (value == "Receipt Time")
                            if (System.Text.RegularExpressions.Regex.IsMatch(s, myDictionary["Time"][m], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                return Globals.TextboxStringMatch[n];
                    }
                    m++;
                }
            }
            return "";
        }
        string value1, value2;
        string Temp = "";

        private void GetOCR(object sender, EventArgs e)
        {
            int m = 0;
            RichTextBox[] txt = new RichTextBox[5];
            txt[0] = templatetextbox1; txt[1] = templatetextbox2; txt[2] = templatetextbox3; txt[3] = templatetextbox4; txt[4] = templatetextbox5;
            string json;
            TemplateCreator.templateDetail = new JObject();
            if (new FileInfo("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\" + Template.Text + ".json").Length != 0)
            {
                using (StreamReader r = new StreamReader("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\" + Template.Text + ".json"))
                {
                    json = r.ReadToEnd();
                }
                TemplateCreator.templateDetail = JObject.Parse(json);
            }
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                value2 = itemChecked.ToString();
                if (value2 == null || value2 == "")
                    return;
                
                if (TemplateCreator.templateDetail[value2][1].ToString() == "" || TemplateCreator.templateDetail[value2][0].ToString() == "" || TemplateCreator.templateDetail[value2][2].ToString() == "" || TemplateCreator.templateDetail[value2][3].ToString() == "")
                    return;
                Rectangle rect = new Rectangle(Int32.Parse(TemplateCreator.templateDetail[value2][0].ToString()), Int32.Parse(TemplateCreator.templateDetail[value2][1].ToString()), Int32.Parse(TemplateCreator.templateDetail[value2][2].ToString()), Int32.Parse(TemplateCreator.templateDetail[value2][3].ToString()));
                Bitmap bit = new Bitmap(bit1, pictureBox1.Width, pictureBox1.Height);
                Bitmap crop = new Bitmap(Int32.Parse(TemplateCreator.templateDetail[value2][2].ToString()), Int32.Parse(TemplateCreator.templateDetail[value2][3].ToString()));
                Graphics gfx = Graphics.FromImage(crop);
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.CompositingQuality = CompositingQuality.HighQuality;
                gfx.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel);
                tessnet2.Tesseract ocr = new tessnet2.Tesseract();
                ocr.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
                ocr.Init(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\tessdata_eng\", "eng", false); // To use correct tessdata
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

        

        private void SearchTemplate(object sender, EventArgs e)
        {
            string connstr = Utility.GetConnectionString();
            SqlConnection connection = new SqlConnection(connstr);
            value1 = Template.Text;
            int m = 0;
            int Index = 0;
            Temp = "";
            RichTextBox[] txt = new RichTextBox[5];
            txt[0] = templatetextbox1; txt[1] = templatetextbox2; txt[2] = templatetextbox3; txt[3] = templatetextbox4; txt[4] = templatetextbox5;
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                cropWidth = cropHeight = 0;
                if (value1 == null || value1 == "")
                    return;
                

                if (value1.Equals("Invoice", StringComparison.Ordinal))
                {
                    if (value2.Equals("Invoice Date", StringComparison.Ordinal))
                    {
                        string query = "select X,Y,Width,Height from InvoiceDateTable where InvoiceDateID = 1";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader Reader;
                        connection.Open();
                        Reader = command.ExecuteReader();
                        while (Reader.Read()) { cropX = Int32.Parse(Reader.GetValue(0).ToString()); cropY = Int32.Parse(Reader.GetValue(1).ToString()); cropWidth = Int32.Parse(Reader.GetValue(2).ToString()); cropHeight = Int32.Parse(Reader.GetValue(3).ToString()); }
                        Index = 0;
                    }
                    if (value2.Equals("Invoice Number", StringComparison.Ordinal))
                    {
                        string query = "select X,Y,Width,Height from InvoiceNoTable where InvoiceNoID = 1";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader Reader;
                        connection.Open();
                        Reader = command.ExecuteReader();
                        while (Reader.Read()) { cropX = Int32.Parse(Reader.GetValue(0).ToString()); cropY = Int32.Parse(Reader.GetValue(1).ToString()); cropWidth = Int32.Parse(Reader.GetValue(2).ToString()); cropHeight = Int32.Parse(Reader.GetValue(3).ToString()); }
                        Index = 1;
                    }
                    if (value2.Equals("Invoice Name", StringComparison.Ordinal))
                    {
                        string query = "select X,Y,Width,Height from InvoiceNameTable where Id = 1";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader Reader;
                        connection.Open();
                        Reader = command.ExecuteReader();
                        while (Reader.Read()) { cropX = Int32.Parse(Reader.GetValue(0).ToString()); cropY = Int32.Parse(Reader.GetValue(1).ToString()); cropWidth = Int32.Parse(Reader.GetValue(2).ToString()); cropHeight = Int32.Parse(Reader.GetValue(3).ToString()); }
                        Index = 2;
                    }
                }
                else if (value1.Equals("Receipt", StringComparison.Ordinal))
                {
                    if (value2.Equals("Receipt Date", StringComparison.Ordinal))
                    {
                        string query = "select X,Y,Width,Height from ReceiptDateTable where DateID = 2";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader Reader;
                        connection.Open();
                        Reader = command.ExecuteReader();
                        while (Reader.Read()) { cropX = Int32.Parse(Reader.GetValue(0).ToString()); cropY = Int32.Parse(Reader.GetValue(1).ToString()); cropWidth = Int32.Parse(Reader.GetValue(2).ToString()); cropHeight = Int32.Parse(Reader.GetValue(3).ToString()); }
                        Index = 0;
                    }
                    if (value2.Equals("Receipt Total", StringComparison.Ordinal))
                    {
                        string query = "select X,Y,Width,Height from ReceiptTotalTable where TotalID = 2";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader Reader;
                        connection.Open();
                        Reader = command.ExecuteReader();
                        while (Reader.Read()) { cropX = Int32.Parse(Reader.GetValue(0).ToString()); cropY = Int32.Parse(Reader.GetValue(1).ToString()); cropWidth = Int32.Parse(Reader.GetValue(2).ToString()); cropHeight = Int32.Parse(Reader.GetValue(3).ToString()); }
                        Index = 1;
                    }
                    if (value2.Equals("Receipt Time", StringComparison.Ordinal))
                    {
                        string query = "select X,Y,Width,Height from ReceiptTimeTable where TimeID = 2";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader Reader;
                        connection.Open();
                        Reader = command.ExecuteReader();
                        while (Reader.Read()) { cropX = Int32.Parse(Reader.GetValue(0).ToString()); cropY = Int32.Parse(Reader.GetValue(1).ToString()); cropWidth = Int32.Parse(Reader.GetValue(2).ToString()); cropHeight = Int32.Parse(Reader.GetValue(3).ToString()); }
                        Index = 2;
                    }
                }
                if (cropWidth < 1 || cropHeight < 1)
                {
                    return;
                }

                /*
                
                
                 = ValidateOutput(value2);// richTextBox1.Text;
                Temp += txt[Index].Text + " ";
                m++;
                connection.Close();*/
            }

        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            JArray array1 = new JArray();
            array1.Add(value1);
            array1.Add(value2);
            array1.Add(DateTime.Now.ToString("h:mm:ss tt") + " " + DateTime.Now.ToString("M/d/yyyy"));
            array1.Add(Temp);

            JObject o = new JObject();
            o["JSON1"] = array1;
            string json1 = o.ToString();
            Debug.WriteLine(json1);
            Debug.WriteLine(json2);
            string query1 = "INSERT INTO OutputTable (ID , JSON1 ,JSON2)";
            query1 += " VALUES (@ID, @JSON1, @JSON2)";
            /*
            SqlCommand myCommand = new SqlCommand(query1, connection);
            myCommand.Parameters.AddWithValue("@ID", 1);
            myCommand.Parameters.AddWithValue("@JSON1", json1);
            myCommand.Parameters.AddWithValue("@JSON2", json2);
            myCommand.ExecuteNonQuery();*/
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
            TemplateCreator temp = new TemplateCreator();
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
            RegexSearch(comboBox1.Text);
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
                        richTextBox1.AppendText(s + " ");
                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.AppendText(s + " ");
                    }
                }
            }
        }


    }
}


