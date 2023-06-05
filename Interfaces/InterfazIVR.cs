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
using PPAI_CU17_GrupoYaNoNosFaltan2.Interfaces;
using PPAI_CU17_GrupoYaNoNosFaltan2.Entidades;

namespace PPAI_CU17_GrupoYaNoNosFaltan2.NewFolder1
{
    public partial class InterfazIVR : Form
    {
        //Relaciones

        public GestorRegistrarLlamada gestorRegistrarLlamada;

        public GestorRegistrarRespuesta gestorRegistrarRespuesta;

        public InterfazIVR()
        {
            
            gestorRegistrarLlamada = new GestorRegistrarLlamada(this);
            gestorRegistrarRespuesta = new GestorRegistrarRespuesta(this);


            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void InterfazIVR_Load(object sender, EventArgs e)
        {
            (Llamada llamada, Categoria categoria) = gestorRegistrarLlamada.opcionNuevaRespuestaOperador();

        }

        public void MostrarDNI(string dni)
        {
            textBox1.Text = dni;
        }

        public void MostrarCategoria(int categoria)
        {
            textBox2.Text = categoria.ToString();
        }

        public void MostrarOpcion(int opcion)
        {
            textBox3.Text = opcion.ToString();
        }

        public void MostrarSubopcion(int subopcion)
        {
            textBox4.Text = subopcion.ToString();
        }

        // Con este botón simulamos que el cliente selecciona la opción Hablar con operador:
        private void button5_Click(object sender, EventArgs e)
        {
            (Llamada llamada1, Categoria categoria) = gestorRegistrarLlamada.opcionNuevaRespuestaOperador();
            this.gestorRegistrarRespuesta.nuevaRespuestaOperador(llamada1,categoria, gestorRegistrarRespuesta);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}