namespace HelloWorld
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.Button();
            this.instruction = new System.Windows.Forms.Button();
            this.applyocr = new System.Windows.Forms.Button();
            this.createtemp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 436);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria Math", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(379, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 151);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(162, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 107);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.exit);
            this.panel2.Controls.Add(this.instruction);
            this.panel2.Controls.Add(this.applyocr);
            this.panel2.Controls.Add(this.createtemp);
            this.panel2.Location = new System.Drawing.Point(59, 263);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 102);
            this.panel2.TabIndex = 1;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Image = ((System.Drawing.Image)(resources.GetObject("exit.Image")));
            this.exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exit.Location = new System.Drawing.Point(498, 16);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(111, 73);
            this.exit.TabIndex = 4;
            this.exit.Text = "Exit";
            this.exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // instruction
            // 
            this.instruction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.instruction.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instruction.Image = ((System.Drawing.Image)(resources.GetObject("instruction.Image")));
            this.instruction.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.instruction.Location = new System.Drawing.Point(345, 16);
            this.instruction.Name = "instruction";
            this.instruction.Size = new System.Drawing.Size(115, 73);
            this.instruction.TabIndex = 3;
            this.instruction.Text = "Instructions";
            this.instruction.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.instruction.UseVisualStyleBackColor = false;
            // 
            // applyocr
            // 
            this.applyocr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.applyocr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyocr.Image = ((System.Drawing.Image)(resources.GetObject("applyocr.Image")));
            this.applyocr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.applyocr.Location = new System.Drawing.Point(185, 16);
            this.applyocr.Name = "applyocr";
            this.applyocr.Size = new System.Drawing.Size(118, 73);
            this.applyocr.TabIndex = 2;
            this.applyocr.Text = "Apply OCR";
            this.applyocr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.applyocr.UseVisualStyleBackColor = false;
            this.applyocr.Click += new System.EventHandler(this.applyocr_Click);
            // 
            // createtemp
            // 
            this.createtemp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.createtemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createtemp.Image = ((System.Drawing.Image)(resources.GetObject("createtemp.Image")));
            this.createtemp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.createtemp.Location = new System.Drawing.Point(23, 16);
            this.createtemp.Name = "createtemp";
            this.createtemp.Size = new System.Drawing.Size(140, 73);
            this.createtemp.TabIndex = 1;
            this.createtemp.Text = "Create Template";
            this.createtemp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.createtemp.UseVisualStyleBackColor = false;
            this.createtemp.Click += new System.EventHandler(this.createtemp_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(775, 460);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button instruction;
        private System.Windows.Forms.Button createtemp;
        private System.Windows.Forms.Button applyocr;
    }
}