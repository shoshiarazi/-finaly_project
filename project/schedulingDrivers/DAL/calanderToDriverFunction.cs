using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DAL
{
    class calanderToDriverFunction
    {
        DriversEntities DB = new DriversEntities();

        //private void calander()
        //{

        //    DB.TypeOfColanders.Add();
        //}
        public void addDriver(Driver d)
        {
            DB.Drivers.Add(d);
            DB.SaveChanges();
        }
    }
}
