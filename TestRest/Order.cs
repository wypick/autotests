using System;
using System.Collections.Generic;
using System.Text;

namespace TestRest
{
    public class Order : Context
    {
        public int id { get; set; }
        public int petId { get; set; }
        public int quantity { get; set; }
        public DateTime shipDate { get; set; }
        public string status { get; set; }
        public bool complete { get; set; }
        static string[] statuses = { "placed", "placed", "delivered " };

        public Order()
        {
            id = Rnd.Next(1, 10);
            petId = Pet.Id;
            quantity = Rnd.Next(0, 100000000);
            shipDate = DateTime.Now;
            status = statuses[Rnd.Next(statuses.Length)];
            complete = true;
        }
    }
}

