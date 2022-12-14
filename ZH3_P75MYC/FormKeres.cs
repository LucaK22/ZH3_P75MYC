using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZH3_P75MYC
{
    public partial class FormKeres : Form
    {
        public FormKeres()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlCim uc1 = new UserControlCim();
            panel1.Controls.Add(uc1);
            uc1.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlTul uc2 = new UserControlTul();
            panel1.Controls.Add(uc2);
            uc2.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlErtek uc3 = new UserControlErtek();
            panel1.Controls.Add(uc3);
            uc3.Dock = DockStyle.Fill;
        }
    }
}
