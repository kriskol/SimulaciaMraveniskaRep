using SimulaciaMraveniskaObjektyNaMravenisku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekt mravenisko, objekty a enum typy suvisiace s mraveniskom
namespace SimulaciaMraveniskaMravenisko
{
    //tato trieda reprezentuje policka na ktorych prebiehal suboj pri stati na policku
    public class PolickaPriBojiNaPolicku
    {
        Suradnice suradnice;

        List<TypyMravcov> typyMravcovPole = new List<TypyMravcov>(); //typy mravcov ucastnikov suboja

        private void NastavSuradnice(Suradnice suradnice)
        {
            this.suradnice = suradnice;
        }
        public void VlozTypMravca(TypyMravcov typyMravcov)
        {
            typyMravcovPole.Add(typyMravcov);
        }

        public Suradnice ZistiSuradnice()
        {
            return suradnice;
        }
        public List<TypyMravcov> ZistiTypyMravcovPole()
        {
            return typyMravcovPole;
        }

        public PolickaPriBojiNaPolicku(Suradnice suradnice, List<TypyMravcov> typyMravcovPole = default(List<TypyMravcov>))
        {
            NastavSuradnice(suradnice);
            if (typyMravcovPole != default(List<TypyMravcov>) && typyMravcovPole.Count > 0) this.typyMravcovPole = typyMravcovPole;
        }
    }
}
