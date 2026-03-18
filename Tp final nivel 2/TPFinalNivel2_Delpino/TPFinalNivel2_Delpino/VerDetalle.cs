using Dominio;
using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinalNivel2_Delpino
{
    public partial class VerDetalle : Form
    {
        Articulo Articulo { get; set; }
        public VerDetalle()
        {
            InitializeComponent();


        }

        public VerDetalle(Articulo articulo)
        {
            InitializeComponent();
            Articulo = articulo;
        }

        private void VerDetalle_Load(object sender, EventArgs e)
        {
            textBoxCodigo.Text = Articulo.Codigo;
            textBoxNombre.Text = Articulo.Nombre;
            textBoxDescripcion.Text = Articulo.Descripcion;
            textBoxImagen.Text = Articulo.ImagenUrl;
            textBoxPrecio.Text = Articulo.Precio.ToString();
            comboBoxCategoria.Text = Articulo.Categoria.Descripcion;
            comboBoxMarca.Text = Articulo.Marca.Descripcion;

            HelperImg.CargarImagen(pictureBoxImg, Articulo.ImagenUrl.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
