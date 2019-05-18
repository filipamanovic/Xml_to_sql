using DataAccess;
using DataAccess.TableClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Business_layer
{
    public class Fill_database : XmlClass
    {
        public Help_class help_Class = new Help_class();
        public string fill_database()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] rgFiles = di.GetFiles("event-*.xml");
                foreach (FileInfo fi in rgFiles)
                {
                    doc.Load(fi.FullName);
                    XmlNodeList sport_list = doc.GetElementsByTagName("sport");
                    XmlNodeList category_list = doc.GetElementsByTagName("category");
                    XmlNodeList tournament_list = doc.GetElementsByTagName("tournament");
                    XmlNodeList competitor_list = doc.GetElementsByTagName("competitor");
                    XmlNodeList event_list = doc.GetElementsByTagName("fixture");

                    help_Class.insert_categories(context, sport_list, category_list);
                    help_Class.insert_tournaments(context, category_list, tournament_list);
                    help_Class.insert_competitors(context, competitor_list);
                    help_Class.insert_events(context, competitor_list, tournament_list, event_list);                  
                }
                context.SaveChanges();
                return "Succesfully filled database :)";
            }
            catch (Exception e)
            {
                return "Greska insert competitors: " + e.Message;
            }
        }
    }
}
