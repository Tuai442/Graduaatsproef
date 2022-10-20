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
        IAlgemeneRepository algemeneRepository = new TestMapper();

        BeheerController beheerController;
        MainWindow mainWindow;

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            beheerController = new BeheerController(werknemerRepository, bezoekerRepository,
            bedrijfRepository, afspraakRepository, algemeneRepository);

            mainWindow = new MainWindow(beheerController);
            mainWindow.Show();

        }
    }
}
