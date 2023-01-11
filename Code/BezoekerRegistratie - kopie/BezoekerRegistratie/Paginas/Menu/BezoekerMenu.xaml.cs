using BezoekerRegistratie.Paginas.Forms;
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
    /// Interaction logic for BezoekerMenu.xaml
    /// </summary>
    public partial class BezoekerMenu : Page
    {
        BezoekerController _bezoekerController;
        public EventHandler<Page> NavigeerHandler;

        public BezoekerMenu(BezoekerController bezoekerController)
        {
            _bezoekerController = bezoekerController;
            InitializeComponent();

            meldBezoekerAanBtn.ButtonClick += MeldBezoekerAan;
            registreerBezoeker.ButtonClick += RegistreerBezoeker;
            maakAfspraak.ButtonClick += MaakAfspraak;
            terugKnop.ButtonClick += GaPaginaTerug;
        }
        private void GaPaginaTerug(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
        private void RegistreerBezoeker(object? sender, EventArgs e)
        {
            RegistreerBezoekerPagina registreerPagina = new RegistreerBezoekerPagina(_bezoekerController);
            NavigeerHandler.Invoke(this, registreerPagina);
        }

        private void MeldBezoekerAan(object? sender, EventArgs e)
        {
            MeldBezoekerAanPagina meldBezoekerAanPagina = new MeldBezoekerAanPagina(_bezoekerController);
            NavigeerHandler.Invoke(this, meldBezoekerAanPagina);
        }
        private void MaakAfspraak(object? sender, EventArgs e)
        {
            MaakAfspraakPagina meldBezoekerAanPagina = new MaakAfspraakPagina(_bezoekerController);
            NavigeerHandler.Invoke(this, meldBezoekerAanPagina);
        }
    }
}
