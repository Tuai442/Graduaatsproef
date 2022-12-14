using Components.Interfaces;
using Components.ViewModels.overige;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class BezoekerView : INotifyPropertyChanged
    {
        private Bezoeker _bezoeker;
        private string _voornaam;
        private string _achternaam;
        private string _email;
        private bool _aanwezig;
        private string _bedrijf;

        public event PropertyChangedEventHandler? PropertyChanged;

        [Hoofding("Voornaam")]
        public string Voornaam
        {
            get { return _voornaam; }
            set
            {
                _voornaam = value;
                _bezoeker.Voornaam = value;
                OnPropertyChanged();
            }
        }

        [Hoofding("Achternaam")]
        public string Achternaam
        {
            get => _achternaam;
            set
            {
                _achternaam = value;
                _bezoeker.Achternaam = value;
                OnPropertyChanged();
            }
        }

        [Hoofding("Email")]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                _bezoeker.Email = value;

                OnPropertyChanged(value);
                
                //OnClassChanged(bezoekerCpy);
            }
        }

        [Hoofding("Is Aanwezig")]
        public bool Aanwezig
        {
            get => _aanwezig;
            set
            {
                _aanwezig = value;
                _bezoeker.Aanwezig = value;
                OnPropertyChanged();
            }
        }

        [Hoofding("Bedrijf")]
        public string Bedrijf
        {
            get => _bedrijf;
            set
            {
                _bedrijf = value;
                _bezoeker.Bedrijf = value;
                OnPropertyChanged();
            }
        }

        public Bezoeker Bezoeker { get => _bezoeker; set => _bezoeker = value; }
        public BezoekerView(Bezoeker bezoeker)
        {
            _bezoeker = bezoeker;
            _voornaam = bezoeker.Voornaam;
            _achternaam = bezoeker.Achternaam;
            _email = bezoeker.Email;
            _aanwezig = bezoeker.Aanwezig;
            _bedrijf = bezoeker.Bedrijf;
            // contactpersoon en zijn bedrijf 
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
