using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab3
{
    internal class GestionBD
    {

        MySqlConnection con;
        ObservableCollection<Employe> employes;
        static GestionBD gestionBD = null;

        public GestionBD()
        {

            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq16;Uid=2168091;Pwd=2168091;");
            employes = new ObservableCollection<Employe>();
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public void ajoutEmploye(string matricule, string nom, string prenom)
        {

            {
                MySqlCommand commande = new MySqlCommand("p_insert_employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@mat", matricule);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        public int verificationText(TextBox box, TextBlock erreur)
        {
            if (box.Text.Length <= 0)
            {
                erreur.Visibility = Visibility.Visible;
                return 1;
            }
            else
            {
                erreur.Visibility = Visibility.Collapsed;
                return 0;
            }
        }
    }
}
