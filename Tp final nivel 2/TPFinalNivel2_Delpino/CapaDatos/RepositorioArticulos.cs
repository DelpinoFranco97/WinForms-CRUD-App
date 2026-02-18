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

        public void Listar()
        {
            List<Articulo> ListaArticulos = new List<Articulo>();
            Conexion datos = new Conexion();

            try
            {
                datos.ejecutarLectura("SELECT * FROM ARTICULOS");
                while (datos.ReaderConnection.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Codigo = datos.ReaderConnection["Codigo"].ToString();
                    articulo.Codigo = datos.ReaderConnection["Nombre"].ToString();
                    articulo.Codigo = datos.ReaderConnection["Marca"].ToString();
                    articulo.Codigo = datos.ReaderConnection["Categoria"].ToString();
                    articulo.Codigo = datos.ReaderConnection["Url"].ToString();
                    articulo.Precio = (decimal)datos.ReaderConnection["Precio"];


                }
            }
            catch (Exception)
            {

                throw;
            }


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
