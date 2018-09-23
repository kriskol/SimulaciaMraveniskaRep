using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
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
