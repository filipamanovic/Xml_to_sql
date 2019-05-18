using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace DataAccess.TableClasses
{
    public class Tournament : BaseEntity
    {
        public string name { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
