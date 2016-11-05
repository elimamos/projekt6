using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projekt6
{
    class FlightListMaker
    {
      
        List<string> cityList = new List<string>() { "NOWY JORK", "DUBLIN", "OSLO", "WARSZAWA", "BERLIN" };
        Random randNum = new Random();
        List<Flight> flightList;
        List<string> outStatus = new List<string>() { "Check in", "Gate Closed", "Departed" };
        List<string> inStatus = new List<string>() { "On time", "Delayed", "Landed","Canceled"};
        Form2 flightListForm;

        public FlightListMaker(Form2 flightListForm)
        {
            this.flightListForm = flightListForm;

        }

            public List<Flight> listMaker()
            {
               
                Flight newFlight = new Flight();
                this.flightList = new List<Flight>();
                for (int i = 0; i <5 ; i++)
                {
                    
                    newFlight = makeFlight();
                    this.flightList.Add(newFlight);
                }

              
                return this.flightList;
            }

          
            public List<Flight> updateFlightList()
            {
                int flightIndex= this.randNum.Next(0,flightList.Count);

                if(this.flightList[flightIndex].isOut==0){
                    Console.WriteLine("UpdatingIN");
                    this.flightList[flightIndex] = updateInFlight(flightList[flightIndex]);

                }
                else{
                    this.flightList[flightIndex] = updateOutFlight(flightList[flightIndex]);
                }

                return flightList;
            }
            private Flight updateOutFlight(Flight flight)
            {
                if (flight.statusIndex == 0)
                {
                    Form4 boarding = new Form4(flight, flightListForm);
                    flightListForm.Hide();
                    boarding.Show();
                    flight.status = this.outStatus[1];
                    flight.statusIndex = 1;
                }
                else if(flight.statusIndex==1){
                    flight.statusIndex = 2;
                    flight.status = this.outStatus[2];
                }
                else if (flight.statusIndex == 2)
                {
                    flight = makeFlight();
                }

                return flight;
            }
            private Flight updateInFlight(Flight flight)
            {
                if (flight.statusIndex == 0)
                {
                    double isDelayed = randNum.NextDouble();
                    if (isDelayed < 0.1)
                    {
                        flight.status = this.inStatus[1];
                        flight.statusIndex = 1;
                    }
                    else
                    {
                        flight.status = this.inStatus[2];
                        flight.statusIndex = 2;
                    }
                }
                else if (flight.statusIndex == 1 )
                {
                    double isCancelled = randNum.NextDouble(); 
                    if (isCancelled < 0.1)
                    {
                        flight.status = this.inStatus[3];
                        flight.statusIndex = 3;

                    }
                    else
                    {
                        flight.status = this.inStatus[2];
                        flight.statusIndex = 2;
                    }
                    
                }
                else if (flight.statusIndex == 3 || flight.statusIndex == 2)
                {
                    flight = makeFlight();
                }


                return flight;

            } 

            private Flight makeFlight() {

                int aRandomPos = this.randNum.Next(cityList.Count - 1);
                int flightNumer = randNum.Next(999, 10000);


                Flight flight = new Flight();

                int isOut = this.randNum.Next(0, 2);
                flight.isOut = isOut;

                if (isOut == 1)
                {
                    flight.from = "GDAŃSK";
                    flight.destination = cityList[aRandomPos];
                    flight.status = this.outStatus[0];
                    flight.statusIndex = 0;
                   
                  
                }
                else
                {
                    flight.destination = "GDAŃSK";
                    flight.from = cityList[aRandomPos];
                    flight.status = this.inStatus[0];
                    flight.statusIndex = 0;

                }

                char[] f;
                char[] t;
                f = flight.from.ToCharArray(0, 1);
                t = flight.destination.ToCharArray(0, 1);

               
               
                flight.flightNumber = f[0].ToString() + t[0].ToString() + flightNumer.ToString();

               
                return flight;

            
            }

        }
    
}

