using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormBulkInsert
{
    public partial class Form1 : Form
    {
        public string connString = "Data Source=10.204.17.207;Initial Catalog=PRACTALISDB_DESARROLLO;User ID=usuarioPractalis;Password=confiamed.123;Application Name=WinFormBulkInsert";
        public DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // connect to SQL
            using (SqlConnection connection = new SqlConnection(connString))
            {
                // make sure to enable triggers
                // more on triggers in next post
                SqlBulkCopy bulkCopy = new SqlBulkCopy(
                    connection,
                    SqlBulkCopyOptions.TableLock |
                    SqlBulkCopyOptions.FireTriggers |
                    //SqlBulkCopyOptions.KeepIdentity |//esto es una prueba de id
                    SqlBulkCopyOptions.UseInternalTransaction,null);

                // set the destination table name
                bulkCopy.DestinationTableName = "ZK_PRUEBA";
                
                connection.Open();

                // write the data in the "dataTable"
                dt = ZK_PRUEBA.getData(Convert.ToInt32(nudRegistros.Value)).AsDataTable();
                DateTime a = DateTime.Now;
                bulkCopy.WriteToServer(dt);
                DateTime b = DateTime.Now;
                System.TimeSpan diff1 = b.Subtract(a);
                lblTiempoBulk.Text = diff1.Seconds.ToString();
                connection.Close();
            }
            // reset
            this.dt.Clear();
            MessageBox.Show("Datos Grabados");
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            List<ZK_PRUEBA> ls = new List<ZK_PRUEBA>();
            ls = ZK_PRUEBA.getData(Convert.ToInt32(nudRegistros.Value));
            DateTime a = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                foreach (ZK_PRUEBA zK in ls)
                {
                    string query = "INSERT INTO[dbo].[ZK_PRUEBA]([ZK_NAME],[ZK_FECHA],[ZK_ESTADO])VALUES(@ZK_NAME,@ZK_FECHA,@ZK_ESTADO)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ZK_NAME", zK.ZK_NAME);
                        command.Parameters.AddWithValue("@ZK_FECHA", zK.ZK_FECHA);
                        command.Parameters.AddWithValue("@ZK_ESTADO", zK.ZK_ESTADO);
                        int result = command.ExecuteNonQuery();

                    }
                }
                connection.Close();
            }
            DateTime b = DateTime.Now;
            System.TimeSpan diff1 = b.Subtract(a);
            lblTiempo.Text = diff1.Seconds.ToString();
        }
    }
}
