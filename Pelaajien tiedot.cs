using System;
using System.Windows.Forms;

namespace Ristinolla
{
    public partial class Pelaajientiedot : Form
    {

        public Pelaajientiedot()
        {
            InitializeComponent();
        }
        private void Pelaajientiedot_Load(object sender, EventArgs e)
        {
            dgvPelaajat.DataSource = Tiedot.HenkiloList;  // käyttää lähteenä HenkiloListaa, jossa näkyy aiemmatkin tulokset. Päivittää listaa aina kun avataan
        }
    }
}
