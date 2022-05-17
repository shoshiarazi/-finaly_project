using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DAL
{
   public class DBConection
    {
        public DBConection()
        {
        }
        //public List<T> GetDbSet<T>() where T : class
        //{
        //    using (DriversEntities driversEntities = new DriversEntities())
        //    {
        //        return driversEntities.GetDbSet<T>().ToList();
        //    }
        //}
        public enum ExecuteActions
        {
            Insert,
            Update,
            Delete
        }
        public void Execute<T>(T entity, ExecuteActions exAction) where T : class
        {
            using (DriversEntities driversEntities = new DriversEntities())
            {
                var model = driversEntities.Set<T>();
                switch (exAction)
                {
                    case ExecuteActions.Insert:
                        model.Add(entity);
                        break;
                    case ExecuteActions.Update:
                        model.Attach(entity);
                        driversEntities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        break;
                    case ExecuteActions.Delete:
                        model.Attach(entity);
                        driversEntities.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                        break;
                    default:
                        break;
                }
                driversEntities.SaveChanges();
            }
        }
    }
}
