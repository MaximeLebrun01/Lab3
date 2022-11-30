
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;

using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        ObservableCollection<projet> liste;
        static GestionBD gestionBD = null;

        public GestionBD()
        {

            con = new MySqlConnection("Server=cours.cegep3r.info;Database=h2022_420214_gr01_2168091-ludovic-vendette;Uid=2168091;Pwd=2168091;");
            employes = new ObservableCollection<Employe>();
            liste = new ObservableCollection<projet>();
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public ObservableCollection<projet> getProjet()
        {
            liste.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_selectAll_projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                //Select

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    liste.Add(new projet()
                    {
                        Num = r.GetString(0),
                        Debut = r.GetString(1),
                        Budget = r.GetInt32(2),
                        Descrip = r.GetString(3),
                        Mat = r.GetString(3)
                    });


                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            

            return liste;
        }

        public ObservableCollection<projet> getProjetDate(string date)
        {
            liste.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_select_date_projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@dat", date);

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    liste.Add(new projet()
                    {
                        Num = r.GetString(0),
                        Debut = r.GetString(1),
                        Budget = r.GetInt32(2),
                        Descrip = r.GetString(3),
                        Mat = r.GetString(3)
                    });


                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }


            return liste;
        }

        public int ajouterProjet(projet p)
        {


            int retour = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand("p_insert_projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@num", p.Num);
                commande.Parameters.AddWithValue("@debut", p.Debut);
                commande.Parameters.AddWithValue("@budget", p.Budget);
                commande.Parameters.AddWithValue("@descrip", p.Descrip);
                commande.Parameters.AddWithValue("@mat", p.Mat);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();
                return retour;
            }
            catch (MySqlException ex)
            {
                con.Close();
                return 0;
            }

        }

        public void ajoutEmploye(string matricule, string nom, string prenom)
        {
            try
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

        public ObservableCollection<Employe> getNom(string nom)
        {
            employes.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_recherche_employe_nom");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@pnom", nom);

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    employes.Add(new Employe()
                    {
                        Matricule = r.GetString(0),
                        Nom = r.GetString(1),
                        Prenom = r.GetString(2),
                    });


                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }


            return employes;
        }

        public ObservableCollection<Employe> getPrenom(string nom)
        {
            employes.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_recherche_employe_prenom");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@pprenom", nom);

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    employes.Add(new Employe()
                    {
                        Matricule = r.GetString(0),
                        Nom = r.GetString(1),
                        Prenom = r.GetString(2),
                    });


                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }


            return employes;
        }
        public int verificationText(TextBox box, TextBlock erreur)
        {
            if (box.Text.Length <= 0)
            {
                erreur.Text = "Ce champ est obligatoire";
                erreur.Visibility = Visibility.Visible;
                return 1;
            }
            else
            {
                erreur.Visibility = Visibility.Collapsed;
                return 0;
            }
        }

        public int verificationBox(ComboBox box, TextBlock erreur)
        {
            if (box.SelectedItem == null)
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
