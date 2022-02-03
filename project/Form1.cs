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
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            label6.Text = "";
        }

        private void showRegisterButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            registerPanel.Visible = true;
        }
        private bool checkLoginInFile(string login)
        {
            string text;

            List<string> lines = new List<string>();
            string debug_text="";
            text = System.IO.File.ReadAllText("Database.txt");
            for(int i = 0; i < text.Length;++i)
            {
                if (text[i] != ' ' && text[i] != '\n')
                {
                    debug_text += text[i];
                }
                if (text[i] == ' ' || i + 1 == text.Length || text[i] == '\n')
                {
                    lines.Add(debug_text);
                    debug_text = "";
                }
            }
            for(int i = 0; i < lines.Count; i += 2)
            {
                if (login == lines[i])
                    return true;
            }
            return false;
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if(textBox4.TextLength >= 4)
            {
                if(!checkLoginInFile(textBox4.Text))
                {
                    if(textBox3.TextLength >= 4)
                    {
                        if(textBox3.Text == textBox5.Text)
                        {
                            string text = System.IO.File.ReadAllText("Database.txt");
                            System.IO.File.WriteAllText("Database.txt", text + "\n" + textBox4.Text + " " + textBox3.Text);
                            label6.Text = "Sucess";
                            label6.ForeColor = Color.Green;
                        }
                        else 
                        {
                            label6.Text = "Password not equal";
                            label6.ForeColor = Color.Red;
                        }
                    }
                    else 
                    {
                        label6.Text = "Password to short (min 4 symbols)";
                        label6.ForeColor = Color.Red;
                    }
                }
                else
                {
                    label6.Text = "Login already exist";
                    label6.ForeColor = Color.Red;
                }
            }
            else
            {
                label6.Text = "Login to short (min 4 symbols)";
                label6.ForeColor = Color.Red;
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string text;

            List<string> lines = new List<string>();
            string debug_text = "";
            text = System.IO.File.ReadAllText("Database.txt");
            for (int i = 0; i < text.Length; ++i)
            {
                if (text[i] != ' ' && text[i] != '\n')
                {
                    debug_text += text[i];
                }
                if (text[i] == ' ' || i + 1 == text.Length || text[i] == '\n')
                {
                    lines.Add(debug_text);
                    debug_text = "";
                }
            }
            for (int i = 0; i < lines.Count; i += 2)
            {
                if (textBox1.Text == lines[i] && textBox2.Text == lines[i + 1])
                {
                    MessageBox.Show("Sucess");
                }
                if(textBox1.Text == lines[i] && textBox2.Text != lines[i + 1])
                {
                    MessageBox.Show("Wrong password!");
                }
            }
        }
    }
}
