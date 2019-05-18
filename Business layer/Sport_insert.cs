using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Business_layer
{
    public class Sport_insert : XmlClass
    {
        public string insert_sports()
        {
            try
            { 
                doc.Load(path);
                elemList = doc.GetElementsByTagName("sport");
                foreach (XmlNode elem in elemList)
                {
                    if (context.Sports.Find(elem.Attributes["id"].Value) == null)
                    {
                        context.Sports.Add(new Sport
                        {
                            Id = elem.Attributes["id"].Value,
                            CreatedAt = DateTime.Now,
                            name = elem.Attributes["name"].Value
                        });
                    }
                }
                context.SaveChanges();
                return "Succesfully inserted sports.";
            }
            catch (Exception e)
            {
                return "Greska: " + e.Message;
            }

        }
    }
}
