using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();//Aquí está toda la información para obtener la cadena de conexión SQL

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spListarContactos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel(){ 
                            contactoID = Convert.ToInt32(dr["contactoID"]),
                            nombre = dr["nombre"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            correo = dr["correo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public ContactoModel Obtener(int contactoID)
        {
            var oContacto = new ContactoModel();

            var cn = new Conexion();//Aquí está toda la información para obtener la cadena de conexión SQL

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spObtenerContacto", conexion);
                cmd.Parameters.AddWithValue("contactoID",contactoID);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.contactoID = Convert.ToInt32(dr["contactoID"]);
                        oContacto.nombre = dr["nombre"].ToString();
                        oContacto.telefono = dr["telefono"].ToString();
                        oContacto.correo = dr["correo"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool Guardar(ContactoModel oContacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();//Aquí está toda la información para obtener la cadena de conexión SQL

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spGuardarContacto", conexion);
                    cmd.Parameters.AddWithValue("nombre", oContacto.nombre);
                    cmd.Parameters.AddWithValue("telefono", oContacto.telefono);
                    cmd.Parameters.AddWithValue("correo", oContacto.correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();//Ejecutamos el sp
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                respuesta=false;
                string error = e.Message;
            }
            return respuesta;
        }

        public bool Editar(ContactoModel oContacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();//Aquí está toda la información para obtener la cadena de conexión SQL

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEditarContacto", conexion);
                    cmd.Parameters.AddWithValue("contactoID", oContacto.contactoID);
                    cmd.Parameters.AddWithValue("nombre", oContacto.nombre);
                    cmd.Parameters.AddWithValue("telefono", oContacto.telefono);
                    cmd.Parameters.AddWithValue("correo", oContacto.correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();//Ejecutamos el sp
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                respuesta = false;
                string error = e.Message;
            }
            return respuesta;
        }

        public bool Eliminar(int contactoID)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();//Aquí está toda la información para obtener la cadena de conexión SQL

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEliminarContacto", conexion);
                    cmd.Parameters.AddWithValue("contactoID", contactoID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();//Ejecutamos el sp
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                respuesta = false;
                string error = e.Message;
            }
            return respuesta;
        }
    }
}
