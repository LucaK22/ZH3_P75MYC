using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZH3_P75MYC.Models;

namespace ZH3_P75MYC
{
    public partial class FormModosit : Form
    {
        FilmekContext context = new FilmekContext();
        public FormModosit()
        {
            InitializeComponent();
            Betöltés();
        }
        void Betöltés()
        {
            genreBindingSource.DataSource = context.Genres.ToList();
            movieBindingSource.DataSource = context.Movies.ToList();
            studioBindingSource.DataSource = context.Studios.ToList();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Mentés();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dynamic elem = (Movie)dataGridView1.CurrentRow.DataBoundItem;
            int index = elem.Id;
            var törlendő = (from x in context.Movies
                            where x.Id == index
                            select x).FirstOrDefault();
            if (MessageBox.Show("Biztosan törlöd?", "Törlés", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                context.Movies.Remove(törlendő);
                Mentés();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Nem lehet üres");
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            Regex r = new("^(19[0-9]{2})$|^(20[0-9]{2})$");
            if (!r.IsMatch(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Nem jó évszám");
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()==true)
            {
                Movie movie = new();
                movie.Title = textBox1.Text;
                var genre = (Genre)comboBox1.SelectedItem;
                movie.GenreId = genre.GenreId;
                movie.StudioId = 14;
                movie.Year = int.Parse(textBox2.Text);
                context.Add(movie);
                Mentés();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormHozzaad hozzaad = new();
            hozzaad.ShowDialog();
        }
    }
}
