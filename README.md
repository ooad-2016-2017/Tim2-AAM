# Tim2-AAM

## Stomatoloska ordinacija

###### Clanovi tima:

1.Amera Alic

2.Adna Alicic

3.Mirza Ceman

###### Opis teme
Sistem online stomatološke oridinacije treba prvenstveno da olakša pacijentima  proces rezervacije termina jer pacijenti više ne moraju dolaziti na lice mjesta da bi se naručili. Također, on dopušta pacijentu uvid u vlastiti karton. Sistem olakšava organizaciju rada stomatologa, te mu pruža mogućnost da pristupa kartonima svih pacijenata ali i da uređuje te kartone i vodi evidenciju o izmjenama. Stomatologu se nudi pregled pacijenata koji su za taj određeni (dogovoreni) period naručeni, što je veoma korisno za njega. Sistem se brine da se pacijent obavijesti o narednom(dogovorenom) predloženom terminu, što oslobađa pacijenta obaveze da pamti termine. Ovaj sistem doprinosi i olakšava komunikaciju između pacijenta i stomatologa, te nudi opcije svim korisnicima koje su korisne i iz dana u dan sve potrebnije.

###### Procesi
1. Prijava/Registracija: 
Svi korisnici sistema se moraju prijaviti ili registrovati. S obzirom da admin dodaje nove uposlene, tako se oni mogu samo prijaviti, dok se pacijenti koji prvi put koriste usluge sistema(odlucili su se za ovu stomatolosku ordinaciju) moraju prvo registrovati, a svaki naredni put ce se samo prijavljivati. Prilikom registracije korisnika, on unosi svoje licne podatke i onda sistem kreira prazan karton.
2. Narucivanje:
Pacijenti mogu online zakazati termin kod stomatologa na osnovu slobodnih termina koje unosi sam stomatolog. U slucaju da je izabran zauzet termin sistem ce obavjestiti pacijenta da ne moze izabrati taj termin
3. Kreiranje kartona:
Pri svakoj prvoj registraciji sistem ce na osnovu unijetih licnih podataka pacijenta kreirati karton i smjestiti ga u listu kartona pacijenata, koji ce biti dostupan kako stomatologu tako i samom pacijentu
4. Azuriranje kartona:
Stomatolog ce imati pravo azurirati karton svakog pacijenta nakon svakog pregleda, pri cemu ce se unositi i datum izmjene. Azuriranje se tice vrste usluge koju je pacijent dobio, tj. da li je bio samo pregled, da li su vrsene neke popravke i sl.
5. Uvid u karton:
Uvid u karton je omogucen svim pacijentima koji su prosli registraciju. Ovo je omoguceneo radi same informisanosti pacijenta o svom stanju.
6. Unos slobodnih termina:
Stomatolog ce na osnovu svoje popunjenosti azururati kalendar termina koji je dostupan paijentima, koji ce na osnovu toga znati kada postoji slobodan termin
7. Predlaganje termina:
Stomatolog nakon azuriranja kartona moze unijeti podsjetnik i sebi i pacijentu kada bi bilo najbolje da pacijent iduci put dodje, radi paracenja nekih promjena npr.poslije operacije kada se konci skidaju ili kada treba ponovo zategnuti aparatic pacijenta i sl. Jer stomatolog najbolje zna kada se moze ocekivati neka promjena koju treba pogledati. Nakon toga pacijent ce biti obavjesten kako bih mogao potvrdiri termin. 

###### Funkcionalnosti
U funkcionalnostima cemo se osvrnuti na procese kroz aktere: 
1. Stomatolog ima mogucnosti:
prijave na sistem, unosenje slobodnih termina(njegovo radno vrijeme i popunjenost), azuriranja kartona pacijenta, predlaganje termina za sljedeci dolazak
2. Pacijent ima mogucnosti: 
registracije (u slucaju da prvi put zeli koristiti usluge ordinacije), prijave (ukoliko je vec korisnik sistema u ordinaciji), online rezervisanje termina (online narucivanje kod stomatologa), uvid u vlastiti karton(read only)
3. Sistem ima mogucnost: 
kreiranje praznog kartona pri svakoj registraciji, informisanje pacijenta da je izabrani termin zauzet, informisanje pacijenta o predlozenom terminu (predlozio stomatolog)
4. Admin ima mogucnosti: 
dodavanja novih uposlenih(stomatologa), brisanje uposlenih, nadziranje rada cijelog sistema 


###### Akteri
#### 1. Pacijent
Pacijent je osoba koja ima mogućnost da se registruje ili prijavi na stranicu ordinacije. Ukoliko je prijavljen, ima mogućnost da odabere doktora i da rezerviše termin. Pored toga pacijent ima uvid u svoj karton. 
#### 2. Stomatolog 
Stomatolog je osoba koja prilikom prijavljivanja na stranicu ima pristup kartonima svih pacijenata koje može uređivati, kao i pregled kartona pacijenata koji su za taj dan naruceni  
#### 3. Administrator
Administrator ima zadatak da prilikom zaposlenja novih stomatologa ili na početku rada ordinacije bude taj koji kreira profil stomatologa.



