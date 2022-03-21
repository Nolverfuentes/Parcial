using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial
{
    public partial class Form1 : Form
    {
        List<ListadoAlumnos> listadodealumnos = new List<ListadoAlumnos>();
        List<Inscripcion_de_alumnos> inscripcionAlm = new List<Inscripcion_de_alumnos>();
        public Form1()
        {
            InitializeComponent();
        }

        public void CargarListado()
        {
            FileStream stream = new FileStream("Listado Alumnos.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)

            {
                ListadoAlumnos listadoalumnos = new ListadoAlumnos();
                listadoalumnos.carné = reader.ReadLine();
                listadoalumnos.nombre= reader.ReadLine();
                listadodealumnos.Add(listadoalumnos);
            }

            reader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarListado();
            dataGridView1.DataSource = listadodealumnos;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textotemp = textBox1.Text;

            int posicion = inscripcionAlm.FindIndex(t => t.nombre == textotemp);
            if (posicion == -1)
            {

                Inscripcion_de_alumnos inscripcion = new Inscripcion_de_alumnos();
                inscripcion.nombre = textBox1.Text;
                dato.numero = (int)numericUpDown1.Value;
                dato.fecha = dateTimePicker1.Value;

                datos.Add(dato);
            }
            else
            {
                datos[posicion].numero++;
                datos[posicion].fecha = DateTime.Now;
            }

        }
    }
}
