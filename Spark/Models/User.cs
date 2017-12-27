using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int EventId { get; set; }
        public int FriendId { get; set; }


    }
}