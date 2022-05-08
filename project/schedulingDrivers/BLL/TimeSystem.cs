using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TimeSystem
    {
       public Line_placement_for_shift[,] myList;
       public int grade;

        public TimeSystem(Line_placement_for_shift[,] myList, int grade)
        {
            this.myList = myList;
            this.grade = grade;
        }

        public TimeSystem()
        {
        }
    }
}
