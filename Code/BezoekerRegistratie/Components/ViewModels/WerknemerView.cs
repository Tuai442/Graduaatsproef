using Accessibility;
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
    public class WerknemerView : ILijstItems, INotifyPropertyChanged
    {
        public Werknemer Werknemer;
        private string _voornaam;
        private string _achternaam;
        private string _email;
        private string _functie;
        private string _bedrijf;
        private Bedrijf _bedrijfModel;

        public event PropertyChangedEventHandler? PropertyChanged;

        [Hoofding("Voornaam")]
        public string Voornaam
        {
            get => _voornaam;
            set
            {
                _voornaam = value;
                Werknemer.Voornaam = value;
                OnPropertyChanged(value);
            }
        }

        [Hoofding("Achternaam")]
        public string Achternaam
        {
            get => _achternaam;
            set
            {
                _achternaam = value;
                Werknemer.Achternaam = value;
                OnPropertyChanged(value);
            }
        }

        [Hoofding("Email")]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                Werknemer.Email = value;
                OnPropertyChanged(value);
            }
        }

        [Hoofding("Functie")]
        public string Functie
        {
            get => _functie;
            set
            {
                _functie = value;
                Werknemer.Functie = value;
                OnPropertyChanged(value);
            }
        }

        [Hoofding("Bedrijf")]
        [CellType(CellType.ComboBox)]
        public string Bedrijf
        {
            get => _bedrijf;
            set
            {
                _bedrijf = value;
                // Werknemer.Bedrijf = value;
                OnPropertyChanged();
            }
        }

        public List<string> Bedrijven = new List<string>()
        {
            "A", "B", "C", "D", "E", "F",
        };


        // Lijst items
        public string Id { get => Email; }
        public string ItemNaam { get => $"{Voornaam} {Achternaam}"; }

        public WerknemerView(Werknemer werkn)
        {
            Werknemer = werkn;
            _voornaam = werkn.Voornaam;
            _achternaam = werkn.Achternaam;
            _email = werkn.Email;
            _functie = werkn.Functie;
            _bedrijf = werkn.Bedrijf.ToString();
            _bedrijfModel = werkn.Bedrijf;
           
        }

        private void OnPropertyChanged(string name = null)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
