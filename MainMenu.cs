﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            label1.Text = LoginPage.username;
        }

        private void createtemp_Click(object sender, EventArgs e)
        {
            TemplateCreator app = new TemplateCreator();
            app.Show();
            this.Close();
        }
    }
}
