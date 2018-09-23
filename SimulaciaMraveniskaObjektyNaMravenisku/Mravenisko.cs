using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulaciaMraveniskaObjektyNaMravenisku;
using SimulaciaMraveniskaHlasky;

//objekt mravenisko, objekty a enum typy suvisiace s mraveniskom
namespace SimulaciaMraveniskaMravenisko
{
    //objekt reprezentujuci mravenisko a objekty na nom
    public class Mravenisko
    {
        private List<PohybujuceSaObjekty>[,] mraveniskoMravce;
        private List<PohybujuceSaObjekty>[,] mraveniskoMravcePredPohybom;
        private NepohybujuceSaObjekty[,] mraveniskoTypyPolicok;
        private List<PolickaPriPrechadzajucomBoji>[,] polickaPriPrechadzajucomBojiPole;// pole reprezentujuce, kde sa odohrali boje pri prechadzani
        private PolickaPriBojiNaPolicku[,] polickaPriBojiNaPolickuPole;// pole reprezentujuce, kde sa odohrali boje na polickach
        private bool[,] miestaParenia;// pole reprezentujuce, kde sa odohralo parenie, True - na policku sa vykonalo parenie
        private bool[,] miestaJedenia;// pole reprezentujuce, na ktorych polickach mravce zvysili energiu jedenim
        private bool[,] miestaZnizeniaMravcov; // pole reprezentujuce, kde nastal ubytok mravcov z dovodu znizenia energie na konci kroku
        private int[,] pocetMravcovOdisloZnizenimEnergie; // pole reprezentujuce kolko mravcov odislo z dovodu znizenia energie


        private int casExistencieMraveniska;
        private int rozmer;
        private int pocet = 0;
        private int pocetTypovMravcovZaciatok = 0;
        private FazaMraveniska fazaMraveniska;
        private int mnzostvoPotravy;
        private int pocetSkaly;
        private int pocetPrazdnaZem;
        private int pocetMravcovTypu1;
        private int pocetMravcovTypu2;
        private int pocetMravcovTypu3;
        private int pocetMravcovTypu4;
        private int cisloNasledujucehoMravca;
        private int pocetMravcovTypu1Celkovo;
        private int pocetMravcovTypu2Celkovo;
        private int pocetMravcovTypu3Celkovo;
        private int pocetMravcovTypu4Celkovo;
        private int mnozstvoPotravyCelkovo;

        public Mravenisko(int zaciatocneMnozstvoPotravy, int pocetSkaly, int pocetPrazdnaZem,
            int zaciatocnyPocetMravcovTypu1, int zaciatocnyPocetMravcovTypu2, int zaciatocnyPocetMravcovTypu3,
            int zaciatocnyPocetMravcovTypu4, int rozmerMraveniska)
        {
            mraveniskoMravce = new List<PohybujuceSaObjekty>[rozmerMraveniska, rozmerMraveniska];
            mraveniskoTypyPolicok = new NepohybujuceSaObjekty[rozmerMraveniska, rozmerMraveniska];
            mraveniskoMravcePredPohybom = new List<PohybujuceSaObjekty>[rozmerMraveniska, rozmerMraveniska];

            for (int i = 0; i < rozmerMraveniska; i++)
                for (int j = 0; j < rozmerMraveniska; j++)
                    mraveniskoMravce[i, j] = new List<PohybujuceSaObjekty>();

            Console.WriteLine(rozmerMraveniska);

            NastavRozmerMraveniska(rozmerMraveniska);
            NastavPocetSkaly(pocetSkaly);

            casExistencieMraveniska = 0;
            mnzostvoPotravy = 0;
            pocetPrazdnaZem = 0;
            pocetMravcovTypu1 = 0;
            pocetMravcovTypu2 = 0;
            pocetMravcovTypu3 = 0;
            pocetMravcovTypu4 = 0;
            cisloNasledujucehoMravca = 0;

            if (zaciatocnyPocetMravcovTypu1 > 0) pocetTypovMravcovZaciatok++;
            if (zaciatocnyPocetMravcovTypu2 > 0) pocetTypovMravcovZaciatok++;
            if (zaciatocnyPocetMravcovTypu3 > 0) pocetTypovMravcovZaciatok++;
            if (zaciatocnyPocetMravcovTypu4 > 0) pocetTypovMravcovZaciatok++;

            pocetMravcovTypu1Celkovo = 0;
            pocetMravcovTypu2Celkovo = 0;
            pocetMravcovTypu3Celkovo = 0;
            pocetMravcovTypu4Celkovo = 0;

            mnozstvoPotravyCelkovo = 0;

            GenerovaniePrazdnaZem(rozmerMraveniska * rozmerMraveniska);
            GenerovanieSkaly(pocetSkaly);
            GenerovaniePotrava(zaciatocneMnozstvoPotravy);
            GenerovanieMravceTypu1(zaciatocnyPocetMravcovTypu1);
            GenerovanieMravceTypu2(zaciatocnyPocetMravcovTypu2);
            GenerovanieMravceTypu3(zaciatocnyPocetMravcovTypu3);
            GenerovanieMravceTypu4(zaciatocnyPocetMravcovTypu4);

            InicializujPoliaReprezuntujceStavyPreVypis();
        }

