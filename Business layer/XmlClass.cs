using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Business_layer
{
    public abstract class XmlClass
    {
        public XmlDocument doc = new XmlDocument();
        public string path { get; set; }
        public Context context = new Context();
        public XmlNodeList elemList { get; set; }
    }
}
