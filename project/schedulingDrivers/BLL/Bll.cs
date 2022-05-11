using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;


namespace BLL
{
    public class Bll
    {
        TryingDoDatabase dalbll = new TryingDoDatabase();

        public string returnDrive(string id)
        {
            return dalbll.returndriver(id);
        }
        public List<Driver> returnAlldriver()
        {
            return dalbll.returnAlldriver();
        }
        public void addDriver(Driver d)
        {
            dalbll.addDriver(d);
        }

    }
}
