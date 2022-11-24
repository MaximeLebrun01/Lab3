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




            if (valide == 0)
            {
                GestionBD.getInstance().ajoutEmploye(Convert.ToInt32(matricule.Text),Convert.ToString(nom.Text),Convert.ToString(prenom.Text));
                this.Frame.Navigate(typeof(Ajout_employe));
            }


        }
    }
}
