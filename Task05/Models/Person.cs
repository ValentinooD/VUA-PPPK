using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Task05.Models
{
    [DataObject]
    public class Person
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Group { get; set; }
        public string? Notes { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   _id.Equals(person._id) &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   Group == person.Group &&
                   Notes == person.Notes;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id, Name, Surname, Group, Notes);
        }

        public override string ToString()
            => Name + " " + Surname;


    }
}
