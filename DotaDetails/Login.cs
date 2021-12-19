using DotaDetails.Controller;
using DotaDetails.Model;
using DotaDetails.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaDetails
{
    public partial class Login : Form, ILogin 
    {
        public string Username { get { return textBox1.Text.ToLower(); } set {textBox1.Text = value; } }
        public string Password { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string AccountID { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPresenter presenter = new LoginPresenter(this);
            presenter.Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register rg = new Register();
            rg.ShowDialog();
        }
    }
}
