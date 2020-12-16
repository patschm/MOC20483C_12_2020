using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ACME.Entities
{
    public class Person
    {
        [XmlAttribute("id")]
        public int ID { get; set; }
        [XmlElement("first-name")]
        public string FirstName { get; set; }
        [XmlElement("last-name")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int Age { get; set; }

        //public ICollection<PersonHobby> Hobbies { get; set; } = new HashSet<PersonHobby>();
    }
}
