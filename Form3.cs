using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Tp_ADO_CONECTADO_Ejercicio_1_y_2
{
    public partial class Form3 : Form
    {
        SqlConnection co;
        SqlCommand cm; 
        public Form3()
        {
            InitializeComponent();

            co = new SqlConnection("Data Source=.;Initial Catalog=\"TP Ejercicio 1 y 2\";Integrated Security=True");
            cm = new SqlCommand("select * from pais", co);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        
        private void Leer(string sql= "select * from pais")
        {
            cm.CommandText = sql;
            SqlDataReader dr = cm.ExecuteReader();

            dataGridView1.Rows.Clear();

            while(dr.Read())
            {
                dataGridView1.Rows.Add(new object[] { dr.GetValue(0), dr.GetValue(1)});
            }
            dr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(co.State == ConnectionState.Closed)
            {
                co.Open();
                Leer();
                button1.Text = "Desconectar";
            }
            else
            {
                co.Close();
                dataGridView1.Rows.Clear();
                button1.Text = "Conectar";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ID = Interaction.InputBox("Ingrese ID: ");
            string Nombre = Interaction.InputBox("Ingrese el nombre: ");

            cm.CommandText = $"insert into pais(ID_Pais, Nombre) values ('{ID}','{Nombre}')";
            cm.ExecuteNonQuery();
            Leer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ID = dataGridView1.SelectedRows[0].Cells[0].Value;
            cm.CommandText = $"delete from Pais where ID_Pais = '{ID}'";
            cm.ExecuteNonQuery();
            Leer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Nombre = Interaction.InputBox("Ingrese el nombre: ");
            cm.CommandText = $"update pais set Nombre = '{Nombre}' where ID_Pais = '{dataGridView1.SelectedRows[0].Cells[0].Value }' ";
            cm.ExecuteNonQuery();
            Leer();
        }
    }
}
