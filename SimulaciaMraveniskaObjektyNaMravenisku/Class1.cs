using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatoveStruktury;
using SimulaciaMraveniskaObjektyNaMravenisku;
using SimulaciaMraveniskaMravenisko;
using CodEx;
using SimulaciaMraveniskaSimulacia;
using SimulaciaMraveniskaUdalostiSpravaUdalosti;
using SimulaciaMraveniskaHlasky;

//objekty simulacie, sprava simulacie


namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //konstantne sucasti programu
    public static class Konstanty
    {
        public const int maximumEnergiaPotrava = 101;
        public const int minimumEnergiaPotrava = 50;
        public const int maximumEnergiaMravec = 101;
        public const int minusHodnotaPriKrmeni = 5;
        public static int minimumPotravy;
        public const int dobaPrestavky = 2000;
        public static bool jeNastaveneMiestoUlozenia = false;
        public static string miestoUlozenia = "";
        public static System.IO.StreamWriter zapisovacUdajov;
        private static int nasobokDobyPrestavky = 1;

        public static StrategiaMravca strategiaMravcaTypu1;
        public static StrategiaMravca strategiaMravcaTypu2;
        public static StrategiaMravca strategiaMravcaTypu3;
        public static StrategiaMravca strategiaMravcaTypu4;

        public static CinnostiMravcov[,] cinnostiMravcovTypu1 = {{CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.otocSaVlavo, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.otocSaVlavo, CinnostiMravcov.chodDopreduObrana },
        { CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa },
        { CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.paritSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduUtok, CinnostiMravcov.chodDopreduUtok },
        { CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa},
        };
        public static CinnostiMravcov[,] cinnostiMravcovTypu2 =
        {
            {CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.otocSaVlavo, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduUtok, CinnostiMravcov.chodDopreduUtok},
            {CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.najedzSa, CinnostiMravcov.chodDopreduUtok },
            {CinnostiMravcov.paritSa, CinnostiMravcov.paritSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.paritSa, CinnostiMravcov.chodDopreduObrana, CinnostiMravcov.chodDopreduUtok, CinnostiMravcov.chodDopreduUtok},
            {CinnostiMravcov.najedzSa, CinnostiMravcov.paritSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.najedzSa, CinnostiMravcov.chodDopreduUtok, CinnostiMravcov.chodDopreduUtok },
        };

        public static void NastavStrategiu1()
        {
            strategiaMravcaTypu1 = new StrategiaMravca(cinnostiMravcovTypu1);
        }
        public static void NastavStrategiu2()
        {
            strategiaMravcaTypu2 = new StrategiaMravca(cinnostiMravcovTypu2);
        }
        public static void NastavStrategiu3(CinnostiMravcov[,] cinnostMravcov)
        {
            strategiaMravcaTypu3 = new StrategiaMravca(cinnostMravcov);
        }
        public static void NastavStrategiu4(CinnostiMravcov[,] cinnostiMravcov)
        {
            strategiaMravcaTypu4 = new StrategiaMravca(cinnostiMravcov);
        }
        public static void NastavMinimumPotravy(int Potrava)
        {
            minimumPotravy = Potrava;
        }
        public static void NastavMiestoUlozenia(string miesto)
        {
            miestoUlozenia = miesto;

            if (miesto != "")
            {
                zapisovacUdajov = new System.IO.StreamWriter(miestoUlozenia);

                ; jeNastaveneMiestoUlozenia = true;
            }
            else jeNastaveneMiestoUlozenia = false;

        }
        public static void NastavNasobokDobyPrestavky(int nasobok)
        {
            nasobokDobyPrestavky = nasobok;
        }
        public static int ZistiVyslednuDobuPrestavku()
        {
            return dobaPrestavky * nasobokDobyPrestavky;
        }
    }

    //hodnoty, ktore budu nastavovanie pocas beho simulacie
    //pripadne generovanie hodnot
    public static class NastaveneHodnotyPocasKrokov
    {
        public static Random random = new Random();

        private static bool parenie;
        private static bool chcemPokracovat;

        public static void NastavParenie(bool parenieP)
        {
            parenie = parenieP;
        }
        public static void NastavPokracovanie(bool pokracovatP)
        {
            chcemPokracovat = pokracovatP;
        }

        public static bool ZistiParenie()
        {
            return parenie;
        }
        public static bool ZistiPokracovanie()
        {
            return chcemPokracovat;
        }

        public static int ZistiHodnotuEnergiePotrava()
        {
            return random.Next(Konstanty.minimumEnergiaPotrava, Konstanty.maximumEnergiaPotrava);
        }
    }

    //typy objektov, ktore budu na mraveniskus
    public enum TypyObjektov
    {
        prazdnaZem, //mravec na nu moze vstupiy
        skala, //mravec na nu nemoze vstupit
        potrava, //mravec na nu moze vstupit a ziskat z nej energiu
        mravec
    }

    //typy mravcov
    public enum TypyMravcov
    {
        MravecTypu1,
        MravecTypu2,
        MravecTypu3,
        MravecTypu4
    }

    //cinnosti mravcov
    public enum CinnostiMravcov
    {
        zostan, //zostane stat, pri boji na policku je zvyhodneny
        otocSaVlavo, //otoci sa vlavo na policku
        chodDopreduUtok,//ide dopredu, pri pripadnom strete s mravcami ineho typu, ktore idu opacne bojuje
        chodDopreduObrana,//ide dopredu, pri pripadnom strete s mravcami ineho typu, kde idu opacne uskakuje
                          //dojde pritom k znizeniu jeho energie
        paritSa,//mravec sa bude chiet parit, pokial bude mat dostatok energie a bude na jeho policku aspon jeden, taky
                //isty mravec, toho isteho typu, tak sa mu to podari 
        najedzSa//mravec sa bude chciet najest na danom policku, ak tam bude potrava, tak sa mu to podari
    }

    //smery pohybu mravcov
    public enum SmerPohybu
    {
        s,
        j,
        v,
        z
    }

    //typy policok pred mravcom a na ktorych je mravec
    public enum TypyPolicok
    {
        prazdnaZem,
        skala,
        potrava,
        priatelPrazdnaZem,//policko s prazdnou zemou a mravcom toho isteho typu, vzhladom ktoremu zistujeme typ policka
        priatelPotrava,//policko s potravou a mravcom toho isteho typu, vzhladom ktorum zistujeme typ policka
        nepriatelPrazdnaZem,//policko s prazdnou zemou a mravcom toho ineho typu, vzhladom ktoremu zistujeme typ policka
        nepriatelPotrava//policko s potravou a mravcom ineho typu, vzhladom ktoremu zistujeme typ policka
    }

    //suradnice vsetkych objektov
    public class Suradnice
    {
        private int xSuradnica, ySuradnica;

        public void NastavXSuradnicu(int xSuradnica)
        {
            this.xSuradnica = xSuradnica;
        }
        public void NastavYSuradnicu(int ySuradnica)
        {
            this.ySuradnica = ySuradnica;
        }
        public int ZistiXSuradnicu()
        {
            return xSuradnica;
        }
        public int ZistiYSuradnicu()
        {
            return ySuradnica;
        }

        public Suradnice(int xSuradnica, int ySuradnica)
        {
            NastavXSuradnicu(xSuradnica);
            NastavYSuradnicu(ySuradnica);
        }
    }

    //trieda reprezentujuca smer pohybu
    class DoprednyPohyb
    {
        private int dopreduX;
        private int dopreduY;
        private SmerPohybu smer;

        public void OtocenieVlavo()
        {
            switch (smer)
            {
                case SmerPohybu.z: SmerJ(); break;
                case SmerPohybu.v: SmerS(); break;
                case SmerPohybu.j: SmerV(); break;
                case SmerPohybu.s: SmerZ(); break;
            }
        }

        public void SmerS()
        {
            dopreduX = 0;
            dopreduY = -1;
            smer = SmerPohybu.s;
        }

        public void SmerJ()
        {
            dopreduX = 0;
            dopreduY = 1;
            smer = SmerPohybu.j;
        }

        public void SmerZ()
        {
            dopreduY = 0;
            dopreduX = -1;
            smer = SmerPohybu.z;
        }

        public void SmerV()
        {
            smer = SmerPohybu.v;
            dopreduY = 0;
            dopreduX = 1;
        }

        public SmerPohybu ZistiSmerPohybu()
        {
            return smer;
        }

        public void NastavSmerPohybu(SmerPohybu smer)
        {
            this.smer = smer;
        }

        public DoprednyPohyb()
        {
            Random random = new Random();

            int smerPohybu = random.Next(4);

            switch ((SmerPohybu)smerPohybu)
            {
                case SmerPohybu.s: SmerS(); break;
                case SmerPohybu.j: SmerJ(); break;
                case SmerPohybu.z: SmerZ(); break;
                case SmerPohybu.v: SmerV(); break;
            }
        }

    }

    //trieda, ktora je predkom vsetkych objektov na mravenusku
    public class ObjektyObecne
    {
        //zakladne udaje o objekte
        protected Suradnice suradnice;
        protected Suradnice predchadzajuceSuradnice;
        private TypyObjektov typyObjektov;
        private string reprezentaciaObjektu;
        private bool viditelnost;
        private bool existencia;
        private bool pohybujemSa;

        //nastavenie zakladnych udajov o objekte
        public void NastavXSuradnicu(int xSuradnica)
        {
            suradnice.NastavXSuradnicu(xSuradnica);
        }
        public void NastavYSuradnicu(int ySuradnica)
        {
            suradnice.NastavYSuradnicu(ySuradnica);
        }
        public void NastavXSuradnicuPredchadzajuceSuradnice(int xSuradnica)
        {
            predchadzajuceSuradnice.NastavXSuradnicu(xSuradnica);
        }
        public void NastavYSuradnicuPredchadzajuceSuradnice(int ySuradnica)
        {
            predchadzajuceSuradnice.NastavYSuradnicu(ySuradnica);
        }
        public void NastavTypyObjektov(TypyObjektov typyObjektov)
        {
            this.typyObjektov = typyObjektov;
        }
        public void NastavReprezentaciaObjektu(string reprezentaciaObjektu)
        {
            this.reprezentaciaObjektu = reprezentaciaObjektu;
            SpravaZobrazovaniaObjektu();
        }
        public void NastavViditelnost(bool viditelnost)
        {
            this.viditelnost = viditelnost;

            if (viditelnost) ObjektJeViditelny();
            else ObjektNieJeViditelny();
        }
        public void NastavExistencia(bool existencia)
        {
            this.existencia = existencia;

            if (existencia) ObjektExistuje();
            else ObjektNeExistuje();
        }
        public void NastavPohybujemSa(bool pohybujemSa)
        {
            this.pohybujemSa = pohybujemSa;
        }

        //zistenie zakladnych udajov o objekte
        public int ZistiXSuradnicu()
        {
            return suradnice.ZistiXSuradnicu();
        }
        public int ZistiYSuradnicu()
        {
            return suradnice.ZistiYSuradnicu();
        }
        public int ZistiXSuradnicuPredchadzajuceSuradnice()
        {
            return predchadzajuceSuradnice.ZistiXSuradnicu();
        }
        public int ZistiYSuradnicuPredchadzajuceSuradnice()
        {
            return predchadzajuceSuradnice.ZistiYSuradnicu();
        }
        public TypyObjektov ZistiTypObjektu()
        {
            return typyObjektov;
        }
        public bool ZistiViditelnost()
        {
            return viditelnost;
        }
        public bool ZistiExistenciu()
        {
            return existencia;
        }
        public bool ZistiPohybujemSa()
        {
            return pohybujemSa;
        }

        //sprava objekty
        protected void KoniecObjektu()
        {
            NastavExistencia(false);
            NastavViditelnost(false);
        }
        private void ObjektJeViditelny() { }
        private void ObjektNieJeViditelny() { }
        private void ObjektExistuje() { }
        private void ObjektNeExistuje() { }
        private void SpravaZobrazovaniaObjektu() { }

        public ObjektyObecne(int xSuradnica, int ySuradnica, TypyObjektov typyObjektov,
            string reprezentaciaObjektu, bool viditelnost, bool existencia, bool pohybujemSa)
        {
            suradnice = new Suradnice(xSuradnica, ySuradnica);
            predchadzajuceSuradnice = new Suradnice(-1, 0);
            NastavTypyObjektov(typyObjektov);
            NastavReprezentaciaObjektu(reprezentaciaObjektu);
            NastavViditelnost(viditelnost);
            NastavExistencia(existencia);
            NastavPohybujemSa(pohybujemSa);
        }

    }

    //trieda, ktora je predkom vsetkych objektov, ktore sa nepohybuju
    public class NepohybujuceSaObjekty : ObjektyObecne
    {
        private bool jeMozneVstupit;

        public void NastavJeMozneVstupit(bool jeMozneVstupit)
        {
            this.jeMozneVstupit = jeMozneVstupit;
        }

        public bool ZistiJeMozneVstupit()
        {
            return jeMozneVstupit;
        }

        public NepohybujuceSaObjekty(int xSuradnica, int ySuradnica, TypyObjektov typyObjektov,
            string reprezentaciaObjektu, bool viditelnost, bool existencia, bool jeMozneVstupit) :
            base(xSuradnica, ySuradnica,
                typyObjektov, reprezentaciaObjektu, viditelnost, existencia, false)
        {
            NastavJeMozneVstupit(jeMozneVstupit);
        }
    }

    //trieda, ktora je predkom vsetkych objektov, ktore sa pohybuju
    public class PohybujuceSaObjekty : ObjektyObecne
    {
        public PohybujuceSaObjekty(int xSuradnica, int ySuradnica, TypyObjektov typyObjektov, string reprezentaciaObjektu,
            bool viditelnost, bool existencia) : base(xSuradnica, ySuradnica, typyObjektov, reprezentaciaObjektu,
                viditelnost, existencia, true)
        { }

    }

    //trieda reprezentujuca prazdnu zem
    public class PrazdnaZem : NepohybujuceSaObjekty
    {
        public PrazdnaZem(int xSuradnica, int ySuradnica,
            bool viditelnost, bool existencia) : base(xSuradnica, ySuradnica, TypyObjektov.prazdnaZem, "",
                viditelnost, existencia, true)
        { }

    }

    //trieda reprezentujuca skalu
    public class Skala : NepohybujuceSaObjekty
    {
        public Skala(int xSuradnica, int ySuradnica, bool viditelnost, bool existencia) :
            base(xSuradnica, ySuradnica, TypyObjektov.skala, "", viditelnost, existencia, false)
        { }
    }

    //trieda reprezentujuca potravu
    public class Potrava : NepohybujuceSaObjekty
    {
        private int mnozstvoEnergia;

        private void NastavMnozstvoEnergia()
        {
            mnozstvoEnergia = NastaveneHodnotyPocasKrokov.ZistiHodnotuEnergiePotrava();
        }

        public int ZistiMnozstvoEnergia()
        {
            return mnozstvoEnergia;
        }

        public int ZiadamEnergia(int energiaMravca)
        {
            int energiaPreMravca = EnergiaPreMravca(energiaMravca);
            ZnizMnozstvoEnergia(energiaPreMravca);
            return energiaPreMravca;
        }

        private void ZnizMnozstvoEnergia(int znizEnergia)
        {
            mnozstvoEnergia -= znizEnergia;

            if (mnozstvoEnergia <= 0) EnergiaPodJedna();
        }

        private void EnergiaPodJedna()
        {
            KoniecObjektu();
        }

        private int EnergiaPreMravca(int energiaMravca)
        {
            Random random = new Random();
            return Math.Min(Konstanty.maximumEnergiaMravec - energiaMravca, ZistiMnozstvoEnergia()) / random.Next(1, 4);
        }

        public Potrava(int xSuradnica, int ySuradnica, bool viditelnost, bool existencia) : base
            (xSuradnica, ySuradnica, TypyObjektov.potrava, "", viditelnost, existencia, true)
        {
            NastavMnozstvoEnergia();
        }

    }

    //trieda reprezentujuca mravca
    public class Mravec : PohybujuceSaObjekty
    {
        private int energia;
        private int vek;
        private TypyMravcov typyMravcov;
        private int idMravca;
        private CinnostiMravcov cinnostiMravcov;
        private bool obrana;
        private bool uskok;
        private DoprednyPohyb doprednyPohyb;
        private bool paritSa;


        private void NastavEnergiaMravca(int energia)
        {
            this.energia = energia;
        }
        private void NastavVekMravca()
        {
            vek = 0;
        }
        private void NastavTypMravca(TypyMravcov typyMravcov)
        {
            this.typyMravcov = typyMravcov;
        }
        private void NastavIdMravca(int id)
        {
            idMravca = id;
        }
        private void NastavDoprednyPohyv()
        {
            doprednyPohyb = new DoprednyPohyb();
        }

        public void OverenieZivota()
        {
            if (energia <= 0)
            {
                KoniecObjektu();
            }
        }

        public void NastavUskok(bool uskokPravdivost)
        {
            uskok = uskokPravdivost;
        }
        public void NastavCinnostMravca(CinnostiMravcov cinnostiMravcov)
        {
            this.cinnostiMravcov = cinnostiMravcov;
        }
        public void NastavObrana(bool obrana)
        {
            this.obrana = obrana;
        }
        public void OtocitVlavo()
        {
            doprednyPohyb.OtocenieVlavo();
        }
        public void ChodDopredu(int rozmerMraveniska)
        {
            Suradnice suradnice = ZistiSuradnica();
            Suradnice noveSuradnice = default(Suradnice);


            noveSuradnice = NasledujucePolickoMraveniska.ZistiSuradniceNasledujucehoPolicka(suradnice, ZistiSmerPohybu(),
                                                                                             rozmerMraveniska);

            NastavXSuradnicuPredchadzajuceSuradnice(ZistiXSuradnicu());
            NastavYSuradnicuPredchadzajuceSuradnice(ZistiYSuradnicu());
            NastavXSuradnicu(noveSuradnice.ZistiXSuradnicu());
            NastavYSuradnicu(noveSuradnice.ZistiYSuradnicu());
        }
        public void NajedzSa(int energia)
        {
            this.energia = (this.energia + energia);
            if (this.energia > Konstanty.maximumEnergiaMravec + 1) this.energia = Konstanty.maximumEnergiaMravec;
        }
        public void ZnizEnergia(int energia)
        {
            this.energia -= energia;

            OverenieZivota();
        }
        public void ZvysEnergia()
        {
            energia = (energia + Konstanty.maximumEnergiaMravec / 10);

            if (energia > Konstanty.maximumEnergiaMravec) energia = Konstanty.maximumEnergiaMravec;
        }
        public void NavysenieVekuMravca()
        {
            vek++;
        }
        public void NastavParitSa(bool parenie)
        {
            paritSa = parenie;
        }
        public void NastavSmer(SmerPohybu smer)
        {
            doprednyPohyb.NastavSmerPohybu(smer);
        }

        public int ZistiEnergiaMravca()
        {
            return energia;
        }
        public int ZistiVekMravca()
        {
            return vek;
        }
        public TypyMravcov ZistiTypyMravcov()
        {
            return typyMravcov;
        }
        public int ZistiIdMravca()
        { return idMravca; }
        public CinnostiMravcov ZistiCinnostMravca()
        {
            return cinnostiMravcov;
        }
        public bool ZistiObranaMravca()
        {
            return obrana;
        }
        public SmerPohybu ZistiDoprednyPohyb()
        {
            return doprednyPohyb.ZistiSmerPohybu();
        }
        public bool ZistiUskok()
        {
            return uskok;
        }
        public Suradnice ZistiSuradnica()
        {
            return suradnice;
        }
        public Suradnice ZistiStareSuradnica()
        {
            return predchadzajuceSuradnice;
        }
        public bool ZistiParitSa()
        {
            return paritSa;
        }
        public SmerPohybu ZistiSmerPohybu()
        {
            return doprednyPohyb.ZistiSmerPohybu();
        }


        public Mravec(int xSuradnica, int ySuradnica, bool viditelnost, bool existencia, TypyMravcov typyMravcov, int idMravca, int NastavovanieEnergia) : base
            (xSuradnica, ySuradnica, TypyObjektov.mravec, "", viditelnost, existencia)
        {
            NastavEnergiaMravca(NastavovanieEnergia);
            NastavVekMravca();
            NastavTypMravca(typyMravcov);
            NastavIdMravca(idMravca);
            NastavObrana(false);
            NastavDoprednyPohyv();
            NastavUskok(false);
            NastavCinnostMravca(CinnostiMravcov.zostan);
            NastavParitSa(false);
        }
    }

    //trieda uchovavajuca strategiu mravcov
    public class StrategiaMravca
    {
        CinnostiMravcov[,] strategiaMravca = new CinnostiMravcov[4, 7];

        public CinnostiMravcov ZistiPrazdnaPrazdna()
        {
            return strategiaMravca[0, 0];
        }
        public CinnostiMravcov ZistiPrazdnaSkaly()
        {
            return strategiaMravca[0, 1];
        }
        public CinnostiMravcov ZistiPrazdnaPotrava()
        {
            return strategiaMravca[0, 2];
        }
        public CinnostiMravcov ZistiPrazdnaVpreduPriatelPrazdna()
        {
            return strategiaMravca[0, 3];
        }
        public CinnostiMravcov ZistiPrazdnaVpreduPriatelPotrava()
        {
            return strategiaMravca[0, 4];
        }
        public CinnostiMravcov ZistiPrazdnaVpreduNepriatelPrazdna()
        {
            return strategiaMravca[0, 5];
        }
        public CinnostiMravcov ZistiPrazdnaVpreduNepriatelPotrava()
        {
            return strategiaMravca[0, 6];
        }

        public CinnostiMravcov ZistiPotravaPrazdna()
        {
            return strategiaMravca[1, 0];
        }
        public CinnostiMravcov ZistiPotravaSkaly()
        {
            return strategiaMravca[1, 1];
        }
        public CinnostiMravcov ZistiPotravaPotrava()
        {
            return strategiaMravca[1, 2];
        }
        public CinnostiMravcov ZistiPotravaVpreduPriatelPrazdna()
        {
            return strategiaMravca[1, 3];
        }
        public CinnostiMravcov ZistiPotravaVpreduPriatelPotrava()
        {
            return strategiaMravca[1, 4];
        }
        public CinnostiMravcov ZistiPotravaVpreduNepriatelPrazdna()
        {
            return strategiaMravca[1, 5];
        }
        public CinnostiMravcov ZistiPotravaVpreduNepriatelPotrava()
        {
            return strategiaMravca[1, 6];
        }

        public CinnostiMravcov ZistiPriatelPrazdnaPrazdna()
        {
            return strategiaMravca[2, 0];
        }
        public CinnostiMravcov ZistiPriatelPrazdnaSkaly()
        {
            return strategiaMravca[2, 1];
        }
        public CinnostiMravcov ZistiPriatelPrazdnaPotrava()
        {
            return strategiaMravca[2, 2];
        }
        public CinnostiMravcov ZistiPriatelPrazdnaVpreduPriatelPrazdna()
        {
            return strategiaMravca[2, 3];
        }
        public CinnostiMravcov ZistiPriatelPrazdnaVpreduPriatelPotrava()
        {
            return strategiaMravca[2, 4];
        }
        public CinnostiMravcov ZistiPriatelPrazdnaVpreduNepriatelPrazdna()
        {
            return strategiaMravca[2, 5];
        }
        public CinnostiMravcov ZistiPriatelPrazdnaVpreduNepriatelPotrava()
        {
            return strategiaMravca[2, 6];
        }

        public CinnostiMravcov ZistiPriatelPotravaPrazdna()
        {
            return strategiaMravca[3, 0];
        }
        public CinnostiMravcov ZistiPriatelPotravaSkaly()
        {
            return strategiaMravca[3, 1];
        }
        public CinnostiMravcov ZistiPriatelPotravaPotrava()
        {
            return strategiaMravca[3, 2];
        }
        public CinnostiMravcov ZistiPriatelPotravaVpreduPriatelPrazdna()
        {
            return strategiaMravca[3, 3];
        }
        public CinnostiMravcov ZistiPriatelPotravaVpreduPriatelPotrava()
        {
            return strategiaMravca[3, 4];
        }
        public CinnostiMravcov ZistiPriatelPotravaVpreduNepriatelPrazdna()
        {
            return strategiaMravca[3, 5];
        }
        public CinnostiMravcov ZistiPriatelPotravaVpreduNepriatelPotrava()
        {
            return strategiaMravca[3, 6];
        }

        public CinnostiMravcov ZistiStrategiaPodlaSuradnice(int i, int j)
        {
            return strategiaMravca[i, j];
        }

        public StrategiaMravca(CinnostiMravcov[,] strategiaMravca)
        {
            this.strategiaMravca = strategiaMravca;
        }

    }

}

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

    //objekt reprezentujuci mravenisko a objekty na nom
    public class Mravenisko
    {
        private List<PohybujuceSaObjekty>[,] mraveniskoMravce;
        private NepohybujuceSaObjekty[,] mraveniskoTypyPolicok;

        private int casExistencieMraveniska;
        private int rozmer;

        private int pocet = 0;

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
            for (int i = 0; i < pocetMravcovTypu1; i++) PridanieMravca(TypyMravcov.MravecTypu1);

        }
        private void GenerovanieMravceTypu2(int pocetMravcovTypu2)
        {
            for (int i = 0; i < pocetMravcovTypu2; i++) PridanieMravca(TypyMravcov.MravecTypu2);
        }
        private void GenerovanieMravceTypu3(int pocetMravcovTypu3)
        {
            for (int i = 0; i < pocetMravcovTypu3; i++) PridanieMravca(TypyMravcov.MravecTypu3);
        }
        private void GenerovanieMravceTypu4(int pocetMravcovTypu4)
        {
            for (int i = 0; i < pocetMravcovTypu4; i++) PridanieMravca(TypyMravcov.MravecTypu4);
        }

        private void PridanieMravca(TypyMravcov typyMravcov)
        {
            List<int[]> volnePozicie = VyberPoziciiPreMravca(1, NajdenieVhodnychPoziciiPreMravca(TypyObjektov.potrava, typyMravcov), typyMravcov);

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
                int indexPozicie = NastaveneHodnotyPocasKrokov.random.Next(0, pozicie.Count);
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
            for (int i = 0; i < 3 - (int)typyMravcov; i++) pozicie.RemoveAt(0);

            List<int[]> pozicieNove = new List<int[]>();
            int[] pozicia;

            for (int i = 0; i < pocetPoziciiNaVybratie; i++)
            {
                int index = NastaveneHodnotyPocasKrokov.random.Next(0, pozicie.Count);
                pozicia = new int[2];
                pozicia = pozicie[index];
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

        public void ZvysCasExistencieMraveniska()
        {
            casExistencieMraveniska++;
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
    }
}

namespace SimulaciaMraveniskaUdalostiSpravaUdalosti
{
    //typy udalosti
    public enum TypyUdalosti
    {
        zvysenieCasu = 0,//navysenie casu mraveniska
        navysenieVekuMravcov = 1,//navysenie veku mravcov
        vykonanieCinnostiMravcovPohybovych = 2,//vykonanie skor pohybovyvh cinnosti jednotlivych mravcov
        bojMravcovPrechadzajucich = 6,//boj mravcov pri prechadzani medzi dvomi susednymi polickami, kde mravce
                                      //rovnakeho typu bojuju spolu proti mravcom ineho typu
        bojMravcovNaPolickach = 7,//boj mravcov na policku, kde mravce rovnakeho typu bojuju spolu
                                  //proti mravcom ineho typu
        paritSa = 8,//spustenie parenia mravcov
        vykonanieCinnostiMravcovNepohybovych = 9,//vykonanie skor nepohybovych cinnosti jednotlivych mravcov
        upravyNepohybujucichPolicok = 10,//aktualizacia nepohybovych policok
        znizenieEnergiaNaKonci = 11,//znizenie energie mravcov na konci kroku, resp. "casu"
        vypisStatistickychUdajov = 12,//vypis statistickych udajov - pri GUI verzii nefunkcne
        precistenieHodnot = 13,//resetovanie hodnote pred dalsim krokom, resp. "casom"
        nastavenieNasledujucichCinnostiMravcov = 14,//nastavenie cinnosti mravcov
        grafickyVypisMraveniska = 15,//vykresli mravenisko
        otazkaNaKoniec = 16//otazka ukoncenia behu mraveniska - pri GUI verzii nefunkcne
    }

    //mozne situacie suboja
    public enum TypySubojov
    {
        subojPriPrechode,
        subojPriStatiNaPolicku
    }

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
                    break; //okrem samotneho triedenia
                           //dochadza i k 5 s. pauze, aby 
                           //vypis, resp. cinnost mravcov,
                           //nebola neustala, a davalo to
                           //nieco vacsiu prehladnost,
                           //pripadne rozhodovanie, kedy
                           //sa simulacia zastavi, skonci
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
                        SpravaUdalosti.GrafickyVypisMraveniska(halda, cas);
                        return true;
                    }
                case TypyUdalosti.otazkaNaKoniec:
                    {
                        NastaveneHodnotyPocasKrokov.NastavPokracovanie(SpravaUdalosti.OtazkaNaUkoncenieMraveniska(mravenisko, halda, cas));
                    }
                    break;
            }

            return false;
        }
    }

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
                    SpravaCinnostiMravca.ZostanStat(mravec, mravenisko, cas); break;
                case CinnostiMravcov.otocSaVlavo:
                    SpravaCinnostiMravca.OtocSaVlavo(mravec, mravenisko, cas); break;
                case CinnostiMravcov.chodDopreduUtok:
                    SpravaCinnostiMravca.ChodDopreduUtok(mravec, mravenisko, cas); break;
                case CinnostiMravcov.chodDopreduObrana:
                    SpravaCinnostiMravca.ChodDopreduObrana(mravec, mravenisko, cas); break;
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
                    SpravaSpravaMraveniska.ZistiPohybJZahajSuboj(mravenisko, new Suradnice(i, j), cas);

                    SpravaSpravaMraveniska.ZistiPohybVZahajSuboj(mravenisko, new Suradnice(i, j), cas);
                }

            SpravaSpravaMraveniska.ZlucenieNahradnychMravenisk(mravenisko.ZistiRozmerMraveniska());

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
                    SpravaSpravaMraveniska.SubojNepohybujuce(mravenisko, new Suradnice(i, j), cas);
                }
            SpravaSpravaMraveniska.InicializaciaMraveniska(mravenisko);

            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.bojMravcovNaPolickach, TypyUdalosti.bojMravcovNaPolickach);

            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
        }

        //spusti rozmnozovanie mravcov na jednotlivych polickach
        public static void ParitSa(Mravenisko mravenisko, int cas)
        {
            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    SpravaSpravaMraveniska.ParenieMravcovDanaSuradnica(mravenisko, new Suradnice(i, j), cas);
        }

        //vykana cinnosti mravcov, ktore az tak nesuvisia s pohybom a ide o samostatnu cinnost konkretneho mravca
        public static void VykonanieCinnnostiMravcovNepohyb(Udalost udalost, Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            switch (udalost.ZistiCinnostMravca())
            {
                case CinnostiMravcov.najedzSa:
                    SpravaCinnostiMravca.NajedzSa(udalost.ZistiObjektMravec(),
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
                        {

                            mravceNaOdstranenie.Add(mravec);
                        }

                    }

            foreach (Mravec mravec in mravceNaOdstranenie)
            {
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

            SpravaSpravaMraveniska.InicializaciaMraveniska(mravenisko);

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

            SpravaSpravaMraveniska.InicializaciaMraveniska(mravenisko);
            SpravaSpravaMraveniska.NajdiStojacichMravcov(mravenisko);
        }

        //zisti ci chce uzivatel pokracovat v simulacii
        public static bool OtazkaNaUkoncenieMraveniska(Mravenisko mravenisko, Halda<Udalost> halda, int cas)
        {
            Reader nacitavac = Reader.Console();

            HlaskyPriNacitavaniHodnotRozhodnuti.ChcetePokracovatVSimulacii();
            string odpoved;

            odpoved = nacitavac.Word();

            Udalost udalost = new Udalost(cas + 10, (int)TypyUdalosti.otazkaNaKoniec,
                                TypyUdalosti.otazkaNaKoniec);
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());



            if (odpoved == "ANO") return true;
            else { if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.Close(); Environment.Exit(-1); return false; }


        }

        public static void GrafickyVypisMraveniska(Halda<Udalost> halda, int cas)
        {
            Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.grafickyVypisMraveniska, TypyUdalosti.grafickyVypisMraveniska);

            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            System.Threading.Thread.Sleep(Konstanty.ZistiVyslednuDobuPrestavku());
        }
    }

    //funkcie pre spravu cinnosti mravca
    public static class SpravaCinnostiMravca
    {
        //mravec zostane stat, tym sa zvysi jeho obrana, pre pripadny boj na jeho policku
        public static void ZostanStat(Mravec mravec, Mravenisko mravenisko, int cas)
        {
            mravec.NastavObrana(true);
            HlaskyCinnostiMravcovStavObjektov.MravecZostalStat(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());
        }
        //mravec sa otoci vlavo
        public static void OtocSaVlavo(Mravec mravec, Mravenisko mravenisko, int cas)
        {
            mravec.OtocitVlavo();
            HlaskyCinnostiMravcovStavObjektov.MravecSaOtocilDolava(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                        mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());
        }
        //mravec ide dopredu, jeho uskok je nast. false, pretoze pri boji pri prechadzani policok
        //bude bojovat, ak vyhra, tak sa dostane na policko pred nim
        //inak zanikne
        public static void ChodDopreduUtok(Mravec mravec, Mravenisko mravenisko, int cas)
        {

            mravec.NastavUskok(false);
            mravec.ChodDopredu(mravenisko.ZistiRozmerMraveniska());
            mravenisko.PosunMravca(new Suradnice(mravec.ZistiXSuradnicuPredchadzajuceSuradnice(), mravec.ZistiYSuradnicuPredchadzajuceSuradnice()), mravec);

            SpravaSpravaMraveniska.nahradneMraveniskoPohybujuce[mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu()].Add(mravec);
            HlaskyCinnostiMravcovStavObjektov.MravecIdeDopreduUtocne(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                mravec.ZistiXSuradnicuPredchadzajuceSuradnice(), mravec.ZistiYSuradnicuPredchadzajuceSuradnice());
            HlaskyCinnostiMravcovStavObjektov.MravecPrisielNaPolicko(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());
        }
        //mravec ide dopredu, jeho uskok je nast. true, pretoze pri boji pri prechadzani policok
        //utecie na policko z ktoreho chcel odist, znizi sa jeho energia
        public static void ChodDopreduObrana(Mravec mravec, Mravenisko mravenisko, int cas)
        {
            mravec.NastavUskok(true);
            mravec.ChodDopredu(mravenisko.ZistiRozmerMraveniska());
            mravenisko.PosunMravca(new Suradnice(mravec.ZistiXSuradnicuPredchadzajuceSuradnice(), mravec.ZistiYSuradnicuPredchadzajuceSuradnice()), mravec);


            SpravaSpravaMraveniska.nahradneMraveniskoPohybujuce[mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu()].Add(mravec);
            HlaskyCinnostiMravcovStavObjektov.MravecIdeDopreduObranne(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                            mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());
            HlaskyCinnostiMravcovStavObjektov.MravecPrisielNaPolicko(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                        mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());
        }
        //mravec sa naje, pokial je na danom policku potrava
        public static void NajedzSa(Mravec mravec, Mravenisko mravenisko, int cas)
        {
            Suradnice suradnice = new Suradnice(mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());
            TypyObjektov typyObjektov = mravenisko.ZistiCoJeNaDanychSuradniciach(suradnice);

            if (typyObjektov == TypyObjektov.potrava)
            {
                Potrava potrava = mravenisko.VratObjektNepohybujuceSaNaDanychSuradniciach(suradnice) as Potrava;
                mravec.NajedzSa(potrava.ZiadamEnergia(mravec.ZistiEnergiaMravca()));

                if (potrava.ZistiExistenciu() == false) mravenisko.PridaniePrazdnaZemKonkretnaPozicia(potrava.ZistiXSuradnicu(), potrava.ZistiYSuradnicu());
                HlaskyCinnostiMravcovStavObjektov.MravecJe(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu(),
                                                mravec.ZistiEnergiaMravca());
            }
        }

    }

    //sprava mraveniska, najma cinnosti mravcov
    public static class SpravaSpravaMraveniska
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
            {
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                {
                    foreach (Mravec mravec in mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)))
                    {
                        if (mravec.ZistiCinnostMravca() != CinnostiMravcov.chodDopreduObrana && mravec.ZistiCinnostMravca() != CinnostiMravcov.chodDopreduUtok)
                            nahradneMraveniskoStojace[i, j].Add(mravec);
                    }
                }
            }
        }

        //zisti existenciu skupiny mravcov, ktore idu z policka so suradnicami "suradnice" na policko pod nimi
        //a tymi co ide opacne
        //spracuje ich suboj
        public static void ZistiPohybJZahajSuboj(Mravenisko mravenisko, Suradnice suradnice, int cas)
        {
            List<Mravec> mravceSmerS = new List<Mravec>();//mravce iduce smerom s
            List<Mravec> mravceSmerJ = new List<Mravec>();//mravce iduce smerom j

            List<Mravec> mravceNaOdstranenie1 = new List<Mravec>();

            Suradnice suradniceSmerS =
                NasledujucePolickoMraveniska.SmerJ(suradnice, mravenisko.ZistiRozmerMraveniska());//suradnice odkial idu mravce 
                                                                                                  //smerujuce na s

            foreach (Mravec mravec in nahradneMraveniskoPohybujuce[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()])
            {
                if (ZistiCiSaSuradniceRovnaju(mravec.ZistiStareSuradnica(), suradniceSmerS))
                {
                    mravceNaOdstranenie1.Add(mravec);
                    mravceSmerS.Add(mravec);
                }
            }

            List<Mravec> mravceNaOdstranenie2 = new List<Mravec>();
            Suradnice suradniceNaJuhu =
                NasledujucePolickoMraveniska.SmerJ(suradnice, mravenisko.ZistiRozmerMraveniska()); //suradnice kam idu mravce
                                                                                                   // iduce zo "suradnice"
            Suradnice suradniceSmerJ = suradnice; //suradnice odkial idu mravce smerujuce na j

            foreach (Mravec mravec in nahradneMraveniskoPohybujuce[suradniceNaJuhu.ZistiXSuradnicu(), suradniceNaJuhu.ZistiYSuradnicu()])
            {
                if (ZistiCiSaSuradniceRovnaju(suradniceSmerJ, mravec.ZistiStareSuradnica()))
                {
                    mravceNaOdstranenie2.Add(mravec);
                    mravceSmerJ.Add(mravec);
                }
            }

            if (mravceSmerS.Count > 0 && mravceSmerJ.Count > 0 && mravceSmerS[0].ZistiTypyMravcov() !=
                mravceSmerJ[0].ZistiTypyMravcov())
            {
                foreach (Mravec mravec in mravceNaOdstranenie1)
                    nahradneMraveniskoPohybujuce[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()].Remove(mravec);

                foreach (Mravec mravec in mravceNaOdstranenie2)
                    nahradneMraveniskoPohybujuce[suradniceNaJuhu.ZistiXSuradnicu(), suradniceNaJuhu.ZistiYSuradnicu()].Remove(mravec);

                SubojPohybujuce(mravceSmerS, suradnice, mravceSmerJ, suradniceNaJuhu, mravenisko, cas);
            }

        }

        //zisti existenciu skupiny mravcov, ktore idu z policka so suradnicami "suradnice" na policku  "vpravo"
        //od nich a tymi co idu naopak
        //spracuje ich suboj
        public static void ZistiPohybVZahajSuboj(Mravenisko mravenisko, Suradnice suradnice, int cas)
        {
            List<Mravec> mravceSmerV = new List<Mravec>();//mravce iduce smerom na v
            List<Mravec> mravceSmerZ = new List<Mravec>();//mravce iduce smerom na z

            List<Mravec> mravceNaOdstranenie1 = new List<Mravec>();
            List<Mravec> mravceNaOdstranenie2 = new List<Mravec>();


            //suradnice kam ide mravce v smere v
            Suradnice suradniceNaV = NasledujucePolickoMraveniska.SmerV(suradnice, mravenisko.ZistiRozmerMraveniska());

            //suradnice odkial idu mravce v smere v
            Suradnice suradniceSmerV = suradnice;

            foreach (Mravec mravec in nahradneMraveniskoPohybujuce[suradniceNaV.ZistiXSuradnicu(), suradniceNaV.ZistiYSuradnicu()])
            {
                if (ZistiCiSaSuradniceRovnaju(suradniceSmerV, mravec.ZistiStareSuradnica()))
                {
                    mravceNaOdstranenie1.Add(mravec);
                    mravceSmerV.Add(mravec);
                }
            }

            foreach (Mravec mravec in mravceNaOdstranenie1)
                nahradneMraveniskoPohybujuce[suradniceNaV.ZistiXSuradnicu(), suradniceNaV.ZistiYSuradnicu()].Remove(mravec);

            mravceNaOdstranenie2 = new List<Mravec>();

            //suradnice odkial idu mravce v smere z
            Suradnice suradniceSmerZ = suradniceNaV;


            foreach (Mravec mravec in nahradneMraveniskoPohybujuce[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()])
            {
                if (ZistiCiSaSuradniceRovnaju(suradniceSmerZ, mravec.ZistiStareSuradnica()))
                {
                    mravceNaOdstranenie2.Add(mravec);
                    mravceSmerZ.Add(mravec);
                }
            }


            if (mravceSmerV.Count > 0 && mravceSmerZ.Count > 0 && mravceSmerV[0].ZistiTypyMravcov() !=
                mravceSmerZ[0].ZistiTypyMravcov())
            {
                foreach (Mravec mravec in mravceNaOdstranenie2)
                    nahradneMraveniskoPohybujuce[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()].Remove(mravec);

                foreach (Mravec mravec in mravceNaOdstranenie1)
                    nahradneMraveniskoPohybujuce[suradniceNaV.ZistiXSuradnicu(), suradniceNaV.ZistiYSuradnicu()].Remove(mravec);

                SubojPohybujuce(mravceSmerV, suradniceNaV, mravceSmerZ, suradnice, mravenisko, cas);
            }
        }

        //spracovanie suboja dvoch proti sebe iducich skupin mravcov (kde jedna skupina obsahu mravce toho istteho typu)
        private static void SubojPohybujuce(List<Mravec> mravce1, Suradnice suradnice1, List<Mravec> mravce2,
            Suradnice suradnice2, Mravenisko mravenisko, int cas)
        {


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



            Suradnice suradniceTypu1PreUskok = default(Suradnice);
            Suradnice suradniceTypu2PreUskok = default(Suradnice);
            Suradnice suradniceTypu3PreUskok = default(Suradnice);
            Suradnice suradniceTypu4PreUskok = default(Suradnice);

            Suradnice suradniceTypu1 = default(Suradnice);
            Suradnice suradniceTypu2 = default(Suradnice);
            Suradnice suradniceTypu3 = default(Suradnice);
            Suradnice suradniceTypu4 = default(Suradnice);

            NastavSuradnicePodlaTypu(ref suradniceTypu1PreUskok, ref suradniceTypu2PreUskok,
                ref suradniceTypu3PreUskok, ref suradniceTypu4PreUskok
                , suradnice2, mravce1[0].ZistiTypyMravcov());
            NastavSuradnicePodlaTypu(ref suradniceTypu1PreUskok, ref suradniceTypu2PreUskok,
                ref suradniceTypu3PreUskok, ref suradniceTypu4PreUskok,
                suradnice1, mravce2[0].ZistiTypyMravcov());

            NastavSuradnicePodlaTypu(ref suradniceTypu1, ref suradniceTypu2, ref suradniceTypu3, ref suradniceTypu4, suradnice1,
                mravce1[0].ZistiTypyMravcov());
            NastavSuradnicePodlaTypu(ref suradniceTypu1, ref suradniceTypu2, ref suradniceTypu3, ref suradniceTypu4, suradnice2,
                mravce2[0].ZistiTypyMravcov());


            ZistiSpravujUskakujuceMravce(mravenisko, mravceTypu1, mravceUskokTypu1, cas);
            ZistiSpravujUskakujuceMravce(mravenisko, mravceTypu2, mravecUskokTypu2, cas);
            ZistiSpravujUskakujuceMravce(mravenisko, mravceTypu3, mravecUskokTypu3, cas);
            ZistiSpravujUskakujuceMravce(mravenisko, mravceTypu4, mravecUskokTypu4, cas);

            VratMravceZKtorehoIsliUskocili(suradniceTypu1PreUskok, mravceUskokTypu1, mravenisko, cas);
            VratMravceZKtorehoIsliUskocili(suradniceTypu2PreUskok, mravecUskokTypu2, mravenisko, cas);
            VratMravceZKtorehoIsliUskocili(suradniceTypu3PreUskok, mravecUskokTypu3, mravenisko, cas);
            VratMravceZKtorehoIsliUskocili(suradniceTypu4PreUskok, mravecUskokTypu4, mravenisko, cas);

            int energiaMravceTypu1 = ZistiEnergiaMravcov(mravceTypu1);
            int energiaMravceTypu2 = ZistiEnergiaMravcov(mravceTypu2);
            int energiaMravceTypu3 = ZistiEnergiaMravcov(mravceTypu3);
            int energiaMravceTypu4 = ZistiEnergiaMravcov(mravceTypu4);

            TypyMravcov typyMravcov = ZistiVyhercaSuboja(energiaMravceTypu1, energiaMravceTypu2, energiaMravceTypu3, energiaMravceTypu4);

            vyherneMravce = ZistiTypVyhercuSpracujVyhru(suradniceTypu1, suradniceTypu2, suradniceTypu3, suradniceTypu4, typyMravcov,
                mravceTypu1, mravceTypu2, mravceTypu3, mravceTypu4, TypySubojov.subojPriPrechode, cas);

            //VypisMravceVytazniSuboj(vyherneMravce, cas);

            VymazMravcePodlaTypu(mravenisko, typyMravcov, suradniceTypu1, suradniceTypu2, suradniceTypu3, suradniceTypu4, mravceTypu1,
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

            RoztriedMravceNaPolickuPodlaTypovSuradnica(suradnice, mravceTypu1, mravceTypu2, mravceTypu3, mravceTypu4);

            int energiaMravceTypu1 = ZistiEnergiaMravcov(mravceTypu1);
            int energiaMravceTypu2 = ZistiEnergiaMravcov(mravceTypu2);
            int energiaMravceTypu3 = ZistiEnergiaMravcov(mravceTypu3);
            int energiaMravceTypu4 = ZistiEnergiaMravcov(mravceTypu4);

            NastavNeparenie(mravceTypu1);
            NastavNeparenie(mravceTypu2);
            NastavNeparenie(mravceTypu3);
            NastavNeparenie(mravceTypu4);

            int pocetMravcovCelkovo;

            pocetMravcovCelkovo = mravceTypu1.Count + mravceTypu2.Count + mravceTypu3.Count + mravceTypu4.Count;

            if (PritomnostMravceViac(pocetMravcovCelkovo, mravceTypu1.Count, mravceTypu2.Count, mravceTypu3.Count, mravceTypu4.Count))
            {

                TypyMravcov typyMravcov = ZistiVyhercaSuboja(energiaMravceTypu1, energiaMravceTypu2, energiaMravceTypu3, energiaMravceTypu4);

                vyherneMravce = ZistiTypVyhercuSpracujVyhru(suradnice, suradnice, suradnice, suradnice, typyMravcov, mravceTypu1, mravceTypu2,
                    mravceTypu3, mravceTypu4, TypySubojov.subojPriStatiNaPolicku, cas);

                //VypisMravceVytazniSuboj(vyherneMravce, cas);

                VymazMravcePodlaTypu(mravenisko, typyMravcov, suradnice, suradnice, suradnice, suradnice,
                    mravceTypu1, mravceTypu2, mravceTypu3, mravceTypu4, cas);
            }
        }

        //spravuje vyhru
        public static List<Mravec> ZistiTypVyhercuSpracujVyhru(Suradnice suradnice1, Suradnice suradnice2, Suradnice suradnice3,
            Suradnice suradnice4, TypyMravcov typyMravcov, List<Mravec> mravce1, List<Mravec> mravce2,
            List<Mravec> mravce3, List<Mravec> mravce4, TypySubojov typySubojov, int cas)
        {
            List<Mravec> mravce = new List<Mravec>();

            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1: SpravaVyhry(mravce1, suradnice1, typySubojov, cas); mravce = mravce1; break;
                case TypyMravcov.MravecTypu2: SpravaVyhry(mravce2, suradnice2, typySubojov, cas); mravce = mravce2; break;
                case TypyMravcov.MravecTypu3: SpravaVyhry(mravce3, suradnice3, typySubojov, cas); mravce = mravce3; break;
                case TypyMravcov.MravecTypu4: SpravaVyhry(mravce4, suradnice4, typySubojov, cas); mravce = mravce4; break;

            }

            return mravce;
        }

        //spravuje vyhru
        private static void SpravaVyhry(List<Mravec> mravce, Suradnice suradnice, TypySubojov typySubojov, int cas)
        {
            if (typySubojov == TypySubojov.subojPriPrechode)
                foreach (Mravec mravec in mravce)
                {
                    mravec.ZvysEnergia(); nahradneMraveniskoPohybujuce[suradnice.ZistiXSuradnicu(),
                     suradnice.ZistiYSuradnicu()].Add(mravec); HlaskyCinnostiMravcovStavObjektov.MravecBojovalV(cas,
                         mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1, suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu(),
                         mravec.ZistiEnergiaMravca());
                }
            else
                nahradneMraveniskoStojace[suradnice.ZistiXSuradnicu(),
                        suradnice.ZistiYSuradnicu()] = new List<Mravec>();
            foreach (Mravec mravec in mravce)
            {
                mravec.ZvysEnergia(); nahradneMraveniskoStojace[suradnice.ZistiXSuradnicu(),
                    suradnice.ZistiYSuradnicu()].Add(mravec);
                HlaskyCinnostiMravcovStavObjektov.MravecBojovalV(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                    suradnice.ZistiXSuradnicu(),
                    suradnice.ZistiYSuradnicu(), mravec.ZistiEnergiaMravca());
            }
        }


        //spracuje mravce, ktore zanikli pri suboji
        private static void VymazMravcePodlaTypu(Mravenisko mravenisko, TypyMravcov typyMravcov, Suradnice suradniceTypu1,
            Suradnice suradniceTypu2, Suradnice suradniceTypu3,
            Suradnice suradniceTypu4, List<Mravec> mravce1, List<Mravec> mravce2,
            List<Mravec> mravce3, List<Mravec> mravce4, int cas)
        {
            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1:
                    VymazMravce(mravenisko, suradniceTypu2, mravce2, cas);
                    VymazMravce(mravenisko, suradniceTypu3, mravce3, cas);
                    VymazMravce(mravenisko, suradniceTypu4, mravce4, cas); break;
                case TypyMravcov.MravecTypu2:
                    VymazMravce(mravenisko, suradniceTypu1, mravce1, cas);
                    VymazMravce(mravenisko, suradniceTypu3, mravce3, cas);
                    VymazMravce(mravenisko, suradniceTypu4, mravce4, cas); break;
                case TypyMravcov.MravecTypu3:
                    VymazMravce(mravenisko, suradniceTypu1, mravce1, cas);
                    VymazMravce(mravenisko, suradniceTypu2, mravce2, cas);
                    VymazMravce(mravenisko, suradniceTypu4, mravce4, cas); break;
                case TypyMravcov.MravecTypu4:
                    VymazMravce(mravenisko, suradniceTypu1, mravce1, cas);
                    VymazMravce(mravenisko, suradniceTypu2, mravce2, cas);
                    VymazMravce(mravenisko, suradniceTypu3, mravce3, cas); break;
            }
        }

        //spracuje mravce, ktore zanikli pri suboji
        private static void VymazMravce(Mravenisko mravenisko, Suradnice suradnice, List<Mravec> mravce, int cas)
        {
            foreach (Mravec mravec in mravce)
            {
                mravec.ZnizEnergia(Konstanty.maximumEnergiaMravec * 2);
                mravenisko.OdstranenieMravca(suradnice, mravec.ZistiIdMravca());
                HlaskyCinnostiMravcovStavObjektov.MravecZanikolNaPolickuPriBoji(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                    mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());
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
        private static void RoztriedMravceNaPolickuPodlaTypovSuradnica(Suradnice suradnice, List<Mravec> mravceTypu1,
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

        //zisti ci su pritomne mravce viacerych
        private static bool PritomnostMravceViac(int celkovyPocet, int pocetTypu1, int pocetTypu2, int pocetTypu3,
                                                    int pocetTypu4)
        {
            if (celkovyPocet > pocetTypu1 && celkovyPocet > pocetTypu2 && celkovyPocet > pocetTypu3 && celkovyPocet > pocetTypu4)
                return true;
            else return false;
        }

        //nastavy "suradnice" podla typu mravcov 
        private static void NastavSuradnicePodlaTypu(ref Suradnice suradnice1, ref Suradnice suradnice2,
            ref Suradnice suradnice3, ref Suradnice suradnice4, Suradnice suradnice, TypyMravcov typyMravcov)
        {
            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1: suradnice1 = suradnice; break;
                case TypyMravcov.MravecTypu2: suradnice2 = suradnice; break;
                case TypyMravcov.MravecTypu3: suradnice3 = suradnice; break;
                case TypyMravcov.MravecTypu4: suradnice4 = suradnice; break;
            }
        }

        //zisti vyhercu suboja, v zavisloti na energii bojujucich skupin
        private static TypyMravcov ZistiVyhercaSuboja(int energiaMravce1, int energiaMravce2, int energiaMravce3, int energiaMravce4)
        {

            int energia = energiaMravce1 + energiaMravce2 + energiaMravce3 + energiaMravce4;

            if (energia == 0) return default(TypyMravcov);

            int hodnota = NastaveneHodnotyPocasKrokov.random.Next(1, energia + 1);

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
            List<Mravec> mravce, List<Mravec> mravceUskok, int cas)
        {

            List<Mravec> mravceNeuskakujuce = new List<Mravec>();

            foreach (Mravec mravec in mravce)


                if (mravec.ZistiUskok())
                {
                    mravec.ZnizEnergia(Konstanty.maximumEnergiaMravec / 20);
                    HlaskyCinnostiMravcovStavObjektov.ZnizenaEnergiaMravcaUskok(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                    mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu(),
                                                                    mravec.ZistiEnergiaMravca());
                    if (mravec.ZistiExistenciu())
                        mravceUskok.Add(mravec);
                    else
                    {
                        HlaskyCinnostiMravcovStavObjektov.MravecZanikolNaPolickuNedostatokEnergie(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                                      mravec.ZistiXSuradnicu(),
                                                                                      mravec.ZistiYSuradnicu());
                        mravenisko.OdstranenieMravca(new Suradnice(mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu()), mravec.ZistiIdMravca());
                    }
                }
                else
                {
                    mravceNeuskakujuce.Add(mravec);
                }

            mravce = mravceNeuskakujuce;
        }

        //da mravce na miesto na ktore uskocili pri prechode
        private static void VratMravceZKtorehoIsliUskocili(Suradnice suradnice,
            List<Mravec> mravce, Mravenisko mravenisko, int cas)
        {
            foreach (Mravec mravec in mravce)
            {
                mravec.OtocitVlavo();
                mravec.OtocitVlavo();
                mravec.ChodDopredu(mravenisko.ZistiRozmerMraveniska());
                HlaskyCinnostiMravcovStavObjektov.MravecPrisielNaPolicko(cas, mravec.ZistiIdMravca(), (int)mravec.ZistiTypyMravcov() + 1,
                                                                            mravec.ZistiXSuradnicu(), mravec.ZistiYSuradnicu());
                mravenisko.OdstranenieMravca(mravec.ZistiStareSuradnica(), mravec.ZistiIdMravca());
                nahradneMraveniskoPohybujuce[suradnice.ZistiXSuradnicu(), suradnice.ZistiYSuradnicu()].Add(mravec);

            }
        }

        //zisti rovnost suradnic
        private static bool ZistiCiSaSuradniceRovnaju(Suradnice suradnice1, Suradnice suradnice2)
        {
            if (suradnice1.ZistiXSuradnicu() == suradnice2.ZistiXSuradnicu() && suradnice1.ZistiYSuradnicu() == suradnice2.ZistiYSuradnicu()) return true;
            return false;
        }

        //zrusi parenie sa u mravcov, ktory sa ucastnili v suboji
        private static void NastavNeparenie(List<Mravec> mravce)
        {
            foreach (Mravec mravec in mravce) mravec.NastavParitSa(false);
        }

        //spravuje parenie mravcov, na to aby vznikli nove mravce musia byt splnene urcite podmienky
        public static void ParenieMravcovDanaSuradnica(Mravenisko mravenisko, Suradnice suradnica, int cas)
        {
            List<Mravec> pariaceSaMravce = new List<Mravec>();
            int xSuradnica = suradnica.ZistiXSuradnicu();
            int ySuradnica = suradnica.ZistiYSuradnicu();

            foreach (Mravec mravec in nahradneMraveniskoStojace[xSuradnica, ySuradnica])
            {
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
    }

    //nastavy cinnost mravcov
    public static class NastavenieCinnostiMravcov
    {

        //zisti typ policka vpredu, dostane suradnice policka, ktore je vpredu
        private static TypyPolicok ZistiTypPolickaVpredu(Mravenisko mravenisko, TypyMravcov typyMravcov, Suradnice suradnice)
        {
            TypyPolicok typyPolicok = default(TypyPolicok);

            switch (mravenisko.VratObjektNepohybujuceSaNaDanychSuradniciach(suradnice).ZistiTypObjektu())
            {
                case TypyObjektov.skala: typyPolicok = TypyPolicok.skala; break;
                case TypyObjektov.prazdnaZem:
                    {
                        List<PohybujuceSaObjekty> mravce = mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(suradnice);
                        if (mravce.Count == 0) typyPolicok = TypyPolicok.prazdnaZem;
                        else if ((mravce[0] as Mravec).ZistiTypyMravcov() == typyMravcov) typyPolicok = TypyPolicok.priatelPrazdnaZem;
                        else typyPolicok = TypyPolicok.nepriatelPrazdnaZem;
                    }
                    break;
                case TypyObjektov.potrava:
                    {
                        List<PohybujuceSaObjekty> mravce = mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(suradnice);
                        if (mravce.Count == 0) typyPolicok = TypyPolicok.potrava;
                        else if ((mravce[0] as Mravec).ZistiTypyMravcov() == typyMravcov) typyPolicok = TypyPolicok.priatelPotrava;
                        else typyPolicok = TypyPolicok.nepriatelPotrava;
                    }
                    break;
            }

            return typyPolicok;
        }

        //zisti typ policka, na ktorom mravec stoji
        private static TypyPolicok ZistiTypPolickaSucasne(Mravenisko mravenisko, TypyMravcov typyMravcov, Suradnice suradnice)
        {
            TypyPolicok typyPolicok = default(TypyPolicok);

            switch (mravenisko.VratObjektNepohybujuceSaNaDanychSuradniciach(suradnice).ZistiTypObjektu())
            {
                case TypyObjektov.prazdnaZem:
                    {
                        List<PohybujuceSaObjekty> mravce = mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(suradnice);
                        if (mravce.Count > 1) typyPolicok = TypyPolicok.priatelPrazdnaZem;
                        else typyPolicok = TypyPolicok.prazdnaZem;
                    }
                    break;
                case TypyObjektov.potrava:
                    {
                        List<PohybujuceSaObjekty> mravce = mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(suradnice);
                        if (mravce.Count > 1) typyPolicok = TypyPolicok.priatelPotrava;
                        else typyPolicok = TypyPolicok.potrava;
                    }
                    break;
            }

            return typyPolicok;
        }

        //zisti cinnost mravca, ktora vypliva z policok pred mravcom a na ktorom stoji
        private static CinnostiMravcov ZistenieCinnostiMravca(TypyPolicok typyPolicokSucasne, TypyPolicok typyPolicokPred,
                                                            TypyMravcov typyMravcov)
        {
            int polickoSucasne;
            int polickoPred;

            polickoPred = (int)typyPolicokPred;
            polickoSucasne = (int)typyPolicokSucasne;

            if (polickoSucasne > 0) polickoSucasne--;

            CinnostiMravcov cinnostMravca;

            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1: { cinnostMravca = Konstanty.strategiaMravcaTypu1.ZistiStrategiaPodlaSuradnice(polickoSucasne, polickoPred); break; }
                case TypyMravcov.MravecTypu2: { cinnostMravca = Konstanty.strategiaMravcaTypu2.ZistiStrategiaPodlaSuradnice(polickoSucasne, polickoPred); break; }
                case TypyMravcov.MravecTypu3: { cinnostMravca = Konstanty.strategiaMravcaTypu3.ZistiStrategiaPodlaSuradnice(polickoSucasne, polickoPred); break; }
                case TypyMravcov.MravecTypu4: { cinnostMravca = Konstanty.strategiaMravcaTypu4.ZistiStrategiaPodlaSuradnice(polickoSucasne, polickoPred); break; }
                default: cinnostMravca = default(CinnostiMravcov); break;
            }

            return cinnostMravca;
        }

        //nastavi cinnosti mravca, v zavislosti od toho vytvori Udalost
        public static void NastavenieCinnostiMravca(Halda<Udalost> halda, int cas, Mravec mravec, Mravenisko mravenisko)
        {
            CinnostiMravcov cinnostiMravcovNova = ZistenieCinnostiMravca(ZistiTypPolickaSucasne(mravenisko, mravec.ZistiTypyMravcov(),
                                                   mravec.ZistiSuradnica()), ZistiTypPolickaVpredu(mravenisko, mravec.ZistiTypyMravcov(),
                                                   NasledujucePolickoMraveniska.ZistiSuradniceNasledujucehoPolicka(
                                                       mravec.ZistiSuradnica(),
                                                       mravec.ZistiSmerPohybu(), mravenisko.ZistiRozmerMraveniska())),
                                                   mravec.ZistiTypyMravcov());

            mravec.NastavCinnostMravca(cinnostiMravcovNova);


            if (cinnostiMravcovNova == CinnostiMravcov.paritSa)
            {
                if (!NastaveneHodnotyPocasKrokov.ZistiParenie())
                {
                    Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.paritSa,
                                                    TypyUdalosti.paritSa);
                    halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

                    NastaveneHodnotyPocasKrokov.NastavParenie(true);

                }

            }
            else if (cinnostiMravcovNova == CinnostiMravcov.najedzSa)
            {
                Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.vykonanieCinnostiMravcovNepohybovych,
                    TypyUdalosti.vykonanieCinnostiMravcovNepohybovych, mravec);
                halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
            }
            else
            {


                Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.vykonanieCinnostiMravcovPohybovych + (int)cinnostiMravcovNova,
                                                TypyUdalosti.vykonanieCinnostiMravcovPohybovych, mravec);

                Mravec mravec2 = udalost.ZistiObjektMravec();


                halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
            }

        }
    }

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
                {
                    return default(CinnostiMravcov);
                }
            }
            else
            {
                return default(CinnostiMravcov);
            }
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

