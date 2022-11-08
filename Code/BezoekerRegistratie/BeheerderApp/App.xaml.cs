using Controller.Interfaces;
using Controller;
using Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Controllers;
using Persistence.Datalaag;

namespace BeheerderApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        IBedrijfRepository bedrijfRepository = new BedrijfRepository();
        IWerknemerRepository werknemerRepository = new WerknemerRepository();
        IBezoekerRepository bezoekerRepository;
        IAfspraakRepository afspraakRepository;

        DomeinController _domeinController;
        MainWindow mainWindow;

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            bezoekerRepository = new BezoekerRepository();
            afspraakRepository = new AfspraakRepository();
            _domeinController = new DomeinController(werknemerRepository, bezoekerRepository,
            bedrijfRepository, afspraakRepository);

            mainWindow = new MainWindow(_domeinController);
            mainWindow.Show();

        }
    }
}
