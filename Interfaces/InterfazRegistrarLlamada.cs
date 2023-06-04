using PPAI_CU17_GrupoYaNoNosFaltan2.Entidades;
using PPAI_CU17_GrupoYaNoNosFaltan2.Gestor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.Interfaces
{
    public partial class InterfazRegistrarLlamada : Form    
    {

        //Relaciones
        public GestorRegistrarRespuesta gestorRegistrarRespuesta { get; set; }



        public InterfazRegistrarLlamada(Llamada llamada1, GestorRegistrarRespuesta gestor)
        {
            InitializeComponent();
            Llamada llamada = llamada1;
            button1.Tag = llamada;
            button3.Tag = llamada;
            gestorRegistrarRespuesta = gestor;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       

        private void InterfazRegistrarLlamada_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void mostrarDatos(List <string> datos)
        {
            
            string nombreCliente = datos[0];
            textBox1.Text = nombreCliente;
            string nombreCate = datos[1];
            textBox2.Text = nombreCate;
            string nombreOpcion = datos[2];
            textBox3.Text = nombreOpcion;
            string nroOrden =  datos[3];
            textBox4.Text = nroOrden;
            string val1 = datos[4];
            label6.Text = val1;
            string val2 = datos[5];
            label7.Text = val2;
            string fechaHora = datos[6];
            label8.Text = fechaHora;


            DateTime fecha1 = new DateTime(2023, 6, 1);
            DateTime fecha2 = new DateTime(2023, 6, 15);
            DateTime fecha3 = new DateTime(2023, 6, 30);

            comboBox1.Items.Add(fecha1);
            comboBox1.Items.Add(fecha2);
            comboBox1.Items.Add(fecha3);

            comboBox1.SelectedIndex = 0; //

            string cantHijos1 = "4";
            string cantHijos2 = "2";
            string cantHijos3 = "3";

            comboBox2.Items.Add(cantHijos1);
            comboBox2.Items.Add(cantHijos2);
            comboBox2.Items.Add(cantHijos3);

            comboBox2.SelectedIndex = 0; //





            this.Show();

        }

        public string comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string respuestaCB1 = (string)comboBox1.SelectedItem;
            return respuestaCB1;
        }

        public object comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            object respuestaC2 = comboBox2.SelectedItem;
            return respuestaC2;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {
            string validacion = label6.Text;
            string respuestaCB1 = comboBox1.SelectedItem.ToString();
            Llamada llamada = (Llamada)button1.Tag;
            bool bandera = gestorRegistrarRespuesta.tomarOpValidacion(respuestaCB1, validacion, llamada);
            if (bandera == true)
            {
                MessageBox.Show("Verificación correcta");
            }
            else
            {
                MessageBox.Show("Verificación incorrecta");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string validacion = label7.Text;
            string respuestaCB2 = comboBox2.SelectedItem.ToString();
            Llamada llamada = (Llamada)button3.Tag;
            bool bandera = gestorRegistrarRespuesta.tomarOpValidacion(respuestaCB2, validacion, llamada);
            if (bandera)
            {
                MessageBox.Show("Verificación correcta");
            }
            else
            {
                MessageBox.Show("Verificación incorrecta");
            }
        }
    }
}
