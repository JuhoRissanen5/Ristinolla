using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Ristinolla
{
    public partial class Tiedot : Form
    {
        public Tiedot()
        {
            InitializeComponent();
        }
        public static List<Henkilo> HenkiloList = new List<Henkilo>();            // käytetään static listaa, koska helpompi päivittää datagridviewiä näin 
        public static string Pelaaja1;                                            // static, koska käytetään useassa formissa 
        public static Henkilo h = new Henkilo();                                   // static ensimmäiselle nimelle, käytetään useassa
        public static Henkilo s = new Henkilo();                                // static toiselle, koska käytetään useassa
        public static Henkilo t = new Henkilo();                                 // käytetään useassa 
        public static string pelaajat = "Ristinollatulokset.json";                  // tiedosto johon tallennetaan 
        bool olemassa = false;
        private void btnTallenna_Click(object sender, EventArgs e)
        {
            if (cb1.SelectedIndex > -1)                             // jos comboboksista valitaan pelaaja niin se käy Pelaaja1 tulee se mitä valittiin
            {
                Pelaaja1 = cb1.SelectedItem.ToString();
                h.Etunimi = Pelaaja1;
                h.Sukunimi = "";
                h.Syntymavuosi = "";          // sukunimi ja syntymävuosi tyhjänä, koska ei oikeen onnistu datagridiin muuten 
                h.Tappiot = 0.ToString();          // voi valita pelaajan, mutta tallentaa uudet tilastot listaan 
                h.Voitot = 0.ToString();              // näyttää tyhmältä myös Henkilolistalla 
                h.Tasapelit = 0.ToString();
                HenkiloList.Add(h);
                olemassa = true;
            }
            if (olemassa == false)          // jos pelaajalla ei ole nimeä niin sitten syötetään
            {
                h.Etunimi = tbEtunimi.Text;
                h.Sukunimi = tbSukunimi.Text;
                h.Syntymavuosi = tbSyntymavuosi.Text;
                Pelaaja1 = h.Etunimi + " " + h.Sukunimi + " " + h.Syntymavuosi;      // pelaajaksi muodostuu se mitä on syötetty juuri 
                h.Tappiot = 0.ToString();
                h.Voitot = 0.ToString();
                h.Tasapelit = 0.ToString();          // alustaa voitoiksi, tappioiksi ja tasapaleiksi 0 
                HenkiloList.Add(h);                    // lisätään listaan
                SerializeJSON(HenkiloList);
                olemassa = true; 
                if (Pelaaja1 == "" || Pelaaja1 == (" " + " "))         // estää että ei voi syöttää nullina, ei toimi perus pelaaja == null toiminto
                {
                    olemassa = false;

                    if (olemassa == false)
                    {
                        MessageBox.Show("Anna tiedot tai valitse pelaaja", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbEtunimi.Focus();
                    }
                }
                else if (Pelaaja1.Contains(h.Etunimi + h.Sukunimi + h.Syntymavuosi))
                {
                    olemassa = true;
                }
                else if (olemassa == true)           // eli jos käyttäjä syöttää tiedot textbokseihin, niin tulee nämä näkyviin
                {
                    btnTietokone.Visible = true;
                    btnToinenpelaaja.Visible = true;
                }

            }
            else if (olemassa == true) // eli jos olemassa on true, niin napit tulevat näkyviin 
            {
                btnTietokone.Visible = true;
                btnToinenpelaaja.Visible = true;
            }

        }

        public static void SerializeJSON(List<Henkilo> input)      // käytetään staticia, koska esiintyy useammassa formissa 
        {
            string json = JsonConvert.SerializeObject(input);    // tallentaa kaikki voittojen tiedot tiedostoon 
            System.IO.File.WriteAllText(pelaajat, json);
        }
        public static List<Henkilo> DeserializeJSON()
        {
            if (File.Exists(pelaajat))
            {
                using (StreamReader sr = new StreamReader(pelaajat))        // purkaa pelaajat kohdassa alustetun kansion 
                {
                    string json = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Henkilo>>(json);
                }
            }
            else
                return new List<Henkilo>();      // jos listalla ei ole yhtään nimeä niin tulostaa uuden listaan eli palauttaa uuden 
        }
        private void btnPoistu_Click(object sender, EventArgs e)
        {
            DialogResult poistu = MessageBox.Show("Haluatko varmasti poistua?", "Varoitus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); // poistumisdialogi
            if (poistu == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (poistu == DialogResult.No)
            {
                btnToinenpelaaja.Visible = false;
                btnTietokone.Visible = false;
            }

        }

        private void btnTietokone_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new Tietokonettavastaan();          // tietokone painike, eli sulkee nykyisen ja avaa tietokonetta vastaan 
            f2.ShowDialog();
            this.Close();
        }

        private void btnToinenpelaaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f1 = new Form1();
            f1.ShowDialog();               // avaa toista pelaajaa vastaan olevan formin 
            this.Close();
        }

        private void tbSyntymavuosi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);            // voi syöttää ainoastaan numeroita tbSyntymäaikaan 
        }

        private void Tiedot_Load(object sender, EventArgs e)
        {
            HenkiloList = DeserializeJSON();                          // Lataa henkilot listasta, jossa näkyy aiemmin pelatut pelaajat
            foreach (Henkilo hh in HenkiloList)                    // lisää ne comboboxiin 
            {
                cb1.Items.Add(hh.Etunimi + " " + hh.Sukunimi + " " + hh.Syntymavuosi);
            }

        }

        private void cb1_Leave(object sender, EventArgs e)
        {
            if (cb1.SelectedIndex > -1)       // MIKÄLI VALITAAN COMBOBOXKSISTA NIIN TEXTBOKSIT MUUTTUVAT SITEN, ETTÄ NIITÄ EI VOI KÄYTTÄÄ 
            {
                Pelaaja1 = cb1.SelectedItem.ToString();
                btnTietokone.Visible = true;
                btnToinenpelaaja.Visible = true;
                tbEtunimi.Enabled = false;
                tbSukunimi.Enabled = false;
                tbSyntymavuosi.Enabled = false;
                btnTietokone.Visible = false;                  // jostain syystä kun painaa tekstboksia buttonit tulee näkyviin vaikka ei ole painettu tallenna nappia
                btnToinenpelaaja.Visible = false;
            }
        }

        private void tbEtunimi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);  // ainoastaan kirjaimia 

        }

        private void tbSukunimi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);   // voi syöttää ainostaan kirjaimia
        }
        
        private void tbSyntymavuosi_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbSyntymavuosi.Text.Length < 4)          // estää poikkeustilanteen
            {
                e.Cancel = true;
                tbSyntymavuosi.Focus();
                errorProvider1.SetError(tbSyntymavuosi, "Syötä nelinumeroinen syntymävuosi väliltä 1923-2023, niin tallenna painike tulee näkyviin!");
                btnTallenna.Enabled = false; 
            }
            else if (int.Parse(tbSyntymavuosi.Text) < 1923 || int.Parse(tbSyntymavuosi.Text) > 2023)
            {
                e.Cancel = true;
                tbSyntymavuosi.Focus();
                errorProvider1.SetError(tbSyntymavuosi, "Syötä syntymävuosi väliltä 1923-2023, niin tallenna nappi tulee näkyviin!");
                btnTallenna.Enabled = false; 
            }
            else if (int.Parse(tbSyntymavuosi.Text)>=1923 && int.Parse(tbSyntymavuosi.Text)<=2023)
            {
                e.Cancel = false;
                errorProvider1.SetError(tbSyntymavuosi, null);
                btnTallenna.Enabled = true; 
            }
        }
    }
}
