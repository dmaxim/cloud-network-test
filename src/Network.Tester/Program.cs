﻿using System;
using System.Linq;
using Network.Tester.Data;

namespace Network.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var entityContext = new EntityContext(Configuration["EntityContext"]);
            var wineryRepository = new WineryRepository(entityContext);

            var wineries = wineryRepository.GetAll().ToList();
            
            Console.WriteLine($"Winery count {wineries.Count}");
        }
    }
}