namespace SimulaciaMraveniskaSimulacia
{
    //trieda, ktora reprezentuje udaje, ktore su vypisovanie ako statisticke udaje, alebo ako udaje
    //v GUI v casti "Simulacia"
    public class VypisovacieUdaje
    {
        int pocetMravcovTypu1;
        int pocetMravcovTypu1Celkovo;
        int pocetMravcovTypu2;
        int pocetMravcovTypu2Celkovo;
        int pocetMravcovTypu3;
        int pocetMravcovTypu3Celkovo;
        int pocetMravcovTypu4;
        int pocetMravcovTypu4Celkovo;

        int mnozstvoPotravy;
        int mnozstvoPotravyCelkovo;

        int cas;

        public void NastavPocetMravcovTypu1(int pocet)
        {
            pocetMravcovTypu1 = pocet;
        }
        public void NastavPocetMravcovTypu1Celkovo(int pocet)
        {
            pocetMravcovTypu1Celkovo = pocet;
        }
        public void NastavPocetMravcovTypu2(int pocet)
        {
            pocetMravcovTypu2 = pocet;
        }
        public void NastavPocetMravcovTypu2Celkovo(int pocet)
        {
            pocetMravcovTypu2Celkovo = pocet;
        }
        public void NastavPocetMravcovTypu3(int pocet)
        {
            pocetMravcovTypu3 = pocet;
        }
        public void NastavPocetMravcovTypu3Celkovo(int pocet)
        {
            pocetMravcovTypu3Celkovo = pocet;
        }
        public void NastavPocetMravcovTypu4(int pocet)
        {
            pocetMravcovTypu4 = pocet;
        }
        public void NastavPocetMravcovTypu4Celkovo(int pocet)
        {
            pocetMravcovTypu4Celkovo = pocet;
        }

