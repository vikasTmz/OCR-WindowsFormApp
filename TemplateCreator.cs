using System;
using System.Diagnostics;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace HelloWorld
{
    public partial class TemplateCreator : Form
    {
        int index = 1;
        bool hasSaved=false;
        public static class Globals
        {
            public static string[] img_path = { "", "", "", "", "", "" }; // Modifiable in Code
            public static Int32 length = 0,index=0;
        }

        public static RichTextBox[] txtbx = new RichTextBox[10];
        public static RichTextBox[] x = new RichTextBox[10];
        public static RichTextBox[] y = new RichTextBox[10];
        public static RichTextBox[] width = new RichTextBox[10];
        public static RichTextBox[] height = new RichTextBox[10];
        public static Button[] historytemp = new Button[10];
        public imagecrop croppper;
        public static JObject template,templateDetail;
        public static List<String> listTemplate = new List<String>();
        public static MemoryStream[] memStream = new MemoryStream[20];
        public static int memoryindex=0;
        int buttonindex = 0;
        public TemplateCreator()
        {
            InitializeComponent();
        }
        public int Length { get; }
        private void TemplateCreator_Load_1(object sender, EventArgs e)
        {
            template = new JObject();
            templateDetail = new JObject();
            string json;

            using (StreamReader r = new StreamReader("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\LISTTEMPLATE.json"))
            {
                json = r.ReadToEnd();
            }

            if (new FileInfo("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\LISTTEMPLATE.json").Length != 0)
                listTemplate = json.Split(',').ToList();
            using (StreamReader r = new StreamReader("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\TEMPLATE.json"))
            {
                json = r.ReadToEnd();
            }
            if (new FileInfo("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\TEMPLATE.json").Length != 0)
                template = JObject.Parse(json);
            
            foreach(string item in listTemplate)
            {
                if (listTemplate.Count > 0)
                {
                    historytemp[buttonindex] = new Button(); historytemp[buttonindex].Location = new Point(15, 140 + buttonindex * 40); historytemp[buttonindex].Size = new Size(219, 40);
                    historytemp[buttonindex].Text = item+" Template";historytemp[buttonindex].Click += new EventHandler(historytemplateclick);
                    this.Controls.Add(historytemp[buttonindex]);
                    buttonindex++;
                }
            }
            
            WindowState = FormWindowState.Maximized;
            richTextBox1.Hide();
            button1.Hide();
            label2.Hide();
            X.Hide();
            Y.Hide();
            Height.Hide();
            Width.Hide();
            button2.Hide();
            label4.Hide();
            button3.Hide();

        }
        public static void ExtractImagesFromPDF(string sourcePdf, string outputPath)
        {
            Globals.index = 0;
            PdfReader pdf = new PdfReader(sourcePdf);
            //System.Diagnostics.Debug.WriteLine(sourcePdf);
            RandomAccessFileOrArray raf = new RandomAccessFileOrArray(sourcePdf);
            try
            {
                for (int pageNumber = 1; pageNumber <= pdf.NumberOfPages; pageNumber++)
                {
                    PdfDictionary pg = pdf.GetPageN(pageNumber);
                    Globals.length = pdf.NumberOfPages;
                    // recursively search pages, forms and groups for images.
                    PdfObject obj = FindImageInPDFDictionary(pg);
                    if (obj != null)
                    {
                        int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                        PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                        PdfStream pdfStrem = (PdfStream)pdfObj;
                        byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                        if ((bytes != null))
                        {
                            using (memStream[memoryindex] = new MemoryStream(bytes))
                            {
                                memStream[memoryindex].Position = 0;
                                Image img = (Bitmap)Image.FromStream(memStream[memoryindex]);
                                // must save the file while stream is open.
                                if (!Directory.Exists(outputPath))
                                    Directory.CreateDirectory(outputPath);
                                Guid guid = Guid.NewGuid();
                                string imagename = guid.ToString();
                                string path = Path.Combine(outputPath, String.Format(@"{0}.jpg", imagename + pageNumber));
                                EncoderParameters parms = new EncoderParameters(1);
                                parms.Param[0] = new EncoderParameter(Encoder.Compression, 0);
                                ImageCodecInfo jpegEncoder = GetImageEncoder("JPEG");
                                img.Save(path, jpegEncoder, parms);
                                Globals.img_path[Globals.index] = path;
                                Globals.index += 1;
                                Globals.length = Globals.index;
                                memStream[memoryindex].Close();
                                memoryindex++;
                            }
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {
                //  Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                //throw;
            }
            finally
            {
                pdf.Close();
                raf.Close();
            }


        }

        public static ImageCodecInfo GetImageEncoder(string imageType)
        {
            imageType = imageType.ToUpperInvariant();



            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
            {
                if (info.FormatDescription == imageType)
                {
                    return info;
                }
            }

            return null;
        }



        private static PdfObject FindImageInPDFDictionary(PdfDictionary pg)
        {
            PdfDictionary res =
                (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));

            PdfDictionary xobj = null;

            if (PdfName.XOBJECT != null && res.Get(PdfName.XOBJECT) != null)
            {
                xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
            }

            if (xobj != null)
            {
                foreach (PdfName name in xobj.Keys)
                {
                    PdfObject obj = xobj.Get(name);
                    if (obj.IsIndirect())
                    {
                        PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);

                        PdfName type =
                          (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));

                        //image at the root of the pdf
                        if (PdfName.IMAGE.Equals(type))
                        {
                            return obj;
                        }// image inside a form
                        else if (PdfName.FORM.Equals(type))
                        {
                            return FindImageInPDFDictionary(tg);
                        } //image inside a group
                        else if (PdfName.GROUP.Equals(type))
                        {
                            return FindImageInPDFDictionary(tg);
                        }

                    }
                }
            }
            return null;

        }
        private void upload(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Pdf Files|*.pdf"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                string[] words = path.Split('\\');
                filename.Text = words[words.Length-1];
                ExtractImagesFromPDF(path, "C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\ExtractedImages");
                Globals.index = 0;
            }
        }
        public void historytemplateclick(object sender, EventArgs e)
        {
            Button clickedbutton = sender as Button;
            richTextBox1.Show();
            richTextBox1.Text = clickedbutton.Text.Substring(0, clickedbutton.Text.Length - 9);
            Debug.WriteLine(richTextBox1.Text);
            button1.Hide();
            label2.Hide();
            button2.Hide();
            button3.Hide();
            X.Show();
            Y.Show();
            Height.Show();
            Width.Show();
            string json;
            templateDetail = new JObject();
            if (new FileInfo("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\" + richTextBox1.Text + ".json").Length != 0)
            {
                using (StreamReader r = new StreamReader("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\" + richTextBox1.Text + ".json"))
                {
                    json = r.ReadToEnd();
                }
                templateDetail = JObject.Parse(json);
            }
            while(index!=1)
            {
                removetempdetail();
                index--;
            }
            index = 1;
            foreach (string item in template[richTextBox1.Text])
            {
                addnewdetail();
                //Debug.WriteLine(item+" : "+ index.ToString() + " : " + templateDetail.ToString());
                txtbx[index - 1].Text = item;
                x[index - 1].Text = templateDetail[item][0].ToString(); y[index - 1].Text = templateDetail[item][1].ToString();
                width[index - 1].Text = templateDetail[item][2].ToString(); height[index - 1].Text = templateDetail[item][3].ToString();
                index++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "")
            {
                label4.Hide();
                X.Show();
                Y.Show();
                Height.Show();
                Width.Show();
                button2.Show();
                button3.Show();
                txtbx[index - 1] = new RichTextBox(); txtbx[index - 1].Location = new Point(367, 200 + index * 40); txtbx[index - 1].Size = new Size(162, 26);
                this.Controls.Add(txtbx[index - 1]);

                x[index - 1] = new RichTextBox(); x[index - 1].Location = new Point(641, 200 + index * 40); x[index - 1].Size = new Size(48, 26);
                this.Controls.Add(x[index - 1]);

                y[index - 1] = new RichTextBox(); y[index - 1].Location = new Point(705, 200 + index * 40); y[index - 1].Size = new Size(48, 26);
                this.Controls.Add(y[index - 1]);

                width[index - 1] = new RichTextBox(); width[index - 1].Location = new Point(770, 200 + index * 40); width[index - 1].Size = new Size(44, 26);
                this.Controls.Add(width[index - 1]);

                height[index - 1] = new RichTextBox(); height[index - 1].Location = new Point(832, 200 + index * 40); height[index - 1].Size = new Size(44, 26);
                this.Controls.Add(height[index - 1]);
                index++;
            }
            else if(richTextBox1.Text == "")
            {
                label4.Text = "Cannot be empty";
                label4.Show();
            }
        }

        private void addnewdetail()
        {
            if (index > txtbx.Length)
                return;
            txtbx[index - 1] = new RichTextBox(); txtbx[index - 1].Location = new Point(367, 200 + index * 40); txtbx[index - 1].Size = new Size(162, 26);
            this.Controls.Add(txtbx[index - 1]);

            x[index - 1] = new RichTextBox(); x[index - 1].Location = new Point(641, 200 + index * 40); x[index - 1].Size = new Size(48, 26);
            this.Controls.Add(x[index - 1]);

            y[index - 1] = new RichTextBox(); y[index - 1].Location = new Point(705, 200 + index * 40); y[index - 1].Size = new Size(48, 26);
            this.Controls.Add(y[index - 1]);

            width[index - 1] = new RichTextBox(); width[index - 1].Location = new Point(770, 200 + index * 40); width[index - 1].Size = new Size(44, 26);
            this.Controls.Add(width[index - 1]);

            height[index - 1] = new RichTextBox(); height[index - 1].Location = new Point(832, 200 + index * 40); height[index - 1].Size = new Size(44, 26);
            this.Controls.Add(height[index - 1]);
        }
        private void Adddetail(object sender, EventArgs e)
        {
            addnewdetail();
            index++;
        }
        private void removetempdetail()
        {
            if (index == 1)
                return;
            this.Controls.Remove(txtbx[index - 2]);
            this.Controls.Remove(x[index - 2]);
            this.Controls.Remove(y[index - 2]);
            this.Controls.Remove(width[index - 2]);
            this.Controls.Remove(height[index - 2]);
        }
        private void Removedetail(object sender, EventArgs e)
        {
            removetempdetail();
            index--;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            croppper = new imagecrop();
            croppper.Show();
            croppper.Uploadimages(0);
        }

        private void OCR_Click(object sender, EventArgs e)
        {
            if (!hasSaved)
               saveTEMP();
            hasSaved = false;
            this.Hide();
            Form1 ocr = new Form1();
            ocr.Show();
        }
        private void saveTEMP()
        {
            if (richTextBox1.Text == "")
            {
                label4.Text = "Cannot be empty";
                label4.Show();
                return;
            }
            if (!listTemplate.Contains(richTextBox1.Text))
                listTemplate.Add(richTextBox1.Text);
            JArray array2 = new JArray();
            for (int i = 0; i < txtbx.Length; i++)
            {
                if (txtbx[i] != null && txtbx[i].Text != "")
                    array2.Add(txtbx[i].Text);
            }
            template[richTextBox1.Text] = array2;
            int j = 0;
            templateDetail = new JObject();
            foreach (string item in template[richTextBox1.Text])
            {
                JArray array1 = new JArray();
                array1.Add(x[j].Text); array1.Add(y[j].Text); array1.Add(width[j].Text); array1.Add(height[j].Text);
                templateDetail[item] = array1;
                j++;
            }

            File.WriteAllText(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\TEMPLATE.json", template.ToString());
            File.WriteAllText(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\" + richTextBox1.Text + ".json", templateDetail.ToString());
            File.WriteAllText(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\LISTTEMPLATE.json", "");
            for (int k=0;k< listTemplate.Count;k++)
            {
                if(k< listTemplate.Count-1)
                    File.AppendAllText(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\LISTTEMPLATE.json",  listTemplate[k] + ",");
                else
                    File.AppendAllText(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\LISTTEMPLATE.json", listTemplate[k]);
            }
            bool existing = false;
            for (int k = 0; k < historytemp.Length; k++)
            {
                if (historytemp[k]!=null && historytemp[k].Text.Substring(0, historytemp[k].Text.Length - 9) == richTextBox1.Text)
                {
                    existing = true;
                    break;
                }
            }
            if (!existing)
            {
                historytemp[buttonindex] = new Button(); historytemp[buttonindex].Location = new Point(15, 140 + buttonindex * 40); historytemp[buttonindex].Size = new Size(219, 40);
                historytemp[buttonindex].Text = richTextBox1.Text + " Template"; historytemp[buttonindex].Click += new EventHandler(historytemplateclick);
                this.Controls.Add(historytemp[buttonindex]);
                buttonindex++;
            }
            //Debug.WriteLine(template.Values.ToString());
        }

        private void addnew_Click(object sender, EventArgs e)
        {
            richTextBox1.Show();
            button1.Show();
            label2.Show();
            richTextBox1.Text = "";
            while (index != 1)
            {
                removetempdetail();
                index--;
            }
            index = 1;
        }

        private void edittemp_Click(object sender, EventArgs e)
        {
            button2.Show();
            button3.Show();
        }

        private void savetemplate_Click(object sender, EventArgs e)
        {
            hasSaved = true;
           saveTEMP();
        }
    }
}
