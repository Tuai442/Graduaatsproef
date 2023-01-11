using Controller;
using Controller.Interfaces;
using Controllers;
using Persistence;
using Persistence.Datalaag;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BezoekerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        IWerknemerRepository werknemerRepository;
        IBezoekerRepository bezoekerRepository;
        IBedrijfRepository bedrijfRepository;
        IAfspraakRepository afspraakRepository;

        DomeinController _domeinController;

        MainWindow mainWindow;

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            werknemerRepository = new WerknemerRepository();
            bezoekerRepository = new BezoekerRepository();
            bedrijfRepository = new BedrijfRepository();
            afspraakRepository = new AfspraakRepository();

            _domeinController = new DomeinController(werknemerRepository, bezoekerRepository,
            bedrijfRepository, afspraakRepository);

            mainWindow = new MainWindow(_domeinController);
            mainWindow.Show();

        }
    }
}
