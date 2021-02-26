using System;
using System.Collections.Generic;
using System.Text;

namespace TestRest
{
    public class Pet : Context
    {
        public int Id { get; set; }
        public Categories Category { get; set; }
        public string Name { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Tag> Tags { get; set; }
        public string Status { get; set; }
        static string[] statuses = { "available", "pending", "sold" };

        public struct Categories
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Tag
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public Pet()
        {
            Id = Rnd.Next(0, 100000000);
            Category = new Categories { Id = Rnd.Next(0, 100000000), Name = GenerateString(10, Rnd)};
            Name = GenerateString(10, Rnd);
            PhotoUrls = new List<string>() { GenerateString(10, Rnd) };
            Tags = new List<Tag> { new Tag { Id = Rnd.Next(0, 100000000), Name = GenerateString(10, Rnd) } };
            Status = statuses[Rnd.Next(statuses.Length)];
        }

        public Pet(string status)
        {
            Id = Rnd.Next(0, 100000000);
            Category = new Categories { Id = Rnd.Next(0, 100000000), Name = GenerateString(10, Rnd) };
            Name = GenerateString(10, Rnd);
            PhotoUrls = new List<string>() { GenerateString(10, Rnd) };
            Tags = new List<Tag> { new Tag { Id = Rnd.Next(0, 100000000), Name = GenerateString(10, Rnd) } };
            Status = status;
        }

        static public void UpdatePet()
        {
            Pet.Name = GenerateString(10, Rnd);
        }
    }
}
