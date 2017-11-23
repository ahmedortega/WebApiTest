using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDAM;

namespace WebAppSeission1.Controllers
{
    public class UsersController : ApiController
    {
        public IEnumerable<User> Get()
        {
            using (UsersEntities _entities = new UsersEntities())
            {
                return _entities.Users.ToList();
            }
        }

        public HttpResponseMessage GetUser(int ID)
        {
            using (UsersEntities _entities = new UsersEntities())
            {
                var car = _entities.Users.FirstOrDefault(c => c.Id == ID);
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
        public HttpResponseMessage Post(User user)
        {
            using (UsersEntities _entities = new UsersEntities())
            {
                try
                {
                    _entities.Users.Add(user);
                    _entities.SaveChanges();
                    var msg = Request.CreateResponse(HttpStatusCode.Created, user);
                    msg.Headers.Location = new Uri(Request.RequestUri + "" + user.Id);
                    return msg;
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        public HttpResponseMessage Delete(int ID)
        {
            using (UsersEntities _entities = new UsersEntities())
            {
                var user = _entities.Users.FirstOrDefault(c => c.Id == ID);
                if (user == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ID not Found");
                }
                else
                {
                    _entities.Users.Remove(user);
                    _entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
            }
        }

        public HttpResponseMessage Put(int ID, User user)
        {
            using (UsersEntities _entities = new UsersEntities())
            {
                try
                {
                    var myUser = _entities.Users.FirstOrDefault(c => c.Id == ID);
                    if (myUser == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, " the ID not Found");
                    }
                    else
                    {
                        myUser.FirstName = user.FirstName;
                        myUser.LastName = user.LastName;
                        myUser.PhoneNo = user.PhoneNo;
                        myUser.Company = user.Company;
                        myUser.Email = user.Email;
                        myUser.image = user.image;
                        _entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, myUser);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }
    }
}
