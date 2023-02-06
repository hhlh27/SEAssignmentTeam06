using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAssignment
{
    class Person
    {
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }
        public string Name { get; set; }

        public Person(string loginEmail, string loginPassword, string name)
        {
            LoginEmail = loginEmail;
            LoginPassword = loginPassword;
            Name = name;
        }
    }
}
