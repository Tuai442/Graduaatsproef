﻿using Components.Paginas;
using Controller;
using Controller.Interfaces.Models;
using Controller.Managers;
using Controller.Models;
using Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BezoekerApp.Paginas
{
    /// <summary>
    /// Interaction logic for AanmeldPagina.xaml
    /// </summary>
    public partial class AanmeldPagina : Page
    {
        DomeinController _domeinController;
        private BezoekerManager _bezoekerManger;

        public EventHandler<Page> NavigeerHandler;
        public AanmeldPagina(DomeinController bezoekerController)
        {
            InitializeComponent();
            _domeinController = bezoekerController;
            _bezoekerManger = _domeinController.GeefBezoekerManager();
            

            logInBtn.ButtonClick += LogIn;
            logUitBtn.ButtonClick += LogUit;

        }
        private void LogIn(object? sender, EventArgs e)
        {
            BedrijfSelecteren bs = new BedrijfSelecteren(_domeinController); // Zouden we dit nie beter op één pagina zetten?
            bs.AanmeldHandler += MeldBezoekerAan;
            NavigeerHandler.Invoke(this, bs);
        }
        private void MeldBezoekerAan(object? sender, Dictionary<string, Dictionary<string, string>> dict)
        {
            string email = emailInvulveld.Text; 
            string voornaam = voornaamInvulveld.Text;
            string achternaam = achternaamInvulveld.Text;
            string bedrijfB = bedrijfInvulveld.Text;
            string contactPersoonEmail = dict["contact-persoon"]["value"];
            string bedrijfCp = dict["contact-persoon"]["naam"];

            try
            {
                _bezoekerManger.MeldBezoekerAan(voornaam, achternaam, 
                    email, bedrijfB, contactPersoonEmail);
                MessageBox.Show("U bent ingelogd.");
                LeegAlleVelden();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                NavigeerHandler.Invoke(this, this);
            }
            
        }

        private void LogUit(object? sender, EventArgs e)
        {
            string email = emailInvulveld.Text;

            try
            {
                _bezoekerManger.MeldBezoekerUit(email);
                MessageBox.Show("Prettige dag nog");
                LeegAlleVelden();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void LeegAlleVelden()
        {
            emailInvulveld.Text = ""; 
            voornaamInvulveld.Text = "";
            achternaamInvulveld.Text = "";
            bedrijfInvulveld.Text = "";
        }

        private void Instellingen_Click(object sender, RoutedEventArgs e)
        {
            InstellingPagina instellingPagina = new InstellingPagina();
            instellingPagina.NavigeerHandler += NavigeerHandler;
            NavigeerHandler.Invoke(this, instellingPagina);
        }

        private void emailInvulveld_LostFocus(object sender, RoutedEventArgs e)
        {
            string email = emailInvulveld.Text;
            Bezoeker bezoeker = _bezoekerManger.ZoekBezoekerOpEmail(email);
            if(bezoeker != null)
            {
                achternaamInvulveld.Text = bezoeker.Achternaam;
                voornaamInvulveld.Text = bezoeker.Voornaam;
                bedrijfInvulveld.Text = bezoeker.Bedrijf;
            }
            
        }
    }
}
