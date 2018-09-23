using SimulaciaMraveniskaMravenisko;
using SimulaciaMraveniskaObjektyNaMravenisku;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//GUI simulacie a jeho sprava a s tym suvisiace objekty a enum
namespace SimulaciaMraveniskaGUI
{
    //spravuje graficke zobrazovanie mraveniska
    public static class GrafickyVystup
    {
        //spusti vykreslovanie mraveniska
        public static void VykresliMraveniskoUvod(Mravenisko mravenisko, TabPage tabPage)
        {
            Graphics graphics;
            graphics = tabPage.CreateGraphics();

            VykresliMravenisko(mravenisko, graphics, tabPage);
        }
        //odstrani vykreslenie mraveniska
        public static void VykresliOknoBezSimulacie(TabPage tabPage)
        {
            Graphics graphics = tabPage.CreateGraphics();

            graphics.Clear(Color.White);
        }
        //zacne vykreslovanie mraveniska
        private static void VykresliMravenisko(Mravenisko mravenisko, Graphics graphics, TabPage tabPage)
        {

            int vyska;
            int sirka;
            int velkostStvorceka;


            vyska = tabPage.Height;
            sirka = tabPage.Width;
            velkostStvorceka = Math.Min(vyska / mravenisko.ZistiRozmerMraveniska(), sirka / mravenisko.ZistiRozmerMraveniska());

            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    switch (mravenisko.VratObjektNepohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)).ZistiTypObjektu())
                    {
                        case TypyObjektov.potrava:
                            VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka, Color.LawnGreen, graphics);
                            if (mravenisko.VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(new Suradnice(i, j)).Count > 0)
                            RozhodovanieOVyfarbovaniMravcovASituacii(mravenisko, graphics, i, j, velkostStvorceka);
                            break;
                        case TypyObjektov.prazdnaZem:
                            VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka,
                                     Color.Khaki, graphics);
                            if (mravenisko.VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(new Suradnice(i, j)).Count > 0)
                                RozhodovanieOVyfarbovaniMravcovASituacii(mravenisko, graphics, i, j, velkostStvorceka);
                            break;
                        case TypyObjektov.skala:
                            VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka,
                                     Color.Gray, graphics);
                            break;
                    }

            if (mravenisko.ZistiFazaMraveniska() == FazaMraveniska.poBojiPrechadzani)
                VykresliBojPriPrechadzani(mravenisko, graphics, velkostStvorceka);

            if (mravenisko.ZistiFazaMraveniska() == FazaMraveniska.poZnizeniEnergie)
                VykresliUbytokMravcovKoniec(mravenisko, graphics, velkostStvorceka);
        }
        // rozhoduje sa o tom ako, ake vykreslovanie mravcov sa bude diat, podla typu fazy vykreslovania
        private static void RozhodovanieOVyfarbovaniMravcovASituacii(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {

            VykresliMravcov(mravenisko, graphics, i, j, velkostStvorceka, 2);

            switch (mravenisko.ZistiFazaMraveniska())
            {
                case FazaMraveniska.poKonciKroku:
                    VypisPocetMravcovNaPolicku(i, j, velkostStvorceka, velkostStvorceka, velkostStvorceka,
                    mravenisko.VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(new Suradnice(i, j)).Count, graphics, Color.Black);
                    break;
                case FazaMraveniska.poBojiPolicku:
                    VykresliMravcovBojNaPolickach(mravenisko, graphics, i, j, velkostStvorceka);
                    break;
                case FazaMraveniska.poNastaveniSmerOtocenia:
                    VykresliSmerOtoceniaMravcovNaPolickach(mravenisko, graphics, i, j, velkostStvorceka);
                    break;
                case FazaMraveniska.poNastaveniSmerAktivnehoPohybuStatie:
                    VykresliSmerPohybuMravcovNaPolickach(mravenisko, graphics, i, j, velkostStvorceka);
                    VykresliZostanieStatiaMravcov(mravenisko, graphics, i, j, velkostStvorceka);
                    break;
                case FazaMraveniska.poVykonaniCinnostiNepohybovych:
                    VykresliJedenieMravcov(mravenisko, graphics, i, j, velkostStvorceka);
                    break;
                case FazaMraveniska.poPareni:
                    VykresliMravcovParenie(mravenisko, graphics, i, j, velkostStvorceka);
                    break;
            }
        }
        //zisti farbu mravcov podla typu
        private static Color ZistiFarbuMravcov(TypyMravcov typyMravcov)
        {
            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1: return Color.Blue;
                case TypyMravcov.MravecTypu2: return Color.Orange;
                case TypyMravcov.MravecTypu3: return Color.Pink;
                case TypyMravcov.MravecTypu4: return Color.LimeGreen;
            }

            return default(Color);
        }
        //zisti pritomnost daneho typu mravcov v poli, ktore obsahuje typy mravcov
        private static bool ZistiPritomnostMravcovDanehoTypu(TypyMravcov typyMravcov, List<TypyMravcov> typyMravcovs)
        {
            foreach (TypyMravcov typMravca in typyMravcovs)
                if (typMravca == typyMravcov)
                    return true;

            return false;
        }
        //nastavi ako sa maju vykreslit mravce v zakladnej podobe
        private static void VykresliMravcov(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka, int velkostCast)
        {

            Color farba = ZistiFarbuMravcov((mravenisko.VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(new Suradnice(i, j))[0] as Mravec).ZistiTypyMravcov());

            VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka,
                             velkostStvorceka / velkostCast,
                             velkostStvorceka, farba,
                             graphics);

        }
        //sposobi najprv vykreslenie policok medzi ktorymi sa bojovalo pri pohybe na cerveno
        //nasledne medzi nimi vykresli spojnice vo farbach mravcov
        private static void VykresliBojPriPrechadzani(Mravenisko mravenisko, Graphics graphics, int velkostStvorceka)
        {
            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    VykresliBojPriPrechadzaniPolicka(mravenisko, graphics, i, j, velkostStvorceka);

            for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    VykresliBojPriPrechadzaniSpojnice(mravenisko, graphics, i, j, velkostStvorceka);
        }
        //vykresli ako cervene policka, tie, medzi ktorymi sa bojovalo
        private static void VykresliBojPriPrechadzaniPolicka(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            if ( mravenisko.ZistiPolickaBojPrechadzajuce(i,j) != default(List<PolickaPriPrechadzajucomBoji>))
                foreach(PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji in mravenisko.ZistiPolickaBojPrechadzajuce(i, j))
                {
                    VykresliObdlznik(polickaPriPrechadzajucomBoji.ZistiSuradniceMravcov().ZistiXSuradnicu() * velkostStvorceka,
                                     polickaPriPrechadzajucomBoji.ZistiSuradniceMravcov().ZistiYSuradnicu() * velkostStvorceka,
                                     velkostStvorceka, velkostStvorceka, Color.Red, graphics);
                    VykresliObdlznik(polickaPriPrechadzajucomBoji.ZistiDruhePolicko().ZistiSuradniceMravcov().ZistiXSuradnicu() * velkostStvorceka,
                                     polickaPriPrechadzajucomBoji.ZistiDruhePolicko().ZistiSuradniceMravcov().ZistiYSuradnicu() * velkostStvorceka,
                                     velkostStvorceka, velkostStvorceka, Color.Red, graphics);
                }
            
        }
        //vykresli 2 spojnice spajajuce policka, tieto ciary reprezentuju boj mravcov pri prechadzani medzi tymito polickami, farby ciar reprezentuju typy mravcov, ktore bojuju
        //takisto vykresli
        private static void VykresliBojPriPrechadzaniSpojnice(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            if (mravenisko.ZistiPolickaBojPrechadzajuce(i, j) != default(List<PolickaPriPrechadzajucomBoji>) && 
                mravenisko.ZistiPolickaBojPrechadzajuce(i, j).Count > 0)
            {

                foreach (PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji1 in mravenisko.ZistiPolickaBojPrechadzajuce(i, j))
                {
                    PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji2 = polickaPriPrechadzajucomBoji1.ZistiDruhePolicko();

                    Suradnice suradnice1 = polickaPriPrechadzajucomBoji1.ZistiSuradniceMravcov();
                    Suradnice suradnice2 = polickaPriPrechadzajucomBoji2.ZistiSuradniceMravcov();

                    Pen pen1 = new Pen(ZistiFarbuMravcov(polickaPriPrechadzajucomBoji1.ZistiTypMravcov()), 3);
                    Pen pen2 = new Pen(ZistiFarbuMravcov(polickaPriPrechadzajucomBoji2.ZistiTypMravcov()), 3);


                    if (NasledujucePolickoMraveniska.SmerJ(suradnice1, mravenisko.ZistiRozmerMraveniska()).ZistiXSuradnicu() == suradnice2.ZistiXSuradnicu() &&
                        NasledujucePolickoMraveniska.SmerJ(suradnice1, mravenisko.ZistiRozmerMraveniska()).ZistiYSuradnicu() == suradnice2.ZistiYSuradnicu())
                    {
                        if (Math.Abs(suradnice1.ZistiYSuradnicu() - suradnice2.ZistiYSuradnicu()) == 1)
                        {
                            VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                          suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                          graphics, velkostStvorceka / 2, velkostStvorceka / 2);
                            VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                          suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                          graphics, velkostStvorceka / 2 + 3, velkostStvorceka / 2);
                        }
                        else
                        {
                            VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                          suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka + velkostStvorceka / 2,
                                          graphics, velkostStvorceka / 2, velkostStvorceka / 2);
                            VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                          suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka + velkostStvorceka / 2,
                                          graphics, velkostStvorceka / 2 + 3, velkostStvorceka / 2);
                            VykresliCiaru(pen1, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka - velkostStvorceka / 2,
                                          suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                          graphics, velkostStvorceka / 2, velkostStvorceka / 2);
                            VykresliCiaru(pen2, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka - velkostStvorceka/2,
                                          suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka ,
                                          graphics, velkostStvorceka / 2 + 3, velkostStvorceka / 2);
                        }

                    }
                    else
                    {
                        if (Math.Abs(suradnice1.ZistiXSuradnicu() - suradnice2.ZistiXSuradnicu()) == 1)
                        {
                            VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                          suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                          graphics, velkostStvorceka / 2, velkostStvorceka / 2);

                            VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka, suradnice2.ZistiXSuradnicu()
                                          * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                          graphics, velkostStvorceka / 2, velkostStvorceka / 2 + 3);
                        }
                        else
                        {
                            VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka - velkostStvorceka/2, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                          suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                          graphics, velkostStvorceka / 2, velkostStvorceka / 2);

                            VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka - velkostStvorceka/2, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                          suradnice1.ZistiXSuradnicu() * velkostStvorceka,
                                          suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                          graphics, velkostStvorceka / 2, velkostStvorceka / 2 + 3);

                            VykresliCiaru(pen1, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                          suradnice2.ZistiXSuradnicu() * velkostStvorceka + velkostStvorceka/2, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                          graphics, velkostStvorceka / 2, velkostStvorceka / 2);

                            VykresliCiaru(pen2, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                         suradnice2.ZistiXSuradnicu() * velkostStvorceka + velkostStvorceka/2, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                         graphics, velkostStvorceka / 2, velkostStvorceka / 2 + 3);

                        }
                    }

                }
            }

        }
        //vykresli policka, kde mravce bojuju na danom policku
        private static void VykresliMravcovBojNaPolickach(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            PolickaPriBojiNaPolicku polickaPriBojiNaPolicku = mravenisko.ZistiPolickoBojNaPolicko(i, j);
            List<TypyMravcov> typyMravcovPole;

            if (polickaPriBojiNaPolicku != default(PolickaPriBojiNaPolicku))
            {

                typyMravcovPole = polickaPriBojiNaPolicku.ZistiTypyMravcovPole();

                if (ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu1, typyMravcovPole))
                    VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka / 2, velkostStvorceka / 2,
                                     ZistiFarbuMravcov(TypyMravcov.MravecTypu1), graphics);
                else VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka / 2, velkostStvorceka / 2, Color.White, graphics);

                if (ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu2, typyMravcovPole))
                    VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2, j * velkostStvorceka, velkostStvorceka / 2,
                                     velkostStvorceka / 2, ZistiFarbuMravcov(TypyMravcov.MravecTypu2),graphics);
                else VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2, j * velkostStvorceka, velkostStvorceka / 2, velkostStvorceka / 2, 
                                      Color.White, graphics);

                if (ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu3, typyMravcovPole))
                    VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka + velkostStvorceka / 2, velkostStvorceka / 2, velkostStvorceka / 2,
                                     ZistiFarbuMravcov(TypyMravcov.MravecTypu3), graphics);
                else VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka + velkostStvorceka / 2, velkostStvorceka / 2, velkostStvorceka / 2, 
                                      Color.White, graphics);

                if ((ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu4, typyMravcovPole)))
                    VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2, j * velkostStvorceka + velkostStvorceka / 2,
                                     velkostStvorceka / 2, velkostStvorceka / 2,ZistiFarbuMravcov(TypyMravcov.MravecTypu4), graphics);
                else VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2, j * velkostStvorceka + velkostStvorceka / 2, velkostStvorceka / 2, 
                                      velkostStvorceka / 2, Color.White, graphics);
            }


        }
        //vykresli smer otocenia mravcov na polickach
        private static void VykresliSmerOtoceniaMravcovNaPolickach(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            bool smerPohybuS = false, smerPohybuZ = false, smerPohybuJ = false, smerPohybuV = false;
            
            foreach(PohybujuceSaObjekty objekt in mravenisko.VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(new Suradnice(i, j)))
            {
                Mravec mravec = objekt as Mravec;

                switch(mravec.ZistiSmerPohybu())
                {
                    case SmerPohybu.s: smerPohybuS = true; break;
                    case SmerPohybu.z: smerPohybuZ = true; break;
                    case SmerPohybu.j: smerPohybuJ = true; break;
                    case SmerPohybu.v: smerPohybuV = true; break; 
                }
            }

            Pen pen = new Pen(Color.Black, 2);
            SolidBrush solidBrush = new SolidBrush(Color.Yellow);

            int zakladX = i * velkostStvorceka;
            int zakladY = j * velkostStvorceka;

            if (smerPohybuS) VykresliTrojuholnik(pen, solidBrush, graphics, zakladX + velkostStvorceka / 4, zakladY + velkostStvorceka / 4,
                                                 zakladX + velkostStvorceka / 2, zakladY + 1, zakladX + velkostStvorceka * 3 / 4, zakladY + velkostStvorceka / 4);

            if (smerPohybuZ) VykresliTrojuholnik(pen, solidBrush, graphics, zakladX + velkostStvorceka / 4, zakladY + velkostStvorceka / 4,
                                                 zakladX + 1, zakladY + velkostStvorceka / 2, zakladX + velkostStvorceka / 4, zakladY + velkostStvorceka * 3 / 4);

            if (smerPohybuJ) VykresliTrojuholnik(pen, solidBrush, graphics, zakladX + velkostStvorceka / 4, zakladY + velkostStvorceka * 3 / 4,
                                                 zakladX + velkostStvorceka / 2, zakladY + velkostStvorceka - 1, zakladX + velkostStvorceka * 3 / 4, 
                                                 zakladY + velkostStvorceka * 3 / 4);

            if (smerPohybuV) VykresliTrojuholnik(pen, solidBrush, graphics, zakladX + velkostStvorceka * 3 / 4, zakladY + velkostStvorceka / 4,
                                                 zakladX + velkostStvorceka -1, zakladY + velkostStvorceka / 2, zakladX + velkostStvorceka * 3 / 4, 
                                                 zakladY + velkostStvorceka * 3 / 4);
                      

        }       
        //vykresli smer pohybu mravcov na polickach
        private static void VykresliSmerPohybuMravcovNaPolickach(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            bool aktivnySmerPohybuS = false; bool aktivneSmerPohybuZ = false; bool aktivnySmerPohybuJ = false; bool aktivnySmerPohybuV = false;

            foreach (PohybujuceSaObjekty pohybujuceSaObjekty in mravenisko.VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(new Suradnice(i, j)))
            {
                Mravec mravec = pohybujuceSaObjekty as Mravec;

                if(mravec.ZistiCinnostMravca() == CinnostiMravcov.chodDopreduObrana || mravec.ZistiCinnostMravca() == CinnostiMravcov.chodDopreduUtok)
                    switch (mravec.ZistiSmerPohybu())
                    {
                        case SmerPohybu.s:aktivnySmerPohybuS = true; break;
                        case SmerPohybu.v:aktivnySmerPohybuV = true; break;
                        case SmerPohybu.j:aktivnySmerPohybuJ = true; break;
                        case SmerPohybu.z:aktivneSmerPohybuZ = true; break;
                    }
            }

            int zakladX = i * velkostStvorceka;
            int zakladY = j * velkostStvorceka;

            Pen pen = new Pen(Color.Black, 2);
            SolidBrush solidBrush = new SolidBrush(Color.WhiteSmoke);

            if (aktivnySmerPohybuS) VykresliTrojuholnik(pen, solidBrush, graphics, zakladX + velkostStvorceka / 4, zakladY + velkostStvorceka / 4,
                                                 zakladX + velkostStvorceka / 2, zakladY + 1, zakladX + velkostStvorceka * 3 / 4, zakladY + velkostStvorceka / 4);

            if (aktivneSmerPohybuZ) VykresliTrojuholnik(pen, solidBrush, graphics, zakladX + velkostStvorceka / 4, zakladY + velkostStvorceka / 4,
                                                zakladX + 1, zakladY + velkostStvorceka / 2, zakladX + velkostStvorceka / 4, zakladY + velkostStvorceka * 3 / 4);

            if (aktivnySmerPohybuJ) VykresliTrojuholnik(pen, solidBrush, graphics, zakladX + velkostStvorceka / 4, zakladY + velkostStvorceka * 3 / 4,
                                                 zakladX + velkostStvorceka / 2, zakladY + velkostStvorceka - 1, zakladX + velkostStvorceka * 3 / 4, 
                                                 zakladY + velkostStvorceka * 3 / 4);

            if (aktivnySmerPohybuV) VykresliTrojuholnik(pen, solidBrush, graphics, zakladX + velkostStvorceka * 3 / 4, zakladY + velkostStvorceka / 4,
                                                 zakladX + velkostStvorceka - 1, zakladY + velkostStvorceka / 2, zakladX + velkostStvorceka * 3 / 4, 
                                                 zakladY + velkostStvorceka * 3 / 4);
        }
        //vykresli kruh, tam kde mravce zostali stat
        private static void VykresliZostanieStatiaMravcov(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            bool zostaliStat = false;
            foreach(PohybujuceSaObjekty objekt in mravenisko.VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(new Suradnice(i, j)))
            {
                Mravec mravec = objekt as Mravec;

                if (mravec.ZistiCinnostMravca() == CinnostiMravcov.zostan) zostaliStat = true;
            }

            if (zostaliStat) VykresliElipsu(i * velkostStvorceka + velkostStvorceka / 4, j * velkostStvorceka + velkostStvorceka / 4, velkostStvorceka / 2, velkostStvorceka / 2,
                                            Color.Aqua, graphics);
        }
        //vykresli policka, kde sa mravce uspesne najedli, taktiez vypise kolko mravcov sa najedlo
        private static void VykresliJedenieMravcov(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            int pocetMravcovNajedlo = 0;

            if (mravenisko.ZistiJedenie(i, j))
            {
                foreach (PohybujuceSaObjekty objekt in mravenisko.VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(new Suradnice(i, j)))
                {
                    Mravec mravec = objekt as Mravec;

                    if (mravec.ZistiCinnostMravca() == CinnostiMravcov.najedzSa && mravec.ZistiPodariloSa() == true) pocetMravcovNajedlo++;
                }

                VykresliObdlznik(i * velkostStvorceka, j*velkostStvorceka, velkostStvorceka, velkostStvorceka, Color.LightGreen, graphics);
                VypisPocetMravcovNaPolicku(i, j, velkostStvorceka, velkostStvorceka, velkostStvorceka, pocetMravcovNajedlo, graphics, Color.Black);
            }
            
        }
        //vykresli policka, kde doslo k ubytku mravcov z dosledku znizenia energie mravcov na konci kroku, taktiez vypise kolko takychto mravcov bolo
        private static void VykresliUbytokMravcovKoniec(Mravenisko mravenisko, Graphics graphics, int velkostStvorceka)
        {
            for(int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                for(int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                    if (mravenisko.ZistiUbytokMravcovPoZnizeniEnergie(i, j))
                    {
                        int pocetOdislichMravcov = mravenisko.ZistiPocetMravcovOdisliZnizenimEnergie(i, j);
                        VykresliObdlznik(i * velkostStvorceka, j *velkostStvorceka, velkostStvorceka, velkostStvorceka, Color.Black, graphics);
                        VypisPocetMravcovNaPolicku(i , j, velkostStvorceka, velkostStvorceka, velkostStvorceka, pocetOdislichMravcov, graphics, Color.White);
                    }
        }
        //vykresli policka, kde prebieha parenie
        private static void VykresliMravcovParenie(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            if (mravenisko.ZistiParenie(i, j))
            {
                VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka, Color.White, graphics);
                VykresliElipsu(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka,
                    ZistiFarbuMravcov((mravenisko.VratObjektPohybujuceSaNaDanychSuradniciachZobrazovanie(new Suradnice(i, j))[0] as Mravec).ZistiTypyMravcov()), graphics);
            }

        }
        //vykresli samotne policko, obldznik
        private static void VykresliObdlznik(int x, int y, int sirka, int vyska, Color farba, Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 2);
            SolidBrush solidBrush = new SolidBrush(farba);

            graphics.DrawRectangle(pen, x, y, sirka, vyska);
            graphics.FillRectangle(solidBrush, x, y, sirka, vyska);

        }
        //vykresli samotne policko, obdlznik
        private static void VykresliElipsu(int x, int y, int sirka, int vyska, Color farba, Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 2);
            SolidBrush solidBrush = new SolidBrush(farba);

            graphics.DrawEllipse(pen, x, y, sirka, vyska);
            graphics.FillEllipse(solidBrush, x, y, sirka, vyska);
        }
        //vykresli ciaru s pripadnym posunutim
        private static void VykresliCiaru(Pen pen, int x1, int y1, int x2, int y2, Graphics graphics, int posunX, int posunY)
        {
            graphics.DrawLine(pen, x1 + posunX, y1 + posunY, x2 + posunX, y2 + posunY);
        }    
        //vykresli trojuholnik
        private static void VykresliTrojuholnik(Pen pen, SolidBrush solidBrush, Graphics graphics, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            Point[] points = new Point[3];
            Point point = new Point(x1, y1);
            points[0] = point;
            point = new Point(x2, y2);
            points[1] = point;
            point = new Point(x3, y3);
            points[2] = point;

            graphics.DrawPolygon(pen, points);
            graphics.FillPolygon(solidBrush, points);
 
        }
        //vypis pocet mravcov na policku
        private static void VypisPocetMravcovNaPolicku(int x, int y,int velkostStvorceka, int sirka, int vyska, int pocet,Graphics graphics, Color color)
        {
            string retazec = pocet.ToString();
            Rectangle rectangle = new Rectangle(x * velkostStvorceka + sirka/8, y * velkostStvorceka + vyska/8, sirka, vyska);
            Font font = new Font( FontFamily.GenericSerif, velkostStvorceka/3);

            Brush brush = new SolidBrush(color);

            graphics.DrawString(retazec, font, brush, rectangle);
        }
   }
}