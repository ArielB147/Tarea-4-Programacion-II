using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_4_Programacion_II
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String codigo = txtcodigo.Text;
            String nombre = txtnombre.Text;
            String apellido = txtapellido.Text;
            String fecha_nacimiento = txtnacimiento.Text;
            String direccion = txtdireccion.Text;
            String genero = txtgenero.Text;
            String estado_civil = txtestado.Text;
            String movil = txtmovil.Text;
            String telefono = txttelefono.Text;
            String correo_electronico = txtcorreo.Text;

            String sql = "INSERT INTO agenda (codigo, nombre, apellido, fecha_nacimiento, direccion, genero, estado_civil, movil, telefono, correo_electronico) VALUES ('" + codigo + "', '" + nombre + "', '" + apellido + "', '" + fecha_nacimiento + "', '" + direccion + "', " +
                "'" + genero + "', '" + estado_civil + "', '" + movil + "', '" + telefono + "', '" + correo_electronico + "')";

            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();

            try 
            {
                MySqlCommand comando = new MySqlCommand (sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado");
                limpiar();

            }
            catch (MySqlException ex) 
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            
            }
            finally
            {
                conexionBD.Close();
            }
        }
        private void limpiar()
        {
            txtnombre.Clear();
            txtid.Clear();
            txtapellido.Clear();
            txtnacimiento.Clear();
            txtdireccion.Clear();
            txtgenero.Clear();

            txtestado.Clear();
            txtmovil.Clear();
            txttelefono.Clear();
            txtcorreo.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             String codigo = txtcodigo.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT id, codigo, nombre, apellido, fecha_nacimiento, direccion, genero, estado_civil, movil, telefono, correo_electronico FROM agenda.agenda WHERE codigo LIKE '"+codigo+"'";


            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open ();

            try 
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if(reader.HasRows) 
                {
                    while(reader.Read()) 
                    {
                        txtid.Text = reader.GetString("id");
                        //txtcodigo.Text = reader .GetString(1);
                        txtnombre.Text = reader .GetString(2);
                        txtapellido.Text = reader .GetString(3);
                        txtnacimiento.Text = reader .GetString(4);
                        txtdireccion.Text = reader .GetString(5);
                        txtgenero.Text = reader .GetString(6);
                        txtestado.Text = reader .GetString(7);
                        txtmovil.Text = reader .GetString(8);
                        txttelefono.Text = reader .GetString(9);
                        txtcorreo.Text = reader .GetString(10);
                    
                    }
                
                } else 
                {
                    MessageBox.Show("No se encuentra registro");
                
                }
            
            } catch (MySqlException ex) 
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            
            }
            finally 
            {
                conexionBD.Close();
                


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String id = txtid.Text;
            String codigo = txtcodigo.Text;
            String nombre = txtnombre.Text;
            String apellido = txtapellido.Text;
            String fecha_nacimiento = txtnacimiento.Text;
            String direccion = txtdireccion.Text;
            String genero = txtgenero.Text;
            String estado_civil = txtestado.Text;
            String movil = txtmovil.Text;
            String telefono = txttelefono.Text;
            String correo_electronico = txtcorreo.Text;

            String sql = "UPDATE agenda SET codigo='"+codigo+"', nombre='" + nombre + "', apellido='" + apellido + "', fecha_nacimiento='" + fecha_nacimiento + "', direccion='" + direccion + "', genero='" + genero + "', estado_civil='" + estado_civil + "', movil='" + movil + "', telefono='" + telefono + "', correo_electronico='" + correo_electronico + "' " +
                "WHERE id='"+id+"'";

            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro modificado");
                limpiar();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);

            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String id = txtid.Text;

            String sql = "DELETE FROM agenda WHERE id= " + id;

            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado");
                limpiar();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);

            }
            finally
            {
                conexionBD.Close();
            }
        }
    }
}
