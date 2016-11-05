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
        private int flightUpdateCounter = 0;
        private int flightUpdateNum = 20;
        Form3 warning;
        Form loginPage;
        FlightListMaker flm;

        Random randNum = new Random();

        public Form2(Form loginPage)
        {
            InitializeComponent();
            this.loginPage = loginPage;
            this.warning = new Form3(this);

            //towrzenie listy lotow
            flm = new FlightListMaker(this);
            List<Flight> fl = flm.listMaker();


            dataGridView1.DataSource = fl.Select(o => new { Number = o.flightNumber, From = o.from, Destination = o.destination, Status = o.status }).ToList(); ;

            //tworzenie timera
            Timer timer1 = new Timer();
            timer1.Interval = 500;
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {


           
            if (this.Visible)
            {
                flightUpdateCounter++;
                if (flightUpdateCounter == flightUpdateNum)
                {
                    Console.WriteLine("Updating");
                    flightUpdateCounter = 0;
                    flightUpdateNum = this.randNum.Next(10,30);
                    List<Flight> fl = flm.updateFlightList();

                    dataGridView1.DataSource = fl.Select(o => new { Number = o.flightNumber, From = o.from, Destination = o.destination, Status = o.status }).ToList(); ;
                }


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
