using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class imagecrop : Form
    {
        public imagecrop()
        {
            InitializeComponent();
        }

        private void imagecrop_Load(object sender, EventArgs e)
        {
            //On Load add the templates to the combo box
            WindowState = FormWindowState.Maximized;
            comboBox1.Items.Clear(); ;
            for (int i=0;i < TemplateCreator.txtbx.Length; i++)
            {
                if (TemplateCreator.txtbx[i] != null && TemplateCreator.txtbx[i].Text != "")
                {
                    comboBox1.Items.Add(TemplateCreator.txtbx[i].Text.ToString());
                }
            }
            panel1.Controls.Add(pictureBox1);
        }
        Bitmap bit1;
        public int selectedindex;
        int cropX, cropY, cropWidth, cropHeight;

        public void Uploadimages(int index)
        {
            string temppath1 = TemplateCreator.Globals.img_path[index];
            if (temppath1 == "")
                return;
            Bitmap image1 = new Bitmap(temppath1);
            bit1 = new Bitmap(TemplateCreator.Globals.img_path[index]);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = bit1;
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if(comboBox1.Text != null || comboBox1.Text != "")
            {
                string sPattern = comboBox1.Text;
                for (int i = 0; i < TemplateCreator.txtbx.Length; i++)
                {
                    if (TemplateCreator.txtbx[i].Text.Equals(sPattern, StringComparison.Ordinal))
                    {
                        selectedindex = i;
                        TemplateCreator.x[i].Text = cropX.ToString();
                        TemplateCreator.y[i].Text = cropY.ToString();
                        TemplateCreator.width[i].Text = cropWidth.ToString();
                        TemplateCreator.height[i].Text = cropHeight.ToString();

                        break;
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (TemplateCreator.Globals.index < TemplateCreator.Globals.length - 1)
                TemplateCreator.Globals.index += 1;
            Uploadimages(TemplateCreator.Globals.index);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TemplateCreator.Globals.index > 0)
                TemplateCreator.Globals.index -= 1;
            Uploadimages(TemplateCreator.Globals.index);
        }
        //GUI for cropping out the Image. On click draw a rectangle from using the initial mouse coordinates as top left X,Y 
        //and then width and height as X(i)-X(f) & H(i)-H(f). (Where f=final and i= initial).
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
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
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Refresh();

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
        Pen borderpen = new Pen(Color.Red, 2);

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SolidBrush rectbrush = new SolidBrush(Color.FromArgb(100, Color.White));

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Graphics gfx = e.Graphics;
            gfx.DrawRectangle(borderpen, rect);
            gfx.FillRectangle(rectbrush, rect);

        }
        //Reset the image i.e load the whole image again
        private void Reset_onclick(object sender, EventArgs e)
        {
            Debug.WriteLine(TemplateCreator.Globals.index);
            bit1 = new Bitmap(TemplateCreator.Globals.img_path[TemplateCreator.Globals.index]);
            pictureBox1.Image = bit1;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
