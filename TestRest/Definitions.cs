using System;
using System.Collections.Generic;
using System.Text;

namespace TestRest
{
    public struct Pet
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Tag> Tags { get; set; }
        public string Status { get; set; }
    }

    public struct Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public struct Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public struct Order
    {
        public int id { get; set; }
        public int petId { get; set; }
        public int quantity { get; set; }
        public DateTime shipDate { get; set; }
        public string status { get; set; }
        public bool complete { get; set; }
    }
}
