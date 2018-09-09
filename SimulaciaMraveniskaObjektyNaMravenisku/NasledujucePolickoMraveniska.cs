using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulaciaMraveniskaObjektyNaMravenisku;

//objekt mravenisko, objekty a enum typy suvisiace s mraveniskom
namespace SimulaciaMraveniskaMravenisko
{
    //na zaklade udajov zistuje suradnice nasledujuceho policka v danom smere 
    public static class NasledujucePolickoMraveniska
    {
        //zistuje suradnice nasledujuceho policka v smere s
        public static Suradnice SmerS(Suradnice suradnice, int rozmer)
        {
            int xSuradnica;
            int ySuradnica;

            xSuradnica = suradnice.ZistiXSuradnicu();
            ySuradnica = (suradnice.ZistiYSuradnicu() + rozmer - 1) % rozmer;

            Suradnice noveSuradnica = new Suradnice(xSuradnica, ySuradnica);

            return noveSuradnica;
        }

        //zistuje suradnice nasledujuceho policka v smere j
        public static Suradnice SmerJ(Suradnice suradnice, int rozmer)
        {
            int xSuradnica;
            int ySuradnica;

            xSuradnica = suradnice.ZistiXSuradnicu();
            ySuradnica = (suradnice.ZistiYSuradnicu() + 1 + rozmer) % rozmer;

            Suradnice noveSuradnice = new Suradnice(xSuradnica, ySuradnica);

            return noveSuradnice;
        }

        //zistuje suradnice nasledujuceho policka v smere z
        public static Suradnice SmerZ(Suradnice suradnice, int rozmer)
        {
            int xSuradnica;
            int ySuradnica;

            xSuradnica = (suradnice.ZistiXSuradnicu() - 1 + rozmer) % rozmer;
            ySuradnica = suradnice.ZistiYSuradnicu();

            Suradnice noveSuradnice = new Suradnice(xSuradnica, ySuradnica);

            return noveSuradnice;
        }

        //zistuje suradnice nasledujuceho policka v smere v
        public static Suradnice SmerV(Suradnice suradnice, int rozmer)
        {
            int xSuradnica;
            int ySuradnica;

            xSuradnica = (suradnice.ZistiXSuradnicu() + 1 + rozmer) % rozmer;
            ySuradnica = suradnice.ZistiYSuradnicu();

            Suradnice noveSuradnice = new Suradnice(xSuradnica, ySuradnica);

            return noveSuradnice;
        }

        //zistuje suradnice nasledujuceho policka podla daneho smeru
        public static Suradnice ZistiSuradniceNasledujucehoPolicka(Suradnice suradnice, SmerPohybu smer, int rozmer)
        {
            Suradnice suradniceNove = default(Suradnice);

            switch (smer)
            {
                case SmerPohybu.s: suradniceNove = SmerS(suradnice, rozmer); break;
                case SmerPohybu.v: suradniceNove = SmerV(suradnice, rozmer); break;
                case SmerPohybu.j: suradniceNove = SmerJ(suradnice, rozmer); break;
                case SmerPohybu.z: suradniceNove = SmerZ(suradnice, rozmer); break;
            }

            return suradniceNove;
        }

    }
}
