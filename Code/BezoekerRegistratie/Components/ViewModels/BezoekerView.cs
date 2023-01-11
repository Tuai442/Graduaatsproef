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
using System.Windows;

namespace Components.ViewModels
{
    public class BezoekerView : INotifyPropertyChanged, IDataGridRij
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
                try
                {
                    _voornaam = value;
                    _bezoeker.Voornaam = value;
                    OnPropertyChanged();
                }
                catch (Exception ex)
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
                    _bezoeker.Achternaam = value;
                    OnPropertyChanged();
                }
                catch (Exception ex)
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
                try
                {
                    _bezoeker.Email = value;
                    _email = value;
                    OnPropertyChanged(value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kan update niet uivoeren",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        //[Hoofding("Is Aanwezig")]
        //public bool Aanwezig
        //{
        //    get => _aanwezig;
        //    set
        //    {
        //        _aanwezig = value;
        //        _bezoeker.Aanwezig = value;
        //        OnPropertyChanged();
        //    }
        //}
        [Hoofding("Bedrijf")]
        public string Bedrijf
        {
            get => _bedrijf;
            set
            {
                try
                {
                    _bedrijf = value;
                    _bezoeker.Bedrijf = value;
                    OnPropertyChanged();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kan update niet uivoeren",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public Bezoeker Bezoeker { get => _bezoeker; set => _bezoeker = value; }
       
        public BezoekerView(Bezoeker bezoeker)
        {
            GeefDataGridIndex = bezoeker.Id;
            _bezoeker = bezoeker;
            _voornaam = bezoeker.Voornaam;
            _achternaam = bezoeker.Achternaam;
            _email = bezoeker.Email;
            _aanwezig = bezoeker.Aanwezig;
            _bedrijf = bezoeker.Bedrijf;
            Content = bezoeker.ToString();
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
        // DataGrid rij
        public int GeefDataGridIndex { get; set; }
        public string Content { get; set; }
    }
}
