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
}
