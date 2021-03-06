﻿namespace HelloWorld
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
            this.button1 = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.filename = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.Label();
            this.Height = new System.Windows.Forms.Label();
            this.addnew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deletetemp = new System.Windows.Forms.Button();
            this.edittemp = new System.Windows.Forms.Button();
            this.savetempbutton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.navigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.temphistory = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(560, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(10, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(162, 26);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 28);
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
            this.X.Location = new System.Drawing.Point(309, 2);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(20, 20);
            this.X.TabIndex = 2;
            this.X.Text = "X";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button2.Location = new System.Drawing.Point(215, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Adddetail);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button3.Location = new System.Drawing.Point(252, 21);
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
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(92, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "* Specify coordinates";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DarkBlue;
            this.button4.Location = new System.Drawing.Point(116, 15);
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
            this.button5.Location = new System.Drawing.Point(101, 180);
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
            this.filename.Location = new System.Drawing.Point(113, 101);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(35, 15);
            this.filename.TabIndex = 4;
            this.filename.Text = "none";
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y.Location = new System.Drawing.Point(368, 2);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(20, 20);
            this.Y.TabIndex = 2;
            this.Y.Text = "Y";
            // 
            // Width
            // 
            this.Width.AutoSize = true;
            this.Width.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Width.Location = new System.Drawing.Point(420, 2);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(59, 20);
            this.Width.TabIndex = 2;
            this.Width.Text = "Width";
            // 
            // Height
            // 
            this.Height.AutoSize = true;
            this.Height.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Height.Location = new System.Drawing.Point(488, 2);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(68, 20);
            this.Height.TabIndex = 2;
            this.Height.Text = "Height";
            // 
            // addnew
            // 
            this.addnew.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnew.Image = ((System.Drawing.Image)(resources.GetObject("addnew.Image")));
            this.addnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addnew.Location = new System.Drawing.Point(3, 2);
            this.addnew.Name = "addnew";
            this.addnew.Size = new System.Drawing.Size(74, 52);
            this.addnew.TabIndex = 10;
            this.addnew.Text = "New";
            this.addnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addnew.UseVisualStyleBackColor = true;
            this.addnew.Click += new System.EventHandler(this.addnew_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.deletetemp);
            this.panel1.Controls.Add(this.edittemp);
            this.panel1.Controls.Add(this.savetempbutton);
            this.panel1.Controls.Add(this.addnew);
            this.panel1.Location = new System.Drawing.Point(8, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 60);
            this.panel1.TabIndex = 11;
            // 
            // deletetemp
            // 
            this.deletetemp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletetemp.Image = ((System.Drawing.Image)(resources.GetObject("deletetemp.Image")));
            this.deletetemp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deletetemp.Location = new System.Drawing.Point(243, 2);
            this.deletetemp.Name = "deletetemp";
            this.deletetemp.Size = new System.Drawing.Size(74, 52);
            this.deletetemp.TabIndex = 13;
            this.deletetemp.Text = "Delete";
            this.deletetemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deletetemp.UseVisualStyleBackColor = true;
            this.deletetemp.Click += new System.EventHandler(this.deletetemp_Click);
            // 
            // edittemp
            // 
            this.edittemp.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edittemp.Image = ((System.Drawing.Image)(resources.GetObject("edittemp.Image")));
            this.edittemp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edittemp.Location = new System.Drawing.Point(163, 2);
            this.edittemp.Name = "edittemp";
            this.edittemp.Size = new System.Drawing.Size(74, 52);
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
            this.savetempbutton.Size = new System.Drawing.Size(74, 52);
            this.savetempbutton.TabIndex = 11;
            this.savetempbutton.Text = "Save";
            this.savetempbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.savetempbutton.UseVisualStyleBackColor = true;
            this.savetempbutton.Click += new System.EventHandler(this.savetemplate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1325, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // navigationToolStripMenuItem
            // 
            this.navigationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem});
            this.navigationToolStripMenuItem.Name = "navigationToolStripMenuItem";
            this.navigationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.navigationToolStripMenuItem.Text = "Navigation";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMenuToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.temphistory);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 560);
            this.panel2.TabIndex = 13;
            // 
            // temphistory
            // 
            this.temphistory.AutoSize = true;
            this.temphistory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temphistory.Location = new System.Drawing.Point(51, 161);
            this.temphistory.Name = "temphistory";
            this.temphistory.Size = new System.Drawing.Size(116, 15);
            this.temphistory.TabIndex = 15;
            this.temphistory.Text = "no template created";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Template History";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(18, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 452);
            this.panel3.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(295, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(271, 448);
            this.panel4.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.richTextBox1);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Location = new System.Drawing.Point(335, 121);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(580, 539);
            this.panel5.TabIndex = 16;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.Height);
            this.panel6.Controls.Add(this.X);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Controls.Add(this.Y);
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.button3);
            this.panel6.Controls.Add(this.Width);
            this.panel6.Location = new System.Drawing.Point(3, 60);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(572, 474);
            this.panel6.TabIndex = 17;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.button4);
            this.panel7.Controls.Add(this.button5);
            this.panel7.Controls.Add(this.filename);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(969, 135);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(344, 247);
            this.panel7.TabIndex = 17;
            // 
            // TemplateCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 668);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TemplateCreator";
            this.Text = "Template Creator";
            this.Load += new System.EventHandler(this.TemplateCreator_Load_1);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label filename;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.Label Width;
        private System.Windows.Forms.Label Height;
        private System.Windows.Forms.Button addnew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button deletetemp;
        private System.Windows.Forms.Button edittemp;
        private System.Windows.Forms.Button savetempbutton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem navigationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label temphistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
    }
}