using ArtiNegocio;
using Dominio;
using Helpers;
using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulos;
        private ArticuloNegocio articuloNegocio { get; set; }
        public Form1()
        {
            InitializeComponent();
            articuloNegocio = new ArticuloNegocio();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cargargrid();
            dataGridArticulos.ClearSelection();
            List<Categoria> listaCategorias = articuloNegocio.Categorias();
            foreach (var item in listaCategorias)
            {
                BoxCategoria.Items.Add(item);
            }

            BoxCategoria.SelectedIndex = -1;
            BoxMarcas.SelectedIndex = -1;
        }




        public void cargargrid()
        {
      
            List<Articulo> listaFiltrada;

            if ((string.IsNullOrEmpty(textBoxBusqueda.Text)))
            {
                listaArticulos = articuloNegocio.MostrarArticulos();
                dataGridArticulos.DataSource = listaArticulos;
                dataGridArticulos.Columns["ImagenUrl"].Visible = false;
                dataGridArticulos.Columns["Descripcion"].Visible = false;
            }
            else if (!(string.IsNullOrEmpty(textBoxBusqueda.Text)))
            {

                listaFiltrada = listaArticulos.FindAll(articulo => articulo.Nombre.ToLower().Contains(textBoxBusqueda.Text.ToLower()));
                dataGridArticulos.DataSource = null;
                dataGridArticulos.DataSource = listaFiltrada;
            }




        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarArticulo agregar = new AgregarArticulo();
            agregar.ShowDialog();
            cargargrid();


        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dataGridArticulos.CurrentRow.DataBoundItem;
            AgregarArticulo modificar = new AgregarArticulo(seleccionado);
            modificar.ShowDialog();
            cargargrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dataGridArticulos.CurrentRow.DataBoundItem;
            ArticuloNegocio eliminar = new ArticuloNegocio();
            eliminar.Eliminar(seleccionado.Id);
            cargargrid();


        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dataGridArticulos.CurrentRow.DataBoundItem;
            VerDetalle Descripcion = new VerDetalle(seleccionado);
            Descripcion.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void dataGridArticulos_SelectionChanged(object sender, EventArgs e)
        {

            Articulo SeleccionadoArticulo = (Articulo)dataGridArticulos.CurrentRow.DataBoundItem;
            string url = SeleccionadoArticulo.ImagenUrl.ToString();
            HelperImg.CargarImagen(pictureBoxArticulo, url);

        }

      

        private void textBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargargrid();
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)


        {

            string seleccion = BoxCategoria.SelectedItem.ToString();
            if (seleccion.ToLower() == "Celulares".ToLower())
            {
                cargarBox(seleccion);
            }

            else if (BoxCategoria.SelectedItem.ToString().ToLower() == "Televisores".ToLower())
            {
                cargarBox(seleccion);
            }
            else if (BoxCategoria.SelectedItem.ToString().ToLower() == "Media".ToLower())
            {
                cargarBox(seleccion);
            }
            else if (BoxCategoria.SelectedItem.ToString().ToLower() == "Audio".ToLower())
            {
                cargarBox(seleccion);
            }




        }

        public void cargarBox(string seleccion)
        {
            List<Articulo> marcas;

            BoxMarcas.Items.Clear();
            marcas = articuloNegocio.FiltrarMarcas(seleccion);
            if (marcas.Count == 0)
            {
                MessageBox.Show("No se encontraron artículos para esta categoria");
            }

            foreach (var item in marcas)
            {
                BoxMarcas.Items.Add(item.Marca.ToString());
            }
        }


        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)


        {
            List<Articulo> listaFiltrada;

            try

            {

                decimal precio;

                if (decimal.TryParse(boxPrecio.Text, out precio))
                {
                    MessageBox.Show("Precio válido: " + precio);
                }



                if (BoxCategoria.SelectedIndex == -1 || BoxMarcas.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxPrecio.Text))
                {
                    MessageBox.Show("Debe completar los campos solicitados");
                    return;
                }

                else if (BoxCategoria.SelectedIndex != -1 && BoxMarcas.SelectedIndex != -1 && precio > 0)
                {

                    listaFiltrada = listaArticulos.FindAll(articulo => articulo.Categoria.ToString() == BoxCategoria.SelectedItem.ToString() &&
                    articulo.Marca.ToString() ==
                    BoxMarcas.SelectedItem.ToString() && precio >= articulo.Precio);
                    if (listaFiltrada.Count == 0)
                    {
                        MessageBox.Show("No se encontraron resultado ");
                        cargargrid();
                        return;
                    }
                    dataGridArticulos.DataSource = null;
                    dataGridArticulos.DataSource = listaFiltrada;
                }



                else if (BoxCategoria.SelectedIndex != -1)
                {

                    listaFiltrada = listaArticulos.FindAll(articulo => articulo.Categoria.ToString() == BoxCategoria.SelectedItem.ToString());
                    dataGridArticulos.DataSource = null;
                    dataGridArticulos.DataSource = listaFiltrada;

                }
                else if (BoxMarcas.SelectedIndex != -1)
                {
                    listaFiltrada = listaArticulos.FindAll(articulo => articulo.Marca.ToString() == BoxMarcas.SelectedItem.ToString());

                    dataGridArticulos.DataSource = null;
                    dataGridArticulos.DataSource = listaFiltrada;

                }




            }
            catch (Exception)
            {

                throw;
            }



        }

        private void labelprecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void BoxMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            BoxCategoria.Items.Clear();
            BoxMarcas.Items.Clear();
            boxPrecio.Clear();
            cargargrid();
        }
     }
}

