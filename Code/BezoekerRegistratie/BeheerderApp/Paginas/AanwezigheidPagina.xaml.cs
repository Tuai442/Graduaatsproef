

using Components.ViewModels;
using Controller;
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

            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ZoekBezoekerOp(object? sender, string e)
        {
            try
            {
                IReadOnlyList<Bezoeker> alleAanwezigeBezoekers = _bezoekerManger.ZoekOp(e);
                List<BezoekerView> bezoekerViews = alleAanwezigeBezoekers.Select(x => new BezoekerView(x)).ToList();
                dataGrid.StelDataIn<BezoekerView>(bezoekerViews);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GaPaginaTerug(object? sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
        //TODO: werkt dit?
        private void VerstuurEmail(object? sender, EventArgs e)
        {
            try
            {
                _domeinController.SendEmail();
                MessageBox.Show("Een lijst met de aanwezige bezoekers is verzonden.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Niet gelukt om de lijst met aanwzige bezoekers te verzenden: " + ex.Message);
            }
        }
    }
}
