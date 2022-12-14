using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZH3_P75MYC.Models;

namespace ZH3_P75MYC
{
    public partial class UserControlErtek : UserControl
    {
        FilmekContext context = new FilmekContext();
        public UserControlErtek()
        {
            InitializeComponent();
            Betöltés();
        }
        void Betöltés()
        {
            int szám;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                szám = int.Parse(textBox1.Text);
            }
            else
            {
                szám = 0;
            }
            var betöltendő = from x in context.Movies
                             where x.AudienceScore >= szám
                             select new
                             {
                                 x.Title,
                                 x.AudienceScore
                             };
            dataGridView1.DataSource = betöltendő.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Betöltés();
        }
    }
}
