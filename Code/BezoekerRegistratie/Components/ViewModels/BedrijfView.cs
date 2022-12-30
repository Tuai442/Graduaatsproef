using Components.Interfaces;
using Components.ViewModels.overige;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Components.ViewModels
{
    public class BedrijfView : ILijstItems, INotifyPropertyChanged, IDataGridRij
    {
        public Bedrijf Bedrijf;
        private string _naam;
        private string _btw;
        private string _adres;
        private string _telefoon;
        private string _email;

        public event PropertyChangedEventHandler? PropertyChanged;

        [Hoofding("Naam")]
        
        public string Naam
        {
            get => _naam;
            set
            {
                try
                {
                    Bedrijf.Naam = value;
                    _naam = value;
                    OnPropertyChanged(Naam);
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Niet gelukt om naam te veranderen. {ex.Message}");
                }

            }
            
        }
        [Hoofding("BTW-Nummer")]
        public string Btw
        {
            get => _btw;
            set
            {
                try
                {
                    Bedrijf.Btw = value;
                    _btw = value;
                    OnPropertyChanged(_btw);
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Niet gelukt om BTW-nummer te veranderen. {ex.Message}");

                }
            }

        }
        [Hoofding("Adres")]
        public string Adres
        {
            get => _adres;
            set
            {
                try
                {
                    Bedrijf.Adres = value;
                    _adres = value;
                    OnPropertyChanged(value);
                }
                catch (Exception ex )
                {

                    MessageBox.Show($"Niet gelukt om adres te veranderen. {ex.Message}");

                }
            }
        }
        [Hoofding("Telefoon Nummer")]
        public string Telefoon
        {
            get => _telefoon;
            set
            {
                try
                {
                    Bedrijf.Telefoon = value;
                    _telefoon = value;
                    OnPropertyChanged(value);
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Niet gelukt om telefoon nummer te veranderen. {ex.Message}");

                }
            }
        }
        [Hoofding("Email")]
        public string Email {
            get => _email;
            set 
            {
                try
                {
                    Bedrijf.Email = value;
                    _email = value;
                    OnPropertyChanged(value);
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Niet gelukt om email te veranderen. {ex.Message}");
                }

            }
        }


        // Lijst items
        public string Id { get => Email; }
        public string ItemNaam { get => Naam; }

        // Datagrid rij
        public int GeefDataGridIndex { get ; set ; }
        public string Content { get; set; }

        public BedrijfView(Bedrijf bedrijf)
        {
            GeefDataGridIndex = bedrijf.Id;
            Bedrijf = bedrijf;
            Naam = bedrijf.Naam;
            Btw = bedrijf.Btw;
            Adres = bedrijf.Adres;
            Telefoon = bedrijf.Telefoon;
            Email = bedrijf.Email;
            Content = bedrijf.ToString();

        }

        private void OnPropertyChanged(string name = null)
        {
            // We willen dat er bij de afspraken in het verleden nog altijd oude data terug gevonden wordt.
            // Daarom nieuwe bezoeker een NIET de oude update.
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
