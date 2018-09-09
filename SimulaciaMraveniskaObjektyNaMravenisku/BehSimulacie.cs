using DatoveStruktury;
using SimulaciaMraveniskaHlasky;
using SimulaciaMraveniskaMravenisko;
using SimulaciaMraveniskaObjektyNaMravenisku;
using SimulaciaMraveniskaUdalostiSpravaUdalosti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//samotna simulacia mraveniska a ziskavanie vstupnych a vystupnych dat
namespace SimulaciaMraveniskaSimulacia
{
    //spustenie nacitavania hodnot
    //inicializacia zakladnych objektov, ako halda v ktorej su udalosti, mravesnisko,.
    //obsahuje funkciu, ktora postupne berie udalosti z haldy, az kym uzivatel nezrusi simulaciu
    //udalosti z haldy dava na dalsie spracovanie do TriedenieUdalosti
    public class BehSimulacie
    {

        int dobaBehu;
        Halda<Udalost> halda;
        Mravenisko mravenisko;
        bool vypis;//false - bezi simulacia, true - vykresluje sa mravenisko

        //spustenie simulacie, po jednom kroku sa zastavi jej vykonavanie, aby sa vykreslilo mravenisko
        public void SpustiSimulaciu()
        {
            while (NastaveneHodnotyPocasKrokov.ZistiPokracovanie() && !vypis)
            {
                Udalost udalost = halda.VratPrvok();

                vypis = TriedenieUdalosti.RoztriedUdalost(udalost, mravenisko, halda, ref dobaBehu);


            }

            NastavVypis(false);

        }

        //nastavy to hodnotu premennej vypis
        public void NastavVypis(bool hodnota)
        {
            vypis = hodnota;
        }

        //inicializacia objektov simulacia, ako mravenisko, hala, prvotne udalosti,...
        public void InicializujSimulaciu(string miestoUlozenia)
        {
            dobaBehu = 0;
            NastavVypis(false);
            //len konzolove
            //NacitavaciaTrieda.SpustiNacitanie(); 
            Konstanty.NastavStrategiuMravceTypu1();
            Konstanty.NastavStrategiuMravceTypu2();
            Konstanty.NastavMiestoUlozenia(miestoUlozenia);
            mravenisko = InicializaciaObjektovMraveniskoHalda.InicializaciaMraveniska();
            halda = InicializaciaObjektovMraveniskoHalda.InicializaciaHaldy();
            InicializaciaObjektovMraveniskoHalda.InicializujHodnoty(mravenisko);
        }

        //vracia objekt, ktory reprezentuje hodnoty, ktore su vypisovane, pri GUI v casti "Simulacia"
        public VypisovacieUdaje ZistiUdaje()
        {
            VypisovacieUdaje vypisovacieUdaje = new VypisovacieUdaje(mravenisko.ZistiPocetMravcovTypu1(),
                                                                    mravenisko.ZistiPocetMravcovTypu1Celkovo(),
                                                                    mravenisko.ZistiPocetMravcovTypu2(),
                                                                    mravenisko.ZistiPocetMravcovTypu2Celkovo(),
                                                                    mravenisko.ZistiPocetMravcovTypu3(),
                                                                    mravenisko.ZistiPocetMravcovTypu3Celkovo(),
                                                                    mravenisko.ZistiPocetMravcovTypu4(),
                                                                    mravenisko.ZistiPocetMravcovTypu4Celkovo(),
                                                                    mravenisko.ZistiPocetPotravy(),
                                                                    mravenisko.ZistiMnozstvoPotravyCelkovo(),
                                                                    dobaBehu);

            return vypisovacieUdaje;
        }

        //vrati mravenisko
        public Mravenisko ZistiMravenisko()
        {
            return mravenisko;
        }

        public int ZistiDobaBehu()
        {
            return dobaBehu;
        }

        //spravuje ukoncenie simulacie
        public void UkonecieSimulacie()
        {
            HlaskyInformacnePocasSimulacie.KoniecSimulacie(dobaBehu);
        }

        public BehSimulacie()
        {
        }

    }
}
