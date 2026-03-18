using Articulos;
using CapaDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<Categoria> categorias = new List<Categoria>();
            categorias = repositorio.Listar<Categoria>("SELECT Id, Descripcion FROM CATEGORIAS");
            return categorias;

        }

        public List<Marca> Marcas()
        {
            List<Marca> marcas = new List<Marca>();
            marcas = repositorio.Listar<Marca>("SELECT Id, Descripcion from Marcas ");
            return marcas;

        }

        public void AgregarNuevo(Articulo articulo)
        {
            repositorio.agregarArticulo(articulo);
        }

        public void modificar(Articulo articulo)
        {
            repositorio.Modificar(articulo);
        }

        public void Eliminar(int id)
        {
            repositorio.elimanarArticulo(id);
        }

        public List<Articulo> FiltrarMarcas(string nombreCategoria)
        {
            List<Articulo> marcas = repositorio.filtrarMarcas(nombreCategoria);
            return marcas;

        }
    }
}
