﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ass2
{
    class Customer
    {
        //Kris Boyte 30016677
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }


        public Customer(string fn, string ln, string ph)
        {
            FName = fn;
            LName = ln;
            Phone = ph;
        }

        public string GetCustomer()
        {
            return $"{FName}\t{LName}\t{Phone}";
        }


    }
}
