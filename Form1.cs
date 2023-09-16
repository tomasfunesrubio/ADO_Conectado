using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp_ADO_CONECTADO_Ejercicio_1_y_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void socioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 nf= new Form2();
            nf.Show();
            

        }

        private void paisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 nf = new Form3();
            nf.Show();
        }

        private void provinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 nf = new Form4();
            nf.Show();
        }
    }
}
