using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL
{
    public class Line_placement_for_shift
    {
        public long kav;
        public System.TimeSpan startTime;
        public long Duration;

        public Line_placement_for_shift(long kav, TimeSpan startTime, long duration)
        {
            this.kav = kav;
            this.startTime = startTime;
            Duration = duration;
        }

        public Line_placement_for_shift(TimeSpan startTime)
        {
            this.startTime = startTime;
        }

        public Line_placement_for_shift(long kav)
        {
            this.kav = kav;
        }

        public Line_placement_for_shift()
        {
        }
    }

}
