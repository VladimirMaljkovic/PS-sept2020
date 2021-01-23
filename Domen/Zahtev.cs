using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Zahtev
    {
        public int ZahtevID { get; set; }
        public DateTime DatumVremeTestiranja { get; set; }
        public bool Hitno { get; set; }
        public string Tip { get; set; }
        public string Rezultat { get; set; }
        public DateTime DatumVremeRezultata { get; set; }
        public string Napomena { get; set; }
        public string Status { get; set; }
        public int OsiguranoLiceID { get; set; }
        public int LaboratorijaID { get; set; }
        public int LaborantID { get; set; }
        public string ImePrezimeOsiguranogLica { get; set; }
        public string NazivLaboratorije { get; set; }
    }
}
