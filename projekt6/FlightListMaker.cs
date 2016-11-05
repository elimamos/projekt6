using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projekt6
{
    class FlightListMaker
    {
      
        List<string> cityList = new List<string>() { "GDAŃSK", "DUBLIN", "OSLO", "WARSZAWA", "BERLIN" };
        Random randNum = new Random();

     
        

            public List<Flight> listMaker()
            {
               
                Flight newFlight = new Flight();
                List<Flight> flightList = new List<Flight>();
                for (int i = 0; i <21 ; i++)
                {
                    int aRandomPos = this.randNum.Next(cityList.Count - 1);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
                    int randomPos = this.randNum.Next(cityList.Count - 1);
                    int flightNumer = randNum.Next(999, 10000);
                   newFlight = makeFlight( aRandomPos, randomPos, flightNumer);
                    flightList.Add(newFlight);
                }

               

                return flightList;
            }
            private Flight makeFlight( int aRandomPos,int randomPos,int flightNumer) {

             

               

                Flight flight = new Flight();

                flight.from = cityList[aRandomPos];
                if (aRandomPos != randomPos)
                {

                    flight.destination = cityList[randomPos];
                }
                else
                {
                    if (randomPos != cityList.Count())
                    {
                        randomPos = +1;
                        flight.destination = cityList[randomPos];
                    }
                    else
                        flight.destination = cityList[0];
                }
                char[] f;
                char[] t;
                f = flight.from.ToCharArray(0, 1);
                t = flight.destination.ToCharArray(0, 1);

               
                Console.WriteLine(flightNumer);
                flight.flightNumber = f[0].ToString() + t[0].ToString() + flightNumer.ToString();

                if (flight.from == "GDAŃSK")
                {
                    flight.status = new DataGridViewComboBoxCell()
                   {

                       DataSource = new string[] { "BOARDING", "LAST CALL", "END OF BOARDING" }

                   };
                }
                else
                {
                    flight.status = new DataGridViewComboBoxCell()
                     {

                         DataSource = new string[] { "ON TIME", "LANDED", "DELAYED", "CANCLED" }

                     };
                }
                return flight;

            
            }

        }
    
}

