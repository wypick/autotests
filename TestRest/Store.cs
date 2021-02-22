using System;
using System.Collections.Generic;
using System.Text;

namespace TestRest
{
    public class Store
    {
        static int id;
        static int quantity;
        static DateTime shipDate;
        static string status;
        static bool complete = true;
        static public Order order;

        static public Order GetOrder(int petId)
        {
            GenerateOrder();

            order = new Order { id = id, petId = petId, quantity = quantity, shipDate = shipDate, status = status, complete = complete };

            return order;
        }

        static public void GenerateOrder()
        {
            Random rnd = new Random();

            //Получить случайное число (в диапазоне от 0 до 10000000)
            id = rnd.Next(1, 10);
            quantity = rnd.Next(0, 100000000);

            shipDate = DateTime.Now;

            string[] statuses = { "placed", "placed", "delivered " };
            status = statuses[rnd.Next(statuses.Length)];
            }
        }
}

