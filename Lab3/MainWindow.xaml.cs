using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySqlX.XDevAPI;
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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.InitializeComponent();
            mainframe.Navigate(typeof(Afficher_projet));
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;
            tblentete.Text = item.Content.ToString();

            switch (item.Tag.ToString())
            {
                case "employé":
                    mainframe.Navigate(typeof(Ajout_employe));
                    break;
                case "projet":
                    mainframe.Navigate(typeof(Ajout_projet));
                    break;
                case "recherche":
                    mainframe.Navigate(typeof(Recherche_employe));
                    break;
                case "liste":
                    mainframe.Navigate(typeof(Afficher_projet));
                    break;
                default:
                    break;
            }
        }
    }
}
