using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ristinolla
{
    public partial class Form1 : Form
    {
        public Image x = Properties.Resources.Ristinolla_risti3_0;     
        public Image o = Properties.Resources.Ristinolla_ympyrä3_0;       // tiedoston resursseista, jotka oon lisännyt niin x ja o 
        int sekunnit = 0;                                                // sekunnit aikaan
        public string p1 = Tiedot.Pelaaja1;                              // edellisessä formissa syötetyt tiedot
        public int p1voitot = 0;
        public int p2voitot = 0;
        public int pelatutpelit = 0;                                    // alustetaan muuttujat nolliksi, joilla kerrotaan pelin tilanne
        public int klikkaukset = 0;
        public int yhteiskesto = 0;
        public string p2 = "Nakki kone 94";                    // Käytännössä turhanimike, mutta ihan hauska oletus nimi toiselle pelaajalle ;D
        bool vuoro = true;                                   // bool muuttuja vuorolle, jotta tiedetään kumman vuoro on true/ false rakenteella 
        public int tasapelit = 0;
        bool olemassa = false;

        public void Pelaajanstatus()  // tarkastaa niin sanotun statuksen, eli kumman vuoron ja lopuksi voittajan. Tämä funktio käydään useasti läpi
        {
            if (vuoro == true)
            {
                vuoro = false;
                lblkumanvuoro.Text = p2;             // muuttaa vuoron tekstiin 
            }
            else
            {
                vuoro = true;
                lblkumanvuoro.Text = p1;
            }
            klikkaukset++;    // klikkaukset lisääntyy, koska mikäli tulee 9 niin on kyseessä tasapeli noin niinkuin järjellä ajateltunakin 
            Voittaja();


        }

        private void Voittaja()       // lueteltuna kaikki voittoon johtavat mahdollisuudet molemmille x ja o 
        {
            if (btn1.Image == x && btn2.Image == x && btn3.Image == x)
            {
                p1voitto();
            }
            else if (btn1.Image == o && btn2.Image == o && btn3.Image == o)
            {
                p2voitto();
            }
            else if (btn1.Image == x && btn4.Image == x && btn7.Image == x)
            {
                p1voitto();
            }
            else if (btn1.Image == o && btn4.Image == o && btn7.Image == o)
            {
                p2voitto();
            }
            else if (btn1.Image == x && btn5.Image == x && btn9.Image == x)
            {
                p1voitto();
            }
            else if (btn1.Image == o && btn5.Image == o && btn9.Image == o)
            {
                p2voitto();
            }
            else if (btn4.Image == x && btn5.Image == x && btn6.Image == x)
            {
                p1voitto();
            }
            else if (btn4.Image == o && btn5.Image == o && btn6.Image == o)
            {
                p2voitto();
            }
            else if (btn7.Image == x && btn8.Image == x && btn9.Image == x)
            {
                p1voitto();
            }
            else if (btn7.Image == o && btn8.Image == o && btn9.Image == o)
            {
                p2voitto();
            }
            else if (btn3.Image == x && btn6.Image == x && btn9.Image == x)
            {
                p1voitto();
            }
            else if (btn3.Image == o && btn6.Image == o && btn9.Image == o)
            {
                p2voitto();
            }
            else if (btn2.Image == x && btn5.Image == x && btn8.Image == x)
            {
                p1voitto();
            }
            else if (btn2.Image == o && btn5.Image == o && btn8.Image == o)
            {
                p2voitto();
            }
            else if (btn7.Image == x && btn5.Image == x && btn3.Image == x)
            {
                p1voitto();
            }
            else if (btn7.Image == o && btn5.Image == o & btn3.Image == o)
            {
                p2voitto();
            }
            else if (klikkaukset == 9)    // mikäli päädytään tasapeliin 
            {
                Tasuri();
                klikkaukset = 0;

            }

        }
        private void Napit()       // funktio estää, että käyttäjä ei voi aloittaa peliä ennen kuin toisen pelaajan tiedot on tallennettu. 
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
        }
        private void p1voitto()     // mikäli pelaaja 1 voittaa
        {
            MessageBox.Show(p1 + " " + "voitti!");
            foreach (Control c in Controls)                      // tekee jokaisesta buttonista epätoden ennenkuin uusipeli painiketta painetaan
            {
                Button b = c as Button;
                if (b != null)
                {
                    b.Enabled = false;
                }
            }
            btnUusi.Enabled = true;
            p1voitot++;
            lblP1voitto.Text = p1voitot.ToString();
            Tiedot.h.Voitot = p1voitot.ToString();                      // lisää voitot henkilön voittoihin 
            klikkaukset = 0;                                            // kun joku voittaa, niin klikkaukset muuttuu 0 
            Taimeri.Stop();                                              // ajastin pysähtyy 
            Tiedot.h.Pelienkesto = Tiedot.h.Pelienkesto + sekunnit;       // Tallentaa kaikki tiedot henkilöön, jonka kautta datagridiin 
            Tiedot.s.Pelienkesto = Tiedot.s.Pelienkesto + sekunnit;
            sekunnit = 0;                                                 // nollaa ajan 
            lblaika.Text = sekunnit.ToString();
            Tiedot.SerializeJSON(Tiedot.HenkiloList);         // päivittää tiedot HenkiloListaan ja sitä kautta datagridiin 


        }
        private void p2voitto()
        {
            MessageBox.Show(p2 + " " + "voitti!");
            foreach (Control c in Controls)      //p2 voitto eli nollaa buttonit eri tyylillä toteutettuna, toimii tuo ylenpikin versio
            {
                Button b = c as Button;          // käy läpi jokaisen buttonin 
                if (b != null)
                {
                    b.Enabled = false;
                }
            }
            btnUusi.Enabled = true;
            p2voitot++;
            Tiedot.s.Voitot = p2voitot.ToString();
            lblToinevoitto.Text = p2voitot.ToString();
            klikkaukset = 0;
            Taimeri.Stop();
            Tiedot.s.Pelienkesto = Tiedot.s.Pelienkesto + sekunnit;      // samat kuin p1 voitossa 
            Tiedot.h.Pelienkesto = Tiedot.h.Pelienkesto + sekunnit;
            sekunnit = 0;
            lblaika.Text = sekunnit.ToString();
            Tiedot.SerializeJSON(Tiedot.HenkiloList);


        }
        public void Uusipeli()
        {
            klikkaukset = 0;
            foreach (Control c in Controls)           // jokaisen buttonin nollaa niin sanotusti kyseinen looppi ja nollaa samalla klikkaukset
            {
                Button b = c as Button;
                if (b != null)
                {
                    b.Enabled = true;
                    b.Image = null;
                }
            }
            btnTallenna.Enabled = false;
            sekunnit = 0;
            lblaika.Text = sekunnit.ToString();
            Taimeri.Start();            // ajastin alkaa kun tätä painetaan, sillä uusi peli alkaa heti kun sitä on painettu
        }
        public Form1()
        {
            InitializeComponent();
            labelp1.Text = Tiedot.Pelaaja1 + " " + "voitot";      // laitettu tähän, vaikka voisi olla ihan alustuksissa tai loadissa, mutta menee läpii näinkin 
        }

        public void Tasuri()       // erillinen funktio tasapelille, koska helpompi merkata voitto Pelaajanstatus funktioon 
        {
            MessageBox.Show("Tasapeli");
            tasapelit++;
            Taimeri.Stop();
            Tiedot.s.Pelienkesto = Tiedot.s.Pelienkesto + sekunnit;
            Tiedot.h.Pelienkesto = Tiedot.h.Pelienkesto + sekunnit;
            sekunnit = 0;
            lblaika.Text = sekunnit.ToString();
            lblTasuri.Text = tasapelit.ToString();
            Tiedot.s.Tasapelit = tasapelit.ToString();
            Tiedot.h.Tasapelit = tasapelit.ToString();
            Tiedot.SerializeJSON(Tiedot.HenkiloList);    // päivittää listaa 
        }
        private void pelaajienTilastotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pelaajientiedot frm2 = new Pelaajientiedot();     // näyttää tilastot datagridviewissä
            frm2.ShowDialog();
        }

        private void btnUusi_Click(object sender, EventArgs e)
        {
            Uusipeli();                      // toteuttaa uusi peli funktion eli käynnistää uuden pelin 
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;     // käytännössä sama funktio kaikille buttoneille eli kun on x vuoro 
            if (vuoro == true)                   // piirtää x 
            {
                btn1.Image = x;                       // sitten katsoo statuksen niin sanotusti eli katsoo löytyykö voittajaa
                Pelaajanstatus();
            }
            else
            {
                btn1.Image = o;                      // piirtää pelaaja 2 ympyrän 
                Pelaajanstatus();                   // ei jostain syystä toiminut sama click eventti kaikille buttoneille, vaikka yritin monesti 
            }
            btn1.Enabled = false;

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (vuoro == true)
            {
                btn2.Image = x;
                Pelaajanstatus();
            }
            else
            {
                btn2.Image = o;
                Pelaajanstatus();
            }
            btn2.Enabled = false;

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (vuoro == true)
            {
                btn3.Image = x;
                Pelaajanstatus();
            }
            else
            {
                btn3.Image = o;
                Pelaajanstatus();
            }
            btn3.Enabled = false;

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (vuoro == true)
            {
                btn4.Image = x;
                Pelaajanstatus();
            }
            else
            {
                btn4.Image = o;
                Pelaajanstatus();
            }
            btn4.Enabled = false;

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (vuoro == true)
            {
                btn5.Image = x;
                Pelaajanstatus();
            }
            else
            {
                btn5.Image = o;
                Pelaajanstatus();
            }
            btn5.Enabled = false;

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (vuoro == true)
            {
                btn6.Image = x;
                Pelaajanstatus();
            }
            else
            {
                btn6.Image = o;
                Pelaajanstatus();
            }
            btn6.Enabled = false;

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (vuoro == true)
            {
                btn7.Image = x;
                Pelaajanstatus();
            }
            else
            {
                btn7.Image = o;
                Pelaajanstatus();
            }
            btn7.Enabled = false;

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (vuoro == true)
            {
                btn8.Image = x;
                Pelaajanstatus();
            }
            else
            {
                btn8.Image = o;
                Pelaajanstatus();
            }
            btn8.Enabled = false;

        }
        private void button9_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (vuoro == true)
            {
                btn9.Image = x;
                Pelaajanstatus();
            }
            else
            {
                btn9.Image = o;
                Pelaajanstatus();
            }
            btn9.Enabled = false;


        }

        private void tbSyntymavuosi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);        // pelkkiä numeroita
        }

        private void btnTallenna_Click(object sender, EventArgs e)
        {
            if (olemassa == false)
            {
                Tiedot.s.Etunimi = tbEtunimi.Text;
                Tiedot.s.Sukunimi = tbSukunimi.Text;
                Tiedot.s.Syntymavuosi = tbSyntymavuosi.Text;
                Tiedot.s.Voitot = 0.ToString();                           // Tallentaa toisen pelaajan syöttämät tiedot 
                Tiedot.s.Tappiot = 0.ToString();
                Tiedot.s.Tasapelit = 0.ToString();
                p2 = Tiedot.s.Etunimi + " " + Tiedot.s.Sukunimi + " " + Tiedot.s.Syntymavuosi;     // pelaaja 2 muodostuu käyttäjän syöttämistä tiedoista 
                lblPelaaja2voitot.Text = p2 + " " + "voitot";
                olemassa = true;
                if (p2 == "" || p2 == (" " + " "))        // ei voi syöttää tyhjää näin 
                {
                    olemassa = false;

                    if (olemassa == false)
                    {
                        MessageBox.Show("Anna tiedot", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbEtunimi.Focus();
                    }

                }
                else if (p1.Contains(Tiedot.s.Etunimi + Tiedot.s.Sukunimi + Tiedot.s.Syntymavuosi))
                {
                    olemassa = true;
                }
                else if (olemassa == true)
                {
                    Napit();                                                     // tekee buttoneista silleen, että niitä voi klikata 
                    tbEtunimi.Enabled = false;
                    tbSukunimi.Enabled = false;
                    tbSyntymavuosi.Enabled = false;                               // kun tiedot on syötetty niin ei voi syöttää uudestaan 
                    Tiedot.HenkiloList.Add(Tiedot.s);                    // päivittää gridiä 
                    btnTallenna.Enabled = false;
                    sekunnit = Convert.ToInt32(lblaika.Text);        // aika lähtee käyntiin tallennuksesta 
                    Taimeri.Start();
                }

            }

        }

        private void tlstripalkuvalikko_Click(object sender, EventArgs e)
        {
            DialogResult alkuvalikko = (MessageBox.Show("Haluatko varmasti siirtyä alkuvalikkoon?", "Varoitus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (alkuvalikko == DialogResult.Yes)
            {
                Tiedot.Pelaaja1 = null;
                p2 = null;
                Tiedot.h.Pelienkesto = 0;           // päääsee alkuvalikkoon ja edelliset tiedot poistuuu 
                Tiedot.s.Pelienkesto = 0;
                this.Hide();
                Tiedot t = new Tiedot();
                t.ShowDialog();

                this.Close();
            }
        }

        private void Taimeri_Tick(object sender, EventArgs e)
        {
            lblaika.Text = sekunnit++.ToString();  // taimeri lähtee käyntiin 
        }

        private void poistuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult poistu = (MessageBox.Show("Haluatko varmasti sulkea ristinollan?", "Varoitus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)); // voi poistua koko sovelluksesta 

            if (poistu == DialogResult.Yes)
            {
                Application.Exit();      // sulkee koko paskan 
            }
        }

        private void tbEtunimi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);    // ainoastaan kirjaimia näin
        }

        private void tbSukunimi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);       // ainoastaan kirjaimia näin 
        }

        private void tbSyntymavuosi_Validating(object sender, System.ComponentModel.CancelEventArgs e)      
        {
            if (tbSyntymavuosi.Text.Length < 4)        // estää poikkeustilanteen 
            {
                e.Cancel = true;
                tbSyntymavuosi.Focus();
                errorProvider1.SetError(tbSyntymavuosi, "Syötä nelinumeroinen syntymävuosi väliltä 1923-2023!");
                btnTallenna.Enabled = false;
            }
            else if (int.Parse(tbSyntymavuosi.Text) < 1923 || int.Parse(tbSyntymavuosi.Text) > 2023)
            {
                e.Cancel = true;
                tbSyntymavuosi.Focus();
                errorProvider1.SetError(tbSyntymavuosi, "Syötä syntymävuosi väliltä 1923-2023");
                btnTallenna.Enabled = false; 
            }
            else if (int.Parse(tbSyntymavuosi.Text) >= 1923 && int.Parse(tbSyntymavuosi.Text) <= 2023)
            {
                e.Cancel = false;
                errorProvider1.SetError(tbSyntymavuosi, null);
                btnTallenna.Enabled = true; 
            }
        }
    }
}
