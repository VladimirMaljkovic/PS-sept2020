using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Request
    {
        public Operacija Operacija { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

    }
}
