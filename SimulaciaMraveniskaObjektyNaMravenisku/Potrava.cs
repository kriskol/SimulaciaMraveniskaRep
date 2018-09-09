using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //trieda reprezentujuca potravu
    public class Potrava : NepohybujuceSaObjekty
    {
        private int mnozstvoEnergia;

        private void NastavMnozstvoEnergia()
        {
            mnozstvoEnergia = GenerovanieHodnot.ZistiHodnotuEnergiePotrava();
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
            return Math.Min(Konstanty.maximumEnergiaMravec - energiaMravca, ZistiMnozstvoEnergia()) / GenerovanieHodnot.random.Next(1, 4);
        }

        public Potrava(int xSuradnica, int ySuradnica, bool viditelnost, bool existencia) : base
            (xSuradnica, ySuradnica, TypyObjektov.potrava, "", viditelnost, existencia, true)
        {
            NastavMnozstvoEnergia();
        }

    }
}
