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
            public static Int32 index = 0, length = 0, count = 0;
        }
        public int Length { get; }


        public static void ExtractImagesFromPDF(string sourcePdf, string outputPath)
        {
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
                            using (MemoryStream memStream = new MemoryStream(bytes))
                            {
                                memStream.Position = 0;
                                Image img = Image.FromStream(memStream);
                                // must save the file while stream is open.
                                if (!Directory.Exists(outputPath))
                                    Directory.CreateDirectory(outputPath);

                                string path = Path.Combine(outputPath, String.Format(@"{0}.jpg", "output" + pageNumber));
                                //System.Diagnostics.Debug.WriteLine(path);
                                EncoderParameters parms = new EncoderParameters(1);
                                parms.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 0);
                                ImageCodecInfo jpegEncoder = GetImageEncoder("JPEG");
                                img.Save(path, jpegEncoder, parms);
                                Globals.img_path[Globals.index] = path;
                                Globals.index += 1;
                                /*var PictureBox1 = new PictureBox();
                                PictureBox1.Location = new System.Drawing.Point(50, 50);
                                PictureBox1.Size = new System.Drawing.Size(100, 100);
                                PictureBox1.Load(path);*/
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
        string json2;
        Bitmap bit1;
        private void ocrUpload(Int32 index)
        {
            string temppath1 = Globals.img_path[index];
            if (temppath1 == "")
                return;
            Bitmap image1 = new Bitmap(temppath1);

            bit1 = new Bitmap(Globals.img_path[index]);
            pictureBox1.Image = bit1;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
            array2.Add(Globals.imgocr_text[Globals.index]);
            JObject o = new JObject();
            o["JSON2"] = array2;
            json2 = o.ToString();

        }

        private void RegexSearch(string sPattern)
        {

            var myDictionary = new Dictionary<string, IList<string>>();
            myDictionary["Invoice"] = new List<string> { "Inv..ce", "I.vo.c.", "Inv..c." };
            myDictionary["Invoice Number"] = new List<string> { "Inv..ce Num...", "Inv..ce No", "Inv..ce Non" };
            myDictionary["Invoice Date"] = new List<string> { "Inv..ce Date", "Inv..ce D.t.", "Inv..ce D..e", };
            myDictionary["Invoice Name"] = new List<string> { "Inv..ce Name", "Inv..ce N.m.", "Inv..ce Na.." };

            myDictionary["Address"] = new List<string> { "Addre..", "Ad..ess", "A..ress" };
            myDictionary["Telephone"] = new List<string> { "Tel", "Telep....", "Tele No" };
            myDictionary["Name"] = new List<string> { "Name", "Na.e", "Names" };
            myDictionary["Amount"] = new List<string> { "Amo.n.", "A.o.n.", "Amnt" };
            myDictionary["DOCTOR"] = new List<string> { "DOCTO.", "DOC.O.", "DO..O." };

            richTextBox1.Text = "";
            foreach (string s in Globals.TextboxStringMatch)
            {
                int j = 0;
                int matchFound = 0;
                if (s == null || sPattern == null)
                    break;

                while (j < 3)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(s, myDictionary[sPattern][j], System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        matchFound = 1;
                        break;
                    }
                    else
                        matchFound = 0;
                    j++;
                }
                if (matchFound == 0)
                {
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.AppendText(s + " ");
                }
                else if (matchFound == 1)
                {
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.AppendText(s + " ");
                }

            }
        }

        private void upload(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (Globals.length == 0)
            {
                string[] customText = new string[] { "Invoice Number", "Invoice Date", "Invoice Name", "Address", "Telephone", "Name", "Amount", "DOCTOR" };
                comboBox1.Items.AddRange(customText);
            }

            dialog.Filter = "Pdf Files|*.pdf"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                ExtractImagesFromPDF(path, "C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\ExtractedImages");
                Globals.index = 0;
                ocrUpload(Globals.index);
            }
            string connstr = Utility.GetConnectionString();

            String query = "select Template from ReferenceTable";
            SqlConnection connection = new SqlConnection(connstr);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                for (int i = 0; i < Reader.FieldCount; i++)
                    Template.Items.Add(Reader.GetValue(i).ToString());

            }
            connection.Close();
            //SqlCommand myCommand = new SqlCommand("select * from Requests where Complete = 0", myConnection);
        }
        private void Template_TextChanged(object sender, EventArgs e)
        {
            if (Template.Text.Equals("Invoice", StringComparison.Ordinal))
            {
                checkedListBox1.Items.Clear();
                if (!checkedListBox1.Items.Contains("Invoice Date"))
                    checkedListBox1.Items.Add("Invoice Date");
                if (!checkedListBox1.Items.Contains("Invoice Number"))
                    checkedListBox1.Items.Add("Invoice Number");
                if (!checkedListBox1.Items.Contains("Invoice Name"))
                    checkedListBox1.Items.Add("Invoice Name");
            }
            if (Template.Text.Equals("Receipt", StringComparison.Ordinal))
            {
                checkedListBox1.Items.Clear();
                if (!checkedListBox1.Items.Contains("Receipt Date"))
                    checkedListBox1.Items.Add("Receipt Date");
                if (!checkedListBox1.Items.Contains("Receipt Total"))
                    checkedListBox1.Items.Add("Receipt Total");
                if (!checkedListBox1.Items.Contains("Receipt Time"))
                    checkedListBox1.Items.Add("Receipt Time");
                if (!checkedListBox1.Items.Contains("Receipt Number"))
                    checkedListBox1.Items.Add("Receipt Number");
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

        string value1 , value2;
        string Temp = "";

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
                DataRowView castedItem = itemChecked as DataRowView;
                value2 = itemChecked.ToString();
                cropWidth = cropHeight = 0;
                if (value1 == null || value1 == "")
                    return;
                if (value2 == null || value2 == "")
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

                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                Bitmap bit = new Bitmap(bit1, pictureBox1.Width, pictureBox1.Height);
                Bitmap crop = new Bitmap(cropWidth, cropHeight);
                Graphics gfx = Graphics.FromImage(crop);
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.CompositingQuality = CompositingQuality.HighQuality;
                gfx.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel);
                pictureBox1.Image = crop;
                pictureBox1.Refresh();
                tessnet2.Tesseract ocr = new tessnet2.Tesseract();
                ocr.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
                ocr.Init(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\tessdata_eng\", "eng", false); // To use correct tessdata
                List<tessnet2.Word> result1 = ocr.DoOCR(crop, Rectangle.Empty);
                foreach (tessnet2.Word word in result1)
                {
                    if(word.Text != "~")
                        Temp += word.Text + " ";
                }
                
                txt[Index].Text = ValidateOutput(value2);// richTextBox1.Text;
                Temp += txt[Index].Text + " ";
                m++;
                connection.Close();
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
            if (Globals.index < Globals.length - 1)
                Globals.index += 1;

            ocrUpload(Globals.index);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Globals.index > 0)
                Globals.index -= 1;

            ocrUpload(Globals.index);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (cropWidth < 1 || cropHeight < 1)
            {
                return;
            }

            // Debug.WriteLine(cropX + " : " + cropY + " : " + cropWidth + " : " + cropHeight);
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap bit = new Bitmap(bit1, pictureBox1.Width, pictureBox1.Height);
            Bitmap crop = new Bitmap(cropWidth, cropHeight);
            Graphics gfx = Graphics.FromImage(crop);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gfx.CompositingQuality = CompositingQuality.HighQuality;
            gfx.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel);
            pictureBox1.Image = crop;
            pictureBox1.Refresh();
            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
            ocr.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
            ocr.Init(@"C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\tessdata_eng\", "eng", false); // To use correct tessdata
            int i = 0;
            while (Globals.TextboxStringMatch[i] != null)
            {
                Globals.TextboxStringMatch[i] = null;
                i++;
            }
            i = 0;
            richTextBox1.Text = "";
            List<tessnet2.Word> result1 = ocr.DoOCR(crop, Rectangle.Empty);
            foreach (tessnet2.Word word in result1)
            {
                Globals.TextboxStringMatch[i] = word.Text;
                i++;
                richTextBox1.Text += word.Text;
                if (word.Text == "\n")
                    Debug.WriteLine(word.Text + "<--newline detected");
                richTextBox1.Text += " ";
            }
           // Globals.imgocr_text[Globals.index] = richTextBox1.Text;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//here i have use mouse click left button only
            {
                pictureBox1.Refresh();
                cropX = e.X;
                cropY = e.Y;
                Cursor = Cursors.Cross;
            }
            pictureBox1.Refresh();
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            if (e.Button == MouseButtons.Left)//here i have use mouse click left button only
            {
                pictureBox1.Refresh();
                cropWidth = e.X - cropX;
                cropHeight = e.Y - cropY;
            }
            pictureBox1.Refresh();
        }

        private void Reset(object sender, EventArgs e)
        {
        }

        private void Reset_onclick(object sender, EventArgs e)
        {
            bit1 = new Bitmap(Globals.img_path[Globals.index]);
            pictureBox1.Image = bit1;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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


        Pen borderpen = new Pen(Color.Red, 2);
        SolidBrush rectbrush = new SolidBrush(Color.FromArgb(100, Color.White));

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Graphics gfx = e.Graphics;
            gfx.DrawRectangle(borderpen, rect);
            gfx.FillRectangle(rectbrush, rect);

        }
    }
}


