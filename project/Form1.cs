using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
            registerPanel.Visible = false;
            registerPanel.Location = loginPanel.Location;
        }

        private void showLoginButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
            registerPanel.Visible = false;
        }

        private void showRegisterButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            registerPanel.Visible = true;
        }
    }
}
