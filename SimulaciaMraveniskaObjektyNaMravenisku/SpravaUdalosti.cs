using CodEx;
using DatoveStruktury;
using SimulaciaMraveniskaHlasky;
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
    //spracovava udalost, vyuziva na to triedy SpravaCinnostiMravca, pre spravu cinnosti mravca
    //a SpravaSpravaMraveniska, kde takisto spracovava (mimo ineho) cinnosti mravcov, ktore sa tykaju
    //skor vsetkych mravcov narozdiel od SpravaCinnostiMravca
    //taktiez jednotlive funkcie zabezpecia vznik novych udalosti na spracovanie
    public static class SpravaUdalosti
    {
        //zvysi cas mraveniska
        public static void ZvysenieCasuMraveniska(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            mravenisko.ZvysCasExistencieMraveniska();

            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.zvysenieCasu,
                                          TypyUdalosti.zvysenieCasu);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }
        //navysi vek vsetkych mravcov
        public static void NavysenieVekuMravcov(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            mravenisko.NavysVekMravcov();

            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.navysenieVekuMravcov,
                                            TypyUdalosti.navysenieVekuMravcov);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }
        //vykona cinnosti, ktore suvisua s pohybom mravcov (okrem boja)
        public static void VykonanieCinnostiMravcovPohyb(Udalost udalost, Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Mravec mravec = udalost.ZistiObjektMravec();

            switch (udalost.ZistiCinnostMravca())
            {
                case CinnostiMravcov.zostan:
                    mravec.ZostanStat(mravenisko, cas);
                    break;
                case CinnostiMravcov.otocSaVlavo:
                    mravec.OtocSaVlavo(mravenisko, cas);
                    break;
                case CinnostiMravcov.chodDopreduUtok:
                    mravec.ChodDopreduUtok(mravenisko, cas);
                    break;
                case CinnostiMravcov.chodDopreduObrana:
                    mravec.ChodDopreduObrana(mravenisko, cas);
                    break;
            }

        }
        //spracuje boj mravcov ktory sa stretli pri prechadzani medzi polickami,
        //ak mravce b idu na policko B z policka C a mravce c idu na policko C z policka B
        //tak ich suboj je spracovany v tejto funkcii
        public static void BojMravcovPrechadzajucich(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                {
                    SpravaMraveniskaMravcov.ZistiPohybSZahajSuboj(mravenisko, new Suradnice(i, j), cas);

                    SpravaMraveniskaMravcov.ZistiPohybVZahajSuboj(mravenisko, new Suradnice(i, j), cas);
                }

            SpravaMraveniskaMravcov.ZlucenieNahradnychMravenisk(mravenisko.ZistiRozmerMraveniska());

            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.bojMravcovPrechadzajucich,
                                            TypyUdalosti.bojMravcovPrechadzajucich);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }
        // spracuje boj mravcov inych typov na vsetkych polickach
        public static void BojMravcovNaPolickach(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                {
                    SpravaMraveniskaMravcov.SubojNepohybujuce(mravenisko, new Suradnice(i, j), cas);
                }

            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.bojMravcovNaPolickach, TypyUdalosti.bojMravcovNaPolickach);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }
        //spusti rozmnozovanie mravcov na jednotlivych polickach
        public static void ParitSa(Mravenisko mravenisko, int cas)
        {
            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    SpravaMraveniskaMravcov.ParenieMravcovDanaSuradnica(mravenisko, new Suradnice(i, j), cas);
        }
        //vykana cinnosti mravcov, ktore az tak nesuvisia s pohybom a ide o samostatnu cinnost konkretneho mravca
        public static void VykonanieCinnnostiMravcovNepohyb(Udalost udalost, Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Mravec mravec = udalost.ZistiObjektMravec();

            switch (udalost.ZistiCinnostMravca())
            {
                case CinnostiMravcov.najedzSa:
                    mravec.NajedzSa(
                      mravenisko, cas); break;
            }
        }
        //upravy, aktualizuje policka na mravenisku
        public static void UpravaNepohybujucichSaPolicok(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            mravenisko.NajdeniePotravyZjedena();

            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.upravyNepohybujucichPolicok,
                                            TypyUdalosti.upravyNepohybujucichPolicok);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }
        //znizi energiu mravcov na konci jedneho "casu" behu simulacie
        public static void ZnizenieEnergiaNaKonci(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            List<Mravec> mravceNaOdstranenie = new List<Mravec>();

            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    foreach (PohybujuceSaObjekty objekt in mravenisko.
                        VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)))
                    {
                        Mravec mravec = objekt as Mravec;
                        mravec.ZnizEnergia(Konstanty.maximumEnergiaMravec / 20);
                        HlaskyCinnostiMravcovStavObjektov.ZnizenaEnergiaMravcaNaKonciDanehoCasu(cas, mravec.ZistiIdMravca(),
                                                                                    (int)mravec.ZistiTypyMravcov() + 1,
                                                                                    mravec.ZistiXSuradnicu(),
                                                                                    mravec.ZistiYSuradnicu(),
                                                                                    mravec.ZistiEnergiaMravca());
                        if (!mravec.ZistiExistenciu())
                             mravceNaOdstranenie.Add(mravec);                       
                    }

            foreach (Mravec mravec in mravceNaOdstranenie)
            {
                mravenisko.NastavUbytokMravcovPoZnizeniEnergie(mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu(), true);
                mravenisko.ZvysPocetMravcovOdisliZnizenimEnergie(mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());

                mravenisko.OdstranenieMravca(mravec.ZistiSuradnica(), mravec.ZistiIdMravca());

                HlaskyCinnostiMravcovStavObjektov.MravecZanikolNaPolickuNedostatokEnergie(cas, mravec.ZistiIdMravca(),
                                                                                            (int)mravec.ZistiTypyMravcov() + 1,
                                                                                            mravec.ZistiXSuradnicu(),
                                                                                            mravec.ZistiYSuradnicu());
            }

            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.znizenieEnergiaNaKonci,
                                          TypyUdalosti.znizenieEnergiaNaKonci);

            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }
        //len konzolova verzia
        public static void VypisStatistickychUdajov(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            HlaskyInformacnePocasSimulacie.VypisCasu(mravenisko.ZistiCasMraveniska());
            HlaskyInformacnePocasSimulacie.VypisPoctuMravcov(mravenisko.ZistiPocetMravcovTypu1(),
                                            mravenisko.ZistiPocetMravcovTypu2(),
                                            mravenisko.ZistiPocetMravcovTypu3(),
                                            mravenisko.ZistiPocetMravcovTypu4());
            HlaskyInformacnePocasSimulacie.VypisPoctuPotravy(mravenisko.ZistiPocetPotravy());

            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.vypisStatistickychUdajov,
                                            TypyUdalosti.vypisStatistickychUdajov);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }
        //resetuje hodnoty pred nasledujucim krokom, resp. "casom", simulacie, takisto sposobi delay medzi dalsim krokom simulacie
        public static void PrecistenieNastavenychHodnot(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            NastaveneHodnotyPocasKrokov.NastavParenie(false);
            SpravaMraveniskaMravcov.InicializaciaMraveniska(mravenisko);

            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    foreach (Mravec mravec in mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)))
                        mravec.NastavUskok(false);

            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.precistenieHodnot,
                                            TypyUdalosti.precistenieHodnot);

            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }
        //nastavy nove cinnosti mravcov na zaklade ich pozicie a strategie
        public static void NastavenieNovychCinnostiMravcov(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.nastavenieNasledujucichCinnostiMravcov,
                                            TypyUdalosti.nastavenieNasledujucichCinnostiMravcov);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    foreach (PohybujuceSaObjekty pohybObjekt in mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)))
                    {
                        Mravec mravec = pohybObjekt as Mravec;
                        NastavenieCinnostiMravcov.NastavenieCinnostiMravca(halda, cas, mravec, mravenisko);
                    }

            SpravaMraveniskaMravcov.InicializaciaMraveniska(mravenisko);
            SpravaMraveniskaMravcov.NajdiStojacichMravcov(mravenisko);
        }
        //zisti ci chce uzivatel pokracovat v simulacii, len konzolova verzia
        public static bool OtazkaNaUkoncenieMraveniska(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Reader nacitavac = Reader.Console();
            HlaskyPriNacitavaniHodnotRozhodnuti.ChcetePokracovatVSimulacii();
            string odpoved;
            odpoved = nacitavac.Word();

            Udalost udalost = new Udalost(cas + 10, (int)TypyUdalosti.otazkaNaKoniec,
                                TypyUdalosti.otazkaNaKoniec);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());



            if (odpoved == "ANO")
                return true;
            else
            {
                if (Konstanty.jeNastaveneMiestoUlozenia)
                    Konstanty.zapisovacUdajov.Close();     
                
                Environment.Exit(-1);
                return false;
                
            }
        }

        //udalost pre vypisovanie mraveniska, len GUI verzia, takisto je tu nastavene zastavenie behu vlaknu na urcite dobu, pre nie prilis rychli beh simulacie
        public static void GrafickyVypisMraveniska(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.grafickyVypisMraveniska, TypyUdalosti.grafickyVypisMraveniska);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            mravenisko.NastavFazaMraveniska(FazaMraveniska.poKonciKroku);
        }
        //udalost pre vypisovanie mraveniska po boji pri prechadzani, len GUI
        public static void GrafickyVypisMraveniskaBojPrechadzanie(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.grafickyVypisMraveniskaBojPrechadzajuci, TypyUdalosti.grafickyVypisMraveniskaBojPrechadzajuci);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            mravenisko.NastavFazaMraveniska(FazaMraveniska.poBojiPrechadzani);
        }
        //udalost pre vypisovanie mraveniska po boji na policku, len GUI
        public static void GrafickyVypisMraveniskaBojPolicku(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.grafickyVypisMraveniskaBojNaPolicku, TypyUdalosti.grafickyVypisMraveniskaBojNaPolicku);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            mravenisko.NastavFazaMraveniska(FazaMraveniska.poBojiPolicku);
        }
        //udalost pre vypisovanie mraveniska po pareni, len GUI
        public static void GrafickyVypisMraveniskaPoPareni(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.grafickyVypisMraveniskaParenie, TypyUdalosti.grafickyVypisMraveniskaParenie);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            mravenisko.NastavFazaMraveniska(FazaMraveniska.poPareni);
        }
        //udalost pre vypisovanie mraveniska po vykonani cinnosti pohybovych
        public static void GrafickyVypisMraveniskaSmerOtocenia(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.grafickyVypisSmerOtocenia, TypyUdalosti.grafickyVypisSmerOtocenia);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            mravenisko.NastavFazaMraveniska(FazaMraveniska.poNastaveniSmerOtocenia);
        }
        //udalost pre vypisanie smeru pohybu mravca, tj. smeru otocenia mravca pokial ide dopredu
        public static void GrafickyVypisMraveniskaSmerAktivnehoPohybuStatie(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.grafickyVypisSmerAktivnehoPohybuStatie, TypyUdalosti.grafickyVypisSmerAktivnehoPohybuStatie);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            mravenisko.NastavFazaMraveniska(FazaMraveniska.poNastaveniSmerAktivnehoPohybuStatie);
        }
        //udalost pre vypisovanie mraveniska po vykonani cinnosti nepohybovych (teraz len po najedeni)
        public static void GrafickyVypisMraveniskaPoVykonaniCinnostiNepohybovych(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.grafickyvVypisPoVykonaniCinnostiNepohybovych,
                                            TypyUdalosti.grafickyvVypisPoVykonaniCinnostiNepohybovych);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            mravenisko.NastavFazaMraveniska(FazaMraveniska.poVykonaniCinnostiNepohybovych);
        }
        //udalost pre vypisovanie mraveniska po znizeni ich energie na konci kroku
        public static void GrafickyVypisMraveniskaPoZnizeniEnergie(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.grafickyVypisPoZnizeniEnergieMravcov,
                                            TypyUdalosti.grafickyVypisPoZnizeniEnergieMravcov);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            mravenisko.NastavFazaMraveniska(FazaMraveniska.poZnizeniEnergie);
        }

    }
}
