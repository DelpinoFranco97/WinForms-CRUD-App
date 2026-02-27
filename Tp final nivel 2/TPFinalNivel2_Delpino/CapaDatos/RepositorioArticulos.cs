using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Articulos;


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

        public void AgregarArticulo(Articulo articulo)
        {
            Conexion datos = new Conexion();
            try
            {
                datos.ejecutarLectura("INSERT INTO ARTICULOS VALUES ('@Codigo','@Nombre','@Descripcion','@idMarca','@idCategoria','@ImagenUrl','@Precio');");
                datos.SetearParametros("@Codigo", articulo.Codigo);
                datos.SetearParametros("@Codigo", articulo.Nombre);
                datos.SetearParametros("@Codigo", articulo.Marca);
                datos.SetearParametros("@Codigo", articulo.NombreCategoria);
                datos.SetearParametros("@Codigo", articulo.ImagenUrl);
                datos.SetearParametros("@Codigo", articulo.Precio);
                datos.command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ElimanarArticulo()
        {

        }

        public void Modificar()
        {

        }

        //public List<Categoria> ListarCategorias(string query)
        //{
        //    Conexion datos = new Conexion();
        //    List<Categoria> listaCategorias = new List<Categoria>();

        //    try
        //    {
        //        datos.ejecutarLectura("SELECT DESCRIPCION FROM CATEGORIAS;");
        //        while (datos.ReaderConnection.Read())
        //            {

        //            Categoria categoria = new Categoria();
        //             categoria.Nombre = datos.ReaderConnection["Descripcion"].ToString();  
        //            listaCategorias.Add(categoria);
                    
        //            }
        //        return listaCategorias;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
               

        //    }



   
        public List<T> Listar<T>(string query) where T : IDESCRIPCION, new()
        {
            Conexion datos = new Conexion();
            List<T> lista = new List<T>();

            try
            {
                datos.ejecutarLectura(query);
                while (datos.ReaderConnection.Read())
                {
                    T objeto = new T();
                    
                    objeto.Descripcion = datos.ReaderConnection["Descripcion"].ToString();
                    lista.Add(objeto);

                }
                return lista;
            }
            catch (Exception)
            {

                throw;


            }



        }
    }
}
