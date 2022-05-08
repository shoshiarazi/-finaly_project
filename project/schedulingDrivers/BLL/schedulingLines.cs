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



        public schedulingLines(TimeSpan startShift, TimeSpan endShift, int numOfDrivers)
        {
            this.numOfDrivers = numOfDrivers;
            this.startShift = startShift;
            this.endShift = endShift;
            foreach (KavTime kav in _driverEntities.KavTimes)
            {
                if (kav.DepartureTime > this.startShift && kav.DepartureTime < this.endShift)
                {
                   this.kavTimesList.Add(kav);
                }
            }
          //this.numOfLines =Math.Ceiling(kavTimesList.Count()/numOfLines);
          this.numOfLines = kavTimesList.Count()/numOfLines+1;
            this.matrizza = new List<Line_placement_for_shift[,]>();
            Random rnd1 = new Random();
            int i;
            int j;

            for (int k = 0; k < 1000; k++)
            {
               this.matrizza.Add(new Line_placement_for_shift[this.numOfLines, this.numOfDrivers]);
            }

            foreach (Line_placement_for_shift[,] ma in this.matrizza)
            {
                foreach (KavTime kav in this.kavTimesList)
                {
                    i = rnd1.Next(0, numOfLines);
                    j = rnd1.Next(0, numOfDrivers);
                    while (ma[i, j] != null)
                    {
                        i = rnd1.Next(0, numOfLines);
                        j = rnd1.Next(0, numOfDrivers);
                    }
                    ma[i, j].kav = kav.KavId;
                    ma[i, j].startTime = kav.DepartureTime;
                    ma[i, j].Duration = kav.LongTime_minutes_;
                }
            }
            
        }
        public  int[] marks(List<Line_placement_for_shift[,]> allMatrixes)
        {
            int[] grades = new int[allMatrixes.Count()];
            for(int i=0; i< allMatrixes.Count(); i++)
            {
                grades[i] = 100;
            }
            int k = 0;
            int howManyEmptytogather = 0; //כמה חורים ריקים יש ברצף
            int howManyEmpty = 0;//כמה ריקים לכל נהג
            foreach(Line_placement_for_shift[,] matrix in allMatrixes)
            {
                for(int i=0;i<numOfDrivers;i++)
                {
                    howManyEmpty = 0;
                    howManyEmptytogather = 0;
                    for (int j=0;j<numOfLines;j++)
                    {
                       if( matrix[j,i]!=null)
                        {
                            if (i!= 0)
                            {
                                if (matrix[j, i - howManyEmptytogather] !=null)
                                {
                                    if (matrix[j, i - howManyEmptytogather].startTime>matrix[j,i].startTime)
                                    {
                                        grades[k]--;
                                    }
                                    if(matrix[j, i - howManyEmptytogather].startTime+matrix[j, i - howManyEmptytogather].Duration>matrix[j,i].startTime)
                                    {
                                        grades[k]--;
                                    }
                                }
                            }
                            howManyEmptytogather = 0;
                        }
                        else
                        {
                            howManyEmptytogather ++;
                            howManyEmpty++;
                        }
                        grades[k] = grades[k] - howManyEmpty;
                    }
                }
                k++;
            }
            return grades;
        }
    }
}
