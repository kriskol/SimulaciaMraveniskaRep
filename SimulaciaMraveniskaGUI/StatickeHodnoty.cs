using SimulaciaMraveniskaMravenisko;
using SimulaciaMraveniskaSimulacia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//GUI simulacie a jeho sprava a s tym suvisiace objekty a enum
namespace SimulaciaMraveniskaGUI
{
    //staticke hodnoty pouzivane v roznych vlaknach
    public static class StatickeHodnoty
    {
        private static BehSimulacie behSimulacieSimulacia;

        private static Mravenisko mravenisko;

        private static AutoResetEvent autoReset = new AutoResetEvent(false);

        public static void NastavBehSimulacieSimulacia(BehSimulacie behSimulacie)
        {
            behSimulacieSimulacia = behSimulacie;
        }
        public static void NastavMravenisko(Mravenisko mraveniskoNastav)
        {
            mravenisko = mraveniskoNastav;
        }
        public static void NastavAutoResetEvent(AutoResetEvent autoResetEvent)
        {
            autoReset = autoResetEvent;
        }

        public static BehSimulacie ZistiBehSimulacieSimulacia()
        {
            return behSimulacieSimulacia;
        }
        public static Mravenisko ZistiMravenisko()
        {
            return mravenisko;
        }
        public static AutoResetEvent ZistiAutoResetEvent()
        {
            return autoReset;
        }
    }
}
