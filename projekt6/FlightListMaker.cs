using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projekt6
{
    class FlightListMaker
    {
     

            public List<Flight> listMaker()
            {
                List<string> statusArrivals = new List<string>() { "ON TIME", "LANDED", "DELAYED", "CANCLED"};
                List<string> statusDepartures = new List<string> () { "BOARDING", "LAST CALL", "END OF BOARDING" };
                List<string> cityList = new List<string>() { "GDAŃSK", "DUBLIN", "OSLO", "WARSZAWA", "BERLIN" }; 
                List<Flight> flightList = new List<Flight>();

                Random randNum = new Random();
                int aRandomPos = randNum.Next(cityList.Count - 1);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
                int randomPos = randNum.Next(cityList.Count - 1);
               // Console.WriteLine(aRandomPos);
                //Console.WriteLine(randomPos);
                Flight flight = new Flight();
               // flight.flightNumber =
                flight.from = cityList[aRandomPos];
                if (aRandomPos != randomPos)
                {

                    flight.destination = cityList[randomPos];
                }
                else {
                    randomPos = +1;
                    flight.destination = cityList[randomPos];
                }
                
                //flight.status = status[aRandomPos];

                flightList.Add(flight);

                return flightList;
            }

        }
    
}

