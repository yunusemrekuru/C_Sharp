namespace d01_merhaba_dunya
{
    public partial class Form1 : Form
    {
        public Form1() //Yap�c� metot
        {
            InitializeComponent();//formun tasar�m�n� olu�turur
        }

        //bu metot designer taraf�ndan olu�truldu
        //ve button1 click olay� ile ili�kilendirildi
        //event(olay)
        private void button1_Click(object sender, EventArgs e)
        {
            //windows senin bu butonun t�kland� diye bize bildiriyor
            //string ad = Console.ReadLine();
            string ad = textBox1.Text;
            //Console.WriteLine($"Merhaba, {ad}");
            label2.Text = $"Merhaba, {ad}";
        }


    }
}
