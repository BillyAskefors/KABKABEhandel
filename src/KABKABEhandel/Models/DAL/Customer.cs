using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Models.DAL
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    
        public string Email { get; set; }

        public string Phone { get; set; }

        public Customer(int id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone; 
        }

        public Customer(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

    }
}
