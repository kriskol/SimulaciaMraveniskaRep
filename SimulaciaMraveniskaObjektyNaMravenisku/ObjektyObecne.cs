using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
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
        }
        public void NastavViditelnost(bool viditelnost)
        {
            this.viditelnost = viditelnost;
        }
        public void NastavExistencia(bool existencia)
        {
            this.existencia = existencia;
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
}
