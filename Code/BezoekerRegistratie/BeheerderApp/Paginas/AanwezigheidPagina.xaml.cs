
using Controller.Interfaces.Models;
using Controller.Managers;
using Controllers;
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
        DomeinController _domeinController;
        private BezoekerManager _bezoekerManger;

        public EventHandler<Page> NavigeerHandler;

        public AanwezigheidPagina(DomeinController beheerController)
        {
            _domeinController = beheerController;
            _bezoekerManger = _domeinController.GeefBezoekerManager();
            InitializeComponent();
            terugKnop.ButtonClick += GaPaginaTerug;

            List<IBezoeker> alleAanwezigeBezoekers = _bezoekerManger.GeefAlleAanwezigeBezoekers();
            List<object> itemSource = alleAanwezigeBezoekers.Select(x => x.GeefItemSource()).ToList();
            aantalAanwLabel.Content = $"Totaal aantalbezoekers: {alleAanwezigeBezoekers.Count}";
            dataGrid.StelDataIn(itemSource);

            dataGrid.OpDataVerandering += UpdateObject;
        }

        private void UpdateObject(object? sender, object obj)
        {
            string type = obj.GetType().Name;
            //if (type == "Bezoeker")
            //{
            //    _bezoekerManger.UpdateBezoeker(obj);
            //}
        }

        private void GaPaginaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
