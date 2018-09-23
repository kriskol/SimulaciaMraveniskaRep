using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//GUI simulacie a jeho sprava a s tym suvisiace objekty a enum
namespace SimulaciaMraveniskaGUI
{
    //odkaz na prave beziacu windows form
    public static class OdkazNaFormu
    {
        private static Form1 MainForm;

        public static void NastavFormu(Form1 form1)
        {
            MainForm = form1;
        }

        public static Form1 ZistiOdkazNaFormu()
        {
            return MainForm;
        }
    }
}
