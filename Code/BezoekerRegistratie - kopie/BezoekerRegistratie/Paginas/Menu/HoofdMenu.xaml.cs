using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BezoekerRegistratie.Paginas
{
    /// <summary>
    /// Interaction logic for HoofdMenu.xaml
    /// </summary>
    public partial class HoofdMenu : Page
    {
        public EventHandler<Page> NavigeerHandler;

        private BezoekerController _bezoekerController;
        private BeheerController _beheerController;
        public HoofdMenu(BeheerController beheerController, BezoekerController bezoekerController)
        {

            InitializeComponent();

            _beheerController = beheerController;
            _bezoekerController = bezoekerController;

            beheerderBtn.ButtonClick += OpenBeheerderMenu;
            bezoekerBtn.ButtonClick += OpenBezoekerMenu;
        }

        private void OpenBezoekerMenu(object? sender, EventArgs e)
        {
            BezoekerMenu bezoekerMenu = new BezoekerMenu(_bezoekerController);
            bezoekerMenu.NavigeerHandler += NavigeerHandler; 
            NavigeerHandler.Invoke(this, bezoekerMenu);
        }

        private void OpenBeheerderMenu(object? sender, EventArgs e)
        {
            BeheerderMenu beheerderMenu = new BeheerderMenu(_beheerController);
            NavigeerHandler.Invoke(this, beheerderMenu);
        }

       
    }
}
