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
                datos.ejecutarLectura("SELECT A.Codigo, A.Nombre,A.ImagenUrl, A.Precio,C.Descripcion as Categoria ,M.Descripcion AS Marca\r\nFROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id join MARCAS M ON A.IdMarca = M.Id;");
                while (datos.ReaderConnection.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Marca = new Marca();
                    articulo.NombreCategoria = new Categoria();
                   
                    articulo.Codigo = datos.ReaderConnection["Codigo"].ToString();
                    articulo.Nombre = datos.ReaderConnection["Nombre"].ToString();
                    articulo.Marca.Nombre = datos.ReaderConnection["Marca"].ToString();
                    articulo.NombreCategoria.Nombre = datos.ReaderConnection["Categoria"].ToString();
                    
                    articulo.ImagenUrl = datos.ReaderConnection["imagenUrl"].ToString();
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
