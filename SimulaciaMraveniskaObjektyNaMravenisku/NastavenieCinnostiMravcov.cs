using DatoveStruktury;
using SimulaciaMraveniskaMravenisko;
using SimulaciaMraveniskaObjektyNaMravenisku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//sprava udalosti a suvisiace objekty a enum typy
namespace SimulaciaMraveniskaUdalostiSpravaUdalosti
{
    //nastavy cinnost mravcov
    public static class NastavenieCinnostiMravcov
    {

        //zisti typ policka vpredu, dostane suradnice policka, ktore je vpredu
        private static TypyPolicok ZistiTypPolickaVpredu(Mravenisko mravenisko, TypyMravcov typyMravcov, Suradnice suradnice)
        {
            TypyPolicok typyPolicok = default(TypyPolicok);

            switch (mravenisko.VratObjektNepohybujuceSaNaDanychSuradniciach(suradnice).ZistiTypObjektu())
            {
                case TypyObjektov.skala: typyPolicok = TypyPolicok.skala; break;
                case TypyObjektov.prazdnaZem:
                    {
                        List<PohybujuceSaObjekty> mravce = mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(suradnice);
                        if (mravce.Count == 0) typyPolicok = TypyPolicok.prazdnaZem;
                        else if ((mravce[0] as Mravec).ZistiTypyMravcov() == typyMravcov) typyPolicok = TypyPolicok.priatelPrazdnaZem;
                        else typyPolicok = TypyPolicok.nepriatelPrazdnaZem;
                    }
                    break;
                case TypyObjektov.potrava:
                    {
                        List<PohybujuceSaObjekty> mravce = mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(suradnice);
                        if (mravce.Count == 0) typyPolicok = TypyPolicok.potrava;
                        else if ((mravce[0] as Mravec).ZistiTypyMravcov() == typyMravcov) typyPolicok = TypyPolicok.priatelPotrava;
                        else typyPolicok = TypyPolicok.nepriatelPotrava;
                    }
                    break;
            }

            return typyPolicok;
        }

        //zisti typ policka, na ktorom mravec stoji
        private static TypyPolicok ZistiTypPolickaSucasne(Mravenisko mravenisko, TypyMravcov typyMravcov, Suradnice suradnice)
        {
            TypyPolicok typyPolicok = default(TypyPolicok);

            switch (mravenisko.VratObjektNepohybujuceSaNaDanychSuradniciach(suradnice).ZistiTypObjektu())
            {
                case TypyObjektov.prazdnaZem:
                    {
                        List<PohybujuceSaObjekty> mravce = mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(suradnice);
                        if (mravce.Count > 1) typyPolicok = TypyPolicok.priatelPrazdnaZem;
                        else typyPolicok = TypyPolicok.prazdnaZem;
                    }
                    break;
                case TypyObjektov.potrava:
                    {
                        List<PohybujuceSaObjekty> mravce = mravenisko.VratObjektPohybujuceSaNaDanychSuradniciach(suradnice);
                        if (mravce.Count > 1) typyPolicok = TypyPolicok.priatelPotrava;
                        else typyPolicok = TypyPolicok.potrava;
                    }
                    break;
            }

            return typyPolicok;
        }

        //zisti cinnost mravca, ktora vypliva z policok pred mravcom a na ktorom stoji
        private static CinnostiMravcov ZistenieCinnostiMravca(TypyPolicok typyPolicokSucasne, TypyPolicok typyPolicokPred,
                                                            TypyMravcov typyMravcov)
        {
            int polickoSucasne;
            int polickoPred;

            polickoPred = (int)typyPolicokPred;
            polickoSucasne = (int)typyPolicokSucasne;

            if (polickoSucasne > 0) polickoSucasne--;

            CinnostiMravcov cinnostMravca;

            switch (typyMravcov)
            {
                case TypyMravcov.MravecTypu1: { cinnostMravca = Konstanty.strategiaMravcaTypu1.ZistiStrategiaPodlaSuradnice(polickoSucasne, polickoPred); break; }
                case TypyMravcov.MravecTypu2: { cinnostMravca = Konstanty.strategiaMravcaTypu2.ZistiStrategiaPodlaSuradnice(polickoSucasne, polickoPred); break; }
                case TypyMravcov.MravecTypu3: { cinnostMravca = Konstanty.strategiaMravcaTypu3.ZistiStrategiaPodlaSuradnice(polickoSucasne, polickoPred); break; }
                case TypyMravcov.MravecTypu4: { cinnostMravca = Konstanty.strategiaMravcaTypu4.ZistiStrategiaPodlaSuradnice(polickoSucasne, polickoPred); break; }
                default: cinnostMravca = default(CinnostiMravcov); break;
            }

            return cinnostMravca;
        }

        //nastavi cinnosti mravca, v zavislosti od toho vytvori Udalost, parit sa je cinnost viacerych mravcov a najedenie sa 
        //nie je pohybova cinnost a tak maju samostatny typ udalosti
        public static void NastavenieCinnostiMravca(Halda<Udalost> halda, int cas, Mravec mravec, Mravenisko mravenisko)
        {
            CinnostiMravcov cinnostiMravcovNova = ZistenieCinnostiMravca(ZistiTypPolickaSucasne(mravenisko, mravec.ZistiTypyMravcov(),
                                                   mravec.ZistiSuradnica()), ZistiTypPolickaVpredu(mravenisko, mravec.ZistiTypyMravcov(),
                                                   NasledujucePolickoMraveniska.ZistiSuradniceNasledujucehoPolicka(
                                                       mravec.ZistiSuradnica(),
                                                       mravec.ZistiSmerPohybu(), mravenisko.ZistiRozmerMraveniska())),
                                                   mravec.ZistiTypyMravcov());

            mravec.NastavCinnostMravca(cinnostiMravcovNova);


            if (cinnostiMravcovNova == CinnostiMravcov.paritSa)
            {
                mravec.NastavParitSa(true);

                if (!NastaveneHodnotyPocasKrokov.ZistiParenie())
                {
                    Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.paritSa,
                                                    TypyUdalosti.paritSa);
                    halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());

                    NastaveneHodnotyPocasKrokov.NastavParenie(true);

                }

            }
            else if (cinnostiMravcovNova == CinnostiMravcov.najedzSa)
            {
                Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.vykonanieCinnostiMravcovNepohybovych,
                    TypyUdalosti.vykonanieCinnostiMravcovNepohybovych, mravec);
                halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
            }
            else
            {


                Udalost udalost = new Udalost(cas + 1, (int)TypyUdalosti.vykonanieCinnostiMravcovPohybovych + (int)cinnostiMravcovNova,
                                                TypyUdalosti.vykonanieCinnostiMravcovPohybovych, mravec);



                halda.VlozPrvok(udalost, udalost.ZistiCasNastania(), udalost.ZistiPriorita());
            }

        }
    }
}
