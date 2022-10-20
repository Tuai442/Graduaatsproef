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

namespace BeheerderApp.Paginas
{
    /// <summary>
    /// Interaction logic for StartSchermBeheerder.xaml
    /// </summary>
    public partial class StartSchermBeheerder : Page
    {
        BeheerController _beheerderController;
        public EventHandler<Page> NavigeerHandler;
        public StartSchermBeheerder(BeheerController beheerderController)
        {
            _beheerderController = beheerderController;
            InitializeComponent();
            lijstMetAanwKnop.ButtonClick += ToonLijsMetAanwezigenPagina;
            gegevensBeherenKnop.ButtonClick += ToonBeherdersPagina;
        }

        private void ToonBeherdersPagina(object? sender, EventArgs e)
        {
            BeheerderPagina beheerderPagina = new BeheerderPagina(_beheerderController);
            NavigeerHandler.Invoke(sender, beheerderPagina);
        }

        private void ToonLijsMetAanwezigenPagina(object? sender, EventArgs e)
        {
            AanwezigheidPagina aanwezigheidPagina = new AanwezigheidPagina(_beheerderController);
            NavigeerHandler.Invoke(sender, aanwezigheidPagina);

        }
    }
}
