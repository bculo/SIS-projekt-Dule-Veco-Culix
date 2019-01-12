using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt.Rsa
{
    public class RSAPar
    {
        public String Privatni { get; set; }
        public String Javni { get; set; }
        
        public RSAPar(String privatni, String javni)
        {
            this.Privatni = privatni;
            this.Javni = javni;
        }
    }
}
