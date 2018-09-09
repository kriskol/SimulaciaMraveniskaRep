using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //trieda, ktora je predkom vsetkych objektov, ktore sa pohybuju
    public class PohybujuceSaObjekty : ObjektyObecne
    {
        public PohybujuceSaObjekty(int xSuradnica, int ySuradnica, TypyObjektov typyObjektov, string reprezentaciaObjektu,
            bool viditelnost, bool existencia) : base(xSuradnica, ySuradnica, typyObjektov, reprezentaciaObjektu,
                viditelnost, existencia, true)
        { }

    }
}
