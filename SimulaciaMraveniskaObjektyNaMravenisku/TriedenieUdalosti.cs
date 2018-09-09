using DatoveStruktury;
using SimulaciaMraveniskaMravenisko;
using SimulaciaMraveniskaObjektyNaMravenisku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//sprava udalosti a suvisiace objekty a enum typy
namespace SimulaciaMraveniskaUdalostiSpravaUdalosti
{
    //funkcia RoztriedUdalost zisti o aku presne udalost, ktoru dostala na vstupe, ide a posle ju dalej
    //na spracovanie do triedy SpravaUdalosti
    public static class TriedenieUdalosti
    {
        public static bool RoztriedUdalost(Udalost udalost, Mravenisko mravenisko, Halda<Udalost> halda, ref int cas)
        {
            switch (udalost.ZistiUdalost())
            {
                case TypyUdalosti.zvysenieCasu:
                    {
                        cas++; SpravaUdalosti.ZvysenieCasuMraveniska(mravenisko, halda, cas);
                    }
                    break;
                case TypyUdalosti.navysenieVekuMravcov: { SpravaUdalosti.NavysenieVekuMravcov(mravenisko, halda, cas); } break;
                case TypyUdalosti.vykonanieCinnostiMravcovPohybovych:
                    {
                        SpravaUdalosti.VykonanieCinnostiMravcovPohyb(
                        udalost, mravenisko, halda, cas);
                    }
                    break;
                case TypyUdalosti.bojMravcovPrechadzajucich:
                    {
                        SpravaUdalosti.BojMravcovPrechadzajucich(mravenisko, halda,
                         cas);
                    }
                    break;
                case TypyUdalosti.bojMravcovNaPolickach:
                    {
                        SpravaUdalosti.BojMravcovNaPolickach(mravenisko, halda, cas);
                    }
                    break;
                case TypyUdalosti.paritSa: { SpravaUdalosti.ParitSa(mravenisko, cas); } break;
                case TypyUdalosti.vykonanieCinnostiMravcovNepohybovych:
                    {
                        SpravaUdalosti.VykonanieCinnnostiMravcovNepohyb(
                      udalost, mravenisko, halda, cas);
                    }
                    break;
                case TypyUdalosti.upravyNepohybujucichPolicok:
                    {
                        SpravaUdalosti.UpravaNepohybujucichSaPolicok(
                       mravenisko, halda, cas);
                    }
                    break;
                case TypyUdalosti.znizenieEnergiaNaKonci:
                    {
                        SpravaUdalosti.ZnizenieEnergiaNaKonci(
                        mravenisko, halda, cas);
                    }
                    break;
                case TypyUdalosti.vypisStatistickychUdajov:
                    {
                        SpravaUdalosti.VypisStatistickychUdajov(mravenisko, halda, cas);
                    }
                    break;
                case TypyUdalosti.nastavenieNasledujucichCinnostiMravcov:
                    {
                        SpravaUdalosti.NastavenieNovychCinnostiMravcov(mravenisko, halda, cas);
                    }
                    break;
                case TypyUdalosti.precistenieHodnot:
                    {
                        SpravaUdalosti.PrecistenieNastavenychHodnot(mravenisko, halda, cas);
                    }
                    break;
                case TypyUdalosti.grafickyVypisMraveniska:
                    {
                        SpravaUdalosti.GrafickyVypisMraveniska(mravenisko, halda, cas);
                        return true;
                    }
                case TypyUdalosti.otazkaNaKoniec:
                    {
                        NastaveneHodnotyPocasKrokov.NastavPokracovanie(SpravaUdalosti.OtazkaNaUkoncenieMraveniska(mravenisko, halda, cas));
                    }
                    break;
                case TypyUdalosti.grafickyVypisMraveniskaBojPrechadzajuci:
                    {
                        SpravaUdalosti.GrafickyVypisMraveniskaBojPrechadzanie(mravenisko, halda, cas);

                        return true;
                    }
                case TypyUdalosti.grafickyVypisMraveniskaBojNaPolicku:
                    {
                        SpravaUdalosti.GrafickyVypisMraveniskaBojPolicku(mravenisko, halda, cas);
                        return true;
                    }
                case TypyUdalosti.grafickyVypisMraveniskaParenie:
                    {
                        SpravaUdalosti.GrafickyVypisMraveniskaPoPareni(mravenisko, halda, cas);

                        return true;
                    }

            }

            return false;
        }
    }
}
