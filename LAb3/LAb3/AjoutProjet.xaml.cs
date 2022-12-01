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
     bool valide = true;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutProjet : Page
    {
        public AjoutProjet()
        {
            this.InitializeComponent();
            employe.ItemsSource = GestionBD.getInstance().getEmployes();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                validation();
                if (valide == true)
                {
                    Employe emp = employe.SelectedItem as Employe;

                    Projet q = new Projet
                    {

                        Numero = numero.Text,
                        Debut = Convert.ToDateTime(arrivalCalendarDatePicker.Date.Value.ToString("dddd dd MMMM yyyy")),
                        Budget = Convert.ToInt32(budget.Text),
                        Description = description.Text,
                        Employe = emp.Matricule
                    };

                    GestionBD.getInstance().ajouter_projet(q);
                }
            }
            catch (FormatException x)
            {

            }

        }

        private void validation()
        {
            reset();

            

            if (numero.Text == "")
            {
                valide = false;
                erreurNumero.Text = "La numéro est obligatoire";
            }

            else if (budget.Text == "")
            {
                valide = false;
                erreurBudget.Text = "Le budget est obligatoire";
            }

            else if (Convert.ToInt64(budget.Text) < 10000)
            {
                valide = false;
                erreurBudget.Text = "Le budget est trop bas";
            }

            else if (Convert.ToInt64(budget.Text) > 100000)
            {
                valide = false;
                erreurBudget.Text = "Le budget est trop haut";
            }

            else if (description.Text == "")
            {
                valide = false;
                erreurDescription.Text = "La description est obligatoire";
            }

            else if (employe.SelectedItem == null)
            {
                valide = false;
                erreurEmploye.Text = "le nom de l'employé est obligatoire";
            }

            else
            {
                valide = true;
            }
            

            try
            {
                if (arrivalCalendarDatePicker.Date == null)
                {
                    erreurDate.Text = "La date du trajet est obligatoire, une date est mise par défaut. Veuillez le changer s'il vous plaît";
                }

            }
            catch (InvalidOperationException ex)
            {

                arrivalCalendarDatePicker.Date = new DateTime(2021, 05, 05);
                erreurDate.Text = "La date du trajet est obligatoire, une date est mise par défaut. Veuillez le changer s'il vous plaît";

            }
        }

        private void reset()
        {
            erreurNumero.Text = "";
            erreurBudget.Text = "";
            erreurDescription.Text = "";
            erreurEmploye.Text = "";
            erreurDate.Text = "";

        }
    }
}
