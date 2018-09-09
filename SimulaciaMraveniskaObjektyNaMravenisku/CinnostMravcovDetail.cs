using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //trieda zachytavajuca aku cinnost mravec vykonal, ci sa mu to vyadrilo a ci bojoval pocas daneho kroku
    class CinnostMravcaDetail
    {
        CinnostiMravcov coChcelRobit;//co chce mravec robit
        bool uskocil;//uskocil z boja
        bool podariloSa;//ci sa mu podarilo vykonat cinnost, ktoruc chcel vykonat, napr. ist dopredu
        bool bojovalPriPrechode;//ci bojoval pri prechode z policka na policko
        bool vyhralBojPriPrechode;//ci vyhral pri prechode z policka na policko
        bool bojovalNaPolicku;//ci bojoval na policku
        bool vyhralBojNaPolicku;//ci vyhral boj na policku


        public void NastavCoChcelRobit(CinnostiMravcov hodnota)
        {
            coChcelRobit = hodnota;
        }
        public void NastavUskocil(bool hodnota)
        {
            uskocil = hodnota;
        }
        public void NastavPodariloSa(bool hodnota)
        {
            podariloSa = hodnota;
        }
        public void NastavBojovalPriPrechode(bool hodnota)
        {
            bojovalPriPrechode = hodnota;
        }
        public void NastavBojovalNaPolicku(bool hodnota)
        {
            bojovalNaPolicku = hodnota;
        }
        public void NastavVyhralBojPriPrechode(bool hodnota)
        {
            vyhralBojPriPrechode = hodnota;
        }
        public void NastavVyhralBojNaPolicku(bool hodnota)
        {
            vyhralBojNaPolicku = hodnota;
        }

        public CinnostiMravcov ZistiCoChcelRobit()
        {
            return coChcelRobit;
        }
        public bool ZistiUskocil()
        {
            return uskocil;
        }
        public bool ZistiPodariloSa()
        {
            return podariloSa;
        }
        public bool ZistiBojovalPriPrechode()
        {
            return bojovalPriPrechode;
        }
        public bool ZistiBojovalNaPolicku()
        {
            return bojovalNaPolicku;
        }
        public bool ZistiVyhralPriPrechode()
        {
            return vyhralBojPriPrechode;
        }
        public bool ZistiVyhralNaPolicku()
        {
            return vyhralBojNaPolicku;
        }

        private void NastavZostan()
        {
            NastavCoChcelRobit(CinnostiMravcov.zostan);
            NastavUskocil(false);
            NastavPodariloSa(true);
            NastavBojovalPriPrechode(false);
            NastavVyhralBojPriPrechode(false);
            NastavBojovalNaPolicku(false);
            NastavVyhralBojNaPolicku(false);
        }
        private void NastavOtocitVlavo()
        {
            NastavCoChcelRobit(CinnostiMravcov.otocSaVlavo);
            NastavUskocil(false);
            NastavPodariloSa(true);
            NastavBojovalNaPolicku(false);
            NastavVyhralBojNaPolicku(false);
            NastavBojovalPriPrechode(false);
            NastavVyhralBojPriPrechode(false);
        }
        private void NastavChodDopreduUtocne()
        {
            NastavCoChcelRobit(CinnostiMravcov.chodDopreduUtok);
            NastavUskocil(false);
            NastavPodariloSa(true);
            NastavBojovalPriPrechode(false);
            NastavVyhralBojPriPrechode(false);
            NastavBojovalNaPolicku(false);
            NastavVyhralBojNaPolicku(false);
        }
        private void NastavChodDopreduObranne()
        {
            NastavCoChcelRobit(CinnostiMravcov.chodDopreduObrana);
            NastavUskocil(false);
            NastavPodariloSa(true);
            NastavBojovalPriPrechode(false);
            NastavVyhralBojPriPrechode(false);
            NastavBojovalNaPolicku(false);
            NastavVyhralBojNaPolicku(false);
        }
        private void NastavNajedzSa()
        {
            NastavCoChcelRobit(CinnostiMravcov.najedzSa);
            NastavUskocil(false);
            NastavPodariloSa(false);
            NastavBojovalPriPrechode(false);
            NastavVyhralBojPriPrechode(false);
            NastavBojovalNaPolicku(false);
            NastavVyhralBojNaPolicku(false);
        }
        private void NastavParitSa()
        {
            NastavCoChcelRobit(CinnostiMravcov.paritSa);
            NastavUskocil(false);
            NastavPodariloSa(false);
            NastavBojovalPriPrechode(false);
            NastavVyhralBojPriPrechode(false);
            NastavBojovalNaPolicku(false);
            NastavVyhralBojNaPolicku(false);
        }

        public CinnostMravcaDetail(CinnostiMravcov coChceRobit)
        {
            switch (coChceRobit)
            {
                case CinnostiMravcov.zostan: NastavZostan(); break;
                case CinnostiMravcov.otocSaVlavo: NastavOtocitVlavo(); break;
                case CinnostiMravcov.chodDopreduUtok: NastavChodDopreduUtocne(); break;
                case CinnostiMravcov.chodDopreduObrana: NastavChodDopreduObranne(); break;
                case CinnostiMravcov.najedzSa: NastavNajedzSa(); break;
                case CinnostiMravcov.paritSa: NastavParitSa(); break;
            }
        }
    }
}
