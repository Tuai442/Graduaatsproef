using BezoekerRegistratie.UI_Onderdelen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BezoekerRegistratie.Models
{
    static class FormVerwerker
    {
        internal static List<string> VerwerkForm(Grid formGrid)
        {
            // Alle info wordt uit de form gehaald en terug gegeven in een lijst

            List<string> result = new List<string>();
            foreach(var child in formGrid.Children)
            {
                if(child.GetType() is TextBox)
                {
                    TextBox textBox = (TextBox)child;
                    result.Add(textBox.Text);
                }
                else if (child.GetType() is CheckBox)
                {
                    throw new NotImplementedException();
                }
                else if(child.GetType() is ComboBox)
                {
                    ZoekbareComboBox cb = (ZoekbareComboBox)child;
                    result.Add(cb.comboBox.Text);
                }
                else if(child.GetType() is DatePicker)
                {
                    DatePicker dp = (DatePicker)child;
                    result.Add(dp.Text);
                }
            }
            return result;
        }
    }
}
