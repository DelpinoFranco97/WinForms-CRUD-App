using ArtiNegocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;

namespace TPFinalNivel2_Delpino
{
    public partial class AgregarArticulo : Form
    {
        private Articulo Articulo = null;
        public AgregarArticulo()
        {
            InitializeComponent();
        }
        public AgregarArticulo(Articulo articulo)
        {
            InitializeComponent();

            this.Articulo = articulo;
        }

        private void AgregarArticulo_Load(object sender, EventArgs e)
        {
            Form1 form = new Form1();

            ArticuloNegocio negocio = new ArticuloNegocio();




            comboBoxCategoria.DisplayMember = "Descripcion";
            comboBoxCategoria.ValueMember = "Id";
            comboBoxCategoria.DataSource = negocio.Categorias();
            comboBoxMarca.DisplayMember = "Descripcion";
            comboBoxMarca.ValueMember = "Id";
            comboBoxMarca.DataSource = negocio.Marcas();

            if (Articulo != null)
            {
                textBoxCodigo.Text = Articulo.Codigo;
                textBoxNombre.Text = Articulo.Nombre;
                textBoxDescripcion.Text = Articulo.Descripcion;
                textBoxImagen.Text = Articulo.ImagenUrl;
                textBoxPrecio.Text = Articulo.Precio.ToString();
                comboBoxCategoria.SelectedValue = Articulo.Categoria.Id;
                comboBoxMarca.SelectedValue = Articulo.Marca.Id;
                HelperImg.CargarImagen(pictureBoxImg, Articulo.Precio.ToString());
                negocio.modificar(Articulo);




            }
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio repo = new ArticuloNegocio();


            string imagen = textBoxImagen.Text;
            decimal precio = 0;

            if (Articulo == null)
            {
                Articulo = new Articulo();

            }

            if (!string.IsNullOrWhiteSpace(textBoxPrecio.Text))
            {
                if (!decimal.TryParse(textBoxPrecio.Text, out precio))
                {
                    MessageBox.Show("Ingrese un precio válido");
                    return;
                }
            }

            bool cod = HelperTextBox.validar(textBoxCodigo, "Codigo");
            bool nombre = HelperTextBox.validar(textBoxNombre, "Nombre");
            bool desc = HelperTextBox.validar(textBoxDescripcion, "Descripcion");
            bool cate = HelperCombo.validarComboBox(comboBoxCategoria, "categoria");
            bool marca = HelperCombo.validarComboBox(comboBoxMarca, "marca");


            if (cod && nombre && desc && cate && marca)
            {

                Articulo.Codigo = textBoxCodigo.Text.Trim();
                if (Articulo.Codigo.Length != 3)
                {
                    MessageBox.Show("El codigo puede tener solo 3 digitos");
                    return;
                }
                Articulo.Nombre = textBoxNombre.Text.Trim();
                Articulo.Descripcion = textBoxDescripcion.Text.Trim();
                Articulo.Precio = precio;
                Articulo.Marca = (Marca)comboBoxMarca.SelectedItem;
                Articulo.Categoria = (Categoria)comboBoxCategoria.SelectedItem;
                int Id = Articulo.Id;
                MessageBox.Show(((Marca)comboBoxMarca.SelectedItem).Id.ToString());
                if (Articulo.Id != 0)
                {
                    repo.modificar(Articulo);
                    MessageBox.Show("Articulo modificado con exito");
                    Close();
                }
                else
                {
                    repo.AgregarNuevo(Articulo);
                    MessageBox.Show("Articulo agregado con exito");
                    Close();
                }

            }
            else
            {
                MessageBox.Show(
                 $"El campo  no puede estar vacío",
                 "Campo obligatorio",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);

            }

        }

    }
}