        public void NastavMnozstvoPotravy(int pocet)
        {
            mnozstvoPotravy = pocet;
        }
        public void NastavMnozstvoPotravyCelkovo(int pocet)
        {
            mnozstvoPotravyCelkovo = pocet;
        }

        public void NastavCas(int cas)
        {
            this.cas = cas;
        }

        public int ZistiPocetMravcovTypu1()
        {
            return pocetMravcovTypu1;
        }
        public int ZistiPocetMravcovTypu1Celkovo()
        {
            return pocetMravcovTypu1Celkovo;
        }
        public int ZistiPocetMravcovTypu2()
        {
            return pocetMravcovTypu2;
        }
        public int ZistiPocetMravcovTypu2Celkovo()
        {
            return pocetMravcovTypu2Celkovo;
        }
        public int ZistiPocetMravcovTypu3()
        {
            return pocetMravcovTypu3;
        }
        public int ZistiPocetMravcovTypu3Celkovo()
        {
            return pocetMravcovTypu3Celkovo;
        }
        public int ZistiPocetMravcovTypu4()
        {
            return pocetMravcovTypu4;
        }
        public int ZistiPocetMravcovTypu4Celkovo()
        {
            return pocetMravcovTypu4Celkovo;
        }

        public int ZistiMnozstvoPotravy()
        {
            return mnozstvoPotravy;
        }
        public int ZistiMnozstvoPotravyCelkovo()
        {
            return mnozstvoPotravyCelkovo;
        }

