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
    public partial class InterfazRegistrarRespuesta : Form    
    {
        //Relaciones
        public GestorRegistrarRespuesta gestorRegistrarRespuesta { get; set; }

        public InterfazRegistrarRespuesta(Llamada llamada1, GestorRegistrarRespuesta gestor)
        {
            InitializeComponent();
            Llamada llamada = llamada1;
            button1.Tag = llamada1;
            button3.Tag = llamada1;
            gestorRegistrarRespuesta = gestor;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.KeyPress += ComboBox_KeyPress;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.KeyPress += ComboBox_KeyPress;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.KeyPress += ComboBox_KeyPress;
            this.StartPosition = FormStartPosition.CenterScreen;
            textBox6.Enter += textBox6_Enter;
            textBox6.Leave += textBox6_Leave;
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
            string correcta1 = datos[7];
            string correcta2 = datos[8];

            Random random = new Random();
            DateTime[] fechas = new DateTime[2];
            for (int i = 0; i < 2; i++)
            {
                int year = random.Next(1960, 2023);
                int month = random.Next(1, 13);
                int day = random.Next(1, 29);
                fechas[i] = new DateTime(year, month, day);
            }

            List<string> fechas1 = new List<string>();
            fechas1.Add(correcta2);
            fechas1.Add(fechas[1].ToString("dd/MM/yyyy"));
            fechas1.Add(fechas[0].ToString("dd/MM/yyyy"));

            comboBox1.Items.Add(correcta2);
            comboBox1.Items.Add(fechas[0].ToString("dd/MM/yyyy"));
            comboBox1.Items.Add(fechas[1].ToString("dd/MM/yyyy"));           
                
            comboBox1.SelectedIndex = 0; //
            
            int numero = int.Parse(correcta1);
            int numero1 = int.Parse(correcta1);
            comboBox2.Items.Add(correcta1);
            comboBox2.Items.Add(numero+(random.Next(1,9)));
            comboBox2.Items.Add(numero1+(random.Next(1, 9)));

            comboBox2.SelectedIndex = 0; //
            this.ShowDialog();
        }

        public string comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string respuestaCB1 = (string)comboBox1.SelectedItem;
            return respuestaCB1;
        }

        public string comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string respuestaCB2 = (string)comboBox2.SelectedItem;
            return respuestaCB2;
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
            string validacion = label7.Text;
            string respuestaCB1 = comboBox1.SelectedItem.ToString();
            Llamada llamada1 = (Llamada)button1.Tag;
            bool bandera = gestorRegistrarRespuesta.tomarOpValidacion(respuestaCB1, validacion, llamada1);
            if (bandera == true)
            {
                MessageBox.Show("Verificación correcta");
                comboBox2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                MessageBox.Show("Verificación incorrecta");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string validacion = label6.Text;
            string respuestaCB2 = comboBox2.SelectedItem.ToString();
            Llamada llamada = (Llamada)button3.Tag;
            bool bandera = gestorRegistrarRespuesta.tomarOpValidacion(respuestaCB2, validacion, llamada);
            if (bandera)
            {
                MessageBox.Show("Verificación correcta");
                
                textBox6.Enabled = true;
                comboBox3.Enabled = true;
            }
            else
            {
                MessageBox.Show("Verificación incorrecta");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gestorRegistrarRespuesta.tomarRespuesta(textBox6.Text);
            string acc = gestorRegistrarRespuesta.tomarAccion(comboBox3.SelectedItem.ToString());
            button2.Enabled = true;
            DialogResult result = MessageBox.Show("¿Quieres confirmar la respuesta?", "Confirmación", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Respuesta confirmada", "Confirmación");
                gestorRegistrarRespuesta.tomarConfirmacion(acc);
                MessageBox.Show("Respuesta operador registrada exitosamente!");
                this.Close();
                gestorRegistrarRespuesta.interfazIVR.Close();
            }
        }

        private void VerificarHabilitarButton2()
        {
            bool accionSeleccionada = comboBox3.SelectedItem != null;
            bool textoIngresado = textBox6.Text.Trim() != "Descripcion.";
            button2.Enabled = accionSeleccionada && textoIngresado;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarHabilitarButton2();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            VerificarHabilitarButton2();
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Descripcion.")
            {
                textBox6.Text = string.Empty;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                textBox6.Text = "Descripcion.";
            }
        }

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Bloquear la edición y eliminación del texto
        }

        private void InterfazRegistrarLlamada_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CU 17 cancelado por llamada cortada", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cerrar el formulario
            this.Close();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }
    }
}
