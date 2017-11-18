using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppSeission1.Controllers
{
    public class CarsController : ApiController
    {
        public IEnumerable<Car> Get()
        {
            using (CarsDBEntities _entities = new CarsDBEntities() )
            {
                return _entities.Cars.ToList();
            }
        }

        public Car GetCar(int id)
        {
            using (CarsDBEntities _entities = new CarsDBEntities())
            {
                return _entities.Cars.FirstOrDefault(c => c.id == id);
            }
        }
    }
}
