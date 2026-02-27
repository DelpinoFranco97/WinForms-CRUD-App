using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Dominio;

namespace ArtiNegocio
{
    public class ArticuloNegocio
    {
            RepositorioArticulos repositorio = new RepositorioArticulos();
        public List<Articulo> MostrarArticulos()
        {
            List < Articulo > articulos= new List<Articulo>();
            articulos = repositorio.Listar();
            return articulos;

        }

   

        public List<Categoria> Categorias()
        {
            List<Categoria> categorias= new List<Categoria>();

            categorias = repositorio.Listar<Categoria>("SELECT DESCRIPCION FROM CATEGORIAS");
            return categorias;

        }

        public List<Marca> Marcas()
        {
            List<Marca> marcas = new List<Marca>();

            marcas = repositorio.Listar<Marca>("SELECT DESCRIPCION FROM MARCAS");
            return marcas;

        }

        public void AgregarNuevo(Articulo articulo)
        {
            repositorio.AgregarArticulo(articulo);
        }
    }
}
