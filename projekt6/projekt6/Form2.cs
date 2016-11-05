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
        public struct flights
        {
            public string flightNumber { get; set; }
            public string from { get; set; }
            public string destination { get; set; }
            public string status { get; set; }
        }
        
        public Form2()
        {
            InitializeComponent();
            List<flights> fl = new List<flights>();
           // fl.Add(new flights() {flightNumber="kakka", from ="kska", destination="OK", status="on time"}); 
            //FlightListMaker flm = new FlightListMaker();
            FlightListMaker flm = new FlightListMaker();
            fl = flm.listMaker();
            Console.WriteLine(fl[0].flightNumber); 
          //  fl = flm.listMaker();
           dataGridView1.DataSource = fl; 
           
        }
       
         


    }
}
