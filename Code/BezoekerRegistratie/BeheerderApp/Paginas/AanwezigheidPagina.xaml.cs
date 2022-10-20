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
    /// Interaction logic for AanwezigheidPagina.xaml
    /// </summary>
    public partial class AanwezigheidPagina : Page
    {
        BeheerController _beheerController;
        public EventHandler<Page> NavigeerHandler;

        public AanwezigheidPagina(BeheerController beheerController)
        {
            _beheerController = beheerController;
            InitializeComponent();
            terugKnop.ButtonClick += GaPaginaTerug;

            List<object> alleAanwezigeBezoekers = _beheerController.GeefAlleAanwezigeBezoekersInTabelData();
            aantalAanwLabel.Content = $"Totaal aantalbezoekers: {alleAanwezigeBezoekers.Count}";
            dataGrid.VoegDataToe(alleAanwezigeBezoekers);
            dataGrid.OpDataVerandering += UpdateObject;
        }

        private void UpdateObject(object? sender, object obj)
        {
            string type = obj.GetType().Name;
            if (type == "Bezoeker")
            {
                _beheerController.UpdateBezoeker(obj);
            }
        }

        private void GaPaginaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
