using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Employe
    {
        String matricule;
        String nom;
        String prenom;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Matricule { get => matricule; set => matricule = value; }
    }
}
