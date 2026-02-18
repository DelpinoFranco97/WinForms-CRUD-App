using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace CapaDatos
{
    public class RepositorioArticulos
    {
        public List<Articulo> ListaArticulos;

        public List<Articulo> Listar()
        {
            List<Articulo> ListaArticulos = new List<Articulo>();
            Conexion datos = new Conexion();

            try
            {
                datos.ejecutarLectura("SELECT * FROM ARTICULOS");
                while (datos.ReaderConnection.Read())
                {
                    Articulo articulo = new Articulo();
                    Marca marca = new Marca();
                    Categoria categoria = new Categoria();
                    articulo.Codigo = datos.ReaderConnection["Codigo"].ToString();
                    articulo.Nombre = datos.ReaderConnection["Nombre"].ToString();
                    marca.Nombre = datos.ReaderConnection["idMarca"].ToString();
                    articulo.Marca = marca;
                    categoria.Nombre = datos.ReaderConnection["idCategoria"].ToString();
                    articulo.NombreCategoria = categoria;
                    articulo.Codigo = datos.ReaderConnection["imagenUrl"].ToString();
                    articulo.Precio = (decimal)datos.ReaderConnection["Precio"];
                    ListaArticulos.Add(articulo);



                }
                return ListaArticulos;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.CerrarConexion(); }
           


        }

        public void AgregarArticulo()
        {

        }

        public void ElimanarArticulo()
        {

        }

        public void Modificar()
        {

        }
    }
}
