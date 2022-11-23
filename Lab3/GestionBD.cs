using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class GestionBD
    {
        MySqlConnection con;
        //ObservableCollection<maison> liste;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            MySqlConnection con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq16;Uid=2168091;Pwd=2168091;");
            //liste = new ObservableCollection<maison>();
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
    }
}
