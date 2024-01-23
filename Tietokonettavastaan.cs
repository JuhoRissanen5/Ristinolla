using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ristinolla
{
    public partial class Tietokonettavastaan : Form
    {
        public enum Pelaaja           // Pelaaja1 on x ja tietokone on ympyrä eli O
        {
            X, O
        }
        int klikkaukset = 0;        // klikkaukset tasapeliä varten
        int p1voitot = 0;               // tasapelien, tietokonevoittojen ja p1 voittojen avulla saan päivitettyä datagridiä 
        int Tietokonevoitot = 0;
        int Tasapelit = 0;
        int sekunnit = 0;                                    // alustetaan muuttujat
        List<Button> buttons;
        public Image x = Properties.Resources.Ristinolla_risti3_0;      // merkitään x ja o tiedoston resursseista. 
        public Image o = Properties.Resources.Ristinolla_ympyrä3_0;
        Pelaaja atm;        //Tämän hetkinen pelaaja, jostain syystä näyttää ettei tätä käytetä. Vaikka on käytössä alenpana 
        Random rnd = new Random(); // alustetaan random, jotta tietokone voi valita randomilla muuttujan
        bool vuoro = true; 
        public Tietokonettavastaan()
        {
            InitializeComponent();
            Resetoi();
            label1.Text = Tiedot.Pelaaja1 + " " + "voitot";             // voisi laittaa loadiinkin, mutta toimii näinkin labelin muuttaminen pelaaja1 tietojen perusteella
            lblvuoro.Text = Tiedot.Pelaaja1; 
        }
        private void Napit()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };        // funktio buttoneista, jotta tietokone osaa valita oikean buttonin, eikä esim uusi peli nappia.
        }
        private void poistuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult poistu = (MessageBox.Show("Haluatko varmasti poistua?", "Varoitus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)); // voi sulkea sovelluksen

            if (poistu == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnUusipeli_Click(object sender, EventArgs e) // resetoi kaikki napit ja voi aloittaa uuden pelin siten .
        {
            Resetoi();
        }

        private void Tietokoneliiku(object sender, EventArgs e)     // itse AI eli tekoäly
        {
            if (buttons.Count > 0)       // eli kun buttoneita on jälkellä enemmän kuin nolla 
            {
                
                int index = rnd.Next(buttons.Count);              // indexi, joka kertoo seuraavan mahdollisen buttonin 
                buttons[index].Enabled = false;     // eli jos buttonia ei ole vielä käytetty 
                atm = Pelaaja.O;                      // tämän hetkinen pelaaja eli tietokone, joka piirtää O 
                buttons[index].Image = o;              // Buttonin kuvakkeeksi tulee o
                buttons.RemoveAt(index);               // ja tämän jälkeen käytetty buttoni poistuu listasta, kun tietokone on tehnyt siiron 
                klikkaukset++;
                lblvuoro.Text = Tiedot.Pelaaja1;
                Voittaja();                                   // joka kerta katsoo kuka voitti
                lblaika.Text = sekunnit.ToString();           // mikäli tietokone aloittaa kierroksen, niin ajastin lähtee käyntiin 
                Taimeri.Start();
                vuoro = true; 
                Tietokoneliike.Stop();                            // kun tietokone on tehnyt liikkeen, pysähtyy tietokone. 
            }
        }
        private void Voittaja()
        {
            if (button1.Image == x && button2.Image == x && button3.Image == x
                || button4.Image == x && button5.Image == x && button6.Image == x
                || button7.Image == x && button8.Image == x && button9.Image == x
                || button2.Image == x && button5.Image == x && button8.Image == x
                || button1.Image == x && button4.Image == x && button7.Image == x
                || button3.Image == x && button6.Image == x & button9.Image == x
                || button1.Image == x && button5.Image == x && button9.Image == x
                || button7.Image == x && button5.Image == x && button3.Image == x)       // kaikki mahdolliset vaihtoehdot voitolle, kun kyseessä on oikea pelaaja
            {
                Tietokoneliike.Stop();
                Taimeri.Stop();                                                    // ajastin pysähtyy ja tietokone pelaajan liike myös, koska voittaja on löytynyt
                Tiedot.t.Pelienkesto = Tiedot.t.Pelienkesto + sekunnit;        // pelienkesto tulee näkyviin datagridiin tällä tavoin 
                Tiedot.h.Pelienkesto = Tiedot.h.Pelienkesto + sekunnit;
                MessageBox.Show(Tiedot.Pelaaja1 + " " + "voitti!");
                p1voitot++;
                lblPelaaja1voitot.Text = p1voitot.ToString();                // muuttaa tekstin voittojen kohdalla, eli lisää 1 voiton
                klikkaukset = 0;                                           // klikkaukset 0, koska muuten tulisi tasapeli heti kun uusi peli käynnistyy tietenkin riippuu tilanteesta...
                sekunnit = 0;                                                // sekunnit 0, koska uusi peli alkaa 
                lblaika.Text = sekunnit.ToString();
                Tiedot.h.Voitot = p1voitot.ToString();
                Tiedot.SerializeJSON(Tiedot.HenkiloList);                          // päivittää tulokset listaan 
                Resetoi();                                                           // resetoi pelin, kun voittaja löytyy
                vuoro = true; 

            }
            else if (button1.Image == o && button2.Image == o && button3.Image == o
                || button4.Image == o && button5.Image == o && button6.Image == o
                || button7.Image == o && button8.Image == o && button9.Image == o
                || button2.Image == o && button5.Image == o && button8.Image == o
                || button1.Image == o && button4.Image == o && button7.Image == o
                || button3.Image == o && button6.Image == o & button9.Image == o
                || button1.Image == o && button5.Image == o && button9.Image == o         // kaikki vaihtoehdot tietokoneen voitolle 
                || button7.Image == o && button5.Image == o && button3.Image == o)
            {
                Tietokoneliike.Stop();                                            // käytännössä samat kuin edellisessä kohdassa 
                Taimeri.Stop();                                                     // ajastin pysähtyyy 
                Tiedot.t.Pelienkesto = Tiedot.t.Pelienkesto + sekunnit;
                Tiedot.h.Pelienkesto = Tiedot.h.Pelienkesto + sekunnit;
                MessageBox.Show("Tietokone voitti");                              // järkevämpi alustaa vain, että tietokone voittaa tässä tilanteessa 
                Tietokonevoitot++;
                lblTietoknevoitot.Text = Tietokonevoitot.ToString();
                klikkaukset = 0;
                sekunnit = 0;
                lblaika.Text = sekunnit.ToString();
                Tiedot.t.Voitot = Tietokonevoitot.ToString();
                Tiedot.SerializeJSON(Tiedot.HenkiloList);
                Resetoi();                                                                // resetoi pelin, kun voittaja löytyy
                vuoro = true; 
            }
            else if (klikkaukset == 9)                                                // tasapeli, eli kun klikkauksia on yhdeksän eli kaikki buttonit on painettu 
            {
                Tasapelit++;
                Taimeri.Stop();
                Tiedot.t.Pelienkesto = Tiedot.t.Pelienkesto + sekunnit;              // muuten käytännössä samat kuin edellisessä else if hässäkässä
                Tiedot.h.Pelienkesto = Tiedot.h.Pelienkesto + sekunnit;            // sekunnit lisätään pelien yhteiskestoon 
                MessageBox.Show("Tasapeli");
                lblTasapelit.Text = Tasapelit.ToString();
                klikkaukset = 0;
                Tietokoneliike.Stop();
                sekunnit = 0;
                lblaika.Text = sekunnit.ToString();
                Tiedot.t.Tasapelit = Tasapelit.ToString();
                Tiedot.h.Tasapelit = Tasapelit.ToString();
                Tiedot.SerializeJSON(Tiedot.HenkiloList);
                Resetoi();
                vuoro = true; 
               
            }
        }

        private void Resetoi()
        {
            foreach (Control c in this.Controls)          // Resetoi kaikki buttonit 
            {
                Button b = c as Button;
                if (b != null)                       // käytännössä saa napit takaisin käyttöön, poistaa kuvakkeet jokaisesta, kun käydään läpi looppi 
                {
                    b.Enabled = true;
                    b.Image = null;
                }
            }

            Napit();
            klikkaukset = 0;
            sekunnit = 0;                           // nollaa klikkaukset ja ajan 
            lblaika.Text = sekunnit.ToString();
        }

        private void tilastotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f1 = new Pelaajientiedot();            // saaadaan tilastot näkyviin
            f1.ShowDialog();
        }

        private void buttonClick(object sender, EventArgs e) // kaikilla buttoneilla yksi click eventti, ei toiminut toiseen formiin, koska siinä on kaksi pelaajaa
        {
            if (vuoro == true)
            {
                var button = (Button)sender;
                atm = Pelaaja.X;
                button.Image = x;                               // kun pelaajana on ihminen tulee buttoniksi x; 
                button.Enabled = false;
                buttons.Remove(button);                    // poistaa buttonin listasta, jotta AI ei voi käyttää sitä 
                klikkaukset++;
                Taimeri.Start();                         // ajastin käynnistyy klikkauksesta. 
                lblaika.Text = sekunnit.ToString();
                lblvuoro.Text = "Tietokone";
                Voittaja();                              // tarkistaa voittajan 
                vuoro = false;
                Tietokoneliike.Start();
            }
            else if (vuoro == false)       // estää napin painalluksen, mikäli ei ole käyttäjän vuoro 
            {
                MessageBox.Show("ET VOI PAINAA NAPPIA VIELÄ", "VAROITUS", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            
        }

        private void Tietokonettavastaan_Load(object sender, EventArgs e)
        {
            Tiedot.t.Etunimi = "Tietokone";  // voisi toteuttaaa toki järkevämminkin, mutta mielestäni näin se on kuitenkin hyvä
            Tiedot.t.Sukunimi = "AI";                // koska jos tietokone valitsisi randomilla jonkun pelaajan listasta olisi se mielestäni typerää 
            Tiedot.t.Syntymavuosi = "2022";          // luo aina uuden tietokoneen datagridview listaan, kun käynnistetään. 
            Tiedot.t.Voitot = 0.ToString();           // näyttää ehkä tyhmältä, mutta tälleen halusin sen toteuttaa joka tapauksessa 
            Tiedot.t.Tappiot = 0.ToString();
            Tiedot.t.Tasapelit = 0.ToString();
            Tiedot.HenkiloList.Add(Tiedot.t);
            Tiedot.SerializeJSON(Tiedot.HenkiloList);
            // tallentaa aina uuden tietokoneen listaan, kun käynnistetään 
        }

        private void Taimeri_Tick(object sender, EventArgs e)
        {
            lblaika.Text = sekunnit++.ToString();       // saa ajan näkymään formissa 
        }

        private void alkuvalikkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult alkuvalikko = (MessageBox.Show("Haluatko varmasti siirtyä alkuvalikkoon?", "Varoitus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (alkuvalikko == DialogResult.Yes)     // siirrytään alkuvalikkoon tästä
            {
                Tiedot.t.Pelienkesto = 0;
                Tiedot.h.Pelienkesto = 0;             // pakko nollata pelienkestot, koska muuten datagridi menee ketuiksi 
                Tiedot.Pelaaja1 = null;             // ja pakko tyhjätä nimi, koska muuten ei voisi syöttää uuden pelaajan tietoja saatikka valita vanhaa 
                this.Hide();
                Tiedot j = new Tiedot();
                j.ShowDialog();
                this.Close();                        // tällä tavalla merkittynä tämä formi katoaa, eikä jää pyörimään taustalle 
            }
        }
    }
}
