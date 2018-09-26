using SimulaciaMraveniskaMravenisko;
using SimulaciaMraveniskaObjektyNaMravenisku;
using SimulaciaMraveniskaHlasky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//sprava udalosti a suvisiace objekty a enum typy
namespace SimulaciaMraveniskaUdalostiSpravaUdalosti
{
    //sprava mraveniska, najma cinnosti mravcov ako boj a parenie
    public static class SpravaMraveniskaMravcov
    {
        public static List<Mravec>[,] nahradneMraveniskoStojace;
        public static List<Mravec>[,] nahradneMraveniskoPohybujuce;

        //inicializacia nahradnych mravenisk
        public static void InicializaciaMraveniska(Mravenisko mravenisko)
        {
            NastavMravenisko(mravenisko, ref nahradneMraveniskoPohybujuce);
            NastavMravenisko(mravenisko, ref nahradneMraveniskoStojace);
        }
        //inicializcacia mraveniska
        public static void NastavMravenisko(Mravenisko mravenisko, ref List<Mravec>[,] mravce)
        {
            mravce = new List<Mravec>[mravenisko.ZistiRozmerMraveniska(), mravenisko.ZistiRozmerMraveniska()];

            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    mravce[i, j] = new List<Mravec>();
        }
        //naplnenie nahradneMraveniskoStojace mravcami na danych polickach, ktory nemenia policko
        public static void NajdiStojacichMravcov(Mravenisko mravenisko)
        {
            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)           
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)   
                    foreach (Mravec mravec in mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)))                   
                        if (mravec.ZistiCinnostMravca() != CinnostiMravcov.chodDopreduObrana && mravec.ZistiCinnostMravca() != CinnostiMravcov.chodDopreduUtok)
                            nahradneMraveniskoStojace[i, j].Add(mravec);                  
        }

        //zisti existenciu skupiny mravcov, ktore idu z policka so suradnicami "suradnice" na policko pod nimi
        //a tymi co ide opacne
        //spracuje ich suboj
        public static void ZistiPohybSZahajSuboj(Mravenisko mravenisko, Suradnice suradnice, int cas)
        {
            List<Mravec> mravceSmerS = new List<Mravec>();//mravce iduce smerom s
            List<Mravec> mravceSmerJ = new List<Mravec>();//mravce iduce smerom j
            List<Mravec> mravceNaOdstranenieS = new List<Mravec>();//mravce na odstranenie iduce smerom s

            Suradnice suradniceNaSevere = suradnice;//suradnice
            Suradnice suradniceSmerS =
            NasledujucePolickoMraveniska.SmerJ(suradnice, mravenisko.ZistiRozmerMraveniska());//suradnice odkial idu mravce 
                                                                                              //smerujuce na s

            foreach (Mravec mravec in nahradneMraveniskoPohybujuce[suradniceNaSevere.ZistiXSuradnicu(), suradniceNaSevere.ZistiYSuradnicu()])
                if (ZistiCiSaSuradniceRovnaju(mravec.ZistiStareSuradnica(), suradniceSmerS))
                {
                    mravceNaOdstranenieS.Add(mravec);
                    mravceSmerS.Add(mravec);
                }

            List<Mravec> mravceNaOdstranenieJ = new List<Mravec>();//mravce na odstranenie iduce smerom j
            Suradnice suradniceNaJuhu = NasledujucePolickoMraveniska.SmerJ(suradniceNaSevere, mravenisko.ZistiRozmerMraveniska()); //suradnice kam idu mravce
                                                                                                   // iduce zo "suradniceNaSevere", teda iduce smerom j
            Suradnice suradniceSmerJ = suradnice; //suradnice odkial idu mravce smerujuce na j

            foreach (Mravec mravec in nahradneMraveniskoPohybujuce[suradniceNaJuhu.ZistiXSuradnicu(), suradniceNaJuhu.ZistiYSuradnicu()])           
                if (ZistiCiSaSuradniceRovnaju(suradniceSmerJ, mravec.ZistiStareSuradnica()))
                {
                    mravceNaOdstranenieJ.Add(mravec);
                    mravceSmerJ.Add(mravec);
                }

            //ak ma suboj zmysel, tak ho spusti
            if (mravceSmerS.Count > 0 && mravceSmerJ.Count > 0 && mravceSmerS[0].ZistiTypyMravcov() !=
                mravceSmerJ[0].ZistiTypyMravcov())
            {
                foreach (Mravec mravec in mravceNaOdstranenieS) //vymazanie mravcov, ktore idu bojovat z nahradneho mraveniska, aby nevznikli duplikaty, ked sa budu mravce zapisovat
                    nahradneMraveniskoPohybujuce[suradniceNaSevere.ZistiXSuradnicu(), suradniceNaSevere.ZistiYSuradnicu()].Remove(mravec);

                foreach (Mravec mravec in mravceNaOdstranenieJ) //vymazanie mravcov, ktore idu bojovat z nahradneho mraveniska, aby nevznikli duplikaty, ked sa budu mravce zapisovat
                    nahradneMraveniskoPohybujuce[suradniceNaJuhu.ZistiXSuradnicu(), suradniceNaJuhu.ZistiYSuradnicu()].Remove(mravec);

                SubojPohybujuce(mravceSmerS, suradniceNaSevere, mravceSmerJ, suradniceNaJuhu, mravenisko, cas);
            }
        }
        //zisti existenciu skupiny mravcov, ktore idu z policka so suradnicami "suradnice" na policku  "vpravo"
        //od nich a tymi co idu naopak
        //spracuje ich suboj
        public static void ZistiPohybVZahajSuboj(Mravenisko mravenisko, Suradnice suradnice, int cas)
        {
            List<Mravec> mravceSmerV = new List<Mravec>();//mravce iduce smerom na v
            List<Mravec> mravceSmerZ = new List<Mravec>();//mravce iduce smerom na z
            List<Mravec> mravceNaOdstranenieV = new List<Mravec>();
            List<Mravec> mravceNaOdstranenieZ = new List<Mravec>();


            //suradnice kam ide mravce v smere v
            Suradnice suradniceNaVychode = NasledujucePolickoMraveniska.SmerV(suradnice, mravenisko.ZistiRozmerMraveniska());
            //suradnice odkial idu mravce v smere v
            Suradnice suradniceSmerV = suradnice;

            foreach (Mravec mravec in nahradneMraveniskoPohybujuce[suradniceNaVychode.ZistiXSuradnicu(), suradniceNaVychode.ZistiYSuradnicu()])
                if (ZistiCiSaSuradniceRovnaju(suradniceSmerV, mravec.ZistiStareSuradnica()))
                {
                    mravceNaOdstranenieV.Add(mravec);
                    mravceSmerV.Add(mravec);
                }

            mravceNaOdstranenieZ = new List<Mravec>();

            //suradnice odkial idu mravce v smere z
            Suradnice suradniceSmerZ = suradniceNaVychode;
            //suradnice kam idu mravce v smere z
            Suradnice suradniceNaZapade = suradnice;

            foreach (Mravec mravec in nahradneMraveniskoPohybujuce[suradniceNaZapade.ZistiXSuradnicu(), suradniceNaZapade.ZistiYSuradnicu()])
                if (ZistiCiSaSuradniceRovnaju(suradniceSmerZ, mravec.ZistiStareSuradnica()))
                {
                    mravceNaOdstranenieZ.Add(mravec);
                    mravceSmerZ.Add(mravec);
                }
            

            //ak ma suboj zmysel, tak ho spusti
            if (mravceSmerV.Count > 0 && mravceSmerZ.Count > 0 && mravceSmerV[0].ZistiTypyMravcov() !=
                mravceSmerZ[0].ZistiTypyMravcov())
            {
                foreach (Mravec mravec in mravceNaOdstranenieZ) //vymazanie mravcov, ktore idu bojovat z nahradneho mraveniska, aby nevznikli duplikaty, ked sa budu mravce zapisovat
                    nahradneMraveniskoPohybujuce[suradniceNaZapade.ZistiXSuradnicu(), suradniceNaZapade.ZistiYSuradnicu()].Remove(mravec);

                foreach (Mravec mravec in mravceNaOdstranenieV) //vymazanie mravcov, ktore idu bojovat z nahradneho mraveniska, aby nevznikli duplikaty, ked sa budu mravce zapisovat
                    nahradneMraveniskoPohybujuce[suradniceNaVychode.ZistiXSuradnicu(), suradniceNaVychode.ZistiYSuradnicu()].Remove(mravec);

                SubojPohybujuce(mravceSmerV, suradniceNaVychode, mravceSmerZ, suradniceNaZapade, mravenisko, cas);
            }
        }

        //spracovanie suboja dvoch proti sebe iducich skupin mravcov (kde jedna skupina obsahuje mravce toho isteho typu)
        private static void SubojPohybujuce(List<Mravec> mravce1, Suradnice suradnice1, List<Mravec> mravce2,
            Suradnice suradnice2, Mravenisko mravenisko, int cas)
        {

            PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji1 = new PolickaPriPrechadzajucomBoji(suradnice1, mravce1[0].ZistiTypyMravcov());
            PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji2 = new PolickaPriPrechadzajucomBoji(suradnice2, mravce2[0].ZistiTypyMravcov(), 
                                                                                                            polickaPriPrechadzajucomBoji1);
            polickaPriPrechadzajucomBoji1.NastavDruhePolicko(polickaPriPrechadzajucomBoji2);
            mravenisko.NastavPolickoBojPrechadzajuce(polickaPriPrechadzajucomBoji1, polickaPriPrechadzajucomBoji1.ZistiSuradniceMravcov().ZistiXSuradnicu(),
                                                        polickaPriPrechadzajucomBoji1.ZistiSuradniceMravcov().ZistiYSuradnicu());
            mravenisko.NastavPolickoBojPrechadzajuce(polickaPriPrechadzajucomBoji2, polickaPriPrechadzajucomBoji2.ZistiSuradniceMravcov().ZistiXSuradnicu(),
                                                        polickaPriPrechadzajucomBoji2.ZistiSuradniceMravcov().ZistiYSuradnicu());

            List<Mravec> mravceTypu1 = new List<Mravec>();
            List<Mravec> mravceTypu2 = new List<Mravec>();
            List<Mravec> mravceTypu3 = new List<Mravec>();
            List<Mravec> mravceTypu4 = new List<Mravec>();

            List<Mravec> vyherneMravce = new List<Mravec>();

            List<Mravec> mravceUskokTypu1 = new List<Mravec>();
            List<Mravec> mravecUskokTypu2 = new List<Mravec>();
            List<Mravec> mravecUskokTypu3 = new List<Mravec>();
            List<Mravec> mravecUskokTypu4 = new List<Mravec>();

            RoztriedMravcePodlaTypovMravce(mravce1, mravceTypu1, mravceTypu2, mravceTypu3, mravceTypu4);
            RoztriedMravcePodlaTypovMravce(mravce2, mravceTypu1, mravceTypu2, mravceTypu3, mravceTypu4);

            NastavBojovaliPriPrechodeDetail(mravceTypu1);
            NastavBojovaliPriPrechodeDetail(mravceTypu2);
            NastavBojovaliPriPrechodeDetail(mravceTypu3);
            NastavBojovaliPriPrechodeDetail(mravceTypu4);

            Suradnice suradniceMravcovTypu1PreUskok = default(Suradnice);
            Suradnice suradniceMravcovTypu2PreUskok = default(Suradnice);
            Suradnice suradniceMravcovTypu3PreUskok = default(Suradnice);
            Suradnice suradniceMravcovTypu4PreUskok = default(Suradnice);

            Suradnice suradniceMravcovTypu1 = default(Suradnice);
            Suradnice suradniceMravcovTypu2 = default(Suradnice);
            Suradnice suradniceMravcovTypu3 = default(Suradnice);
            Suradnice suradniceMravcovTypu4 = default(Suradnice);

            NastavSuradnicePodlaTypu(ref suradniceMravcovTypu1PreUskok, ref suradniceMravcovTypu2PreUskok,
                ref suradniceMravcovTypu3PreUskok, ref suradniceMravcovTypu4PreUskok
                , suradnice2, mravce1[0].ZistiTypyMravcov());
            NastavSuradnicePodlaTypu(ref suradniceMravcovTypu1PreUskok, ref suradniceMravcovTypu2PreUskok,
                ref suradniceMravcovTypu3PreUskok, ref suradniceMravcovTypu4PreUskok,
                suradnice1, mravce2[0].ZistiTypyMravcov());

            NastavSuradnicePodlaTypu(ref suradniceMravcovTypu1, ref suradniceMravcovTypu2, ref suradniceMravcovTypu3, ref suradniceMravcovTypu4, suradnice1,
                mravce1[0].ZistiTypyMravcov());
            NastavSuradnicePodlaTypu(ref suradniceMravcovTypu1, ref suradniceMravcovTypu2, ref suradniceMravcovTypu3, ref suradniceMravcovTypu4, suradnice2,
                mravce2[0].ZistiTypyMravcov());


            ZistiSpravujUskakujuceMravce(mravenisko, ref mravceTypu1, mravceUskokTypu1, cas);
            ZistiSpravujUskakujuceMravce(mravenisko, ref mravceTypu2, mravecUskokTypu2, cas);
            ZistiSpravujUskakujuceMravce(mravenisko, ref mravceTypu3, mravecUskokTypu3, cas);
            ZistiSpravujUskakujuceMravce(mravenisko, ref mravceTypu4, mravecUskokTypu4, cas);

            VratMravceNaPolickoZKtorehoIsliUskociliNanTeraz(suradniceMravcovTypu1PreUskok, mravceUskokTypu1, mravenisko, cas);
            VratMravceNaPolickoZKtorehoIsliUskociliNanTeraz(suradniceMravcovTypu2PreUskok, mravecUskokTypu2, mravenisko, cas);
            VratMravceNaPolickoZKtorehoIsliUskociliNanTeraz(suradniceMravcovTypu3PreUskok, mravecUskokTypu3, mravenisko, cas);
            VratMravceNaPolickoZKtorehoIsliUskociliNanTeraz(suradniceMravcovTypu4PreUskok, mravecUskokTypu4, mravenisko, cas);

            int energiaMravceTypu1 = ZistiEnergiaMravcov(mravceTypu1);
            int energiaMravceTypu2 = ZistiEnergiaMravcov(mravceTypu2);
            int energiaMravceTypu3 = ZistiEnergiaMravcov(mravceTypu3);
            int energiaMravceTypu4 = ZistiEnergiaMravcov(mravceTypu4);

            TypyMravcov typyMravcov = ZistiVyhercaSuboja(energiaMravceTypu1, energiaMravceTypu2, energiaMravceTypu3, energiaMravceTypu4);

            SpracujVyhru(suradniceMravcovTypu1, suradniceMravcovTypu2, suradniceMravcovTypu3, suradniceMravcovTypu4, typyMravcov,
                mravceTypu1, mravceTypu2, mravceTypu3, mravceTypu4, TypySubojov.subojPriPrechode, cas);

            VymazMravcePodlaTypu(mravenisko, typyMravcov, suradniceMravcovTypu1, suradniceMravcovTypu2, suradniceMravcovTypu3, suradniceMravcovTypu4, mravceTypu1,
                mravceTypu2, mravceTypu3, mravceTypu4, cas);



        }
        //spracovanie suboja mravcov roznych typov na danom policku
        public static void SubojNepohybujuce(Mravenisko mravenisko, Suradnice suradnice, int cas)
        {
            List<Mravec> mravceTypu1 = new List<Mravec>();
            List<Mravec> mravceTypu2 = new List<Mravec>();
            List<Mravec> mravceTypu3 = new List<Mravec>();
            List<Mravec> mravceTypu4 = new List<Mravec>();

            List<Mravec> vyherneMravce = new List<Mravec>();

            RoztriedMravceNaPolickuPodlaTypovSuradnice(suradnice, mravceTypu1, mravceTypu2, mravceTypu3, mravceTypu4);

            int energiaMravceTypu1 = ZistiEnergiaMravcov(mravceTypu1);
            int energiaMravceTypu2 = ZistiEnergiaMravcov(mravceTypu2);
            int energiaMravceTypu3 = ZistiEnergiaMravcov(mravceTypu3);
            int energiaMravceTypu4 = ZistiEnergiaMravcov(mravceTypu4);

            int pocetMravcovCelkovo;

            pocetMravcovCelkovo = mravceTypu1.Count + mravceTypu2.Count + mravceTypu3.Count + mravceTypu4.Count;

            //pokial ma suboj zmysel, tak sa spusti
            if (PritomnostMravceViacTypov(pocetMravcovCelkovo, mravceTypu1.Count, mravceTypu2.Count, mravceTypu3.Count, mravceTypu4.Count))
            {
                VlozPolickBojNepohybujuci(suradnice, mravenisko, mravceTypu1, mravceTypu2, mravceTypu3, mravceTypu4);

                TypyMravcov typyMravcov = ZistiVyhercaSuboja(energiaMravceTypu1, energiaMravceTypu2, energiaMravceTypu3, energiaMravceTypu4);

                SpracujVyhru(suradnice, suradnice, suradnice, suradnice, typyMravcov, mravceTypu1, mravceTypu2,
                    mravceTypu3, mravceTypu4, TypySubojov.subojPriStatiNaPolicku, cas);

                NastavNeparenie(mravceTypu1);
                NastavNeparenie(mravceTypu2);
                NastavNeparenie(mravceTypu3);
                NastavNeparenie(mravceTypu4);

                NastavBojovalNaPolickuDetail(mravceTypu1);
                NastavBojovalNaPolickuDetail(mravceTypu2);
                NastavBojovalNaPolickuDetail(mravceTypu3);
                NastavBojovalNaPolickuDetail(mravceTypu4);

                VymazMravcePodlaTypu(mravenisko, typyMravcov, suradnice, suradnice, suradnice, suradnice,
                    mravceTypu1, mravceTypu2, mravceTypu3, mravceTypu4, cas);
            }
        }
        
        //spravuje vyhru
        public static void SpracujVyhru(Suradnice suradniceTypu1, Suradnice suradniceTypu2, Suradnice suradniceTypu3,
            Suradnice suradniceTypu4, TypyMravcov typyMravcov, List<Mravec> mravceTypu1, List<Mravec> mravceTypu2,
            List<Mravec> mravceTypu3, List<Mravec> mravceTypu4, TypySubojov typySubojov, int cas)
        {
            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1: SpravaVyhry(mravceTypu1, suradniceTypu1, typySubojov, cas); break;
                case TypyMravcov.MravecTypu2: SpravaVyhry(mravceTypu2, suradniceTypu2, typySubojov, cas); break;
                case TypyMravcov.MravecTypu3: SpravaVyhry(mravceTypu3, suradniceTypu3, typySubojov, cas); break;
                case TypyMravcov.MravecTypu4: SpravaVyhry(mravceTypu4, suradniceTypu4, typySubojov, cas); break;

            }
        }
        //spravuje vyhru
        private static void SpravaVyhry(List<Mravec> mravce, Suradnice suradnice, TypySubojov typySubojov, int cas)
        {
            if (typySubojov == TypySubojov.subojPriPrechode)
                foreach (Mravec mravec in mravce)
                {
                    mravec.NastavVyhralPriPrechode(true);
                    mravec.ZvysEnergia();
                    nahradneMraveniskoPohybujuce[suradnice.ZistiXSuradnicu(),
                        suradnice.ZistiYSuradnicu()].Add(mravec);
                    HlaskyCinnostiMravcovStavObjektov.MravecBojovalV(cas,
                         mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1, suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu(),
                         mravec.ZistiEnergiaMravca());

                }
            else
            {
                nahradneMraveniskoStojace[suradnice.ZistiXSuradnicu(),
                         suradnice.ZistiYSuradnicu()] = new List<Mravec>();
                foreach (Mravec mravec in mravce)
                {
                    mravec.NastavVyhralNaPolicku(true);
                    mravec.ZvysEnergia(); nahradneMraveniskoStojace[suradnice.ZistiXSuradnicu(),
                        suradnice.ZistiYSuradnicu()].Add(mravec);
                    HlaskyCinnostiMravcovStavObjektov.MravecBojovalV(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                        suradnice.ZistiXSuradnicu(),
                        suradnice.ZistiYSuradnicu(), mravec.ZistiEnergiaMravca());
                }
            }
        }
        //spracuje mravce, ktore zanikli pri suboji
        private static void VymazMravcePodlaTypu(Mravenisko mravenisko, TypyMravcov typyMravcov, Suradnice suradniceTypu1,
            Suradnice suradniceTypu2, Suradnice suradniceTypu3,
            Suradnice suradniceTypu4, List<Mravec> mravceTypu1, List<Mravec> mravceTypu2,
            List<Mravec> mravceTypu3, List<Mravec> mravceTypu4, int cas)
        {
            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1:
                    VymazMravce(mravenisko, suradniceTypu2, mravceTypu2, cas);
                    VymazMravce(mravenisko, suradniceTypu3, mravceTypu3, cas);
                    VymazMravce(mravenisko, suradniceTypu4, mravceTypu4, cas); break;
                case TypyMravcov.MravecTypu2:
                    VymazMravce(mravenisko, suradniceTypu1, mravceTypu1, cas);
                    VymazMravce(mravenisko, suradniceTypu3, mravceTypu3, cas);
                    VymazMravce(mravenisko, suradniceTypu4, mravceTypu4, cas); break;
                case TypyMravcov.MravecTypu3:
                    VymazMravce(mravenisko, suradniceTypu1, mravceTypu1, cas);
                    VymazMravce(mravenisko, suradniceTypu2, mravceTypu2, cas);
                    VymazMravce(mravenisko, suradniceTypu4, mravceTypu4, cas); break;
                case TypyMravcov.MravecTypu4:
                    VymazMravce(mravenisko, suradniceTypu1, mravceTypu1, cas);
                    VymazMravce(mravenisko, suradniceTypu2, mravceTypu2, cas);
                    VymazMravce(mravenisko, suradniceTypu3, mravceTypu3, cas); break;
            }
        }
        //spracuje mravce, ktore zanikli pri suboji
        private static void VymazMravce(Mravenisko mravenisko, Suradnice suradnice, List<Mravec> mravce, int cas)
        {
            foreach (Mravec mravec in mravce)
            {
                mravec.ZnizEnergia(Konstanty.maximumEnergiaMravec * 7);
                mravenisko.OdstranenieMravca(suradnice, mravec.ZistiIdMravca());
                HlaskyCinnostiMravcovStavObjektov.MravecZanikolNaPolickuPriBoji(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                    mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());

                mravec.NastavPodariloSa(false);
            }
        }
        //zlucenie mravcov v nahradnych mraveniskach
        public static void ZlucenieNahradnychMravenisk(int rozmerMraveniska)
        {
            for (int i = 0; i < rozmerMraveniska; i++)
                for (int j = 0; j < rozmerMraveniska; j++)
                    foreach (Mravec mravec in nahradneMraveniskoPohybujuce[i, j])
                        nahradneMraveniskoStojace[i, j].Add(mravec);
        }
        //roztriedi mravce na urcenych suradniciach podla ich typov
        private static void RoztriedMravceNaPolickuPodlaTypovSuradnice(Suradnice suradnice, List<Mravec> mravceTypu1,
            List<Mravec> mravceTypu2, List<Mravec> mravceTypu3, List<Mravec> mravceTypu4)
        {
            foreach (Mravec mravec in nahradneMraveniskoStojace[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()])
                switch (mravec.ZistiTypyMravcov())
                {
                    case TypyMravcov.MravecTypu1: mravceTypu1.Add(mravec); break;
                    case TypyMravcov.MravecTypu2: mravceTypu2.Add(mravec); break;
                    case TypyMravcov.MravecTypu3: mravceTypu3.Add(mravec); break;
                    case TypyMravcov.MravecTypu4: mravceTypu4.Add(mravec); break;
                }
        }
        //roztriedi mravce z "mravce" podla typov
        private static void RoztriedMravcePodlaTypovMravce(List<Mravec> mravce, List<Mravec> mravecTypu1, List<Mravec> mravecTypu2,
                                                            List<Mravec> mravecTypu3, List<Mravec> mravecTypu4)
        {
            foreach (Mravec mravec in mravce)
                switch (mravec.ZistiTypyMravcov())
                {
                    case TypyMravcov.MravecTypu1: mravecTypu1.Add(mravec); break;
                    case TypyMravcov.MravecTypu2: mravecTypu2.Add(mravec); break;
                    case TypyMravcov.MravecTypu3: mravecTypu3.Add(mravec); break;
                    case TypyMravcov.MravecTypu4: mravecTypu4.Add(mravec); break;
                }
        }
        //zisti ci su pritomne mravce viacerych typov
        private static bool PritomnostMravceViacTypov(int celkovyPocet, int pocetTypu1, int pocetTypu2, int pocetTypu3,
                                                    int pocetTypu4)
        {
            if (celkovyPocet > pocetTypu1 && celkovyPocet > pocetTypu2 && celkovyPocet > pocetTypu3 && celkovyPocet > pocetTypu4)
                return true;
            else return false;
        }
        //nastavy "suradnice" podla typu mravcov 
        private static void NastavSuradnicePodlaTypu(ref Suradnice suradniceTypu1, ref Suradnice suradniceTypu2,
            ref Suradnice suradniceTypu3, ref Suradnice suradniceTypu4, Suradnice suradnice, TypyMravcov typyMravcov)
        {
            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1: suradniceTypu1 = suradnice; break;
                case TypyMravcov.MravecTypu2: suradniceTypu2 = suradnice; break;
                case TypyMravcov.MravecTypu3: suradniceTypu3 = suradnice; break;
                case TypyMravcov.MravecTypu4: suradniceTypu4 = suradnice; break;
            }
        }
        //zisti vyhercu suboja, v zavisloti na energii bojujucich skupin
        private static TypyMravcov ZistiVyhercaSuboja(int energiaMravce1, int energiaMravce2, int energiaMravce3, int energiaMravce4)
        {

            int energia = energiaMravce1 + energiaMravce2 + energiaMravce3 + energiaMravce4;

            if (energia == 0) return default(TypyMravcov);

            int hodnota = GenerovanieHodnot.random.Next(1, energia + 1);

            if (hodnota <= energiaMravce1) return TypyMravcov.MravecTypu1;
            else if (hodnota <= energiaMravce1 + energiaMravce2) return TypyMravcov.MravecTypu2;
            else if (hodnota <= energiaMravce1 + energiaMravce2 + energiaMravce3) return TypyMravcov.MravecTypu3;
            else return TypyMravcov.MravecTypu4;

        }
        //zisti energie mravcov
        private static int ZistiEnergiaMravcov(List<Mravec> mravce)
        {
            int energia = 0;
            foreach (Mravec mravec in mravce)
            {
                energia += mravec.ZistiEnergiaMravca();
                if (mravec.ZistiObranaMravca()) energia += Konstanty.maximumEnergiaMravec / 20;
            }
            return energia;
        }
        //spravuje mravce, ktore uskakuju z boja 
        private static void ZistiSpravujUskakujuceMravce(Mravenisko mravenisko,
            ref List<Mravec> mravce, List<Mravec> mravceUskakujuce, int cas)
        {

            List<Mravec> mravceNeuskakujuce = new List<Mravec>();

            foreach (Mravec mravec in mravce)
                if (mravec.ZistiUskok())
                {
                    mravec.ZnizEnergia(Konstanty.maximumEnergiaMravec / 20);
                    HlaskyCinnostiMravcovStavObjektov.ZnizenaEnergiaMravcaUskok(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                    mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu(),
                                                                   mravec.ZistiEnergiaMravca());
                    mravec.NastavUskocil(true);
                    mravec.NastavPodariloSa(false);

                    if (mravec.ZistiExistenciu())
                        mravceUskakujuce.Add(mravec);
                    else
                    {
                        HlaskyCinnostiMravcovStavObjektov.MravecZanikolNaPolickuNedostatokEnergie(cas, mravec.ZistiIdMravca(), 
                                                                                      (int)mravec.ZistiTypyMravcov() + 1,
                                                                                      mravec.ZistiXSuradnicu(),
                                                                                      mravec.ZistiYSuradnicu());
                        mravenisko.OdstranenieMravca(new Suradnice(mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu()), mravec.ZistiIdMravca());
                    }
                }
                else
                    mravceNeuskakujuce.Add(mravec);
                

            mravce = mravceNeuskakujuce;
        }
        //da mravce na miesto na ktore uskocili pri prechode
        private static void VratMravceNaPolickoZKtorehoIsliUskociliNanTeraz(Suradnice suradnice,
            List<Mravec> mravce, Mravenisko mravenisko, int cas)
        {
            foreach (Mravec mravec in mravce)
            {
                mravec.OtocitVlavo();
                mravec.OtocitVlavo();
                mravec.ChodDopredu(mravenisko.ZistiRozmerMraveniska());
                mravec.OtocitVlavo();
                mravec.OtocitVlavo();
                HlaskyCinnostiMravcovStavObjektov.MravecPrisielNaPolicko(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                            mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());
                mravenisko.PosunMravca(mravec.ZistiStareSuradnica(), mravec);
                nahradneMraveniskoStojace[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()].Add(mravec);

            }
        }
        //zisti rovnost suradnic
        private static bool ZistiCiSaSuradniceRovnaju(Suradnice suradnice1, Suradnice suradnice2)
        {
            if (suradnice1.ZistiXSuradnicu() == suradnice2.ZistiXSuradnicu() 
                && suradnice1.ZistiYSuradnicu() == suradnice2.ZistiYSuradnicu())
                return true;
            else
            return false;
        }
        //zrusi parenie sa u mravcov, ktory sa ucastnili v suboji
        private static void NastavNeparenie(List<Mravec> mravce)
        {
            foreach (Mravec mravec in mravce)
                mravec.NastavParitSa(false);           
        }
        //nastavi u mravcov, ze bojovali pri prechode
        private static void NastavBojovaliPriPrechodeDetail(List<Mravec> mravce)
        {
            foreach (Mravec mravec in mravce) mravec.NastavBojovalPriPrechode(true);
        }
        //nastavi u mravce, ze bojovali na policku
        private static void NastavBojovalNaPolickuDetail(List<Mravec> mravce)
        {
            foreach (Mravec mravec in mravce) mravec.NastavBojovalNaPolicku(true);
        }

        //spravuje parenie mravcov, na to aby vznikli nove mravce musia byt splnene urcite podmienky
        public static void ParenieMravcovDanaSuradnica(Mravenisko mravenisko, Suradnice suradnica, int cas)
        {
            List<Mravec> pariaceSaMravce = new List<Mravec>();
            int xSuradnica = suradnica.ZistiXSuradnicu();
            int ySuradnica = suradnica.ZistiYSuradnicu();

            foreach (PohybujuceSaObjekty pohybObjekt in mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(suradnica))
            {
                Mravec mravec = pohybObjekt as Mravec;

                if (mravec.ZistiParitSa())
                {
                    HlaskyCinnostiMravcovStavObjektov.MravecSaRozhodolParit(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                suradnica.ZistiXSuradnicu(), suradnica.ZistiYSuradnicu());
                    if (mravec.ZistiEnergiaMravca() > 3) pariaceSaMravce.Add(mravec);
                }
            }
            int energiaPreMravcov = 0;
            int energia = 0;

            int pocetMravcovNovych = pariaceSaMravce.Count / 2;

            if (pocetMravcovNovych > 0)
            {

                mravenisko.NastavParenie(xSuradnica, ySuradnica, true);

                foreach (Mravec mravec in pariaceSaMravce)
                {
                    energia = mravec.ZistiEnergiaMravca() / 3;
                    energiaPreMravcov += energia;
                    mravec.ZnizEnergia(energia);
                    HlaskyCinnostiMravcovStavObjektov.MravecSaPari(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                        suradnica.ZistiXSuradnicu(), suradnica.ZistiYSuradnicu());
                    HlaskyCinnostiMravcovStavObjektov.ZnizenaEnergiaMravcaParenie(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                        mravec.ZistiXSuradnicu(),
                                                                        mravec.ZistiYSuradnicu(), mravec.ZistiEnergiaMravca());
                    mravec.NastavPodariloSa(true);
                }

                energia = energiaPreMravcov / pocetMravcovNovych;

                TypyMravcov typyMravcov = default(TypyMravcov);
                typyMravcov = pariaceSaMravce[0].ZistiTypyMravcov();

                for (int i = 0; i < pocetMravcovNovych - 1; i++)
                {
                    mravenisko.PridanieMravcaKonkretnaPozicia(typyMravcov, xSuradnica, ySuradnica, energia, cas);
                    energiaPreMravcov -= energia;
                }

                mravenisko.PridanieMravcaKonkretnaPozicia(typyMravcov, xSuradnica, ySuradnica, energiaPreMravcov, cas);
            }
        }

        //vlozi policka na ktorych sa bojovalo pri boji na polickach do prislusneho pola v premennej "mravenisko"
        private static void VlozPolickBojNepohybujuci(Suradnice suradnice, Mravenisko mravenisko, List<Mravec> mravceTypu1, List<Mravec> mravceTypu2, List<Mravec> mravceTypu3,
                                                        List<Mravec> mravceTypu4)
        {
            PolickaPriBojiNaPolicku polickaPriBojiNaPolicku = new PolickaPriBojiNaPolicku(suradnice);

            if (mravceTypu1.Count > 0) polickaPriBojiNaPolicku.VlozTypMravca(TypyMravcov.MravecTypu1);
            if (mravceTypu2.Count > 0) polickaPriBojiNaPolicku.VlozTypMravca(TypyMravcov.MravecTypu2);
            if (mravceTypu3.Count > 0) polickaPriBojiNaPolicku.VlozTypMravca(TypyMravcov.MravecTypu3);
            if (mravceTypu4.Count > 0) polickaPriBojiNaPolicku.VlozTypMravca(TypyMravcov.MravecTypu4);

            mravenisko.NastavPolickoBojNaPolicku(polickaPriBojiNaPolicku, suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu());
        }
    }
}
