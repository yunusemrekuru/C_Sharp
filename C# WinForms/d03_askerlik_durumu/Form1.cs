namespace d03_askerlik_durumu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKontrolEt_Click(object sender, EventArgs e)
        {
            string ad = txtAdSoyad.Text;
            int yas = Convert.ToInt32(txtYas.Text);

            int cinsiyet = cbCinsiyet.SelectedIndex;//se�ili indeks
            bool saglikOzru = chkSaglik.Checked;//se�ili ise true
            bool tecilVarMi = rdTecilEvet.Checked;//se�ili ise true

            if (cinsiyet == 0) //Erkek demek
            {
                if (yas > 20) //Ya�� uygun
                {
                    if (!saglikOzru)//sa�l�k durumu uygun
                    {
                        if (!tecilVarMi)
                        {
                            lblDurum.Text = "ASKERE G�DEB�L�R";
                        }
                        else lblDurum.Text = "Tecil var.";
                    }
                    else lblDurum.Text = "Sa�l�k durumu uygun de�il.";
                }
                else lblDurum.Text = "Ya� uygun de�il.";
            }
            else lblDurum.Text = "Cinsiyet Uygun De�il.";
        }
    }
}
