using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class projet
    {

        //(num, debut, budget, descrip, mat)
        string num;
        string debut;
        int budget;
        string descrip;
        string mat;

        public string Num { get => num; set => num = value; }
        public string Debut { get => debut; set => debut = value; }
        public int Budget { get => budget; set => budget = value; }
        public string Descrip { get => descrip; set => descrip = value; }
        public string Mat { get => mat; set => mat = value; }
    }
}
