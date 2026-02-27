using ArtiNegocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinalNivel2_Delpino
{
    public partial class AgregarArticulo : Form
    {
        public AgregarArticulo()
        {
            InitializeComponent();
        }

        private void AgregarArticulo_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            comboBoxCategoria.DataSource = negocio.Categorias();
            comboBoxMarca.DataSource = negocio.Marcas();

            comboBoxCategoria.DisplayMember = "Descripcion";
            comboBoxMarca.DisplayMember = "Descripcion";
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            


            Articulo articulo = new Articulo();
            

            string imagen = textBoxImagen.Text;
            decimal precio = 0;

            if (!string.IsNullOrWhiteSpace(textBoxPrecio.Text))
            {
                if (!decimal.TryParse(textBoxPrecio.Text, out precio))
                {
                    MessageBox.Show("Ingrese un precio válido");
                    return;
                }
            }
       
            articulo.Codigo = textBoxCodigo.Text;
            articulo.Nombre = textBoxNombre.Text;
            articulo.Descripcion = textBoxDescripcion.Text;
            articulo.Precio = precio;
            articulo.Marca = (Marca)comboBoxMarca.SelectedItem;
            articulo.NombreCategoria = (Categoria)comboBoxCategoria.SelectedItem;


        }
    }
}