        private void GenerovaniePotrava(int zaciatocneMnozstvoPotravy)
        {
            for (int i = 0; i < zaciatocneMnozstvoPotravy; i++) PridaniePotravy();
        }
        private void GenerovanieSkaly(int pocetSkaly)
        {
            List<int[]> volnePozicie = VyberPozicii(pocetSkaly, NajdenieVhodnychPozicii(TypyObjektov.prazdnaZem));

            foreach (int[] pozicia in volnePozicie)
            {
                Skala skala = new Skala(pozicia[0], pozicia[1], true, true);
                mraveniskoTypyPolicok[pozicia[0], pozicia[1]] = skala;
                HlaskyCinnostiMravcovStavObjektov.SkalaVznikla(casExistencieMraveniska, skala.ZistiXSuradnicu(),
                                                                skala.ZistiYSuradnicu());
            }
        }
        private void GenerovaniePrazdnaZem(int pocetPrazdnaZem)
        {
            List<int[]> volnePozicie = VyberPozicii(pocetPrazdnaZem, NajdenieVhodnychPozicii(TypyObjektov.prazdnaZem));

            foreach (int[] pozicia in volnePozicie)
            {
                PridaniePrazdnaZemKonkretnaPozicia(pozicia[0], pozicia[1]);
            }
        }
        private void GenerovanieMravceTypu1(int pocetMravcovTypu1)
        {
            PridanieMravcov(TypyMravcov.MravecTypu1, pocetMravcovTypu1);

        }
        private void GenerovanieMravceTypu2(int pocetMravcovTypu2)
        {
            PridanieMravcov(TypyMravcov.MravecTypu2, pocetMravcovTypu2);
        }
        private void GenerovanieMravceTypu3(int pocetMravcovTypu3)
        {
            PridanieMravcov(TypyMravcov.MravecTypu3, pocetMravcovTypu3);
        }
        private void GenerovanieMravceTypu4(int pocetMravcovTypu4)
        {
            PridanieMravcov(TypyMravcov.MravecTypu4, pocetMravcovTypu4);
        }

        private void PridanieMravcov(TypyMravcov typyMravcov, int pocetMravcov)
        {
            List<int[]> volnePozicie = VyberPoziciiPreMravca(pocetMravcov, NajdenieVhodnychPoziciiPreMravca(TypyObjektov.potrava, typyMravcov), typyMravcov);

            foreach (int[] pozicia in volnePozicie)
            {
                PridanieMravcaKonkretnaPozicia(typyMravcov, pozicia[0], pozicia[1], Konstanty.maximumEnergiaMravec,
                    casExistencieMraveniska);
            }
        }
        private void PridaniePotravy()
        {
            List<int[]> volnePozicie = VyberPozicii(1, NajdenieVhodnychPozicii(TypyObjektov.prazdnaZem));

            foreach (int[] pozicia in volnePozicie)
            {
                ZnizenieDanehoPoctuNepohybujuceSaObjekty(pozicia);
                Potrava potrava = new Potrava(pozicia[0], pozicia[1], true, true);
                mraveniskoTypyPolicok[pozicia[0], pozicia[1]] = potrava;
                HlaskyCinnostiMravcovStavObjektov.PotravaVzniklaNaPolicku(casExistencieMraveniska, potrava.ZistiXSuradnicu(),
                                                                            potrava.ZistiYSuradnicu(), potrava.ZistiMnozstvoEnergia());
                ZvysPocetPotravy();
            }
        }
        public void PridanieMravcaKonkretnaPozicia(TypyMravcov typyMravcov, int xSuradnica, int ySuradnica, int energia, int cas)
        {
            Mravec mravec;
            mravec = new Mravec(xSuradnica, ySuradnica, true, true, typyMravcov, cisloNasledujucehoMravca, energia);
            mraveniskoMravce[xSuradnica, ySuradnica].Add(mravec);
            //
            cisloNasledujucehoMravca++;

            pocet++;

            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1: ZvysPocetMravcovTypu1(); break;
                case TypyMravcov.MravecTypu2: ZvysPocetMravcovTypu2(); break;
                case TypyMravcov.MravecTypu3: ZvysPocetMravcovTypu3(); break;
                case TypyMravcov.MravecTypu4: ZvysPocetMravcovTypu4(); break;
            }
            HlaskyCinnostiMravcovStavObjektov.MravecVznikolNaPolickuSoZaciatocnouEnergiou(cas, mravec.ZistiIdMravca(),
                                                                             (int)mravec.ZistiTypyMravcov() + 1,
                                                                             mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu(),
                                                                             energia);
            Console.WriteLine(pocet);
        }
        public void PridaniePrazdnaZemKonkretnaPozicia(int xSuradnica, int ySuradnica)
        {
            int[] pozicia = new int[2];
            pozicia[0] = xSuradnica;
            pozicia[1] = ySuradnica;
            ZnizenieDanehoPoctuNepohybujuceSaObjekty(pozicia);

            PrazdnaZem prazdnaZemV = new PrazdnaZem(xSuradnica, ySuradnica, true, true);
            mraveniskoTypyPolicok[xSuradnica, ySuradnica] = prazdnaZemV;
            ZvysPocetPrazdnaZem();

        }

