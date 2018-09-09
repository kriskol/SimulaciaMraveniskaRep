using SimulaciaMraveniskaObjektyNaMravenisku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekt mravenisko, objekty a enum typy suvisiace s mraveniskom
namespace SimulaciaMraveniskaMravenisko
{
    //tato trieda reprezentuje policka na ktorych prebiehal suboj pri prechadzani medzi polickami
    public class PolickaPriPrechadzajucomBoji
    {
        Suradnice SuradniceMravcov;

        TypyMravcov typMravcov;

        PolickaPriPrechadzajucomBoji druhePolicko;

        private void NastavSuradniceMravcov(Suradnice suradnice)
        {
            SuradniceMravcov = suradnice;
        }
        private void NastavTypMravcov(TypyMravcov typyMravcov)
        {
            typMravcov = typyMravcov;
        }
        public void NastavDruhePolicko(PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji)
        {
            druhePolicko = polickaPriPrechadzajucomBoji;
        }

        public Suradnice ZistiSuradniceMravcov()
        {
            return SuradniceMravcov;
        }
        public TypyMravcov ZistiTypMravcov()
        {
            return typMravcov;
        }
        public PolickaPriPrechadzajucomBoji ZistiDruhePolicko()
        {
            return druhePolicko;
        }

        public PolickaPriPrechadzajucomBoji(Suradnice suradnice, TypyMravcov typyMravcov, PolickaPriPrechadzajucomBoji druhePolicko = default(PolickaPriPrechadzajucomBoji))
        {
            NastavSuradniceMravcov(suradnice);
            NastavTypMravcov(typyMravcov);
            NastavDruhePolicko(druhePolicko);
        }
    }
}
