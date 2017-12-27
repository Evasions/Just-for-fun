using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Spark.Models
{
    public class UserContext : DbContext
    {
       public UserContext() :
       base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
    }

    public class EstablishmentsContex : DbContext
    {
        public EstablishmentsContex() { }

        public DbSet<EstablishmentsModel> dbEstablishments { get; set; }
    }
}