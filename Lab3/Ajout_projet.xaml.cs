using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class Ajout_projet : Page
    {
        public Ajout_projet()
        {
            this.InitializeComponent();
            tbldebut.MinYear = DateTimeOffset.Now;
        }

        private void btnaddprojet_click(object sender, RoutedEventArgs e)
        {
            int valide = 0;
            valide += GestionBD.getInstance().verificationText(tblnum, erreurNum);
            valide += GestionBD.getInstance().verificationDate(tbldebut, erreurDebut);
            valide += GestionBD.getInstance().verificationText(tbldescription, erreurDes);
            valide += GestionBD.getInstance().verificationText(tblmatricule, erreurMat);

            if (GestionBD.getInstance().verificationText(tblbudget, erreurBudget) == 0)
            {
                if (Regex.IsMatch(tblbudget.Text, @"[aA-zZ]"))
                {
                    valide++;
                    erreurBudget.Text = "Lettres interdit dans ce champ";
                    erreurBudget.Visibility = Visibility.Visible;
                }
                else if (Convert.ToInt32(tblbudget.Text) < 10000 || Convert.ToInt32(tblbudget.Text) > 100000)
                {
                    valide++;
                    erreurBudget.Text = "Budget doit être entre 10k et 100k";
                    erreurBudget.Visibility = Visibility.Visible;
                }
            }

            if (valide == 0)
            {
                GestionBD.getInstance().ajouterProjet(
                    new projet()
                    {
                        Num = tblnum.Text,
                        Debut = tbldebut.Date.Date.ToString("yyyy-MM-dd"),
                        Budget = Convert.ToInt32(tblbudget.Text),
                        Descrip = tbldescription.Text,
                        Mat = tblmatricule.Text
                    }
                );
            }
        }
    }
}
