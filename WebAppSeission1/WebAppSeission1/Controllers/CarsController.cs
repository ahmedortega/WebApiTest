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

        public HttpResponseMessage GetCar(int ID)
        {
            using (CarsDBEntities _entities = new CarsDBEntities())
            {
                var car = _entities.Cars.FirstOrDefault(c => c.id == ID);
                if (car == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "This (ID) not Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, car);
                }
            }
        }
        public Car Post(Car car)
        {
            using (CarsDBEntities _entities = new CarsDBEntities())
            {
                return _entities.Cars.Add(car);
            }
        }

    }
}
