
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using services;


namespace client
{
    public partial class Form1 : Form
    {
        private ConcursClientCtrl ctrl;
    
        //MainForm mainController;
        public Form1(ConcursClientCtrl ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
       
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
                ctrl.login(usernameS, passwordS);
                
                
                MainForm mainController = new MainForm(ctrl);
                mainController.Text = "Chat window for " + usernameS;
                mainController.Show();
                this.Hide();
                

            }
            catch (ConcursException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
