using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;




namespace DAL
{
    public class TryingDoDatabase
    {
        DriversEntities DB = new DriversEntities();
        public void addDriver(Driver d)
        {
            DB.Drivers.Add(d);
            DB.SaveChanges();
        }
        public void addLine(kavim k,KavTime[] allTimes)
        {
            DB.kavims.Add(k);
            foreach (KavTime item in allTimes)
            {
                DB.KavTimes.Add (item);
            }
            DB.SaveChanges();
        }
        public void addTypeOfColander(TypeOfColander mishmeret)
        {
            DB.TypeOfColanders.Add(mishmeret);
            DB.SaveChanges();
        }
        public void addPreference(Preference preference)
        {
            DB.Preferences.Add(preference);
            DB.SaveChanges();
        }


        public List<Driver> returnAlldriver()
        {
          return  DB.Drivers.ToList();
            
        }
        public string returndriver(string id)
        {
            return DB.Drivers.Find(id).DriverName.ToString();

        }

    }
}
