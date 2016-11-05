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
    public partial class Form4 : Form 
    {
        private Timer time = new Timer();
        Random randNum = new Random();
        Form flights;

        public Form4(Flight flight,Form flights)
        {
            InitializeComponent();
            this.flights = flights;
            time.Interval = 1000;
            label1.Text = "Boarding for flight nr " + (string)flight.flightNumber;
            button2.Hide();
            checkedListBox1.Hide();

         
           
            
            
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
           
         
            progressBar1.Maximum = 100;
           
            time.Tick += new EventHandler(IncreaseProgressBar);
            time.Start();
            
            
            
                     
        }

       

        private void IncreaseProgressBar(object sender, EventArgs e)
{
               double random = randNum.NextDouble();
   // Increment the value of the ProgressBar a value of one each time.
   progressBar1.Increment(20);
   // Display the textual value of the ProgressBar in the StatusBar control's first panel.
   label2.Text = progressBar1.Value.ToString() + "% Completed";
   // Determine if we have completed by comparing the value of the Value property to the Maximum value.
   if (progressBar1.Value == progressBar1.Maximum)
   {
       
      
       time.Stop();
       if (random > 0.85)
       {
           MessageBox.Show("END OF BOARDING");
           this.Hide();
           flights.Show();
           
       }
       else {
           MessageBox.Show("PASSENGERS MISSING!");
           checkedListBox1.Show();
           int rand = randNum.Next(1, 6);
           for (int i = 0; i < rand; i++)
           {
               int passengerNumber= randNum.Next(999,10000);
               checkedListBox1.Items.Insert(i,"Passanger nr "+passengerNumber.ToString());
           }
           button2.Show();
       }
       
   }
}

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Step = 20;

            for (int j = 0; j < 5; j++)
            {

                progressBar1.PerformStep();
            }

            if (checkedListBox1.CheckedItems.Count == checkedListBox1.Items.Count)
            {
                MessageBox.Show("BOARDING FINISHED.");
                this.Hide();
                flights.Show();
            }
            else
                MessageBox.Show("NOT ALL PASSENGERES WERE INFORMED!");
            
        }

    }
}
