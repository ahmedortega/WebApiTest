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
                var car = _entities.Cars.FirstOrDefault(c => c.Id == ID);
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
        /*public Car Post(Car car)
        {
            using (CarsDBEntities _entities = new CarsDBEntities())
            {
                _entities.Cars.Add(car);
                _entities.SaveChanges();
                return car;
            }
        }
        */
        public HttpResponseMessage Post(Car car)
        {
            using (CarsDBEntities _entities = new CarsDBEntities())
            {
                try
                {
                    _entities.Cars.Add(car);
                    _entities.SaveChanges();
                    var msg = Request.CreateResponse(HttpStatusCode.Created, car);
                    msg.Headers.Location = new Uri(Request.RequestUri +""+car.Id);
                    return msg;
                }
                catch(Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        public HttpResponseMessage Delete(int ID)
        {
            using (CarsDBEntities _entities = new CarsDBEntities())
            {
                var car = _entities.Cars.FirstOrDefault(c => c.Id == ID);
                if (car == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ID not Found");
                }
                else
                {
                    _entities.Cars.Remove(car);
                    _entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, car);
                }
            }
        }

        public HttpResponseMessage Put(int ID, Car car)
        {
            using (CarsDBEntities _entities = new CarsDBEntities())
            {
                try
                {
                var myCar = _entities.Cars.FirstOrDefault(c => c.Id == ID);
                    if (myCar == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, " the ID not Found");
                    }
                    else
                    {
                        myCar.Name = car.Name;
                        myCar.ModelYear = car.ModelYear;
                        myCar.Color = car.Color;
                        _entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, myCar);
                    }
                }
                catch(Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }







    }
}
