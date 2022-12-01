using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LAb3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RechercherProjet : Page
    {
        bool valide = true;
        public RechercherProjet()
        {
            this.InitializeComponent();

        }

        private void iRechercherProjet_Click(object sender, RoutedEventArgs e)
        {
            validation();
            if (valide)
            {
                lvProjet.ItemsSource = GestionBD.getInstance().rechercher_Projet(Convert.ToDateTime(RechercheProjet.Date.Value.ToString("dddd dd MMMM yyyy")));
            }
        }

        private void validation()
        {
            reset();

            try
            {
                if (RechercheProjet.Date == null)
                {
                    valide = false;
                    tblErreurRN.Text = "La date du trajet est obligatoire, une date est mise par défaut. Veuillez le changer s'il vous plaît";
                }

                else
                {
                    valide = true;
                }

            }
            catch (InvalidOperationException ex)
            {

                RechercheProjet.Date = new DateTime(2021, 05, 05);
                tblErreurRN.Text = "La date du trajet est obligatoire, une date est mise par défaut. Veuillez le changer s'il vous plaît";

            }
        }

        private void reset()
        {
            tblErreurRN.Text = "";

        }
    }

}
