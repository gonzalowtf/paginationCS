using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace LaFalda
{
    class Conexion
    {
        public MySqlConnectionStringBuilder builder;
        public MySqlConnection conn;
        public MySqlCommand cmd;

        public Conexion()
        {


            if (tipoConexion.tipoconn == 0)
            {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder();
                csb.Server = "lafalda.ddns.net";
                //csb.Server = "192.168.0.152";
                //csb.Server = "localhost";
                csb.UserID = "root"; // root
                csb.Password = "alfabetaomega3"; //alfabetaomega3
                csb.Database = "lafalda";
                conn = new MySqlConnection(csb.ToString());
            }
            else
            {
                if (tipoConexion.tipoconn == 1)
                {
                    MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder();
                    //csb.Server = "lafalda.ddns.net";
                    csb.Server = "192.168.0.152";
                    //csb.Server = "localhost";
                    csb.UserID = "root"; // root
                    csb.Password = "alfabetaomega3"; //alfabetaomega3
                    csb.Database = "lafalda";
                    conn = new MySqlConnection(csb.ToString());
                }
                else
                {
                    if (tipoConexion.tipoconn == 2)
                    {
                        MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder();
                        //csb.Server = "lafalda.ddns.net";
                        //csb.Server = "192.168.0.152";
                        csb.Server = "localhost";
                        csb.UserID = "root"; // root
                        csb.Password = "alfabetaomega3"; //alfabetaomega3
                        csb.Database = "lafalda";
                        conn = new MySqlConnection(csb.ToString());
                    }
                }
            }


        }
    }
}