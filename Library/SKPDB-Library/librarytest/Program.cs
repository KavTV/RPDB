﻿using System;
using SKPDB_Library;

namespace librarytest
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("Server = 10.108.48.80; Port=5432; User Id = postgres; Password=Kode123; Database=SKPDB;");
            //manager.EditProject(9,2,"kasp609g","Kan også edit","no","jens",new DateTime(2020,11,5),new DateTime(2020,11,10), new string[] { "kasp609g", "seba6474" });
            //foreach (var item in manager.GetProjectComments(2))
            //{
            //    Console.WriteLine(item.Timestamp);
            //}
            //Console.WriteLine(manager.GetAuthToken("kasp609g"));
            
        }
    }
}