using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace DataAccess.TableClasses
{
    public class Category : BaseEntity
    {
        public string name { get; set; }
        public string SportId { get; set; }
        public Sport Sport { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
    }
}
