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
    public partial class Form2 : Form
    {

        SqlConnection co;
        SqlCommand cm; 
        public Form2()
        {
            InitializeComponent();
            co = new SqlConnection("Data Source=.;Initial Catalog=\"TP Ejercicio 1 y 2\";Integrated Security=True");
            cm = new SqlCommand("select * from socio", co);

            
        }

        private void Leer(string sql = "select * from socio" )
        {
            cm.CommandText = sql;
            SqlDataReader dr = cm.ExecuteReader();
            dataGridView1.Rows.Clear();
            while(dr.Read())
            {
                dataGridView1.Rows.Add(new object[] {dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(5)});
            }

            dr.Close();


        }


        private void Form2_Load(object sender, EventArgs e)
        {

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
                button1.Text = "Conectar";
                dataGridView1.Rows.Clear();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Interaction.InputBox("Ingrese el ID"));
            string Nombre = Interaction.InputBox("Ingrese el nombre");
            string Apellido = Interaction.InputBox("Ingrese el apellido");
            string email = Interaction.InputBox("Ingrese el email");
            string idPais = Interaction.InputBox("Ingrese el ID pais: ");
            string idProvincia = Interaction.InputBox("Ingrese el ID provincia");

            cm.CommandText = $"insert into socio(ID_Socio,Nombre,Apellido,Email,ID_Pais,ID_Provincia) values ({ID}, '{Nombre}', '{Apellido}', '{email}', '{idPais}','{idProvincia}')";
            cm.ExecuteNonQuery();
            Leer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;
            cm.CommandText = $"delete from socio where ID_Socio = {id}";
            cm.ExecuteNonQuery();
            Leer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Nombre = Interaction.InputBox("Ingrese el nombre: ");
            string Apellido = Interaction.InputBox("Ingrese el apellido: ");
            cm.CommandText = $"update socio set Nombre = '{Nombre}', Apellido = '{Apellido}' where ID= {dataGridView1.SelectedRows[0].Cells[0].Value}";
            cm.ExecuteNonQuery();
            Leer();
        }
    }
}
