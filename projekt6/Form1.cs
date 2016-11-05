using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projekt6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        
    

        /* przycisk zalogowania*/

        private void button1_Click(object sender, EventArgs e)
        {
            /*string login =textBox3.Text;
            string password = textBox2.Text; 
            if ((login=="ola" && password=="155315") || (login=="elisa" && password=="155305"))
            {
                this.Hide();
                Form2 program = new Form2();
                program.Show();
            }

            else
            {
                MessageBox.Show("Check your User name and Password");
            }*/
            this.Hide();
            Form2 program = new Form2();
            program.Show();

        }

        
    }
}
