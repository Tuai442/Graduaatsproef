using Components.Interfaces;
using Components.ViewModels.overige;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class BedrijfView : ILijstItems, INotifyPropertyChanged
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
                _naam = value;
                Bedrijf.Naam = value;
                OnPropertyChanged(Naam);
            }
        }
        [Hoofding("BTW-Nummer")]
        public string Btw
        {
            get => _btw;
            set
            {
                _btw = value;
                Bedrijf.Btw = value;
                OnPropertyChanged(_btw);
            }

        }
        [Hoofding("Adres")]
        public string Adres
        {
            get => _adres;
            set
            {
                _adres = value;
                Bedrijf.Adres = value;
                OnPropertyChanged(value);
            }
        }
        [Hoofding("Telefoon Nummer")]
        public string Telefoon
        {
            get => _telefoon;
            set
            {
                _telefoon = value;
                Bedrijf.Telefoon = value;
                OnPropertyChanged(value);
            }
        }
        [Hoofding("Email")]
        public string Email {
            get => _email;
            set 
            {
                _email = value;
                Bedrijf.Email = value;
                OnPropertyChanged(value);
            }
        }


        // Lijst items
        public string Id { get => Email; }
        public string ItemNaam { get => Naam; }


        public BedrijfView(Bedrijf bedrijf)
        {
            Bedrijf = bedrijf;
            Naam = bedrijf.Naam;
            Btw = bedrijf.Btw;
            Adres = bedrijf.Adres;
            Telefoon = bedrijf.Telefoon;
            Email = bedrijf.Email;

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
