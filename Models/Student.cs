using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSConsumer.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ClassID { get; set; }

    }
}