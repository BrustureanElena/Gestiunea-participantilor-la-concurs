using CSharp.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.utils;
namespace CsharpInterfata
{
    public partial class Form1 : Form
    {
        Service Service { get; set; }
        MainForm mainController;
        public Form1(Service service)
        {
            InitializeComponent();
            Service = service;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxParola.PasswordChar = '*';

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            String usernameS = textBoxUsername.Text;
            String passwordS = textBoxParola.Text;
            try
            {
                Service.login(usernameS, passwordS);
                mainController = new MainForm(Service,this);
                this.Hide();
                mainController.Show();

            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