        //odstranenie mravca podla jeho id
        public void OdstranenieMravca(Suradnice suradnice, int cisloMravca)
        {
            Mravec mravec = default(Mravec);

            foreach (Mravec mravecHladany in mraveniskoMravce[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()])
                if (mravecHladany.ZistiIdMravca() == cisloMravca) mravec = mravecHladany;

            if (mravec != default(Mravec)) mraveniskoMravce[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()].Remove(mravec);

            ZnizeniePoctuMravcov(mravec);
        }

        //najdenie vhodnych pozicii na mravenisku, pre umiestnenie neveho objektu
        private List<int[]> NajdenieVhodnychPozicii(TypyObjektov typyObjektov)
        {
            List<int[]> pozicie = new List<int[]>();
            for (int i = 0; i < ZistiRozmerMraveniska(); i++)
            {
                for (int j = 0; j < ZistiRozmerMraveniska(); j++)
                {
                    if (mraveniskoTypyPolicok[i, j] == default(NepohybujuceSaObjekty) || mraveniskoTypyPolicok[i, j].ZistiTypObjektu() ==
                        TypyObjektov.prazdnaZem ||
                        mraveniskoTypyPolicok[i, j].ZistiTypObjektu() == typyObjektov)
                    {
                        int[] pozicia = new int[2];
                        pozicia[0] = i;
                        pozicia[1] = j;
                        pozicie.Add(pozicia);
                    }
                }
            }

            return pozicie;
        }
        //najdenie vhodnych pozicii na mravenisku, pomocou NajdenieVhodnychPozicii
        private List<int[]> VyberPozicii(int pocetPoziciiNaVybratie, List<int[]> pozicie)
        {
            int pocetVolnychPoziciie = pozicie.Count;
            List<int[]> vybranePozicie = new List<int[]>();

            for (int i = 0; i < Math.Min(pocetPoziciiNaVybratie, pocetVolnychPoziciie); i++)
            {
                int indexPozicie = GenerovanieHodnot.random.Next(0, pozicie.Count);
                int[] pozicia = pozicie[indexPozicie];
                vybranePozicie.Add(pozicia);
                pozicie.RemoveAt(indexPozicie);
            }

            return vybranePozicie;
        }
        //najdenie vhodnych pozicii pre mravca
        private List<int[]> NajdenieVhodnychPoziciiPreMravca(TypyObjektov typyObjektov, TypyMravcov typyMravcov)
        {
            List<int[]> pozicie = new List<int[]>();

            for (int i = 0; i < ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < ZistiRozmerMraveniska(); j++)
                    if ((mraveniskoTypyPolicok[i, j] == default(NepohybujuceSaObjekty) ||
                        mraveniskoTypyPolicok[i, j].ZistiTypObjektu() == TypyObjektov.prazdnaZem ||
                        mraveniskoTypyPolicok[i, j].ZistiTypObjektu() == typyObjektov) &&
                        (mraveniskoMravce[i, j].Count == 0 ||
                        (mraveniskoMravce[i, j][0] as Mravec).ZistiTypyMravcov() == typyMravcov))
                    {
                        int[] pozicia = new int[2];
                        pozicia[0] = i;
                        pozicia[1] = j;
                        pozicie.Add(pozicia);
                    }

            return pozicie;
        }
        //najdenie vhodnych pozicii pre mravca
        private List<int[]> VyberPoziciiPreMravca(int pocetPoziciiNaVybratie, List<int[]> pozicie,
            TypyMravcov typyMravcov)
        {
            List<int[]> pozicieNove = new List<int[]>();
            int[] pozicia;

            int pocetVolnychPoziciiNaVybratieTyp = Math.Min((rozmer * rozmer - ZistiPocetSkaly()) / Math.Max(pocetTypovMravcovZaciatok,1), pocetPoziciiNaVybratie);

            for (int i = 0; i < pocetVolnychPoziciiNaVybratieTyp; i++)
            {
                int index = GenerovanieHodnot.random.Next(0, pozicie.Count);
                pozicia = new int[2];
                pozicia = pozicie[index];
                pozicieNove.Add(pozicia);
                pozicie.RemoveAt(index);
            }

            while (pozicieNove.Count < pocetPoziciiNaVybratie)
            {
                int index = GenerovanieHodnot.random.Next(0, pozicieNove.Count);
                pozicia = new int[2];
                pozicia = pozicieNove[index];
                pozicieNove.Add(pozicia);
            }

            return pozicieNove;
        }

