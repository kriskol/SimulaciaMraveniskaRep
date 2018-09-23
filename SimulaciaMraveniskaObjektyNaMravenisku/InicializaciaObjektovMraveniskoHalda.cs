using DatoveStruktury;
using SimulaciaMraveniskaMravenisko;
using SimulaciaMraveniskaObjektyNaMravenisku;
using SimulaciaMraveniskaUdalostiSpravaUdalosti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//samotna simulacia mraveniska a ziskavanie vstupnych a vystupnych dat
namespace SimulaciaMraveniskaSimulacia
{
    //inicializuje zakladne hodnoty, mravenisko, haldu, prvotne  udalosti, nasledne ich vracia
    static class InicializaciaObjektovMraveniskoHalda
    {
        public static Halda<Udalost> InicializaciaHaldy()
        {
            Halda<Udalost> halda = new Halda<Udalost>();

            NaplnHaldaUdalostami(halda);

            return halda;
        }
        public static Mravenisko InicializaciaMraveniska()
        {
            Mravenisko mravenisko = new Mravenisko(ZadaneHodnoty.ZistiMnozstvoPotravy(), ZadaneHodnoty.ZistiPocetSkal(),
                                                    ZadaneHodnoty.ZistiRozmerMraveniska() * ZadaneHodnoty.ZistiRozmerMraveniska(),
                                                    ZadaneHodnoty.ZistiPocetMravcovTypu1(),
                                                    ZadaneHodnoty.ZistiPocetMravcovTypu2(),
                                                    ZadaneHodnoty.ZistiPocetMravcovTypu3(),
                                                    ZadaneHodnoty.ZistiPocetMravcovTypu4(),
                                                    ZadaneHodnoty.ZistiRozmerMraveniska()
                                                    );
            return mravenisko;
        }

        private static void NastavKonstantneHodnoty()
        {
            Konstanty.NastavMinimumPotravy(ZadaneHodnoty.ZistiMinimalneMnozstvoPotravy());
        }
        private static void NastavNekonstantneHodnoty(Mravenisko mravenisko)
        {
            NastaveneHodnotyPocasKrokov.NastavParenie(false);
            NastaveneHodnotyPocasKrokov.NastavPokracovanie(true);

            SpravaMraveniskaMravcov.InicializaciaMraveniska(mravenisko);
        }

        public static Udalost ZaciatocnaNavysenieCasuMraveniska()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.zvysenieCasu,
                TypyUdalosti.zvysenieCasu);

            return udalost;
        }
        public static Udalost ZaciatocnaNavysenieVekuMravcov()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.navysenieVekuMravcov,
                                        TypyUdalosti.navysenieVekuMravcov);

            return udalost;
        }
        public static Udalost ZaciatocnaBojMravcovPrechadzajucich()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.bojMravcovPrechadzajucich,
                                            TypyUdalosti.bojMravcovPrechadzajucich);

            return udalost;
        }
        public static Udalost ZaciatocnaBojMravcovStojacich()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.bojMravcovNaPolickach,
                                            TypyUdalosti.bojMravcovNaPolickach);

            return udalost;
        }
        public static Udalost ZaciatocnaNepohybujucePolicka()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.upravyNepohybujucichPolicok,
                                TypyUdalosti.upravyNepohybujucichPolicok);

            return udalost;
        }
        public static Udalost ZaciatocnaZnizenieEnergie()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.znizenieEnergiaNaKonci,
                                        TypyUdalosti.znizenieEnergiaNaKonci);

            return udalost;
        }
        public static Udalost ZaciatocnaVypisStatistickych()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.vypisStatistickychUdajov,
                                            TypyUdalosti.vypisStatistickychUdajov);

            return udalost;
        }
        public static Udalost ZaciatocnaPrecistenieHodnot()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.precistenieHodnot,
                                            TypyUdalosti.precistenieHodnot);

            return udalost;
        }
        public static Udalost ZaciatocnaNastavenieCinnosti()
        {
            Udalost udalost = new Udalost(0, (int)TypyUdalosti.nastavenieNasledujucichCinnostiMravcov,
                                        TypyUdalosti.nastavenieNasledujucichCinnostiMravcov);

            return udalost;
        }
        public static Udalost ZaciatocnaVypisGrafickyMravenisko()
        {
            Udalost udalost = new Udalost(0, (int)TypyUdalosti.grafickyVypisMraveniska, TypyUdalosti.grafickyVypisMraveniska);

            return udalost;
        }
        public static Udalost ZaciatocnaOtazkaKoniec()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.otazkaNaKoniec,
                                            TypyUdalosti.otazkaNaKoniec);

            return udalost;
        }
        public static Udalost ZaciatocnaVykresliBojPrechadz()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.grafickyVypisMraveniskaBojPrechadzajuci, TypyUdalosti.grafickyVypisMraveniskaBojPrechadzajuci);

            return udalost;
        }
        public static Udalost ZaciatocnaVykresliBojNaPolicku()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.grafickyVypisMraveniskaBojNaPolicku, TypyUdalosti.grafickyVypisMraveniskaBojNaPolicku);

            return udalost;
        }
        public static Udalost ZaciatocnaVykresliParenie()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.grafickyVypisMraveniskaParenie, TypyUdalosti.grafickyVypisMraveniskaParenie);

            return udalost;
        }
        public static Udalost ZaciatocnaVykresliSmerOtocenia()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.grafickyVypisSmerOtocenia, 
                TypyUdalosti.grafickyVypisSmerOtocenia);
            return udalost;
        }
        public static Udalost ZaciatocnaVykresliSmerAktivnehoPohybuStatie()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.grafickyVypisSmerAktivnehoPohybuStatie, TypyUdalosti.grafickyVypisSmerAktivnehoPohybuStatie);
            return udalost;
        }
        public static Udalost ZaciatocnaVykresliPoVykonaniCinnostiNepohybovych()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.grafickyvVypisPoVykonaniCinnostiNepohybovych,
                TypyUdalosti.grafickyvVypisPoVykonaniCinnostiNepohybovych);

            return udalost;
        }
        public static Udalost ZaciatocnaVykresliPoZnizeniEnergie()
        {
            Udalost udalost = new Udalost(1, (int)TypyUdalosti.grafickyVypisPoZnizeniEnergieMravcov,
                                            TypyUdalosti.grafickyVypisPoZnizeniEnergieMravcov);
            return udalost;
        }

        private static void NaplnHaldaUdalostami(Halda<Udalost> halda)
        {
            Udalost udalost;

            udalost = ZaciatocnaBojMravcovPrechadzajucich();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaBojMravcovStojacich();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaNastavenieCinnosti();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaNavysenieCasuMraveniska();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaNavysenieVekuMravcov();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaNepohybujucePolicka();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            //len konzolova verzia
            //udalost = ZaciatocnaOtazkaKoniec();
            //halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaPrecistenieHodnot();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            //len konzolova verzia
            //udalost = ZaciatocnaVypisStatistickych();
            //halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaVypisGrafickyMravenisko();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaZnizenieEnergie();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaVykresliBojPrechadz();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaVykresliBojNaPolicku();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaVykresliParenie();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaVykresliSmerOtocenia();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaVykresliSmerAktivnehoPohybuStatie();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaVykresliPoVykonaniCinnostiNepohybovych();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaVykresliPoZnizeniEnergie();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }
        public static void InicializujHodnoty(Mravenisko mravenisko)
        {
            NastavKonstantneHodnoty();
            NastavNekonstantneHodnoty(mravenisko);
        }
    }
}
