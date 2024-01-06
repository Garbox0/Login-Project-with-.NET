using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Usersapp.Logica;
using System.Linq.Expressions;

namespace Usersapp.Datos
{
    class dusuarios
    {
        private SqlCommand cmd = new SqlCommand();
        private int idusuario;
        public bool insertar(lusuarios dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("InsertarUsuarios", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", dt.Usuario);
                cmd.Parameters.AddWithValue("@Clave", dt.Clave);
                cmd.Parameters.AddWithValue("@Icono", dt.Icono);
                cmd.Parameters.AddWithValue("@Estado", dt.Estado);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public DataTable mostrarUsuario()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("mostrarUsuario", CONEXIONMAESTRA.conexion);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }

        public bool editarUsuario(lusuarios dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("editarUsuario", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", dt.Idusuario);
                cmd.Parameters.AddWithValue("@Usuario", dt.Usuario);
                cmd.Parameters.AddWithValue("@Clave", dt.Clave);
                cmd.Parameters.AddWithValue("@Icono", dt.Icono);
                cmd.Parameters.AddWithValue("@Estado", dt.Estado);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public bool eliminarUsuario(lusuarios dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("eliminarUsuario", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", dt.Idusuario);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }

        public DataTable buscarUsuario(string parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("buscarUsuario", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Buscador", parametros);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }

    }
    
}


