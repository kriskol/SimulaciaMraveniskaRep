using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulaciaMraveniskaMravenisko;
using SimulaciaMraveniskaHlasky;
using SimulaciaMraveniskaUdalostiSpravaUdalosti;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
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
        private CinnostMravcaDetail cinnostMravcaDetail;

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

            cinnostMravcaDetail = new CinnostMravcaDetail(cinnostiMravcov);
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
            if (this.energia > Konstanty.maximumEnergiaMravec) this.energia = Konstanty.maximumEnergiaMravec;
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

        public void NastavUskocil(bool pravdivost)
        {
            cinnostMravcaDetail.NastavUskocil(pravdivost);
        }
        public void NastavPodariloSa(bool pravdivost)
        {
            cinnostMravcaDetail.NastavPodariloSa(pravdivost);
        }
        public void NastavBojovalPriPrechode(bool pravdivost)
        {
            cinnostMravcaDetail.NastavBojovalPriPrechode(pravdivost);
        }
        public void NastavVyhralPriPrechode(bool pravdivost)
        {
            cinnostMravcaDetail.NastavVyhralBojPriPrechode(pravdivost);
        }
        public void NastavBojovalNaPolicku(bool pravdivost)
        {
            cinnostMravcaDetail.NastavBojovalNaPolicku(pravdivost);
        }
        public void NastavVyhralNaPolicku(bool pravdivost)
        {
            cinnostMravcaDetail.NastavVyhralBojNaPolicku(pravdivost);
        }

        public bool ZistiUskocil()
        {
            return cinnostMravcaDetail.ZistiUskocil();
        }
        public bool ZistiPodariloSa()
        {
            return cinnostMravcaDetail.ZistiPodariloSa();
        }
        public bool ZistiBojovalPriPrechode()
        {
            return cinnostMravcaDetail.ZistiBojovalPriPrechode();

        }
        public bool ZistiVyhralPriPrechode()
        {
            return cinnostMravcaDetail.ZistiVyhralPriPrechode();
        }
        public bool ZistiVyhralNaPolicku()
        {
            return cinnostMravcaDetail.ZistiVyhralNaPolicku();
        }
        public bool ZistiBojovalNaPolicku()
        {
            return cinnostMravcaDetail.ZistiBojovalNaPolicku();
        }


        //mravec zostane stat, tym sa zvysi jeho obrana, pre pripadny boj na jeho policku
        public void ZostanStat(Mravenisko mravenisko, int cas)
        {
            NastavObrana(true);
            HlaskyCinnostiMravcovStavObjektov.MravecZostalStat(cas, ZistiIdMravca(), (int)ZistiTypyMravcov() + 1,
                ZistiXSuradnicu(), ZistiYSuradnicu());

        }
        //mravec sa otoci vlavo
        public void OtocSaVlavo(Mravenisko mravenisko, int cas)
        {
            OtocitVlavo();
            HlaskyCinnostiMravcovStavObjektov.MravecSaOtocilDolava(cas, ZistiIdMravca(), (int)ZistiTypyMravcov() + 1,
                                                        ZistiXSuradnicu(), ZistiYSuradnicu());

        }
        //mravec ide dopredu, jeho uskok je nast. false, pretoze pri boji pri prechadzani policok
        //bude bojovat, ak vyhra, tak sa dostane na policko pred nim
        //inak zanikne
        public void ChodDopreduUtok(Mravenisko mravenisko, int cas)
        {

            NastavUskok(false);
            ChodDopredu(mravenisko.ZistiRozmerMraveniska());
            mravenisko.PosunMravca(new Suradnice(ZistiXSuradnicuPredchadzajuceSuradnice(), ZistiYSuradnicuPredchadzajuceSuradnice()), this);

            SpravaMraveniskaMravcov.nahradneMraveniskoPohybujuce[ZistiXSuradnicu(), ZistiYSuradnicu()].Add(this);
            HlaskyCinnostiMravcovStavObjektov.MravecIdeDopreduUtocne(cas, ZistiIdMravca(), (int)ZistiTypyMravcov() + 1,
                ZistiXSuradnicuPredchadzajuceSuradnice(), ZistiYSuradnicuPredchadzajuceSuradnice());
            HlaskyCinnostiMravcovStavObjektov.MravecPrisielNaPolicko(cas, ZistiIdMravca(), (int)ZistiTypyMravcov() + 1,
                                                ZistiXSuradnicu(), ZistiYSuradnicu());

        }
        //mravec ide dopredu, jeho uskok je nast. true, pretoze pri boji pri prechadzani policok
        //utecie na policko z ktoreho chcel odist, znizi sa jeho energia
        public void ChodDopreduObrana(Mravenisko mravenisko, int cas)
        {
            NastavUskok(true);
            ChodDopredu(mravenisko.ZistiRozmerMraveniska());
            mravenisko.PosunMravca(new Suradnice(ZistiXSuradnicuPredchadzajuceSuradnice(), ZistiYSuradnicuPredchadzajuceSuradnice()), this);


            SpravaMraveniskaMravcov.nahradneMraveniskoPohybujuce[ZistiXSuradnicu(), ZistiYSuradnicu()].Add(this);
            HlaskyCinnostiMravcovStavObjektov.MravecIdeDopreduObranne(cas, ZistiIdMravca(), (int)ZistiTypyMravcov() + 1,
                                                            ZistiXSuradnicu(), ZistiYSuradnicu());
            HlaskyCinnostiMravcovStavObjektov.MravecPrisielNaPolicko(cas, ZistiIdMravca(), (int)ZistiTypyMravcov() + 1,
                                                                        ZistiXSuradnicu(), ZistiYSuradnicu());
        }
        //mravec sa naje, pokial je na danom policku potrava
        public void NajedzSa(Mravenisko mravenisko, int cas)
        {
            Suradnice suradnice = new Suradnice(ZistiXSuradnicu(), ZistiYSuradnicu());
            TypyObjektov typyObjektov = mravenisko.ZistiCoJeNaDanychSuradniciach(suradnice);

            if (typyObjektov == TypyObjektov.potrava)
            {
                Potrava potrava = mravenisko.VratObjektNepohybujuceSaNaDanychSuradniciach(suradnice) as Potrava;
                NajedzSa(potrava.ZiadamEnergia(ZistiEnergiaMravca()));

                NastavPodariloSa(true);

                if (potrava.ZistiExistenciu() == false) mravenisko.PridaniePrazdnaZemKonkretnaPozicia(potrava.ZistiXSuradnicu(), potrava.ZistiYSuradnicu());
                HlaskyCinnostiMravcovStavObjektov.MravecJe(cas, ZistiIdMravca(), (int)ZistiTypyMravcov() + 1,
                                                ZistiXSuradnicu(), ZistiYSuradnicu(),
                                                ZistiEnergiaMravca());
            }

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
}
