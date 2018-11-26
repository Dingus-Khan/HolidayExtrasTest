using System;

namespace UserAPI
{
    public class Models
    {
        public class User
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string GivenName { get; set; }
            public string FamilyName { get; set; }
            public DateTime DateCreated { get; set; }
        }
    }
}
