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

namespace BeheerderApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        IWerknemerRepository werknemerRepository = new TestMapper();
        IBezoekerRepository bezoekerRepository = new TestMapper();
        IBedrijfRepository bedrijfRepository = new TestMapper();
        IAfspraakRepository afspraakRepository = new TestMapper();

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
