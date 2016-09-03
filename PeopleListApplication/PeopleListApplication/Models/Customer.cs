using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleListApplication.Models
{
    public class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Interests { get; set; }
        public byte[] Photo { get; set; }
    }
}