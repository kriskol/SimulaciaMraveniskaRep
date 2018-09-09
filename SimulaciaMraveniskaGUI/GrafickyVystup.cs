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
                {
                    switch (mravenisko.VratObjektNepohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)).ZistiTypObjektu())
                    {
                        case TypyObjektov.potrava:
                            {
                                VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka, Color.LawnGreen, graphics);

                                if (mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)).Count > 0)

                                    RozhodovanieOVyfarbovaniMravcov(mravenisko, graphics, i, j, velkostStvorceka);

                            }
                            break;
                        case TypyObjektov.prazdnaZem:
                            {
                                VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka,
                                        Color.Khaki, graphics);

                                if (mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j)).Count > 0)

                                    RozhodovanieOVyfarbovaniMravcov(mravenisko, graphics, i, j, velkostStvorceka);


                            }
                            break;
                        case TypyObjektov.skala:
                            {
                                VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka,
                                            Color.Gray, graphics);

                            }
                            break;
                    }
                }

            if (mravenisko.ZistiFazaMraveniska() == FazaMraveniska.poBojiPrechadzani)
                for (int i = 0; i < mravenisko.ZistiRozmerMraveniska(); i++)
                    for (int j = 0; j < mravenisko.ZistiRozmerMraveniska(); j++)
                        VyfarbenieBojPriPrechadzaniSpojnice(mravenisko, graphics, i, j, velkostStvorceka);
        }


        // rozhoduje sa o tom ako, ake vykreslovanie mravcov sa bude diat, podla typu fazy vykreslovania
        public static void RozhodovanieOVyfarbovaniMravcov(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            switch (mravenisko.ZistiFazaMraveniska())
            {
                case FazaMraveniska.poKonciKroku: VyfarbenieMravcov(mravenisko, graphics, i, j, velkostStvorceka, 2); break;
                case FazaMraveniska.poBojiPrechadzani:
                    {
                        VyfarbenieMravcov(mravenisko, graphics, i, j, velkostStvorceka, 2);
                        VyfarbenieBojPriPrechadzaniPolicko(mravenisko, i, j, graphics, velkostStvorceka);
                    }
                    break;
                case FazaMraveniska.poBojiPolicku:
                    {
                        VyfarbenieMravcov(mravenisko, graphics, i, j, velkostStvorceka, 2);
                        VyfarbenieMravcovBojNaPolickach(mravenisko, graphics, i, j, velkostStvorceka);
                    }
                    break;
                case FazaMraveniska.poPareni:
                    {
                        VyfarbenieMravcov(mravenisko, graphics, i, j, velkostStvorceka, 2);
                        VyfarbenieMravcovParenie(mravenisko, graphics, i, j, velkostStvorceka);
                    }
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

        //zisti pritomnost daneho typu mravcov v poli, ktore obsahuje typy mr
        private static bool ZistiPritomnostMravcovDanehoTypu(TypyMravcov typyMravcov, List<TypyMravcov> typyMravcovs)
        {
            foreach (TypyMravcov typMravca in typyMravcovs) if (typMravca == typyMravcov) return true;

            return false;
        }

        //nastavi ako sa maju vykreslit mravce v zakladnej podobe
        private static void VyfarbenieMravcov(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka, int velkostCast)
        {

            Color farba = ZistiFarbuMravcov((mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j))[0] as Mravec).ZistiTypyMravcov());

            VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka
                              , velkostStvorceka / velkostCast,
                             velkostStvorceka, farba,
                              graphics);

        }

        private static void VyfarbenieBojPriPrechadzaniPolicko(Mravenisko mravenisko, int i, int j, Graphics graphics, int velkostStvorceka)
        {
            if (mravenisko.ZistiPolickBojPrechadzajuce(i, j) != default(List<PolickaPriPrechadzajucomBoji>) && mravenisko.ZistiPolickBojPrechadzajuce(i, j).Count
                > 0)
                foreach (PolickaPriPrechadzajucomBoji polickoPrechadzajuce in mravenisko.ZistiPolickBojPrechadzajuce(i, j))
                {
                    VykresliObdlznik(polickoPrechadzajuce.ZistiSuradniceMravcov().ZistiXSuradnicu() * velkostStvorceka,
                        polickoPrechadzajuce.ZistiSuradniceMravcov().ZistiYSuradnicu() * velkostStvorceka,
                        velkostStvorceka, velkostStvorceka, Color.Red, graphics);

                    VykresliObdlznik(polickoPrechadzajuce.ZistiDruhePolicko().ZistiSuradniceMravcov().ZistiXSuradnicu() * velkostStvorceka,
                        polickoPrechadzajuce.ZistiDruhePolicko().ZistiSuradniceMravcov().ZistiYSuradnicu() * velkostStvorceka, velkostStvorceka,
                        velkostStvorceka, Color.Red, graphics);
                }
        }

        //vykresli 2 spojnice spajajuce policka, tieto ciary reprezentuju boj mravcov pri prechadzani medzi tymito polickami, farby ciar reprezentuju typy mravcov, ktore bojuju
        //takisto vykresli
        private static void VyfarbenieBojPriPrechadzaniSpojnice(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            if (mravenisko.ZistiPolickBojPrechadzajuce(i, j) != default(List<PolickaPriPrechadzajucomBoji>) && mravenisko.ZistiPolickBojPrechadzajuce(i, j).Count > 0)
            {

                foreach (PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji1 in mravenisko.ZistiPolickBojPrechadzajuce(i, j))
                {
                    PolickaPriPrechadzajucomBoji polickaPriPrechadzajucomBoji2 = polickaPriPrechadzajucomBoji1.ZistiDruhePolicko();

                    Suradnice suradnice1 = polickaPriPrechadzajucomBoji1.ZistiSuradniceMravcov();
                    Suradnice suradnice2 = polickaPriPrechadzajucomBoji2.ZistiSuradniceMravcov();

                    Pen pen1 = new Pen(ZistiFarbuMravcov(polickaPriPrechadzajucomBoji1.ZistiTypMravcov()), 3);
                    Pen pen2 = new Pen(ZistiFarbuMravcov(polickaPriPrechadzajucomBoji2.ZistiTypMravcov()), 3);

                    if (NasledujucePolickoMraveniska.SmerJ(suradnice1, mravenisko.ZistiRozmerMraveniska()) == suradnice2)
                    {
                        if (Math.Abs(suradnice1.ZistiYSuradnicu() - suradnice2.ZistiYSuradnicu()) == 1)
                        {
                            VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                            suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2,
                                                velkostStvorceka / 2);

                            VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                            suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2 + 3,
                                             velkostStvorceka / 2);
                        }
                        else
                        {
                            VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                            suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka + velkostStvorceka / 2
                                            , graphics, velkostStvorceka / 2,
                                                velkostStvorceka / 2);

                            VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                            suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka + velkostStvorceka / 2,
                                            graphics, velkostStvorceka / 2 + 3,
                                             velkostStvorceka / 2);

                            VykresliCiaru(pen1, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                            suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka - velkostStvorceka / 2,
                                            graphics, velkostStvorceka / 2,
                                                velkostStvorceka / 2);

                            VykresliCiaru(pen2, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                            suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka - velkostStvorceka / 2,
                                            graphics, velkostStvorceka / 2 + 3,
                                             velkostStvorceka / 2);
                        }

                    }
                    else
                    {
                        if (Math.Abs(suradnice1.ZistiXSuradnicu() - suradnice2.ZistiXSuradnicu()) == 1)
                        {
                            VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                            suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2,
                                            velkostStvorceka / 2);

                            VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka, suradnice2.ZistiXSuradnicu()
                                * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2, velkostStvorceka / 2 + 3);
                        }
                        else
                        {
                            VykresliCiaru(pen1, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                            suradnice1.ZistiXSuradnicu() * velkostStvorceka + velkostStvorceka / 2, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                            graphics, velkostStvorceka / 2,
                                            velkostStvorceka / 2);

                            VykresliCiaru(pen2, suradnice1.ZistiXSuradnicu() * velkostStvorceka, suradnice1.ZistiYSuradnicu() * velkostStvorceka,
                                suradnice1.ZistiXSuradnicu() * velkostStvorceka + velkostStvorceka / 2,
                                suradnice1.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2, velkostStvorceka / 2 + 3);

                            VykresliCiaru(pen1, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                            suradnice2.ZistiXSuradnicu() * velkostStvorceka - velkostStvorceka / 2, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics,
                                            velkostStvorceka / 2,
                                            velkostStvorceka / 2);

                            VykresliCiaru(pen2, suradnice2.ZistiXSuradnicu() * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka,
                                suradnice2.ZistiXSuradnicu() - velkostStvorceka / 2
                                * velkostStvorceka, suradnice2.ZistiYSuradnicu() * velkostStvorceka, graphics, velkostStvorceka / 2, velkostStvorceka / 2 + 3);

                        }
                    }

                }
            }

        }

        //vykresli policka, kde mravce bojuju na danom policku
        private static void VyfarbenieMravcovBojNaPolickach(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            PolickaPriBojiNaPolicku polickaPriBojiNaPolicku = mravenisko.ZistiPolickoBojNaPolicko(i, j);
            List<TypyMravcov> typyMravcovPole;

            if (polickaPriBojiNaPolicku != default(PolickaPriBojiNaPolicku))
            {

                typyMravcovPole = polickaPriBojiNaPolicku.ZistiTypyMravcovPole();

                if ((ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu1, typyMravcovPole))) VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka,
                                                                                velkostStvorceka / 2, velkostStvorceka / 2,
                                                                                                     ZistiFarbuMravcov(TypyMravcov.MravecTypu1), graphics);
                else VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka / 2, velkostStvorceka / 2, Color.White, graphics);

                if ((ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu2, typyMravcovPole))) VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2,
                                                                                                                    j * velkostStvorceka, velkostStvorceka / 2,
                                                                                                                    velkostStvorceka / 2, ZistiFarbuMravcov(TypyMravcov.MravecTypu2),
                                                                                                                    graphics);
                else VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2, j * velkostStvorceka, velkostStvorceka / 2, velkostStvorceka / 2, Color.White,
                                        graphics);

                if ((ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu3, typyMravcovPole))) VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka + velkostStvorceka / 2,
                                                                                                                   velkostStvorceka / 2, velkostStvorceka / 2,
                                                                                                                   ZistiFarbuMravcov(TypyMravcov.MravecTypu3), graphics);
                else VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka + velkostStvorceka / 2, velkostStvorceka / 2, velkostStvorceka / 2, Color.White, graphics);

                if ((ZistiPritomnostMravcovDanehoTypu(TypyMravcov.MravecTypu4, typyMravcovPole))) VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2,
                                                                                                                    j * velkostStvorceka + velkostStvorceka / 2,
                                                                                                                    velkostStvorceka / 2, velkostStvorceka / 2,
                                                                                                                    ZistiFarbuMravcov(TypyMravcov.MravecTypu4), graphics);
                else VykresliObdlznik(i * velkostStvorceka + velkostStvorceka / 2, j * velkostStvorceka + velkostStvorceka / 2, velkostStvorceka / 2, velkostStvorceka / 2,
                    Color.White, graphics);
            }


        }

        //vykresli policka, kde prebieha parenie
        private static void VyfarbenieMravcovParenie(Mravenisko mravenisko, Graphics graphics, int i, int j, int velkostStvorceka)
        {
            if (mravenisko.ZistiParenie(i, j))
            {
                VykresliObdlznik(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka, Color.White, graphics);

                VykresliElipsu(i * velkostStvorceka, j * velkostStvorceka, velkostStvorceka, velkostStvorceka,
                    (ZistiFarbuMravcov((mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(new Suradnice(i, j))[0] as Mravec).ZistiTypyMravcov())), graphics);
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
    }
}