        public int ZistiCas()
        {
            return cas;
        }

        public VypisovacieUdaje(int pocet1, int pocet1Celkovo, int pocet2, int pocet2Celkovo,
                                int pocet3, int pocet3Celkovo, int pocet4, int pocet4Celkovo,
                                int mnozstvoPotravy, int mnozstvoPotravycelkovo, int cas)
        {
            NastavPocetMravcovTypu1(pocet1);
            NastavPocetMravcovTypu1Celkovo(pocet1Celkovo);
            NastavPocetMravcovTypu2(pocet2);
            NastavPocetMravcovTypu2Celkovo(pocet2Celkovo);
            NastavPocetMravcovTypu3(pocet3);
            NastavPocetMravcovTypu3Celkovo(pocet3Celkovo);
            NastavPocetMravcovTypu4(pocet4);
            NastavPocetMravcovTypu4Celkovo(pocet4Celkovo);
            NastavMnozstvoPotravy(mnozstvoPotravy);
            NastavMnozstvoPotravyCelkovo(mnozstvoPotravycelkovo);
            NastavCas(cas);
        }
    }

    //tato staticka trieda sluzi ako uschovna zadanych hodnot od uzivatel
    //taketo uschovne hodnot su este 2 (nie nutne vsetky uchovavaju hodnoty od uzivatela)
    //su to: Konstanty, NastaveneHodnotyPocasKrokov
    public static class ZadaneHodnoty
    {
        private static int rozmerMraveniska = 0;
        private static int pocetMravcovTypu1 = 0;
        private static int pocetMravcovTypu2 = 0;
        private static int pocetMravcovTypu3 = 0;
        private static int pocetMravcovTypu4 = 0;
        private static int pocetSkal;
        private static int mnzostvoPotravy;
        private static int minimalneMnozstvoPotravy;

