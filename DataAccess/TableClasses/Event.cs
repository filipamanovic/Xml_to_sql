using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace DataAccess.TableClasses
{
    public class Event : BaseEntity
    {
        public string TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public DateTime utc_scheduled { get; set; }

        public string id_competitor_host { get; set; }
        public Competitor HostCompetitor { get; set; }

        public string id_competitor_guest { get; set; }
        public Competitor GuestCompetitor { get; set; }

        public string insert_events(string path, Context cnt)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] rgFiles = di.GetFiles("event-*.xml");
                XmlDocument doc = new XmlDocument();
                foreach (FileInfo fi in rgFiles)
                {
                    doc.Load(fi.FullName);
                    XmlNodeList events = doc.GetElementsByTagName("fixture");
                    XmlNodeList tournament = doc.GetElementsByTagName("tournament");
                    if (cnt.Events.Find(events[0].Attributes["id"].Value) == null)
                    {
                        string host = "";
                        string guest = "";
                        XmlNodeList competitors = doc.GetElementsByTagName("competitor");
                        foreach(XmlNode com in competitors)
                        {
                            if(com.Attributes["qualifier"].Value == "home")
                            {
                                host = com.Attributes["id"].Value;
                            } else
                            {
                                guest = com.Attributes["id"].Value;
                            }
                        }
                        cnt.Events.Add(new Event
                        {
                            Id = events[0].Attributes["id"].Value,
                            CreatedAt = DateTime.Now,
                            id_competitor_guest = guest,
                            id_competitor_host = host,
                            TournamentId = tournament[0].Attributes["id"].Value,
                            utc_scheduled = DateTime.Parse(events[0].Attributes["scheduled"].Value)                 
                        });
                    }
                    
                }
                cnt.SaveChanges();
                return "Succesfully inserted Events";
            }
            catch (Exception e)
            {
                return "Greska insert event: " + e.Message;
            }

        }



    }
}
