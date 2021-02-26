using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace TestRest
{
    public class Context
    {
        public static Pet Pet { get; set; }
        public static Order Order { get; set; }
        public static Random Rnd { get; set; }
        public static string AddedPet { get; set; }
        public static string AddedOrder { get; set; }
        public static HttpResponseMessage Response { get; set; }

        public static void Init()
        {
            Rnd = new Random();
        }

        public static string GenerateString(int length, Random random)
        {
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }
}
