using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulaciaMraveniskaSimulacia;

//konzolove spustenie simulacie

namespace SimulaciaMraveniskaSpustenieKonzolove
{
    class Program
    {
        static void Main(string[] args)
        {
            BehSimulacie behSimulacie = new BehSimulacie();

            behSimulacie.SpustiSimulaciu();
        }
    }
}
