﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Components.ViewModels
{
    public class HoofdingAttribute : Attribute
    {
        public string Hoofding { get; set; }

        public HoofdingAttribute(string hoofding)
        {
            Hoofding = hoofding;
        }
    }


    public static class HoofdingManager
    {
        public static Dictionary<string, string> GeefHoofding<T>()
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    HoofdingAttribute authAttr = attr as HoofdingAttribute;
                    if (authAttr != null)
                    {
                        string propName = prop.Name;
                        string auth = authAttr.Hoofding;

                        _dict.Add(propName, auth);
                    }
                }
            }

            return _dict;
        }
    }
}