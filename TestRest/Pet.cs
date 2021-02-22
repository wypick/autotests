using System;
using System.Collections.Generic;
using System.Text;

namespace TestRest
{
    public class Pets
    {
        static int id;
        static Category category;
        static string name;
        static List<string> photoUrls;
        static List<Tag> tags;
        static string status;
        static public Pet pet;


        static public Pet GetPet(string condition = null)
        {
            if (condition != null)
            {
                GeneratePet(condition);
            }
            else
                GeneratePet();

            pet = new Pet { Id = id, Category = category, Name = name, PhotoUrls = photoUrls, Tags = tags, Status = status };
           
            return pet;
        }

        static public void GeneratePet(string condition = null)
        {
            Random rnd = new Random();

            //Получить случайное число (в диапазоне от 0 до 10000000)
            id = rnd.Next(0, 100000000);

            category = new Category { Id = rnd.Next(0, 100000000), Name = GenerateString(10, rnd) };

            name = GenerateString(10, rnd);
            photoUrls = new List<string>() { GenerateString(10, rnd) };

            Tag tag = new Tag { Id = rnd.Next(0, 100000000), Name = GenerateString(10, rnd) };
            tags = new List<Tag> { tag };

            if (condition != null)
            {
                status = condition;
            }
            else
            {
                string[] statuses = { "available", "pending", "sold" };
                status = statuses[rnd.Next(statuses.Length)];
            }
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
