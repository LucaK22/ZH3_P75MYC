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
    public partial class UserControlTul : UserControl
    {
        FilmekContext context = new FilmekContext();
        public UserControlTul()
        {
            InitializeComponent();
            Betöltés();
        }
        void Betöltés()
        {
            var szűr = from x in context.Genres
                       where x.Genre1.Contains(textBox1.Text)
                       select x;
            listBox1.DataSource = szűr.ToList();
            listBox1.DisplayMember = "Genre1";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Betöltés();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var genre = (Genre)listBox1.SelectedItem;
            var cim = from x in context.Movies
                      where x.GenreId == genre.GenreId
                      select x;
            listBox2.DataSource = cim.ToList();
            listBox2.DisplayMember = "Title";
        }
    }
}
