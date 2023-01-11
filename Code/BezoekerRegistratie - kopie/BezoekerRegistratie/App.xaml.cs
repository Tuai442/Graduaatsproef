using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Controller;
using Controller.Interfaces;
using Persistence;

namespace BezoekerRegistratie
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

        BezoekerController bezoekerController;

        BeheerController beheerController;

        MainWindow mainWindow;
        
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            bezoekerController = new BezoekerController(werknemerRepository, bezoekerRepository,
            bedrijfRepository, afspraakRepository);

            beheerController = new BeheerController(werknemerRepository, bezoekerRepository,
            bedrijfRepository, afspraakRepository);

            mainWindow = new MainWindow(bezoekerController, beheerController);
            mainWindow.Show();
            
        }
    }
}
