using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_4_Programacion_II
{
    class conexion
    {
        public static MySqlConnection Conexion() 
        {
            string servidor = "localhost";
            string bd = "Agenda";
            string usuario = "root";
            string contraseña = "jirafon13";

            string cadenaconexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id= " + usuario + "; Password=" + contraseña +"";

            try 
            { 
              MySqlConnection conexionBD = new MySqlConnection(cadenaconexion);
              
              return conexionBD;

            }
            catch (MySqlException ex) 
            { 
                Console.WriteLine("Error: " + ex.Message);
                return null;
            
            }

        }


    }
}
