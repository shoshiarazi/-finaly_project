using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Genetic;
using Models;


namespace BLL
{
   public class schedulingLines
    {
        private readonly DriversEntities _driverEntities;
        public int numOfDrivers;
        public int numOfLines;
        public List<KavTime> kavTimesList;
        public TimeSpan startShift;
        public TimeSpan endShift;
        public List<Line_placement_for_shift[,]> matrizza;
        public List<int[,]> lis;



        public schedulingLines(TimeSpan startShift, TimeSpan endShift)
        {
            numOfDrivers= _driverEntities.Drivers.Count()/3;
            foreach(KavTime kav in _driverEntities.KavTimes)
            {
                if(kav.DepartureTime>startShift&& kav.DepartureTime<endShift)
                {
                    kavTimesList.Add(kav);
                }
            }
            numOfLines = kavTimesList.Count();
            matrizza = new List<Line_placement_for_shift[,]>();
            for(int i=0;i<1000;i++)
            {
                matrizza.Add(new Line_placement_for_shift[numOfLines, numOfDrivers/numOfLines]);
            }
            foreach(Line_placement_for_shift[,] ma in matrizza)
            {
                for(int i=0;i<numOfLines;i++)
                {
                    for(int j=0;j<numOfDrivers;j++)
                    {
ma[i,j].kav
                    }
                }
            }
        }


        //        public int schedulingLinesInMishmeret()
        //        {
        //for(int i=0;i<)
        //        }

    }
}
