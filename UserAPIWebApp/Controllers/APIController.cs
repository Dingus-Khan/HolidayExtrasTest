using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserAPIWebApp.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class APIController : Controller
    {
        private UserAPI.Users Users { get; set; } = new UserAPI.Users();

        [HttpGet]
        public JsonResult GetUsers() {
            return Json(Users.GetUsers());
        }

        [HttpGet]
        public JsonResult GetUser(int id) {
            return Json(Users.GetUser(id));
        }

        [HttpDelete]
        public JsonResult DeleteUser(int id) {
            return Json(Users.DeleteUser(id));
        }

        [HttpPost]
        public JsonResult CreateUser() {
            var userJson = "";

            using (var reader = new System.IO.StreamReader(Request.Body)) {
                userJson = reader.ReadToEnd();
            }

            return Json(Users.CreateUser(userJson));
        }

        [HttpPost]
        public JsonResult UpdateUser() {
            var userJson = "";

            using (var reader = new System.IO.StreamReader(Request.Body))
            {
                userJson = reader.ReadToEnd();
            }

            return Json(Users.UpdateUser(userJson));
        }
    }
}