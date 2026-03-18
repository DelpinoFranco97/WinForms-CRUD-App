using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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
        public SqlCommand command { get { return Command; } }
       

        public Conexion()
        {
            // Inicializacion de atributos de la clase.

            Connec = new SqlConnection("server=.\\SQLEXPRESS; database = CATALOGO_DB; integrated security =true");
            Command = new SqlCommand();




        }

        public void ejecutarLectura()
        {
            Command.Connection = Connec;
         
            try
            {
                Connec.Open();
                Reader = Command.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void setearConsulta(string query)

        {
            Command.Parameters.Clear();
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = query;
       



        }

 

        public void ejecutarAccion()
        {   Command.Connection = Connec;
            try
            {
                Connec.Open();
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ejecutarReader()
        {
            try
            {
                if (Reader != null && !Reader.IsClosed)
                    Reader.Close();

                if (Connec.State != ConnectionState.Open)  
                    Connec.Open();

                Reader = Command.ExecuteReader();
            }
            catch
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
                if (Connec.State == System.Data.ConnectionState.Closed && Reader.IsClosed)
                {
                    Connec.Open();
                    Reader = Command.ExecuteReader();
                }
               

            }
            catch (Exception )
            {
                throw;

            }


        }

        public void CerrarConexion()
        {
            if (Reader != null)
            {
                Reader.Close(); 
            }
              
            Connec.Close();
        }

        public void SetearParametros(string clave, object valor)
        {
            if (valor == null)
                Command.Parameters.AddWithValue(clave, DBNull.Value);
            else
                Command.Parameters.AddWithValue(clave, valor);
        }

    }
}

