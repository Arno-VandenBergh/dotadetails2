using DotaDetails.DAL;
using DotaDetails.Model;
using DotaDetails.Presenter;
using DotaDetails.View;
using Microsoft.Data.Sqlite;
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
    public partial class Register : Form, IRegister
    {
        public Register()
        {
            InitializeComponent();
        }

        public string AccountID { get {return textBox1.Text; } set {textBox1.Text = value; } }
        public string Password { get { return textBox2.Text; } set { textBox2.Text = value; } }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterPresenter presenter = new RegisterPresenter(this);
            presenter.Register();
        }
    }
}
