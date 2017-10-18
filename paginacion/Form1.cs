using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;
using MySql.Data.MySqlClient;
using LaFalda;

namespace paginacion
{
    public partial class Form1 : Form
    {
        int vali = 0;
        int valf = 0;
        int valti = 0;
        int valtf = 0;
        public Form1()
        {
            InitializeComponent();
            this.PGENUMBER.Text = "1";
            
            string message = "Acceder de forma remota?";
            string caption = "Error al seleccionar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                tipoConexion.tipoconn = 0;
            }
            else
            {
                string message2 = "Estoy en la falda?";
                string caption2 = "Error al seleccionar";
                MessageBoxButtons buttons2 = MessageBoxButtons.YesNo;
                DialogResult result2;

                // Displays the MessageBox.

                result2 = MessageBox.Show(message2, caption2, buttons2);
                if (result2 == System.Windows.Forms.DialogResult.Yes)
                {

                    tipoConexion.tipoconn = 1;
                }
                else
                {
                    tipoConexion.tipoconn = 2;


                }
            }


           

            try
            {
                Conexion c = new Conexion();
                c.cmd = c.conn.CreateCommand();
                c.conn.Open();
                c.cmd.CommandText = "select max(id_carga), min(id_carga) from cargas";
                MySqlDataReader reader = c.cmd.ExecuteReader();
                while (reader.Read())
                {

                    valf = reader.GetInt32(0);
                    vali = reader.GetInt32(1);


                }
                
                c.conn.Close();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Error mysql " + err);
            }


            try
            {
                Conexion c = new Conexion();
                c.conn.Open();
                c.cmd = c.conn.CreateCommand();
                MySqlDataAdapter db = new MySqlDataAdapter("select * from cargas where id_carga <= "+valf+ " and id_carga>= " + (valf-100)+" order by fecha desc", c.conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(db);
                DataSet ds = new DataSet();
                db.Fill(ds);
                this.dataGridView1.DataSource = ds.Tables[0];
                c.conn.Close();
        }
        catch (MySqlException e)
        {
            MessageBox.Show("Error mysql " + e);
        }

            valtf = valf;
            valti = valf - 100;
            this.PGENUMBER.Text = valtf + "-" + valti;



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            valtf = valtf + 100;
            valti = valti + 100;
            if (valtf >= valf)
            {
                valtf = valf;
                valti = valf-100;
                try
                {
                    Conexion c = new Conexion();
                    c.conn.Open();
                    c.cmd = c.conn.CreateCommand();
                    MySqlDataAdapter db = new MySqlDataAdapter("select * from cargas where id_carga <= " + valtf + " and id_carga>= " + valti + " order by fecha desc", c.conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(db);
                    DataSet ds = new DataSet();
                    db.Fill(ds);
                    this.dataGridView1.DataSource = ds.Tables[0];
                    c.conn.Close();
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Error mysql " + err);
                }
            }
            else
            {
                try
                {
                    Conexion c = new Conexion();
                    c.conn.Open();
                    c.cmd = c.conn.CreateCommand();
                    MySqlDataAdapter db = new MySqlDataAdapter("select * from cargas where id_carga <= " + valtf + " and id_carga>= " + valti + " order by fecha desc", c.conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(db);
                    DataSet ds = new DataSet();
                    db.Fill(ds);
                    this.dataGridView1.DataSource = ds.Tables[0];
                    c.conn.Close();
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Error mysql " + err);
                }
            }
            this.PGENUMBER.Text = valtf + "-" + valti;

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            valtf = valtf - 100;
            valti = valti - 100;
            if (valti <= vali)
            {
                valtf = 100;
                valti = 0;
                try
                {
                    Conexion c = new Conexion();
                    c.conn.Open();
                    c.cmd = c.conn.CreateCommand();
                    MySqlDataAdapter db = new MySqlDataAdapter("select * from cargas where id_carga <= " + valtf + " and id_carga>= " + valti + " order by fecha desc", c.conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(db);
                    DataSet ds = new DataSet();
                    db.Fill(ds);
                    this.dataGridView1.DataSource = ds.Tables[0];
                    c.conn.Close();
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Error mysql " + err);
                }
            }
            else
            {
                try
                {
                    Conexion c = new Conexion();
                    c.conn.Open();
                    c.cmd = c.conn.CreateCommand();
                    MySqlDataAdapter db = new MySqlDataAdapter("select * from cargas where id_carga <= " + valtf + " and id_carga>= " + valti+ " order by fecha desc", c.conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(db);
                    DataSet ds = new DataSet();
                    db.Fill(ds);
                    this.dataGridView1.DataSource = ds.Tables[0];
                    c.conn.Close();
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Error mysql " + err);
                }
            }
            this.PGENUMBER.Text = valtf + "-" + valti;

        }
    }
}
