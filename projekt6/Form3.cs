using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projekt6
{
    public partial class Form3 : Form
    {
        Form flightList;
        public Form3(Form flightList)
        {
            this.flightList = flightList;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flightList.Show();
            this.Hide();
        }
    }
}
