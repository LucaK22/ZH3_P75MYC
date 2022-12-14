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
    public partial class UserControlCim : UserControl
    {
        FilmekContext context = new FilmekContext();
        public UserControlCim()
        {
            InitializeComponent();
            Betöltés();
        }
        void Betöltés()
        {
            var szűr = from x in context.Movies
                       where x.Title.Contains(textBox1.Text)
                       select x;
            listBox1.DataSource = szűr.ToList();
            listBox1.DisplayMember = "Title";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Betöltés();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var movie = (Movie)listBox1.SelectedItem;

            var műfaj = (from x in context.Genres
                        where x.GenreId == movie.GenreId
                        select x).FirstOrDefault();
            var studio = (from x in context.Studios
                         where x.StudioId == movie.StudioId
                         select x).FirstOrDefault();
            var értékév = (from x in context.Movies
                         where x.Id == movie.Id
                         select x).FirstOrDefault();

            label1.Text = $"Műfaj: {műfaj.Genre1}";
            label2.Text = $"Stúdió: {studio.Studio1}";
            label3.Text = $"Értékelés: {értékév.AudienceScore}%";
            label4.Text = $"Készült: {értékév.Year}";
        }
    }
}
