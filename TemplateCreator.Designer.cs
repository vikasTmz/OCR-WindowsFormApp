namespace HelloWorld
{
    partial class TemplateCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateCreator));
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.filename = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.Label();
            this.Height = new System.Windows.Forms.Label();
            this.OCR = new System.Windows.Forms.Button();
            this.addnew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deletetemp = new System.Windows.Forms.Button();
            this.edittemp = new System.Windows.Forms.Button();
            this.savetempbutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(487, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(367, 138);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(162, 26);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(535, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Template";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.Location = new System.Drawing.Point(651, 173);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(20, 20);
            this.X.TabIndex = 2;
            this.X.Text = "X";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button2.Location = new System.Drawing.Point(544, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Adddetail);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(406, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button3.Location = new System.Drawing.Point(581, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Removedetail);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(936, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(277, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Upload Pdf and Specify coordinates";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DarkBlue;
            this.button4.Location = new System.Drawing.Point(1024, 134);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 59);
            this.button4.TabIndex = 6;
            this.button4.Text = "Upload PDF";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.upload);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button5.Location = new System.Drawing.Point(1043, 219);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(135, 57);
            this.button5.TabIndex = 7;
            this.button5.Text = "View/Crop Images";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // filename
            // 
            this.filename.AutoSize = true;
            this.filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filename.ForeColor = System.Drawing.Color.Black;
            this.filename.Location = new System.Drawing.Point(1152, 156);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(35, 15);
            this.filename.TabIndex = 4;
            this.filename.Text = "none";
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y.Location = new System.Drawing.Point(707, 173);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(20, 20);
            this.Y.TabIndex = 2;
            this.Y.Text = "Y";
            // 
            // Width
            // 
            this.Width.AutoSize = true;
            this.Width.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Width.Location = new System.Drawing.Point(762, 173);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(59, 20);
            this.Width.TabIndex = 2;
            this.Width.Text = "Width";
            // 
            // Height
            // 
            this.Height.AutoSize = true;
            this.Height.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Height.Location = new System.Drawing.Point(843, 173);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(68, 20);
            this.Height.TabIndex = 2;
            this.Height.Text = "Height";
            // 
            // OCR
            // 
            this.OCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OCR.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OCR.Location = new System.Drawing.Point(1043, 310);
            this.OCR.Name = "OCR";
            this.OCR.Size = new System.Drawing.Size(135, 68);
            this.OCR.TabIndex = 9;
            this.OCR.Text = "Apply OCR";
            this.OCR.UseVisualStyleBackColor = true;
            this.OCR.Click += new System.EventHandler(this.OCR_Click);
            // 
            // addnew
            // 
            this.addnew.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnew.Image = ((System.Drawing.Image)(resources.GetObject("addnew.Image")));
            this.addnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addnew.Location = new System.Drawing.Point(3, 2);
            this.addnew.Name = "addnew";
            this.addnew.Size = new System.Drawing.Size(74, 63);
            this.addnew.TabIndex = 10;
            this.addnew.Text = "New";
            this.addnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addnew.UseVisualStyleBackColor = true;
            this.addnew.Click += new System.EventHandler(this.addnew_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.deletetemp);
            this.panel1.Controls.Add(this.edittemp);
            this.panel1.Controls.Add(this.savetempbutton);
            this.panel1.Controls.Add(this.addnew);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1299, 68);
            this.panel1.TabIndex = 11;
            // 
            // deletetemp
            // 
            this.deletetemp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletetemp.Image = ((System.Drawing.Image)(resources.GetObject("deletetemp.Image")));
            this.deletetemp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deletetemp.Location = new System.Drawing.Point(243, 2);
            this.deletetemp.Name = "deletetemp";
            this.deletetemp.Size = new System.Drawing.Size(74, 63);
            this.deletetemp.TabIndex = 13;
            this.deletetemp.Text = "Delete";
            this.deletetemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deletetemp.UseVisualStyleBackColor = true;
            // 
            // edittemp
            // 
            this.edittemp.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edittemp.Image = ((System.Drawing.Image)(resources.GetObject("edittemp.Image")));
            this.edittemp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edittemp.Location = new System.Drawing.Point(163, 2);
            this.edittemp.Name = "edittemp";
            this.edittemp.Size = new System.Drawing.Size(74, 63);
            this.edittemp.TabIndex = 12;
            this.edittemp.Text = "Edit";
            this.edittemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.edittemp.UseVisualStyleBackColor = true;
            this.edittemp.Click += new System.EventHandler(this.edittemp_Click);
            // 
            // savetempbutton
            // 
            this.savetempbutton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savetempbutton.Image = ((System.Drawing.Image)(resources.GetObject("savetempbutton.Image")));
            this.savetempbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.savetempbutton.Location = new System.Drawing.Point(83, 2);
            this.savetempbutton.Name = "savetempbutton";
            this.savetempbutton.Size = new System.Drawing.Size(74, 63);
            this.savetempbutton.TabIndex = 11;
            this.savetempbutton.Text = "Save";
            this.savetempbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.savetempbutton.UseVisualStyleBackColor = true;
            this.savetempbutton.Click += new System.EventHandler(this.savetemplate_Click);
            // 
            // TemplateCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OCR);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Height);
            this.Controls.Add(this.Width);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.X);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Name = "TemplateCreator";
            this.Text = "Template Creator";
            this.Load += new System.EventHandler(this.TemplateCreator_Load_1);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label filename;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.Label Width;
        private System.Windows.Forms.Label Height;
        private System.Windows.Forms.Button OCR;
        private System.Windows.Forms.Button addnew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button deletetemp;
        private System.Windows.Forms.Button edittemp;
        private System.Windows.Forms.Button savetempbutton;
    }
}