        public static void NastavRozmerMraveniska(int rozmer)
        {
            rozmerMraveniska = rozmer;
        }
        public static void NastavPocetMravcovTypu1(int pocet)
        {
            pocetMravcovTypu1 = pocet;
        }
        public static void NastavPocetMravcovTypu2(int pocet)
        {
            pocetMravcovTypu2 = pocet;
        }
        public static void NastavPocetMravcovTypu3(int pocet)
        {
            pocetMravcovTypu3 = pocet;
        }
        public static void NastavPocetMravcovTypu4(int pocet)
        {
            pocetMravcovTypu4 = pocet;
        }
        public static void NastavPocetSkal(int pocet)
        {
            pocetSkal = pocet;
        }
        public static void NastavMnozstvoPotravy(int mnozstvo)
        {
            mnzostvoPotravy = mnozstvo;
        }
        public static void NastavMinimalneMnozstvoPotravy(int mnozstvo)
        {
            minimalneMnozstvoPotravy = mnozstvo;
        }

        public static int ZistiRozmerMraveniska()
        {
            return rozmerMraveniska;
        }
        public static int ZistiPocetMravcovTypu1()
        {
            return pocetMravcovTypu1;
        }
        public static int ZistiPocetMravcovTypu2()
        {
            return pocetMravcovTypu2;
        }
        public static int ZistiPocetMravcovTypu3()
        {
            return pocetMravcovTypu3;
        }
        public static int ZistiPocetMravcovTypu4()
        {
            return pocetMravcovTypu4;
        }
        public static int ZistiPocetSkal()
        {
            return pocetSkal;
        }
        public static int ZistiMnozstvoPotravy()
        {
            return mnzostvoPotravy;
        }
        public static int ZistiMinimalneMnozstvoPotravy()
        {
            return minimalneMnozstvoPotravy;
        }
        /*
        public static int ZistiPocetPrazdnaZem()
        {
            return rozmerMraveniska * rozmerMraveniska;
            //return rozmerMraveniska * rozmerMraveniska - pocetSkal - mnzostvoPotravy;

        }
        */

    }

