using Google.Protobuf.WellKnownTypes;
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
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Lab3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ajout_employe : Page
    {
        public Ajout_employe()
        {
            this.InitializeComponent();
        }

        private void ajoutEmploye_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;
            valide += GestionBD.getInstance().verificationText(matricule, erreurMatricule);
            valide += GestionBD.getInstance().verificationText(nom, erreurNom);
            valide += GestionBD.getInstance().verificationText(prenom, erreurPrenom);

            if (Regex.IsMatch(nom.Text, @"\d"))
            {
                valide++;
                erreurNom.Text = "Chiffres interdit dans ce champ";
                erreurNom.Visibility = Visibility.Visible;
            }
            
            if (Regex.IsMatch(prenom.Text, @"\d"))
            {
                valide++;
                erreurPrenom.Text = "Chiffres interdit dans ce champ";
                erreurPrenom.Visibility = Visibility.Visible;
            }

                if (valide == 0)
            {
                GestionBD.getInstance().ajoutEmploye(matricule.Text,nom.Text,prenom.Text);
                this.Frame.Navigate(typeof(Ajout_employe));
            }


        }
    }
}
