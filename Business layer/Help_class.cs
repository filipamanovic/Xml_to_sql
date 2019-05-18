using DataAccess;
using DataAccess.TableClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Business_layer
{
    public class Help_class 
    {
        public void insert_categories(Context context, XmlNodeList sport_list, XmlNodeList category_list)
        {
            if (context.Sports.Find(sport_list[0].Attributes["id"].Value) != null)
            {
                if (context.Categories.Find(category_list[0].Attributes["id"].Value) == null)
                {
                    context.Categories.Add(new Category
                    {
                        Id = category_list[0].Attributes["id"].Value,
                        name = category_list[0].Attributes["name"].Value,
                        SportId = sport_list[0].Attributes["id"].Value,
                        CreatedAt = DateTime.Now
                    });
                }
            }
            else
            {
                context.Sports.Add(new Sport
                {
                    Id = sport_list[0].Attributes["id"].Value,
                    name = sport_list[0].Attributes["name"].Value
                });
                if (context.Categories.Find(category_list[0].Attributes["id"].Value) == null)
                {
                    context.Categories.Add(new Category
                    {
                        Id = category_list[0].Attributes["id"].Value,
                        name = category_list[0].Attributes["name"].Value,
                        SportId = sport_list[0].Attributes["id"].Value,
                        CreatedAt = DateTime.Now
                    });
                }
            }
        }

        public void insert_tournaments(Context context,XmlNodeList category_list, XmlNodeList tournament_list)
        {
            if (context.Tournaments.Find(tournament_list[0].Attributes["id"].Value) == null)
            {
                context.Tournaments.Add(new Tournament
                {
                    Id = tournament_list[0].Attributes["id"].Value,
                    name = tournament_list[0].Attributes["name"].Value,
                    CategoryId = category_list[0].Attributes["id"].Value,
                    CreatedAt = DateTime.Now
                });
            }
        }

        public void insert_competitors(Context context, XmlNodeList competitor_list)
        {
            foreach (XmlNode cm in competitor_list)
            {
                if (context.Competitors.Find(cm.Attributes["id"].Value) == null)
                {
                    context.Competitors.Add(new Competitor
                    {
                        Id = cm.Attributes["id"].Value,
                        name = cm.Attributes["name"].Value,
                        short_name = cm.Attributes["abbreviation"].Value,
                        CreatedAt = DateTime.Now
                    });
                }
            }
        }

        public void insert_events(Context context, XmlNodeList competitor_list, XmlNodeList tournament_list, XmlNodeList event_list)
        {
            if (context.Events.Find(event_list[0].Attributes["id"].Value) == null)
            {
                string host = "";
                string guest = "";
                foreach (XmlNode com in competitor_list)
                {
                    if (com.Attributes["qualifier"].Value == "home")
                    {
                        host = com.Attributes["id"].Value;
                    }
                    else
                    {
                        guest = com.Attributes["id"].Value;
                    }
                }
                context.Events.Add(new Event
                {
                    Id = event_list[0].Attributes["id"].Value,
                    CreatedAt = DateTime.Now,
                    id_competitor_guest = guest,
                    id_competitor_host = host,
                    TournamentId = tournament_list[0].Attributes["id"].Value,
                    utc_scheduled = DateTime.Parse(event_list[0].Attributes["scheduled"].Value)
                });
            }
        }




    }
}
