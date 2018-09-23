using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//objekty na mravenisku, objekty suvisiace s objektami na mravenisku, enum typy
//konstatne hodnoty, generovanie hodnot, sprava strategii mravcov, sprava niektorych cinnosti,
namespace SimulaciaMraveniskaObjektyNaMravenisku
{
    //trieda reprezentujuca smer pohybu
    class DoprednyPohyb
    {
        
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
            smer = SmerPohybu.s;
        }
        public void SmerJ()
        {
            smer = SmerPohybu.j;
        }
        public void SmerZ()
        {
            smer = SmerPohybu.z;
        }
        public void SmerV()
        {
            smer = SmerPohybu.v;
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
}
