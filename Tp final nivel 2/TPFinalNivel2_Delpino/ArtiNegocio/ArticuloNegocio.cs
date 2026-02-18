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
    }
}
