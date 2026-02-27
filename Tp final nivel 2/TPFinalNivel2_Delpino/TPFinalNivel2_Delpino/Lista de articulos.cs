using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtiNegocio;
using Dominio;

namespace TPFinalNivel2_Delpino
{
    public partial class Form1 : Form
    {   private List<Articulo> listaArticulos;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio repo = new ArticuloNegocio();
          
            listaArticulos = repo.MostrarArticulos();
            dataGridArticulos.DataSource = listaArticulos;
            dataGridArticulos.Columns["ImagenUrl"].Visible = false;
           




        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarArticulo agregar = new AgregarArticulo();
            agregar.ShowDialog();
            
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

     

        private void dataGridArticulos_SelectionChanged(object sender, EventArgs e)
        {



            Articulo SeleccionadoArticulo = (Articulo) dataGridArticulos.CurrentRow.DataBoundItem;
            string url = SeleccionadoArticulo.ImagenUrl.ToString();
            
            cargarImage(url);
        }
        private void cargarImage(string url)
        {
            try
            {
                pictureBoxArticulo.Load(url);
            }
            catch
            {
                pictureBoxArticulo.Load("https://i.imgur.com/8Km9tLL.png");
            }
        }
    }
}
