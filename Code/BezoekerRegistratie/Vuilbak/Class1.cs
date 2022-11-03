using AutoMapper;
using Controller.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vuilbak
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Persoon, ViewPersoon>());
            var mapper = new Mapper(config);
            
            IPersoon persoon = new Persoon();
            persoon.Naam = "Tuur";

            ViewPersoon viewPersson = mapper.Map<ViewPersoon>(persoon);
            Console.WriteLine(viewPersson);
            

        }


        public static void Test<T>()
        {
            Console.WriteLine(typeof(T));
        }

        
    }
}
