using Components.ViewModels.overige;
using Controller;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModels
{
    public class AfspraakView: INotifyPropertyChanged
    {

        public int Id { get; set; }

        [Hoofding("Start Tijd")]
        public DateTime StartTijd { get; set; }

        [Hoofding("Eind Tijd")]
        public DateTime? EindTijd { get; set; }

        [Hoofding("Bedrijf")]
        public string Bedrijf { get; set; }

        [Hoofding("Bezoekers Naam")]
        public string BezoekerNaam
        {
            get { return $"{Afspraak.BezoekerVoornaam} {Afspraak.BezoekerAchternaam}"; }
            set { }
        }

        [Hoofding("Werknemer Naam")]
        public string WerknemerNaam
        {
            get { return $"{Afspraak.WerknemerVoornaam} {Afspraak.WerknemerAchternaam}"; }
            set { }
        }

        public Afspraak Afspraak { get; set; }
        public AfspraakView(Afspraak afspraak)
        {
            Afspraak = afspraak;
            Bedrijf = afspraak.Bedrijf.ToString();
            StartTijd = Afspraak.StartTijd;
            EindTijd = Afspraak.EindTijd;
            
           
        }

        public event PropertyChangedEventHandler? PropertyChanged;
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
