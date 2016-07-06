using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        JObject users;
        public static string username;
        //static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private void LoginPage_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            string json;
            users = new JObject();
            using (StreamReader r = new StreamReader("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\USERS.json"))
            {
                json = r.ReadToEnd();
            }
            if (new FileInfo("C:\\Users\\Vikas Thmz\\Documents\\Visual Studio 2015\\Projects\\HelloWorld\\JSON\\USERS.json").Length != 0)
                users = JObject.Parse(json);
            /*myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 100;
            myTimer.Start();*/
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connstr = Utility.GetConnectionString();String query = "select name,email,pass from RegisterTable where email='"+textBox1.Text+"' and pass='"+password+"'";SqlConnection connection = new SqlConnection(connstr);connection.Open();SqlCommand command = new SqlCommand(query, connection);SqlDataAdapter da = new SqlDataAdapter(query,connection);DataTable dt = new DataTable();da.Fill(dt);

            //dt.Rows.Count > 0//SqlDataReader dr;dr = command.ExecuteReader();
            if(users[textBox1.Text] != null && Register.Decrypt(users[textBox1.Text][0].ToString(), "OcrAppHash12345") == textBox2.Text)//(dr.Read())
            {
                username = users[textBox1.Text][1].ToString();
                MainMenu mainmenu = new MainMenu();
                mainmenu.Show();
                this.Hide();
                MessageBox.Show("Welcome " + users[textBox1.Text][1].ToString());
            }

            else
            {
                MessageBox.Show("Email Id or Password does not match/exist");
            }
        }
    }
}
