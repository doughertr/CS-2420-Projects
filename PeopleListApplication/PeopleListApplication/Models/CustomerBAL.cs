using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PeopleListApplication.Models
{
    public class CustomerBAL : DbContext 
    {
        public DbSet<Customer> Customers { get; set; }
    }
}