using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloStructureMap
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genger { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} - {EmailAddress} - {PhoneNumber} - {BirthDate}";
        }
    }
}
