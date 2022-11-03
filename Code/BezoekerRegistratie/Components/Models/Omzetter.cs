using AutoMapper;
using Components.ViewModels;
using Controller;
using Controller.Interfaces.Models;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Models
{
    public class Omzetter
    {
        private static MapperConfiguration _configAfspraakViewModel;
        private static Mapper _mapperAfspraakViewModel;

        private static MapperConfiguration _configWerknemerViewModel;
        private static Mapper _mapperWerknemerViewModel;

        private static MapperConfiguration _configBezoekerViewModel;
        private static Mapper _mapperBezoekerViewModel;

        private static MapperConfiguration _configBedrijfViewModel;
        private static Mapper _mapperBedrijfViewModel;

        static Omzetter()
        {
            _configAfspraakViewModel = new MapperConfiguration(cfg => cfg.CreateMap<Afspraak, AfspraakViewModel>());
            _mapperAfspraakViewModel = new Mapper(_configAfspraakViewModel);

            _configWerknemerViewModel = new MapperConfiguration(cfg => cfg.CreateMap<Werknemer, WerknemerViewModel>());
            _mapperWerknemerViewModel = new Mapper(_configWerknemerViewModel);

            _configBezoekerViewModel = new MapperConfiguration(cfg => cfg.CreateMap<Bezoeker, BezoekerViewModel>());
            _mapperBezoekerViewModel = new Mapper(_configBezoekerViewModel);

            _configBedrijfViewModel = new MapperConfiguration(cfg => cfg.CreateMap<Bedrijf, BedrijfViewModel>());
            _mapperBedrijfViewModel = new Mapper(_configBedrijfViewModel);
        }

        public static List<AfspraakViewModel> ZetAfsprakenOmInViewModellen(IReadOnlyList<Afspraak> afspraken)
        {
            List<AfspraakViewModel> resultaat = new List<AfspraakViewModel>();
            foreach (Afspraak afspraak in afspraken)
            {
                resultaat.Add(_mapperAfspraakViewModel.Map<AfspraakViewModel>(afspraak));
            }
            //afspraken.ForEach(x => _mapperAfspraakViewModel.Map<AfspraakViewModel>(x));
            return resultaat;
        }

        public static List<BedrijfViewModel> ZetBedrijvenOmInViewModellen(IReadOnlyList<Bedrijf> bedrijven)
        {
            List<BedrijfViewModel> resultaat = new List<BedrijfViewModel>();
            foreach (Bedrijf bedrijf in bedrijven)
            {
                resultaat.Add(_mapperBedrijfViewModel.Map<BedrijfViewModel>(bedrijf));
            }
            return resultaat;
        }

        public static List<BezoekerViewModel> ZetBezoekersOmInViewModellen(IReadOnlyList<Bezoeker> bezoekers)
        {
            List<BezoekerViewModel> resultaat = new List<BezoekerViewModel>();
            foreach (Bezoeker bezoeker in bezoekers)
            {
                resultaat.Add(_mapperBezoekerViewModel.Map<BezoekerViewModel>(bezoeker));
            }
            return resultaat;
        }

        public static List<WerknemerViewModel> ZetWerknemersOmInViewModellen(IReadOnlyList<Werknemer> werknemers)
        {
            List<WerknemerViewModel> resultaat = new List<WerknemerViewModel>();
            foreach (Werknemer werknemer in werknemers)
            {
                resultaat.Add(_mapperWerknemerViewModel.Map<WerknemerViewModel>(werknemer));
            }
            return resultaat;
        }
    }
}
