

using Components.ViewModels;
using Controller;
using Controller.Interfaces.Models;
using Controller.Managers;
using Controller.Models;
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

        public AanwezigheidPagina(DomeinController domeinController)
        {
            _domeinController = domeinController;
            _bezoekerManger = _domeinController.GeefBezoekerManager();
            InitializeComponent();
            terugKnop.ButtonClick += GaPaginaTerug;
            verstuurEmail.ButtonClick += VerstuurEmail;

            IReadOnlyList<Bezoeker> alleAanwezigeBezoekers = _bezoekerManger.GeefAlleAanwezigeBezoekers();
            List<BezoekerView> bezoekerViews = alleAanwezigeBezoekers.Select(x => new BezoekerView(x)).ToList();
            dataGrid.StelDataIn<BezoekerView>(bezoekerViews);
            dataGrid.OpDataFiltering += ZoekBezoekerOp;

            aantalAanwLabel.Content = $"Totaal aanwezige bezoekers : {alleAanwezigeBezoekers.Count}";

            //dataGrid.OpDataVerandering += UpdateObject;
        }
        private void ZoekBezoekerOp(object? sender, string e)
        {
            IReadOnlyList<Bezoeker> alleAanwezigeBezoekers = _bezoekerManger.ZoekOp(e);
            List<BezoekerView> bezoekerViews = alleAanwezigeBezoekers.Select(x => new BezoekerView(x)).ToList();
            dataGrid.StelDataIn<BezoekerView>(bezoekerViews);
        }
        private void UpdateObject(object? sender, object obj) // TODO mag weg?
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
        private void VerstuurEmail(object? sender, EventArgs e)
        {
            try
            {
                _domeinController.SendEmail();
            }
            catch (Exception)
            {
                MessageBox.Show("Niet gelukt om de lijst met aanwezige bezoekers te verzenden.");
            }
        }
    }
}
