using Components.Interfaces;
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
    public class AfspraakView: INotifyPropertyChanged, IDataGridRij
    {
        public int Id { get; set; }

        [Hoofding("Start Tijd")]
        public DateTime StartTijd { get;private set; }

        [Hoofding("Eind Tijd")]
        public DateTime? EindTijd { get; private set; }

        [Hoofding("Bedrijf")]
        public string Bedrijf { get; set; }

        [Hoofding("Bezoekers Naam")]
        public string BezoekerNaam
        {
            get { return $"{Afspraak.Bezoeker.Voornaam} {Afspraak.Bezoeker.Achternaam}"; }
            set { }
        }

        [Hoofding("Werknemer Naam")]
        public string WerknemerNaam
        {
            get { return $"{Afspraak.Werknemer.Voornaam} {Afspraak.Werknemer.Achternaam}"; }
            set { }
        }

        public Afspraak Afspraak { get; set; }
        

        public AfspraakView(Afspraak afspraak)
        {
            GeefDataGridIndex = afspraak.Id;
            Afspraak = afspraak;
            Bedrijf = afspraak.Werknemer.Bedrijf.ToString();
            StartTijd = Afspraak.StartTijd;
            EindTijd = Afspraak.EindTijd;
            Content = afspraak.ToString();
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


        public int GeefDataGridIndex { get; set; }
        public string Content { get; set; }

    }
}
