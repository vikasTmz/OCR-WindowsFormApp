using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        Thread t;
        string password;
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private void LoginPage_Load(object sender, EventArgs e)
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 100;
            myTimer.Start();
            //t = new Thread(new ThreadStart(passwordhash));
            //t.Start();
        }
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            myTimer.Stop();
            if (textBox2.Text != "" || textBox2.Text != null)
            {
                myTimer.Enabled = true;
                if (textBox2.Text.Length == 0)
                    return;
                if (!textBox2.Text[textBox2.Text.Length - 1].ToString().Equals("*", StringComparison.Ordinal))
                    password += textBox2.Text[textBox2.Text.Length - 1].ToString();
                int length = textBox2.Text.Length;
                textBox2.Text = "";
                for (int i = 0; i < length; i++)
                {
                    textBox2.Text += "*";
                }
                textBox2.SelectionStart = textBox2.Text.Length;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.Show();
        }
        private void passwordhash()
        {
            while (true)
            {
               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(password);
            string connstr = Utility.GetConnectionString();
            String query = "select name,email,pass from RegisterTable where email='"+textBox1.Text+"' and pass='"+password+"'";
            SqlConnection connection = new SqlConnection(connstr);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(query,connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                SqlDataReader dr;
                dr = command.ExecuteReader();
                if(dr.Read())
                {
                    myTimer.Stop();
                    this.Hide();
                    TemplateCreator app = new TemplateCreator();
                    app.Show();
                    MessageBox.Show("Welcome " + dr["name"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Email Id or Password does not match/exist");
            }
        }
    }
}
