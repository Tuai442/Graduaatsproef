using Components.Interfaces;
using Components.ViewModels.overige;
using Controller;
using Controller.Managers;
using Controller.Models;
using Persistence.Datalaag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Components.ViewModels
{
    public class AfspraakView : INotifyPropertyChanged, IDataGridRij
    {
        public Afspraak Afspraak { get; set; }
        private BedrijfManager _bedrijfManager = new BedrijfManager(new BedrijfRepository());


        public AfspraakView(Afspraak afspraak)
        {
            GeefDataGridIndex = afspraak.Id;
            Afspraak = afspraak;
            Bedrijf = afspraak.Werknemer.Bedrijf.ToString();
            StartTijd = Afspraak.StartTijd;
            EindTijd = Afspraak.EindTijd;
            Content = afspraak.ToString();
        }

        [Hoofding("Start Tijd")]
        public DateTime StartTijd { get; set; }

        [Hoofding("Eind Tijd")]
        public DateTime? EindTijd { get; set; }

        private string _bedrijf;
        [Hoofding("Bedrijf")]
        [CellType(CellType.ComboBox)]
        public string Bedrijf
        {
            get => _bedrijf; 
            set
            {
                try
                {
                    Afspraak.Werknemer.Bedrijf = _bedrijfManager.GeefBedrijfViaNaam(value);
                    _bedrijf = value;
                    OnPropertyChanged();
                }catch(Exception ex)
                {
                    MessageBox.Show("Kan bedrijf niet veranderen: " + ex.Message);
                }
            }
        }

        [Hoofding("Bezoekers Naam")]
        public string BezoekerVoornaam
        {
            get { return $"{Afspraak.Bezoeker.Voornaam} {Afspraak.Bezoeker.Achternaam}"; }
            set 
            {
            }
        }


        [Hoofding("Werknemer Voornaam")]
        public string WerknemerVoornaam
        {
            get { return $"{Afspraak.Werknemer.Voornaam}"; }
            set 
            {
                try
                {
                    Afspraak.Werknemer.Voornaam = value;
                    OnPropertyChanged(value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kan update voornaam niet uivoeren",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        [Hoofding("Werknemer Achternaam")]
        public string WerknemerAchternaam
        {
            get { return $"{Afspraak.Werknemer.Achternaam}"; }
            set 
            {
                try
                {
                    Afspraak.Werknemer.Achternaam = value;
                    OnPropertyChanged(value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kan update achternaam niet uivoeren",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        


        //event handler
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        
        public int GeefDataGridIndex { get; set; }
        public string Content { get; set; }

    }
}
