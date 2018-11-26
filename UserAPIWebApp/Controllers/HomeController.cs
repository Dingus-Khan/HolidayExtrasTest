using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserAPIWebApp.Models;

namespace UserAPIWebApp.Controllers
{
    public class HomeController : Controller
    {
        public UserAPI.Users Users { get; set; } = new UserAPI.Users();

        public IActionResult Index(IndexViewModel viewModel)
        {
            viewModel.Users = Users.GetUsers();
            return View(viewModel);
        }
    }
}
