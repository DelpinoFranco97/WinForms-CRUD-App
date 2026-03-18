using Articulos;
using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace CapaDatos
{
    public class RepositorioArticulos
    {
        public List<Articulo> ListaArticulos;
        private Conexion datos = new Conexion();

        public List<Articulo> Listar()
        {
            List<Articulo> ListaArticulos = new List<Articulo>();
            

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre,A.Descripcion,A.ImagenUrl, A.Precio,C.Descripcion as Categoria,A.IdMarca, A.IdCategoria ,M.Descripcion AS Marca\r\nFROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id join MARCAS M ON A.IdMarca = M.Id;");
                datos.ejecutarLectura();
                while (datos.ReaderConnection.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Marca = new Marca();
                    articulo.Categoria = new Categoria();
                    articulo.Id = (int)datos.ReaderConnection["Id"];
                    articulo.Codigo = datos.ReaderConnection["Codigo"].ToString();
                    articulo.Nombre = datos.ReaderConnection["Nombre"].ToString();
                    articulo.Descripcion = datos.ReaderConnection["Descripcion"].ToString();
                    articulo.Marca.Descripcion = datos.ReaderConnection["Marca"].ToString();
                    articulo.Categoria.Descripcion = datos.ReaderConnection["Categoria"].ToString();
                    articulo.Marca.Id = (int)datos.ReaderConnection["IdMarca"];
                    articulo.Categoria.Id = (int)datos.ReaderConnection["IdCategoria"];
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
            finally {
              
                datos.CerrarConexion(); }



        }

        public void agregarArticulo(Articulo articulo)
        {
           

            try
            {
              
              

                datos.setearConsulta("INSERT INTO ARTICULOS VALUES (@Codigo, @Nombre,  @Descripcion,@idMarca, @idCategoria, @ImagenUrl, @Precio);");
                datos.SetearParametros("@Codigo", articulo.Codigo);
                datos.SetearParametros("@Nombre", articulo.Nombre);
                datos.SetearParametros("@idMarca", articulo.Marca.Id);
                datos.SetearParametros("@idCategoria", articulo.Categoria.Id);
                datos.SetearParametros("@Descripcion", articulo.Descripcion);
                datos.SetearParametros("@ImagenUrl", articulo.ImagenUrl);
                datos.SetearParametros("@Precio", articulo.Precio);

                /*datos.VerificarConexion(); */  // abre conexión
                datos.ejecutarAccion();  // recién acá ejecuta
            }
            finally
            {
                datos.CerrarConexion();

            }
        }

        public void elimanarArticulo(int Id)
        {
            
            try
            {
                
                datos.setearConsulta($"DELETE FROM ARTICULOS WHERE Id = {Id}");
                datos.ejecutarLectura();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public void Modificar(Articulo articulo)
        {
          
            try
            {
               
                
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre,    Descripcion = @Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio WHERE Id = @Id;");
                datos.SetearParametros("@Id", articulo.Id);
                datos.SetearParametros("@Codigo", articulo.Codigo);
                datos.SetearParametros("@Nombre", articulo.Nombre);
                datos.SetearParametros("@idMarca", articulo.Marca.Id);
                datos.SetearParametros("@idCategoria", articulo.Categoria.Id);
                datos.SetearParametros("@Descripcion", articulo.Descripcion);
                datos.SetearParametros("@ImagenUrl", articulo.ImagenUrl);
                datos.SetearParametros("@Precio", articulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { 
                datos.CerrarConexion();
            }
        }

        public List<T> Listar<T>(string query) where T : IDESCRIPCION, new()
        {
            
            List<T> lista = new List<T>();

            try
            {
               
                datos.setearConsulta(query);
                
                datos.ejecutarLectura();
                datos.ejecutarReader();

                while (datos.ReaderConnection.Read())
                {
                    T objeto = new T();
                   
                    objeto.Id = (int)datos.ReaderConnection["Id"];
                    objeto.Descripcion = datos.ReaderConnection["Descripcion"].ToString();
                    lista.Add(objeto);

                }
                return lista;
            }
            catch (Exception)
            {

                throw;


            }
            finally {  datos.CerrarConexion();}



        }
        public List<Articulo> filtrarMarcas ( string Descripcion)
        {


            List<Articulo> marcas = new List<Articulo>();
          
            
            try
            {
                datos.setearConsulta("select DISTINCT  MARCAS.Descripcion from ARTICULOS JOIN MARCAS ON MARCAS.Id = ARTICULOS.IdMarca  where  IdCategoria = (SELECT id from CATEGORIAS WHERE Descripcion = @Descripcion) ");
                datos.SetearParametros("@Descripcion", Descripcion);
                datos.ejecutarReader();


                while (datos.ReaderConnection.Read())
                {
                    Articulo articulo = new Articulo();
                   
                    articulo.Marca = new Marca();
                    articulo.Marca.Descripcion = datos.ReaderConnection["Descripcion"].ToString();
                    marcas.Add(articulo);
                }
                return marcas;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }


    }
}
