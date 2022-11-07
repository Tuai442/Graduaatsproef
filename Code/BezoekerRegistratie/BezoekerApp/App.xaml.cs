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
        protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tuur\Desktop\t\Graduaatsproef\Code\BezoekerRegistratie\Datalaag\Database1.mdf;Integrated Security=True";

        IWerknemerRepository werknemerRepository;
        IBezoekerRepository bezoekerRepository;
        IBedrijfRepository bedrijfRepository;
        IAfspraakRepository afspraakRepository;

        DomeinController _domeinController;


        MainWindow mainWindow;

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            werknemerRepository = new WerknemerRepository();
            bezoekerRepository = new BezoekerRepository(connectionString);
            bedrijfRepository = new BedrijfRepository();
            afspraakRepository = new AfspraakRepository(connectionString);

            _domeinController = new DomeinController(werknemerRepository, bezoekerRepository,
            bedrijfRepository, afspraakRepository);

         
            mainWindow = new MainWindow(_domeinController);
            mainWindow.Show();

        }
    }
}
