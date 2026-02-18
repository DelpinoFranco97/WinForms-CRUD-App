using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        // Declaracion de atributos de la clase.
        private SqlCommand Command;
        private SqlDataReader Reader;
        private SqlConnection Connec;

        public SqlDataReader ReaderConnection { get { return Reader; } }

        public Conexion()
        {
            // Inicializacion de atributos de la clase.

            Connec = new SqlConnection("server=.\\SQLEXPRESS; database = CATALOGO_DB; integrated security =true");
            Command = new SqlCommand();
        }

        public void ejecutarLectura(string query)
        {
           VerificarConexion();
          setearConsulta(query);
          ejecutarReader();
          




        }

        public void setearConsulta(string query)
        {
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = query;


        }


        public void ejecutarReader()
        // Verifica  el estado del lector. Utilizo la propiedad IsClosed de sqlreader para obetener el valor. 

        {
            try
            {
                if (Reader != null && !Reader.IsClosed)
                {
                    Reader.Close();
                }
                Reader = Command.ExecuteReader();

            }
            catch (Exception )
            {
                throw;
            }
        }


        public void VerificarConexion()
        {

            // Verifica el estado de la conexion y lanza posibles errores para que otra capa lo maneje.
            // Importante utilizo el namespace data y utilizo propiedad conectionstate que me permite saber el estaod de la conexion
            try
            {
                Command.Connection = Connec;
                if (Connec.State == System.Data.ConnectionState.Closed)
                {
                    Connec.Open();
                }

            }
            catch (Exception )
            {
                throw;

            }


        }

        public void CerrarConexion()
        {

            try
            {
                if (Connec.State == System.Data.ConnectionState.Open)
                {
                    Connec.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

