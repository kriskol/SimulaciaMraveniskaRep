using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //trieda, ktora je predkom vsetkych objektov, ktore sa nepohybuju
    public class NepohybujuceSaObjekty : ObjektyObecne
    {
        private bool jeMozneVstupit;

        public void NastavJeMozneVstupit(bool jeMozneVstupit)
        {
            this.jeMozneVstupit = jeMozneVstupit;
        }

        public bool ZistiJeMozneVstupit()
        {
            return jeMozneVstupit;
        }

        public NepohybujuceSaObjekty(int xSuradnica, int ySuradnica, TypyObjektov typyObjektov,
            string reprezentaciaObjektu, bool viditelnost, bool existencia, bool jeMozneVstupit) :
            base(xSuradnica, ySuradnica,
                typyObjektov, reprezentaciaObjektu, viditelnost, existencia, false)
        {
            NastavJeMozneVstupit(jeMozneVstupit);
        }
    }
}
