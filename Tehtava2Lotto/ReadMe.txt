Liitä siinä tapauksessa projektin mukaan ReadMe.txt tiedosto jossa perustelet erilaiseen toteutukseen johtaneet ratkaisut.

- Random on lisätty Lotto -luokan alustukseen että randomgeneraattoriin tulee enemmän viivettä ennen käyttöä => lisää satunnaisuutta.
- Yhden numeron generointi on omassa functiossaan vain selkeämmän käytön kannalta.
- Random generointi ottaa vastaan myös minimi arvon jotta functio olisi monikäytännöllisempi.
- NumeroidenLkm sisältää Eurojackpotissa extranumerot jotka on hoidettu poikkeus tapauksina rivien luonnissa.


Virheet:
- Ohjelma vilkauttaa rivi-kenttää punaisena ja ilmoittaa jos rivi arvoa ei voida lukea tai se on alle nollan. Helpottaa havaitsemista.
- Ohjelma käyttää Suomi-lottoa oletuksena ja silloin jos jostain syystä pelin nimeä ei tunneta. Ohjelma ei kaadu viheellisestä pelityypistä.
- Ohjelma hyväksyy rivimäärän 0 koska tämä ei varsinaiseti ole virhe vaikka se ei rivejä luokkaan.

Extra toimintoja:
- Ohjelma varoitaa käyttäjää jos riviarvoksi annetaan yli 100. Tarpeeksi suuri luku saa debug ympäristössä 60sec aikakatkaisun aikaiseksi.
- Ohjelma varoittaa tietojen häviämisestä suljettaessa omasta painikkeesta. Tietoja ei tallenneta.
- Ohjelma automaattisesti valitsee riviarvon tekstin joka generoinnin sekä pelityypin vaihdon jälkeen ja ohjelmaa käynnistäessä. On lisäämässä käyttömukavuutta.
- Ohjelma rullaa listan viimeiseen riviin automaattisesti. Taaskin käyttäjän mukavuus syistä.
- Ohjelma listaa numerot järjestyksessä.
