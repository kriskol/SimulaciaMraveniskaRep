using SimulaciaMraveniskaObjektyNaMravenisku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//sprava udalosti a suvisiace objekty a enum typy
namespace SimulaciaMraveniskaUdalostiSpravaUdalosti
{
    //objekt reprezentujuci udalost, obshajuci zakladne informacie o udalosti a jej akteroch
    public class Udalost
    {
        private int casNastania;
        private int priorita;
        private TypyUdalosti typUdalost;
        private Mravec mravec;

        private void NastavCasNastania(int cas)
        {
            casNastania = cas;
        }
        private void NastavPriorita(int priorita)
        {
            this.priorita = priorita;
        }
        private void NastavTypUdalost(TypyUdalosti udalost)
        {
            typUdalost = udalost;
        }
        private void NastavObjektMravec(Mravec objektMravec)
        {
            mravec = objektMravec;
        }


        public int ZistiCasNastania()
        {
            return casNastania;
        }
        public int ZistiPriorita()
        {
            return priorita;
        }
        public TypyUdalosti ZistiUdalost()
        {
            return typUdalost;
        }
        public Mravec ZistiObjektMravec()
        {
            return mravec;
        }
        public CinnostiMravcov ZistiCinnostMravca()
        {
            if (typUdalost == TypyUdalosti.vykonanieCinnostiMravcovPohybovych ||
                typUdalost == TypyUdalosti.vykonanieCinnostiMravcovNepohybovych)
            {
                if (mravec != default(Mravec))
                {
                    return mravec.ZistiCinnostMravca();
                }
                else
                    return default(CinnostiMravcov);
            }
            else
                return default(CinnostiMravcov);
        }


        public Udalost(int casNastania, int priorita,
            TypyUdalosti typyUdalosti, Mravec objektMravec = default(Mravec))
        {
            NastavCasNastania(casNastania);
            NastavPriorita(priorita);
            NastavTypUdalost(typyUdalosti);
            NastavObjektMravec(objektMravec);

        }
    }
}
