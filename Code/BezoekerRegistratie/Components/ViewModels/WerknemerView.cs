using Accessibility;
using Components.Interfaces;
using Components.ViewModels.overige;
using Controller.Interfaces;
using Controller.Managers;
using Controller.Models;
using Persistence.Datalaag;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows;

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
        private BedrijfManager _bedrijfManager;



    public event PropertyChangedEventHandler? PropertyChanged;

        [Hoofding("Voornaam")]
        public string Voornaam
        {
            get => _voornaam;
            set
            {
                try
                {
                    Werknemer.Voornaam = value;
                    _voornaam = value;
                    OnPropertyChanged(value);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kan update niet uivoeren",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        [Hoofding("Achternaam")]
        public string Achternaam
        {
            get => _achternaam;
            set
            {
                try
                {
                    _achternaam = value;
                    Werknemer.Achternaam = value;
                    OnPropertyChanged(value);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kan update niet uivoeren",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        [Hoofding("Email")]
        public string Email
        {
            get => _email;
            set
            {
                // TODO: noah kun jij alle properties zo maken?
                try
                {
                    Werknemer.Email = value;
                    _email = value;
                    OnPropertyChanged(value);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kan update niet uivoeren",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                
            }
        }

        [Hoofding("Functie")]
        public string Functie
        {
            get => _functie;
            set
            {
                try
                {
                    _functie = value;
                    Werknemer.Functie = value;
                    OnPropertyChanged(value);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kan update niet uivoeren",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        [Hoofding("Bedrijf")]
        [CellType(CellType.ComboBox)]
        public string Bedrijf
        {
            get => _bedrijf;
            set
            {
                Werknemer.Bedrijf = _bedrijfManager.GeefBedrijfViaNaam(value);
                _bedrijf = value;
                OnPropertyChanged();
            }
        }


        //[Hoofding("Bedrijf-TEST")]
        //[CellType(CellType.ComboBox)]
        //public List<Bedrijf> Test
        //{
        //    get => test;
        //    set
        //    {

        //    }
        //}

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
            _bedrijfManager = new BedrijfManager(new BedrijfRepository());
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
