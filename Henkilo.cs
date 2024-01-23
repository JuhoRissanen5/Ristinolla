using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ristinolla
{
    public class Henkilo         // Henkilo class, jota hyödynnetään useassa formissa 
    {                                  // tämän avulla saan datagridin toimimaan 
        public string Etunimi { get; set; }            // esimerkiksi kun textboksiin syötetään tietoja tehdään se tämän Henkilo classin kautta.
        public string Sukunimi { get; set; }
        public string Syntymavuosi { get; set; }

        public string Voitot { get; set; }  

        public string Tappiot { get; set;  }

        public string Tasapelit { get; set; }   

        public int Pelienkesto { get; set; }


    }
}