        //znizenie poctu daneho typu nepohybujucich objektov
        private void ZnizenieDanehoPoctuNepohybujuceSaObjekty(int[] pozicia)
        {
            if ((mraveniskoTypyPolicok[pozicia[0], pozicia[1]]) != null)
                switch (mraveniskoTypyPolicok[pozicia[0], pozicia[1]].ZistiTypObjektu())
                {
                    case TypyObjektov.prazdnaZem: ZnizPocetPrazdnaZem(); break;
                    case TypyObjektov.potrava:
                        {
                            ZnizPocetPotravy();
                            Potrava potrava = mraveniskoTypyPolicok[pozicia[0], pozicia[1]] as Potrava;
                            HlaskyCinnostiMravcovStavObjektov.PotravaZanikla(casExistencieMraveniska,
                                                                            potrava.ZistiXSuradnicu(),
                                                                            potrava.ZistiYSuradnicu());
                        }
                        break;
                }
        }
        //znizenie poctu mravcov
        private void ZnizeniePoctuMravcov(Mravec mravec)
        {
            if (mravec != default(Mravec))
            {
                switch (mravec.ZistiTypyMravcov())
                {
                    case TypyMravcov.MravecTypu1: ZnizPocetMravcovTypu1(); break;
                    case TypyMravcov.MravecTypu2: ZnizPocetMravcovTypu2(); break;
                    case TypyMravcov.MravecTypu3: ZnizPocetMravcovTypu3(); break;
                    case TypyMravcov.MravecTypu4: ZnizPocetMravcovTypu4(); break;
                }
            }
        }