    //stara sa o nacitanie hodnot od uzivatela, ako je rozmer mravniska, pocet mravcov,.
    /*static class NacitavaciaTrieda
    {
        static Reader nacitavac = Reader.Console();

        public static void NacitajRozmerMraveniska()
        {
            HlaskyPriNacitavaniHodnotRozhodnuti.ZadavanieRozmeruMraveniska();

            int rozmer;
            nacitavac.Int(out rozmer);

            ZadaneHodnoty.NastavRozmerMraveniska(rozmer);

        }



        public static void NacitajPoctyMravcov()
        {
            HlaskyPriNacitavaniHodnotRozhodnuti.ZadavaniePoctuMravcov();

            int pocetMravcovTypu1, pocetMravcovTypu2;
            int pocetMravcovTypu3, pocetMravcovTypu4;

            nacitavac.Int(out pocetMravcovTypu1);
            nacitavac.Int(out pocetMravcovTypu2);
            nacitavac.Int(out pocetMravcovTypu3);
            nacitavac.Int(out pocetMravcovTypu4);

            ZadaneHodnoty.NastavPocetMravcovTypu1(pocetMravcovTypu1);
            ZadaneHodnoty.NastavPocetMravcovTypu2(pocetMravcovTypu2);
            ZadaneHodnoty.NastavPocetMravcovTypu3(pocetMravcovTypu3);
            ZadaneHodnoty.NastavPocetMravcovTypu4(pocetMravcovTypu4);
        }

        public static void NacitajPocetSkal()
        {
            HlaskyPriNacitavaniHodnotRozhodnuti.ZadajteSkal();
            HlaskyPriNacitavaniHodnotRozhodnuti.RozsahHodnoty(0, 
                ZadaneHodnoty.ZistiRozmerMraveniska() * ZadaneHodnoty.ZistiRozmerMraveniska() - 4);

            int pocetSkal;

            nacitavac.Int(out pocetSkal);

            ZadaneHodnoty.NastavPocetSkal(pocetSkal);
        }

        public static void NacitajInfoMnozstvaPotravy()
        {
            HlaskyPriNacitavaniHodnotRozhodnuti.ZadavaniePoctuStartovnejPotravy();
            HlaskyPriNacitavaniHodnotRozhodnuti.RozsahHodnoty(0, ZadaneHodnoty.ZistiRozmerMraveniska() *
                                                             ZadaneHodnoty.ZistiRozmerMraveniska() -
                                                             ZadaneHodnoty.ZistiPocetSkal() *
                                                             ZadaneHodnoty.ZistiPocetSkal());

            int zaciatocneMnozstvoPotravy;
            int minimalneMnozstvoPotravy;

            nacitavac.Int(out zaciatocneMnozstvoPotravy);
            nacitavac.Int(out minimalneMnozstvoPotravy);

            ZadaneHodnoty.NastavMnozstvoPotravy(zaciatocneMnozstvoPotravy);
            ZadaneHodnoty.NastavMinimalneMnozstvoPotravy(minimalneMnozstvoPotravy);


        }

        public static void SpustiNacitanie()
        {
            NacitajRozmerMraveniska();
            NacitajPocetSkal();
            NacitajInfoMnozstvaPotravy();
            NacitajPoctyMravcov();
        }

    }
    */

