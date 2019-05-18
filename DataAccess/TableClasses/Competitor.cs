using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace DataAccess.TableClasses
{
    public class Competitor : BaseEntity
    {
        public string name { get; set; }
        public string short_name { get; set; }
        public string country_code { get; set; }
        public ICollection<Event> HostsEvent { get; set; }
        public ICollection<Event> GuestsEvent { get; set; }

        public string insert_competitors(string path, Context cnt)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] rgFiles = di.GetFiles("event-*.xml");
                XmlDocument doc = new XmlDocument();
                foreach (FileInfo fi in rgFiles)
                {
                    doc.Load(fi.FullName);
                    XmlNodeList competitor = doc.GetElementsByTagName("competitor");
                    foreach(XmlNode cm in competitor)
                    {
                        if (cnt.Competitors.Find(cm.Attributes["id"].Value) == null)
                        {
                            cnt.Competitors.Add(new Competitor
                            {
                                Id = cm.Attributes["id"].Value,
                                name = cm.Attributes["name"].Value,
                                short_name = cm.Attributes["abbreviation"].Value,
                                CreatedAt = DateTime.Now
                            });
                        }                        
                    }
                }
                cnt.SaveChanges();
                return "Succesfully inserted Competitors";
            }
            catch (Exception e)
            {
                return "Greska insert competitors: " + e.Message;
            }
        }

    }
}
