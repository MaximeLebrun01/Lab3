
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

            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq16;Uid=2168091;Pwd=2168091;");
            employes = new ObservableCollection<Employe>();
            liste = new ObservableCollection<projet>();
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }




    }
}
