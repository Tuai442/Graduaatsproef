using Components.ViewModels.overige;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Components.ViewModels
{
    public class CellTypeAttribute : Attribute
    {
        public CellType CellType { get; set; }

        public CellTypeAttribute(CellType cellType)
        {
            CellType = cellType;
        }
    }

    public static class CellManager
    {
        public static Dictionary<string, CellType> GeefCellType<T>()
        {
            Dictionary<string, CellType> _dict = new Dictionary<string, CellType>();

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    CellTypeAttribute ct = attr as CellTypeAttribute;
                    if (ct != null)
                    {
                        string propName = prop.Name;
                        CellType cellType = ct.CellType;

                        _dict.Add(propName, cellType);
                    }
                }
            }

            return _dict;
        }
    }
}