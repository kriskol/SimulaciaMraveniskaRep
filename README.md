# SimulaciaMraveniskaRep
Simulácia mraveniska

Informácie o spustení simulácie:

Ako "Start Up Project" je nastavená windows form app. v zložke SimulaciaMraveniskaGUI, pomocou tohto GUI je možné nastaviť atribúty simulácie. Konzolové načítanie v časti SimulaciaMraveniskaSpustenieKonzolove v terajšej verzii kódu nie je možné, i keď je predpripravené.

Výpis behu simulácie je ale stále konzolový, takisto i samotné ukončenie simulácie je zatiaľ konzolové, teda pre výpis behu 
je nutné nastaviť "output type" na konzolový výstup.
V nastaveniach simulácie je taktiež možné nastaviť súbor, kam sa bude konzolový výstup simulácie zapisovať.

To či má byť simulácia ukončená je dotazované po 1. kroku (po jednej časovej jednotke) a následne po každých 10 krokoch simulácie.

Informácie o simulácii:

V simulácii sú prítomné 4 typy mravcov, mravec 1.typu (modrá farba), 2.typu( hnedá farba), 3.typu(rúžová farba), 
4.typu (limetkovo-zelená farba).

Typy políčok(stratégia mravca):
prázdna zem - políčko na ktoré je možné vstúpiť,
nie je možné sa na ňom najesť

potrava - políčko na ktoré je možné vstúpiť,
je možné sa ňom najesť

skala - políčko na ktoré nie je možné vstúpiť

priatelPrazdna - políčko, kde je prázdna zem a sú tam
i mravce toho istého typu, vzhľadom ku ktorému uvažujeme
dané políčko

priatelPotrava - políčko, kde je potrava a sú tam i mravce toho
istého typu, vzhľadom ku ktorému uvažujeme políčko

nepriatelPrazdna - políčko, kde je prázdna zem a na ňom sú 
mravce iného typu, ak ten vzhľadom ku ktorému  uvažujeme 
políčko

nepriatelPotrava - políčko, kde je potrava a sú tam i mravce
iného typu, ako ten vzhľadom ku ktorému uvažujeme 
políčko

Akcie mravcov:
zostaň stáť - mravce zostane stáť na políčku, pokiaľ by došlo k
boju na jeho políčku, tak má výhodu

otoč sa vľavo - mravec sa na políčku otočí vľavo

choď dopredu obranne - mravec ide dopredu o jedno políčko, pokiaľ sa stretne s
mravcami iného typu v opačnom smere, tak sa vráti na políčko z ktorého vychádzal
zníži sa mu pritom jeho energia

choď dopredu útočne - mravec ide dopredu o jedno políčko, pokiaľ sa stretne s
mravcami iného typu v opačnom smere, tak bojuje s mravcami, ak vyhrá a 
nemá maximálnu energiu, tak sa jeho energia zvýši

najedz sa - mravec sa pokúsi získať energiu z potravy, pokiaľ je na políčku potrava

rozmnožuj sa - mravec sa pokúsi rozmnožovať s mravcami toho istého typu na 
políčku na ktorom sa nachádza. Predpoklad úspešného rozmnožovania mravca
je ten, že na políčku je aspoň jeden mravec toho istého typu, ktorý sa chce rozmnožovať
a všetci majú dostatok energie. Taktiež sa nemôžu v danom kroku účastniť boja.
Pri párení dôjde k znížení ich energie, pričom pokiaľ sa pári n mravcov, tak vznikne n/2 
mravcov, zaokrúhlené nadol. Energia novovzniknutých mravcov je získaná z energie, ktorú
stratia mravce, ktorý sa rozmnožovali. Táto energie je medzi nich čo možno najrovnomernejšie
rozložená.

U mravca je najdôležitejší atribút jeho energia. Pokiaľ ju má nulovú, tak zanikne. Taktiež od
jeho energie závysia jeho šance na výhru v súboji.

Stratégie mravcov typu 1 a 2, sú nastavené. 

Stratégie mravcov ostatných typov nastavené niesu. 
Pokiaľ ich chcete používať, tak musíte nastaviť ich stratégie v časti Nastavenia Mravcov.

V časti nastavenie mravcov nastavujeme stratégiu mravca pomocou tabuľky 4x7.
4 riadky reprezentuju políčka na ktorom uvažovaný mravec stoji, a to: prázdna zem, potrava,
priatelPrazdna a priatelPotrava.
7 stlpcov reprezentuje políčka, ktoré sú pred uvažovaným mravcom a to sú:
prázdna zem, skala, potrava, priatelPrazdna, priatelPotrava, nepriatelPrazdna, nepriatelPotrava.

V časti simulácia je možné nastavenie rýchlosti behu simulácie (čím väčšie číslo, tým je simulácia
pomalšia) a miesto kam sa uloží textový výstup.

Policka v casti vystup su zobrazovane, takymi farbami ako v casti Nastavenia Mravcov, pokiaľ
nich nie su mravce. Pokial su tak sa jedno policko zobrazuje pomocou 2
obdlznikov, kde 1.obdlznik (zprava) ma farbu typu policka tak ako v casti Nastavenia Mravcov
druhy ma farbu typu mravcov, ktory na nom su.

Vykreslovanie špeciálnych situácií:

Boj pri prechadzani medzi dvomi susedným políčkami: obe sú zobrazené červenou farbou, a 
vedú medzi nimi dve čiary, kde každá čiara zastupuje jeden typ bojujucich mravcov a odpoveda
tym i svojou farbou 
- vykreslenie vo fáze "Boje pri prechadzani"

Boj na policku: vykresla sa 4 menšie štvorčeky, kde každý štvorček reprezentuje jeden typ mravcov
s ich odopovedajucov farbou, pokiaľ sa dany typ mravcov účastní boja, inak je farba biela
- vykreslenie vo fáze "Boje na policku"

Parenie: vykresli sa na danom policku kruh, ktoreho farba je farba mravcov, ktorý sa pária
- vykreslenie vo fáze "Parenie"
