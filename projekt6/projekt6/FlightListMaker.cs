using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projekt6
{
    class FlightListMaker:Form2
    {
     
            public FlightListMaker()
            {



            }

            public List<flights> listMaker()
            {
                List<string> status = new List<string>() { "ON TIME", "LANDED", "DELAYED", "CANCLED", "BOARDING", "LAST CALL", "END OF BOARDING" };
                List<string> flightNumbersList = new List<string>() { "FR9678", "FR9723", "GD7723", "HR3426" };
                List<flights> flightList = new List<flights>();

                Random randNum = new Random();
                int aRandomPos = randNum.Next(flightNumbersList.Count - 1);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
                flightList.Add(new flights() { flightNumber = flightNumbersList[aRandomPos], destination = "W", from = "A", status = status[aRandomPos] });



                return flightList;
            }

        }
    
}

