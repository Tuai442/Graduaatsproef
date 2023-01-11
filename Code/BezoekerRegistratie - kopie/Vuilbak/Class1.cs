
using System.Reflection;
using Vuilbak;

ViewPersoon viewPersoon = new ViewPersoon();
viewPersoon.Naam = "Tuur";



public class Test
{
    public static Dictionary<string, string> GetNaam()
    {
        Dictionary<string, string> _dict = new Dictionary<string, string>();

        PropertyInfo[] props = typeof(ViewPersoon).GetProperties();
        foreach (PropertyInfo prop in props)
        {
            object[] attrs = prop.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                ColumnNaamAttribute authAttr = attr as ColumnNaamAttribute;
                if (authAttr != null)
                {
                    string propName = prop.Name;
                    string auth = authAttr.ColumnNaam;

                    _dict.Add(propName, auth);
                }
            }
        }

        return _dict;
    }
}

