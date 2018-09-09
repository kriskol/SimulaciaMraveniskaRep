using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //suradnice vsetkych objektov
    public class Suradnice
    {
        private int xSuradnica, ySuradnica;

        public void NastavXSuradnicu(int xSuradnica)
        {
            this.xSuradnica = xSuradnica;
        }
        public void NastavYSuradnicu(int ySuradnica)
        {
            this.ySuradnica = ySuradnica;
        }
        public int ZistiXSuradnicu()
        {
            return xSuradnica;
        }
        public int ZistiYSuradnicu()
        {
            return ySuradnica;
        }

        public Suradnice(int xSuradnica, int ySuradnica)
        {
            NastavXSuradnicu(xSuradnica);
            NastavYSuradnicu(ySuradnica);
        }
    }
}
