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
        
        public Form2()
        {
            InitializeComponent();
            // = new List<Flight>();

            // fl.Add(new flights() {flightNumber="kakka", from ="kska", destination="OK", status="on time"}); 

            FlightListMaker flm = new FlightListMaker();

            List<Flight> fl = flm.listMaker();
            Console.WriteLine(fl[0].flightNumber);
            //  fl = flm.listMaker();
            dataGridView1.DataSource = fl;


            Timer timer1 = new Timer();
            timer1.Interval = 500;

            timer1.Enabled = true;

            timer1.Tick += new System.EventHandler(timer1_Tick);
            



        }
       
        private void timer1_Tick(object sender, EventArgs e)
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
                Form3 program = new Form3();
                program.Show();
                this.Hide();
                noClickIterations = 0;
            }

            this.ative = false;
        
        }


        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ative = true;
            
        }

       
}


    
}
