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



    class MyAttribute : Attribute
    {
        public string Description { get; set; }

    }

    public class SomeClass
    {
        [MyAttribute]
        public string GetValue()
        {
            return "Hello World";
        }
    }

   

    public class Program
    {
        static void Main(string[] args)
        {
            object[] attributes = typeof(SomeClass).
                         GetMethod("GetValue").
                         ReturnTypeCustomAttributes.
                         GetCustomAttributes(false);

            foreach (object attribute in attributes)
            {
                Console.WriteLine(attribute);
            }

        }


       
        
    }
}
