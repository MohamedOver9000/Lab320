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
    public sealed partial class AjoutEmploye : Page
    {
        public AjoutEmploye()
        {
            this.InitializeComponent();
        }

         private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                validation();
                if (valide == true)
                {
                    Employe a = new Employe()
                    {
                        Matricule = matricule.Text,
                        Nom = nom.Text,
                        Prenom = prenom.Text
                    };

                    GestionBD.getInstance().ajouter_employe(a);

                }
            }
            catch (FormatException v)
            {

            }
        }

        private void validation()
        {
            reset();
            if (matricule.Text == "")
            {
                valide = false;
                erreurMatricule.Text = "La matricule est obligatoire";
            }

            if (nom.Text == "")
            {
                valide = false;
                erreurNom.Text = "Le nom est obligatoire";
            }

            if (prenom.Text == "")
            {
                valide = false;
                erreurPrenom.Text = "Le prenom est obligatoire";
            }

            else
            {
                valide = true;
            }

        }

        public void reset()
        {
            erreurMatricule.Text = "";
            erreurNom.Text = "";
            erreurPrenom.Text = "";

        }
    }
}