    //inicializuje zakladne hodnoty, mravenisko, haldu, prvotne  udalosti, nasledne ich vracia
    static class InicializaciaObjektovMraveniskaHalda
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

            SpravaSpravaMraveniska.InicializaciaMraveniska(mravenisko);
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

        public static Udalost VypisGrafickyMravenisko()
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

            //udalost = ZaciatocnaOtazkaKoniec();
            //halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaPrecistenieHodnot();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            //udalost = ZaciatocnaVypisStatistickych();
            //halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = VypisGrafickyMravenisko();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

            udalost = ZaciatocnaZnizenieEnergie();
            halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

        }

        public static void InicializujHodnoty(Mravenisko mravenisko)
        {
            NastavKonstantneHodnoty();
            NastavNekonstantneHodnoty(mravenisko);
        }
    }

    //spustenie nacitavania hodnot
    //inicializacia zakladnych objektov, ako halda v ktorej su udalosti, mravesnisko,.
    //obsahuje funkciu, ktora postupne berie udalosti z haldy, az kym uzivatel nezrusi simulaciu
    //udalosti z haldy dava na dalsie spracovanie do TriedenieUdalosti
    public class BehSimulacie
    {

        int dobaBehu;
        Halda<Udalost> halda;
        Mravenisko mravenisko;
        bool vypis;

        //spustenie simulacie
        public Mravenisko SpustiSimulaciu()
        {
            while (NastaveneHodnotyPocasKrokov.ZistiPokracovanie() && !vypis)
            {
                Udalost udalost = halda.VratPrvok();

                vypis = TriedenieUdalosti.RoztriedUdalost(udalost, mravenisko, halda, ref dobaBehu);


            }

            NastavVypis(false);

            return mravenisko;
        }

        //nastavy to hodnotu premennej vypis
        public void NastavVypis(bool hodnota)
        {
            vypis = hodnota;
        }

        //inicializacia objektov simulacia, ako mravenisko, hala, prvotne udalosti,...
        public void InicializujSimulaciu(string miestoUlozenia)
        {
            dobaBehu = 0;
            NastavVypis(false);
            //NacitavaciaTrieda.SpustiNacitanie();
            Konstanty.NastavMiestoUlozenia(miestoUlozenia);
            mravenisko = InicializaciaObjektovMraveniskaHalda.InicializaciaMraveniska();
            halda = InicializaciaObjektovMraveniskaHalda.InicializaciaHaldy();
            InicializaciaObjektovMraveniskaHalda.InicializujHodnoty(mravenisko);
        }

        //vracia objekt, ktory reprezentuje hodnoty, ktore su vypisovane, pri GUI v casti "Simulacia"
        public VypisovacieUdaje ZistiUdaje()
        {
            VypisovacieUdaje vypisovacieUdaje = new VypisovacieUdaje(mravenisko.ZistiPocetMravcovTypu1(),
                                                                    mravenisko.ZistiPocetMravcovTypu1Celkovo(),
                                                                    mravenisko.ZistiPocetMravcovTypu2(),
                                                                    mravenisko.ZistiPocetMravcovTypu2Celkovo(),
                                                                    mravenisko.ZistiPocetMravcovTypu3(),
                                                                    mravenisko.ZistiPocetMravcovTypu3Celkovo(),
                                                                    mravenisko.ZistiPocetMravcovTypu4(),
                                                                    mravenisko.ZistiPocetMravcovTypu4Celkovo(),
                                                                    mravenisko.ZistiPocetPotravy(),
                                                                    mravenisko.ZistiMnozstvoPotravyCelkovo(),
                                                                    dobaBehu);

            return vypisovacieUdaje;
        }

        //spravuje ukoncenie simulacie
        public void UkonecieSimulacie()
        {
            HlaskyInformacnePocasSimulacie.KoniecSimulacie(dobaBehu);

            Resetovanie.ResetovanieHodnot();
        }

        public BehSimulacie()
        {
            //InicializujSimulaciu("");
            Konstanty.NastavStrategiu1();
            Konstanty.NastavStrategiu2();
        }

    }

    //obsahuje staticke triedy pre resetovanie, inicializaciu niektorych hodnot pred dalsim spustenim simulacie
    public static class Resetovanie
    {

        public static void ResetovanieHodnot()
        {
            NastaveneHodnotyPocasKrokov.NastavParenie(false);
            NastaveneHodnotyPocasKrokov.NastavPokracovanie(false);
        }
    }
}

