namespace d07_metin_editoru
{
    public partial class Form1 : Form
    {
        string? acikOlanDosya = null;//null yok demek

        public Form1()
        {
            InitializeComponent();

            //ayarlar� bir dosyadan geri okuyabilirsiniz

        }

        private void tsmiAc_Click(object sender, EventArgs e)
        {
            DialogResult cevap = openFileDialog1.ShowDialog();

            //diyalog penceresinden gelen cevab� kontrol et (Evet,Tamam,�ptal)
            if (cevap == DialogResult.OK)
            {
                //kullan�c�n�n se�ti�i dosyan�n ad� 
                string dosyaAdi = openFileDialog1.FileName;
                string icerik = File.ReadAllText(dosyaAdi);

                acikOlanDosya = dosyaAdi;//sakla daHA SONRA kullan

                Text = Path.GetFileName(dosyaAdi);

                txtEditor.Text = icerik;
            }
        }

        private void tsmiYeni_Click(object sender, EventArgs e)
        {
            txtEditor.Text = "";
            Text = "Yeni Dosya";
            acikOlanDosya = null;//art�k kay�tl� olan a��k dosya yok
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikOlanDosya == null) //dosya ad� bo� mu
            {
                //SaveFileDialog s�n�f�ndan bir �rnek olu�tur
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Metin Dosyalar�(*.txt)|*.txt|T�m Dosyalar(*.*)|*.*";
                dialog.DefaultExt = "*.txt";

                DialogResult cevap = dialog.ShowDialog();

                if (cevap == DialogResult.OK)
                {
                    string dosyaAdi = dialog.FileName;
                    //*******Art�k dosya A��k
                    acikOlanDosya = dosyaAdi;

                    File.WriteAllText(dosyaAdi, txtEditor.Text);
                }
            }
            else //Dosya daha �nce kay�tl� ise
            {
                File.WriteAllText(acikOlanDosya, txtEditor.Text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Uygulama kapat�l�yor....");
            //MessageBox.Show("Uygulama kapat�l�yor....","Dikkat");
            //MessageBox.Show("Uygulama kapat�l�yor....","Dikkat",MessageBoxButtons.YesNo);
            //MessageBox.Show("Uygulama kapat�l�yor....","Dikkat",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            DialogResult cevap = MessageBox.Show("De�i�iklikleri kay�t etmek ister misiniz?", "Dikkat",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                kaydetToolStripMenuItem_Click(sender, EventArgs.Empty);
            }
            else if (cevap == DialogResult.Cancel)
            {
                e.Cancel = true;//formu kapatmaktan vazge�tim diye windows'a s�yl�yorum
            }
        }

        private void hakk�ndaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //formun yeni bir �rne�ini olu�turdum
            FrmHakkinda form = new FrmHakkinda();

            //form.Show(); //arkada kalan forma t�klanabilir
            form.ShowDialog();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtEditor.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtEditor.Copy();
        }

        private void yap��t�rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtEditor.Paste();
        }

        private void renkAyarlar�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFontVeRenk form = new FrmFontVeRenk(txtEditor);
            form.ShowDialog();
            //tamama bas�ld� 

            txtEditor.Font = form.SeciliFont;
            txtEditor.BackColor = form.SeciliArkaplanRengi;
            txtEditor.ForeColor = form.SeciliYaziRengi;

            //ayarlar� bir dosyaya kay�t edebilirsiniz

        }
    }
}
