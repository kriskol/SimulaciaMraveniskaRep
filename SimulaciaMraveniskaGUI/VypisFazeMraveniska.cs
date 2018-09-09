﻿using SimulaciaMraveniskaMravenisko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//GUI simulacie a jeho sprava a s tym suvisiace objekty a enum
namespace SimulaciaMraveniskaGUI
{
    //vypisuje fazu mraveniska pri jeho vykreslovani
    public static class VypisFazeMraveniska
    {
        public static void VypisFazeMraveniskaUvod(Mravenisko mravenisko, Label labelCas, Label labelFaza)
        {
            labelCas.Text = mravenisko.ZistiCasMraveniska().ToString();

            VypisFazeMraveniskaRozhod(mravenisko, labelFaza);
        }

        private static void VypisFazeMraveniskaRozhod(Mravenisko mravenisko, Label labelFaza)
        {
            switch (mravenisko.ZistiFazaMraveniska())
            {
                case FazaMraveniska.poBojiPolicku: labelFaza.Text = "Boje na polickach."; break;
                case FazaMraveniska.poBojiPrechadzani: labelFaza.Text = "Boje pri prechadzani."; break;
                case FazaMraveniska.poKonciKroku: labelFaza.Text = "Koniec kroku simulacie."; break;
                case FazaMraveniska.poPareni: labelFaza.Text = "Parenie."; break;
            }
        }
    }
}
