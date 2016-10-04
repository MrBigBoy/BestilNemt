﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Login Login;
        public List<Shop> Shops = new List<Shop>();

        public Person()
        {

        }
        public Person(int id, string name, string email, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Address = address;
            // hej
        }


    }
    

}
