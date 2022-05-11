using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Genetic;
using Models;


namespace BLL
{
    public class schedulingLines : ChromosomeBase
    {
        private readonly DriversEntities _driverEntities;
        public int numOfDrivers;
        public int numOfLines;
        public List<KavTime> kavTimesList;
        public TimeSpan startShift;
        public TimeSpan endShift;
        //public List<Line_placement_for_shift[,]> matrizza;
        public List<int[,]> lis;


        public List<TimeSystem> timeSystems;


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
            this.numOfLines = kavTimesList.Count() / numOfLines + 1;
            this.timeSystems = new List<TimeSystem>();
            //this.matrizza = new List<Line_placement_for_shift[,]>();
            Random rnd1 = new Random();
            int i;
            int j;

            for (int k = 0; k < 1000; k++)
            {
                // this.matrizza.Add(new Line_placement_for_shift[this.numOfLines, this.numOfDrivers]);
                this.timeSystems.Add(new TimeSystem(new Line_placement_for_shift[this.numOfLines, this.numOfDrivers], 100));
            }
            foreach (TimeSystem system in this.timeSystems)
            // ma=  system.myList
            //  foreach (Line_placement_for_shift[,] ma in this.matrizza)
            {
                foreach (KavTime kav in this.kavTimesList)
                {
                    i = rnd1.Next(0, numOfLines);
                    j = rnd1.Next(0, numOfDrivers);
                    while (system.myList[i, j] != null)
                    {
                        i = rnd1.Next(0, numOfLines);
                        j = rnd1.Next(0, numOfDrivers);
                    }
                    system.myList[i, j].kav = kav.KavId;
                    system.myList[i, j].startTime = kav.DepartureTime;
                    system.myList[i, j].Duration = kav.LongTime_minutes_;
                }
            }

        }

        public override IChromosome Clone()
        {
            throw new NotImplementedException();
        }

        public override IChromosome CreateNew()
        {
            throw new NotImplementedException();
        }

        public override void Crossover(IChromosome pair)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override void Generate()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //public  int[] marks(List<Line_placement_for_shift[,]> allMatrixes)
        //{

        //    int[] grades = new int[allMatrixes.Count()];
        //    for(int i=0; i< allMatrixes.Count(); i++)
        //    {
        //        grades[i] = 100;
        //    }
        //    int k = 0;
        //    int howManyEmptytogather = 0; //כמה חורים ריקים יש ברצף
        //    int howManyEmpty = 0;//כמה ריקים לכל נהג
        //    foreach(Line_placement_for_shift[,] matrix in allMatrixes)
        //    {
        //        for(int i=0;i<numOfDrivers;i++)
        //        {
        //            howManyEmpty = 0;
        //            howManyEmptytogather = 0;
        //            for (int j=0;j<numOfLines;j++)
        //            {
        //               if( matrix[j,i]!=null)
        //                {
        //                    if (i!= 0)
        //                    {
        //                        if (matrix[j, i - howManyEmptytogather] !=null)
        //                        {
        //                            if (matrix[j, i - howManyEmptytogather].startTime>matrix[j,i].startTime)
        //                            {
        //                                grades[k]--;
        //                            }
        //                            if(matrix[j, i - howManyEmptytogather].startTime+TimeSpan.FromMinutes(matrix[j, i - howManyEmptytogather].Duration)>matrix[j,i].startTime)
        //                            {
        //                                grades[k]--;
        //                            }
        //                        }
        //                    }
        //                    howManyEmptytogather = 0;
        //                }
        //                else
        //                {
        //                    howManyEmptytogather ++;
        //                    howManyEmpty++;
        //                }
        //                grades[k] = grades[k] - howManyEmpty;
        //            }
        //        }
        //        k++;
        //    }

        //    return grades;
        //}
        public void getmarks()
        {


            int k = 0;
            int howManyEmptytogather = 0; //כמה חורים ריקים יש ברצף
            int howManyEmpty = 0;//כמה ריקים לכל נהג
            foreach (TimeSystem system in this.timeSystems)
            {
                for (int i = 0; i < numOfDrivers; i++)
                {
                    howManyEmpty = 0;
                    howManyEmptytogather = 0;
                    for (int j = 0; j < numOfLines; j++)
                    {
                        if (system.myList[j, i] != null)
                        {
                            if (i != 0)
                            {
                                if (system.myList[j, i - howManyEmptytogather] != null)
                                {
                                    if (system.myList[j, i - howManyEmptytogather].startTime > system.myList[j, i].startTime)
                                    {
                                        system.grade--;
                                    }
                                    if (system.myList[j, i - howManyEmptytogather].startTime + TimeSpan.FromMinutes(system.myList[j, i - howManyEmptytogather].Duration) > system.myList[j, i].startTime)
                                    {
                                        system.grade--;
                                    }
                                }
                            }
                            howManyEmptytogather = 0;
                        }
                        else
                        {
                            howManyEmptytogather++;
                            howManyEmpty++;
                        }
                        system.grade = system.grade - howManyEmpty;
                    }
                }
            }


            timeSystems.OrderBy(s => s.grade);

        }

        public override void Mutate()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
