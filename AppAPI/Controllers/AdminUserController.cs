using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppAPI.Controllers
{
    [RoutePrefix("api/v1/admin-user")]
    public class AdminUserController : ApiController
    {
        RestAPIEntities restAPIEntities;

        [Route("adminuser")]
        public List<AdminUser> GetAllAdminUser()
        {
            restAPIEntities = new RestAPIEntities();
            var listAdminUsers = restAPIEntities
                .AdminUsers
                .ToList();

            return listAdminUsers;
        }

        [Route("adminuser/{id}")]
        [HttpGet]
        public List<AdminUser> GetAdminUser(int id)
        {
            if (id > 0)
            {
                restAPIEntities = new RestAPIEntities();
                var listAdminUsers = restAPIEntities
                    .AdminUsers
                    .Where(d => d.AdminUserId == id)
                    .ToList();

                return listAdminUsers;
            }
            return null;
        }

        [Route("adminuser")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]AdminUser adminUser)
        {
            if (adminUser != null)
            {
                restAPIEntities = new RestAPIEntities();
                restAPIEntities.AdminUsers.Add(adminUser);
                restAPIEntities.SaveChanges();
                return Ok("Success");
            }
            return BadRequest("Failed");
        }

        [Route("adminuser/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id > 0)
            {
                restAPIEntities = new RestAPIEntities();
                var obj = restAPIEntities
                    .AdminUsers
                    .Where(d => d.AdminUserId == id)
                    .FirstOrDefault();
                if (obj != null)
                {
                    restAPIEntities.AdminUsers.Remove(obj);
                    restAPIEntities.SaveChanges();
                    return Ok("Success");
                }
                else
                {
                    return Ok("No Content");
                }
            }
            return BadRequest("Failed");
        }
    }
}