        private void NastavRozmerMraveniska(int rozmerMraveniska)
        {
            rozmer = rozmerMraveniska;
        }
        private void NastavPocetSkaly(int pocetSkaly)
        {
            this.pocetSkaly = pocetSkaly;
        }
        private void ZvysPocetPotravy()
        {
            mnzostvoPotravy++;
            mnozstvoPotravyCelkovo++;
        }
        private void ZnizPocetPotravy()
        {
            mnzostvoPotravy--;

            if (mnzostvoPotravy < Konstanty.minimumPotravy)
                for (int i = 0; i < Konstanty.minimumPotravy - mnzostvoPotravy; i++) PridaniePotravy();

        }
        private void ZvysPocetPrazdnaZem()
        {
            pocetPrazdnaZem++;
        }
        private void ZnizPocetPrazdnaZem()
        {
            pocetPrazdnaZem--;
        }
        private void ZvysPocetMravcovTypu1()
        {
            pocetMravcovTypu1++;
            pocetMravcovTypu1Celkovo++;
        }
        private void ZnizPocetMravcovTypu1()
        {
            pocetMravcovTypu1--;
        }
        private void ZvysPocetMravcovTypu2()
        {
            pocetMravcovTypu2++;
            pocetMravcovTypu2Celkovo++;
        }
        private void ZnizPocetMravcovTypu2()
        {
            pocetMravcovTypu2--;
        }
        private void ZvysPocetMravcovTypu3()
        {
            pocetMravcovTypu3++;
            pocetMravcovTypu3Celkovo++;
        }
        private void ZnizPocetMravcovTypu3()
        {
            pocetMravcovTypu3--;
        }
        private void ZvysPocetMravcovTypu4()
        {
            pocetMravcovTypu4++;
            pocetMravcovTypu4Celkovo++;
        }
        private void ZnizPocetMravcovTypu4()
        {
            pocetMravcovTypu4--;
        }
        //zvysi cas a zaroven resetuje niektore polia pre nasledujuci krok
        public void ZvysCasExistencieMraveniska()
        {
            casExistencieMraveniska++;

            InicializujPoliaReprezuntujceStavyPreVypis();
        }
        public void NavysVekMravcov()
        {
            for (int i = 0; i < ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < ZistiRozmerMraveniska(); j++)
                    foreach (Mravec mravec in mraveniskoMravce[i, j])
                    {
                        mravec.NavysenieVekuMravca();
                    }

        }
        //spravuje policka s potravou
        //kde je potrava uz vycerpana
        public void NajdeniePotravyZjedena()
        {
            for (int i = 0; i < ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < ZistiRozmerMraveniska(); j++)
                    if (mraveniskoTypyPolicok[i, j].ZistiTypObjektu() == TypyObjektov.potrava)
                    {
                        if (mraveniskoTypyPolicok[i, j].ZistiExistenciu() == false) PridaniePrazdnaZemKonkretnaPozicia(i, j);
                    }
        }
        //spravuje posun mravca, ked ide dopredu
        public void PosunMravca(Suradnice suradnice, Mravec mravecZmeneny)
        {
            int xSuradnica = suradnice.ZistiXSuradnicu();
            int ySuradnica = suradnice.ZistiYSuradnicu();
            mraveniskoMravce[xSuradnica, ySuradnica].Remove(mravecZmeneny);
            mraveniskoMravce[mravecZmeneny.ZistiXSuradnicu(), mravecZmeneny.ZistiYSuradnicu()].Add(mravecZmeneny);
        }
        public void NastavFazaMraveniska(FazaMraveniska fazaMraveniska)
        {
            this.fazaMraveniska = fazaMraveniska;
        }
        public void NastavPolickoBojPrechadzajuce(PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji, int x, int y)
        {
            polickaPriPrechadzajucomBojiPole[x, y].Add(polickaPriPrechadzajucomBoji);
        }
        public void NastavPolickoBojNaPolicku(PolickaPriBojiNaPolicku polickaPriBojiNaPolicku, int x, int y)
        {
            polickaPriBojiNaPolickuPole[x, y] = polickaPriBojiNaPolicku;
        }
        public void NastavParenie(int x, int y, bool pravdivost)
        {
            miestaParenia[x, y] = pravdivost;
        }
        public void NastavJedenie(int x, int y, bool pravdivost)
        {
            miestaJedenia[x, y] = pravdivost;
        }
        public void NastavUbytokMravcovPoZnizeniEnergie(int x, int y, bool pravdivost)
        {
            miestaZnizeniaMravcov[x, y] = pravdivost;
        }
        public void ZvysPocetMravcovOdisliZnizenimEnergie(int x, int y)
        {
            pocetMravcovOdisloZnizenimEnergie[x, y]++;
        }

        public int ZistiRozmerMraveniska()
        {
            return rozmer;
        }
        public int ZistiPocetSkaly()
        {
            return pocetSkaly;
        }
        public int ZistiPocetPotravy()
        {
            return mnzostvoPotravy;
        }
        public int ZistiPocetPrazdnaZem()
        {
            return pocetPrazdnaZem;
        }
        public int ZistiPocetVsetkychMravcov()
        {
            return ZistiPocetMravcovTypu1() + ZistiPocetMravcovTypu2() + ZistiPocetMravcovTypu3() + ZistiPocetMravcovTypu4();
        }
        public int ZistiPocetMravcovTypu1()
        {
            return pocetMravcovTypu1;
        }
        public int ZistiPocetMravcovTypu2()
        {
            return pocetMravcovTypu2;
        }
        public int ZistiPocetMravcovTypu3()
        {
            return pocetMravcovTypu3;
        }
        public int ZistiPocetMravcovTypu4()
        {
            return pocetMravcovTypu4;
        }
        public int ZistiCasMraveniska()
        {
            return casExistencieMraveniska;
        }
        public int ZistiPocetMravcovOdisliZnizenimEnergie(int x, int y)
        {
            return pocetMravcovOdisloZnizenimEnergie[x, y];
        }

