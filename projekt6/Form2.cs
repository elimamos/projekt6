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
    public partial class Form2 : Form 
    {
        private bool ative=false;
        private int noClickIterations = 0;
        Form3 warning;
        Form loginPage;
        public Form2(Form loginPage)
        {
            InitializeComponent();
            this.loginPage = loginPage;
            this.warning = new Form3(this);

            //towrzenie listy lotow
            FlightListMaker flm = new FlightListMaker();
            List<Flight> fl = flm.listMaker();
            Console.WriteLine(fl[0].flightNumber);
            dataGridView1.DataSource = fl;

            //tworzenie timera
            Timer timer1 = new Timer();
            timer1.Interval = 500;
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(this.Visible);
            if (this.Visible)
            {
                if (this.ative)
                {
                    this.noClickIterations = 0;
                }
                else
                {
                    this.noClickIterations++;
                }

                if (noClickIterations > 60)
                {

                    this.warning.Show();
                    this.Hide();
                    noClickIterations = 0;
                }

                this.ative = false;
            }
            else if(warning.Visible){
                this.noClickIterations++;

                if (noClickIterations > 60)
                {
                    warning.Hide();
                    loginPage.Show();
                    noClickIterations = 0;
                }

            }
        }


        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ative = true;
            
        }

       
}

    
}
