namespace ZH3_P75MYC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormModosit modosit = new();
            modosit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormKeres keres = new();
            keres.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Biztosan kilépsz?", "Kilépés", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}