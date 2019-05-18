using Business_layer;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var sport = new Sport_insert();
            Console.WriteLine("Enter full path to file: ");
            sport.path  = Console.ReadLine();
            string sport_insert_msg = sport.insert_sports();
            Console.WriteLine(sport_insert_msg);

            var fill_database = new Fill_database();
            Console.WriteLine("Enter full path to the folder: ");
            fill_database.path = Console.ReadLine();
            string fill_database_msg = fill_database.fill_database();
            Console.WriteLine(fill_database_msg);

        }      
    }
}