        public int ZistiPocetMravcovTypu1Celkovo()
        {
            return pocetMravcovTypu1Celkovo;
        }
        public int ZistiPocetMravcovTypu2Celkovo()
        {
            return pocetMravcovTypu2Celkovo;
        }
        public int ZistiPocetMravcovTypu3Celkovo()
        {
            return pocetMravcovTypu3Celkovo;
        }
        public int ZistiPocetMravcovTypu4Celkovo()
        {
            return pocetMravcovTypu4Celkovo;
        }
        public int ZistiMnozstvoPotravyCelkovo()
        {
            return mnozstvoPotravyCelkovo;
        }
        public FazaMraveniska ZistiFazaMraveniska()
        {
            return fazaMraveniska;
        }
        public List<PolickaPriPrechadzajucomBoji> ZistiPolickaBojPrechadzajuce(int x, int y)
        {
            return polickaPriPrechadzajucomBojiPole[x, y];
        }
        public PolickaPriBojiNaPolicku ZistiPolickoBojNaPolicko(int x, int y)
        {
            return polickaPriBojiNaPolickuPole[x, y];
        }
        public bool ZistiParenie(int x, int y)
        {
            return miestaParenia[x, y];
        }
        public bool ZistiJedenie(int x, int y)
        {
            return miestaJedenia[x, y];

        }
        public bool ZistiUbytokMravcovPoZnizeniEnergie(int x, int y)
        {
            return miestaZnizeniaMravcov[x, y];
        }

        //zisti typ nepohybujuceho objektu na suradniciach
        public TypyObjektov ZistiCoJeNaDanychSuradniciach(Suradnice suradnice)
        {
            int xSuradnica = suradnice.ZistiXSuradnicu();
            int ySuradnica = suradnice.ZistiYSuradnicu();

            if (mraveniskoTypyPolicok[xSuradnica, ySuradnica] == default(NepohybujuceSaObjekty)) return default(TypyObjektov);

            return mraveniskoTypyPolicok[xSuradnica, ySuradnica].ZistiTypObjektu();
        }
        public NepohybujuceSaObjekty VratObjektNepohybujuceSaNaDanychSuradniciach(Suradnice suradnice)
        {
            return mraveniskoTypyPolicok[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()];
        }
        public List<PohybujuceSaObjekty> VratObjektPohybujuceSaNaDanychSuradniciach(Suradnice suradnice)
        {
            return mraveniskoMravce[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()];  

        }
        public List<PohybujuceSaObjekty> VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(Suradnice suradnice)
        {
            if (ZistiFazaMraveniska() == FazaMraveniska.poNastaveniSmerOtocenia || ZistiFazaMraveniska() == FazaMraveniska.poNastaveniSmerAktivnehoPohybuStatie)
                return mraveniskoMravcePredPohybom[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()];
            else
                return mraveniskoMravce[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()];
        }

        private void InicializujPoliaReprezuntujceStavyPreVypis()
        {
            polickaPriPrechadzajucomBojiPole = new List<PolickaPriPrechadzajucomBoji>[rozmer, rozmer];
            polickaPriBojiNaPolickuPole = new PolickaPriBojiNaPolicku[rozmer, rozmer];
            miestaParenia = new bool[rozmer, rozmer];
            miestaJedenia = new bool[rozmer, rozmer];
            miestaZnizeniaMravcov = new bool[rozmer, rozmer];
            pocetMravcovOdisloZnizenimEnergie = new int[rozmer, rozmer];

            for (int i = 0; i < ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < ZistiRozmerMraveniska(); j++)
                {
                    polickaPriPrechadzajucomBojiPole[i, j] = new List<PolickaPriPrechadzajucomBoji>();
                }

            for (int i = 0; i < rozmer; i++)
                for (int j = 0; j < rozmer; j++)
                {
                    miestaParenia[i, j] = false;
                    miestaJedenia[i, j] = false;
                    miestaZnizeniaMravcov[i, j] = false;

                    pocetMravcovOdisloZnizenimEnergie[i, j] = 0;
                }

            for(int i = 0; i < rozmer; i++)
                for (int j=0; j < rozmer; j++)
                {
                    mraveniskoMravcePredPohybom[i, j] = new List<PohybujuceSaObjekty>();

                    foreach (PohybujuceSaObjekty pohybujuceSa in VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)))
                        mraveniskoMravcePredPohybom[i, j].Add(pohybujuceSa);
                }

        }
    }
}
