//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Accord.Genetic;
//using Models;

//namespace bll
//{
//    public class Drivertablechromosome : ChromosomeBase
//    {
//        private readonly DriversEntities _driverentities;
//        static Random random = new Random();

//        static TimeSpan randomstarttime()
//        {
//            return TimeSpan.FromMilliseconds(random.Next((int)TimeSpan.FromHours(9).TotalMilliseconds,
//                (int)TimeSpan.FromHours(17).TotalMilliseconds));
//        }


//        public List<SchedularView> value;

//        public Drivertablechromosome(DriversEntities driverentities)
//        {
//            _driverentities = driverentities;
//            generate();
//        }
//        public Drivertablechromosome(List<SchedularView> slots, DriversEntities driverentities)
//        {
//            _driverentities = driverentities;
//            value = slots.ToList();
//        }
//        public override void Generate()
//        {
//            IEnumerable<SchedularView> generaterandomslots()
//            {


//                var drivers = _driverentities.ColanderToDrivers.ToList()
//                //  .where(colandertodrivers => colandertodrivers.typeofcolande).tolist();
//                //.Include(colandertodrivers => colandertodrivers.kavimtocolanders).tolist();

//                foreach (var driver in drivers)
//                {

//                    //yield return new schedularview()
//                    //{
//                    //    //students = course.students.select(student => student.studentid).tolist(),
//                    //    //courseid = course.id,
//                    //    //startat = randomstarttime(),
//                    //    //placeid = _driverentities.places.orderby(place => guid.newguid()).firstordefault().id,
//                    //    //teacherid = course.teacher.id,
//                    //    //day = random.next(1, 5)
//                    //};

//                }
//            }

//            value = generaterandomslots().tolist();

//        }

//        public override ichromosome createnew()
//        {
//            var timetablechromosome = new timetablechromosome(_driverentities);
//            timetablechromosome.generate();
//            return timetablechromosome;
//        }

//        public override ichromosome clone()
//        {
//            return new timetablechromosome(value, _driverentities);
//        }

//        public override void mutate()
//        {
//            var index = random.next(0, value.count - 1);
//            var schedularview = value.elementat(index);
//            schedularview.startat = randomstarttime();
//            schedularview.day = random.next(1, 5);
//            value[index] = schedularview;

//        }

//        public override void crossover(ichromosome pair)
//        {
//            var randomval = random.next(0, value.count - 2);
//            var otherchromsome = pair as timetablechromosome;
//            for (int index = randomval; index < otherchromsome.value.count; index++)
//            {
//                value[index] = otherchromsome.value[index];
//            }

//        }

//        public class fitnessfunction : ifitnessfunction
//        {
//            public double evaluate(ichromosome chromosome)
//            {
//                double score = 1;
//                var values = (chromosome as timetablechromosome).value;
//                var getoverlaps = new func<schedularview, list<schedularview>>(current => values
//                    .except(new[] { current })
//                    .where(slot => slot.day == current.day)
//                    .where(slot => slot.day == current.day)
//                    .where(slot => slot.startat == current.startat
//                                  || slot.startat <= current.endat && slot.startat >= current.startat
//                                  || slot.endat >= current.startat && slot.endat <= current.endat)
//                    .tolist());



//                foreach (var value in values)
//                {
//                    var overlaps = getoverlaps(value);
//                    score -= overlaps.groupby(slot => slot.teacherid).sum(x => x.count() - 1);
//                    score -= overlaps.groupby(slot => slot.placeid).sum(x => x.count() - 1);
//                    score -= overlaps.groupby(slot => slot.courseid).sum(x => x.count() - 1);
//                    score -= overlaps.sum(item => item.students.intersect(value.students).count());
//                }

//                score -= values.groupby(v => v.day).count() * 0.5;
//                return math.pow(math.abs(score), -1);
//            }
//        }
//    }
//}
