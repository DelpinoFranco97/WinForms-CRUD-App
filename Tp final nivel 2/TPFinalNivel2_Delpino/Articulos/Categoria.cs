using Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
   public class Categoria:IDESCRIPCION
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }  
   

        public override string ToString()
        {
            return Descripcion;
        }

      
    }
}
