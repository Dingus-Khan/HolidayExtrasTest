using System;
using System.Collections.Generic;
using UserAPI;

namespace UserAPIWebApp.Models
{
    public class IndexViewModel
    {
        public List<UserAPI.Models.User> Users { get; set; } = new List<UserAPI.Models.User>();
    }
}
