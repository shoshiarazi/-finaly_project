using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class driversbl
    {
        DBConection dbCon;
        public List<Driver> listOfDrivers;

        public driversbl()
        {
            dbCon = new DBConection();
            //listOfDrivers = dbCon.GetDbSet<Driver>().ToList();
        }
        public List<Driver> GetAllDrivers()
        {
            return listOfDrivers;
        }
        public void InsertDriver(Driver driver)
        {
            //if (listOfDrivers.Find(d => d.DriverId == driver.DriverId) == null)
            //{
            //    try
            //    {
                    dbCon.Execute<Driver>(new Driver()
                    {
                        DriverId = driver.DriverId,
                        DriverName = driver.DriverName,
                        PhoneDriver = driver.PhoneDriver
                    }, DBConection.ExecuteActions.Insert);
                    //listOfDrivers = dbCon.GetDbSet<Driver>().ToList();
                    //return listOfDrivers.First(d => d.DriverId == driver.DriverId).DriverId;
                //}
                //catch (Exception ex)
                //{
                   
                //}

            //}
        }
    }
}
