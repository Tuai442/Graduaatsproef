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
        IWerknemerRepository werknemerRepository = new WerknemerRepository();
        IBezoekerRepository bezoekerRepository = new BezoekerRepository();
        IBedrijfRepository bedrijfRepository = new BedrijfRepository();
        IAfspraakRepository afspraakRepository = new AfspraakRepository();

        DomeinController _domeinController;


        MainWindow mainWindow;

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            _domeinController = new DomeinController(werknemerRepository, bezoekerRepository,
            bedrijfRepository, afspraakRepository);

         
            mainWindow = new MainWindow(_domeinController);
            mainWindow.Show();

        }
    }
}
