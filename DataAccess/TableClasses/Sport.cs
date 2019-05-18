using DataAccess.TableClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataAccess
{
    public class Sport : BaseEntity
    {
        public string name { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
