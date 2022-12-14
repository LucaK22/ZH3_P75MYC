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
    public partial class FormHozzaad : Form
    {
        FilmekContext context = new FilmekContext();
        public FormHozzaad()
        {
            InitializeComponent();
            Betöltés();
        }
        void Betöltés()
        {
            studioBindingSource.DataSource = context.Studios.ToList();
            genreBindingSource.DataSource = context.Genres.ToList();
        }
        void Mentés()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Betöltés();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Genre g = new();
                g.Genre1 = textBox1.Text;
                context.Add(g);
            }
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                Studio s = new();
                s.Studio1 = textBox2.Text;
                context.Add(s);
            }
            Mentés();
        }
    }
}
