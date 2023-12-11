
using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Reflection.Metadata.Ecma335;
namespace CRUDCORE.Datos
{
    public class RegistroDatos
    {


        public List<RegistroModel> Listar()
        {
            var Olista = new List<RegistroModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Olista.Add(new RegistroModel()
                        {
                            idRegistro = Convert.ToInt32(dr["IdRegistro"]),
                            Nombre = dr["Nombre"].ToString(),
                            Genero = dr["Genero"].ToString(),
                            Año = Convert.ToInt32(dr["Año"]),

                        });
                    }
                }
            }
            return Olista;
        }
        public RegistroModel Obtener(int IdRegistro)
        {
            var Ocontacto = new RegistroModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdRegistro", IdRegistro);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Ocontacto.idRegistro = Convert.ToInt32(dr["IdRegistro"]);
                            Ocontacto.Nombre = dr["Nombre"].ToString();
                            Ocontacto.Genero = dr["Genero"].ToString();
                            Ocontacto.Año = Convert.ToInt32(dr["Año"]);
                    }
                }
            }
            return Ocontacto;

        }

        public bool Guardar(RegistroModel Oregistro)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", Oregistro.Nombre);
                    cmd.Parameters.AddWithValue("Genero", Oregistro.Genero);
                    cmd.Parameters.AddWithValue("Año",Oregistro.Año);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta= true;

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                respuesta = false;
            }

            return respuesta;

        }
        public bool Editar(RegistroModel Oregistro)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdRegistro", Oregistro.idRegistro);
                    cmd.Parameters.AddWithValue("Nombre", Oregistro.Nombre);
                    cmd.Parameters.AddWithValue("Genero", Oregistro.Genero);
                    cmd.Parameters.AddWithValue("Año", Oregistro.Año);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                respuesta = false;
            }

            return respuesta;

        }
        public bool Eliminar(int IdRegistro)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdRegistro", IdRegistro);
                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                respuesta = false;
            }

            return respuesta;

        }

    }
    }
