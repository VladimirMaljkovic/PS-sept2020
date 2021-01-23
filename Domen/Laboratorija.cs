using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Laboratorija
    {
        public int LaboratorijaID { get; set; }
        public string Naziv { get; set; }
        public int DnevniKapacitetTestova { get; set; }
        public string Grad { get; set; }

        public override string ToString()
        {
            return $"{Naziv}, {Grad}";
        }
    }
}