namespace SimulaciaMraveniskaHlasky
{
    //hlasky pri nacitavani hodnot
    static class HlaskyPriNacitavaniHodnotRozhodnuti
    {
        public static void ZadavanieRozmeruMraveniska()
        {
            Console.WriteLine("Zadajte rozmer mraveniska.(8/16/32/64)");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadajte rozmer mraveniska.(8/16/32/64)");
        }
        public static void NespravneRozmer()
        {
            Console.WriteLine("Zadali ste nespravny rozmer mraveniska. Opakujte zadanie.");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadali ste nespravny rozmer mraveniska. Opakujte zadanie.");
        }
        public static void ZadavaniePoctuMravcov()
        {
            Console.WriteLine("Zadajte pocty mravcov danych typov (najprv 1.typu, 2. typu, 3.typu, 4.typu)");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadajte pocty mravcov danych typov (najprv 1.typu, 2.typu, 3.typu, 4.typu");
        }
        public static void NespravneZadaniePoctuMravcov()
        {
            Console.WriteLine("Zadali ste nekorektne pocty mravcov.");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadali ste nekorektne pocty mravcov.");
        }
        public static void ZadavaniePoctuStartovnejPotravy()
        {
            Console.WriteLine("Zadajte mnozstvo startovnej potravy a minimalne mnozstvo potravy");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadajte mnozstvo startovnej potravy a minimalne mnozstvo potravy");
        }
        public static void NespravneZadaniePoctuPotravy()
        {
            Console.WriteLine("Zadali ste nekorektne mnozstva potravy");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadali ste nekorektne mnozstva potravy");
        }
        public static void RozsahHodnoty(int spodnaHranica, int vrchnaHranica)
        {
            Console.WriteLine("Dana hodnota musi byt v rozsahu " + spodnaHranica + " - " + vrchnaHranica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Dana hodnota musi byt v rozsahu " + spodnaHranica + " - " + vrchnaHranica + ".");
        }
        public static void ZadajteSkal()
        {
            Console.WriteLine("Zadajte pocet skal.");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadajte pocet skal.");
        }
        public static void ZadaliSteNekorektnuHodnotuOpakujteZadanie()
        {
            Console.WriteLine("Zadali ste nekorektnu hodnotu, opakujte zadanie hodnoty.");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Zadali ste nekorektnu hodnotu, opakujte zadanie hodnoty.");
        }
        public static void ZaciatokSimulacie()
        {
            Console.WriteLine("Chcete zacat simulaciu? (ANO/NIE)");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Chcete zacat simulaciu? (ANO/NIE)");
        }
        public static void ChcetePokracovatVSimulacii()
        {
            Console.WriteLine("Chcete pokracovat v simulacii? (ANO/NIE)");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Chcete pokracovat v simulacii? (ANO/NIE)");
        }
    }

    //informacne hlasky pocas simulacie
    static class HlaskyInformacnePocasSimulacie
    {

        public static void VypisCasu(int cas)
        {
            Console.WriteLine("Terajsi cas je:" + cas);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Terajsi cas je:" + cas);
        }

        public static void VypisPoctuMravcov(int pocetMravcovTypu1, int pocetMravcovTypu2,
                                            int pocetMravcovTypu3, int pocetMravcovTypu4)
        {
            Console.WriteLine("Pocty mravcov:");
            Console.WriteLine("typu 1:" + pocetMravcovTypu1);
            Console.WriteLine("typu 2:" + pocetMravcovTypu2);
            Console.WriteLine("typu 3:" + pocetMravcovTypu3);
            Console.WriteLine("typu 4:" + pocetMravcovTypu4);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Pocty mravcov:");
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("typu 1:" + pocetMravcovTypu1);
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("typu 2:" + pocetMravcovTypu2);
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("typu 3:" + pocetMravcovTypu3);
            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("typu 4:" + pocetMravcovTypu4);
        }

        public static void VypisPoctuPotravy(int pocetPotravy)
        {
            Console.WriteLine("Mnozstvo policok s potravou " + pocetPotravy);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Mnozstvo policok s potravou " + pocetPotravy);
        }

        public static void KoniecSimulacie(int cas)
        {
            Console.WriteLine("Simulacie skoncila v case: " + cas);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("Simulacie skoncila v case: " + cas);
        }
    }

    //hlasky popisujuce cinnosti mravcov, resp. akcie
    //ktore mravce vykonali, alebo boli ich sucastou
    //takisto existenciu inych objektov
    static class HlaskyCinnostiMravcovStavObjektov
    {
        private static void MravecCisloCas(int cas, int cisloMravca, int cisloTypuMravca)
        {
            Console.Write("[" + cas + "] Mravec cislo " + cisloMravca + " typu " + cisloTypuMravca + " ");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("[" + cas + "] Mravec cislo " + cisloMravca + " typu " + cisloTypuMravca + " ");
        }

        public static void MravecZostalStat(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" zostal stat na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" zostal stat na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecSaOtocilDolava(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" sa otocil vlavo na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" sa otocil vlavo na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecIdeDopreduUtocne(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" ide utocne dopredu na policko so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" ide utocne dopredu na policko so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecIdeDopreduObranne(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" ide obranne dopredu na policko so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" ide obranne dopredu na policko so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecJe(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" sa najedol a zvysila sa jeho energia na " + energia + " na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" sa najedol a zvysila sa jeho energia na " + energia + " na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecBojovalV(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" bojoval a vyhral, jeho energia sa zvysila na " + energia + " je na policku so suradnicami" + xSuradnica, "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" bojoval a vyhral, jeho energia sa zvysila na " + energia + " je na policku so suradnicami" + xSuradnica, "," + ySuradnica + ".");
        }
        public static void MravecSaRozhodolParit(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" sa chce parit na policku " + xSuradnica, "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" sa chce parit na policku " + xSuradnica, "," + ySuradnica + ".");
        }
        public static void MravecSaPari(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" sa pari na policku " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" sa pari na policku " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecPrisielNaPolicko(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);

            Console.WriteLine(" prisiel na policko so suradnicami " + xSuradnica + "," + ySuradnica);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" prisiel na policko so suradnicami " + xSuradnica + "," + ySuradnica);
        }
        public static void ZnizenaEnergiaMravcaParenie(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" prisiel pri pareni o energiu, terajsia hodnota energie:" + energia + " je na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" prisiel pri pareni o energiu, terajsia hodnota energie:" + energia + " je na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void ZnizenaEnergiaMravcaUskok(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" prisiel pri uskok od boja o energiu, terajsia hodnota energie:" + energia + " teraz je na policku so suradnicamu" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" prisiel pri uskok od boja o energiu, terajsia hodnota energie:" + energia + " teraz je na policku so suradnicamu" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void ZnizenaEnergiaMravcaNaKonciDanehoCasu(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" prisiel na konci kroku o energiu, hodnota jeho energie je: " + energia + ", je na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" prisiel na konci kroku o energiu, hodnota jeho energie je: " + energia + ", je na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecZanikolNaPolickuPriBoji(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" zanikol pri prehratom boji na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" zanikol pri prehratom boji na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecZanikolNaPolickuNedostatokEnergie(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" zanikol kvoli nedostatku energie na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" zanikol kvoli nedostatku energie na policku so suradnicami" + xSuradnica + "," + ySuradnica + ".");
        }
        public static void MravecVznikolNaPolickuSoZaciatocnouEnergiou(int cas, int cisloMravca, int cisloTypuMravca, int xSuradnica, int ySuradnica, int energia)
        {
            MravecCisloCas(cas, cisloMravca, cisloTypuMravca);
            Console.WriteLine(" vznikol so zaciatocnou energiou: " + energia + " na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine(" vznikol so zaciatocnou energiou: " + energia + " na policku so suradnicami " + xSuradnica + "," + ySuradnica + ".");
        }

        public static void PotravaVzniklaNaPolicku(int cas, int xSuradnica, int ySuradnica, int energia)
        {
            Console.WriteLine("[" + cas + "] Vznikla potrava na pozicii so suradnicami " + xSuradnica + "," + ySuradnica + " s energiou " + energia);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("[" + cas + "] Vznikla potrava na pozicii so suradnicami " + xSuradnica + "," + ySuradnica + " s energiou " + energia);
        }
        public static void PotravaZanikla(int cas, int xSuradnica, int ySuradnica)
        {
            Console.WriteLine("[" + cas + "] Potrava zanikla na policku so suradnicami " + xSuradnica + "," + ySuradnica);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("[" + cas + "] Potrava zanikla na policku so suradnicami " + xSuradnica + "," + ySuradnica);
        }
        public static void SkalaVznikla(int cas, int xSuradnica, int ySuradnica)
        {
            Console.WriteLine("[" + cas + "] Vznikla skala na policku so suradnicami " + xSuradnica + "," + ySuradnica);

            if (Konstanty.jeNastaveneMiestoUlozenia) Konstanty.zapisovacUdajov.WriteLine("[" + cas + "] Vznikla skala na policku so suradnicami " + xSuradnica + "," + ySuradnica);
        }
    }
}
