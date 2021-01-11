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
            Cursor = Cursors.WaitCursor;
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
            Cursor = Cursors.Arrow;
            MessageBox.Show("Datos Grabados");
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            List<ZK_PRUEBA> ls = new List<ZK_PRUEBA>();
            ls = ZK_PRUEBA.getData(Convert.ToInt32(nudRegistros.Value));
            DateTime a = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                foreach (ZK_PRUEBA zK in ls)
                {
                    string query = "INSERT INTO[dbo].[ZK_PRUEBA]([ZK_NAME],[ZK_FECHA],[ZK_ESTADO])VALUES(@ZK_NAME,@ZK_FECHA,@ZK_ESTADO) SELECT SCOPE_IDENTITY()";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ZK_NAME", zK.ZK_NAME);
                        command.Parameters.AddWithValue("@ZK_FECHA", zK.ZK_FECHA);
                        command.Parameters.AddWithValue("@ZK_ESTADO", zK.ZK_ESTADO);
                        int result = Convert.ToInt32(command.ExecuteScalar());
                        funGrabarDetalle(result);
                    }
                }
                connection.Close();
            }
            DateTime b = DateTime.Now;
            System.TimeSpan diff1 = b.Subtract(a);
            lblTiempo.Text = diff1.Seconds.ToString();
            Cursor = Cursors.Arrow;
        }


        private void funGrabarDetalle(int ID)
        {

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                for(int i=0;i<100;i++)
                {
                    int result = 0;
                    string query = "SELECT MAX(ISNULL(ZKD_CODIGO,0)) + 1 as id FROM ZK_PRUEBA_DETALLE WHERE ZKD_CODIGOA = 2019 AND ZKD_CODIGOB = 1 AND ZKD_CODIGOC = 12 AND ZKD_CODIGOD = 8";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //command.Parameters.AddWithValue("@ZK_ID", ID);
                        //result = command.ExecuteReader();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //Console.WriteLine(String.Format("{0}", reader["id"]));
                                result = Convert.ToInt32(reader["id"]);
                            }
                        }
                    }

                    //insertar detalle
                    query = "INSERT INTO[dbo].[ZK_PRUEBA_DETALLE]([ZKD_CODIGO],[ZKD_CODIGOA],[ZKD_CODIGOB],[ZKD_CODIGOC],[ZKD_CODIGOD],[ZK_ID]) VALUES (@ZKD_CODIGO,2019,1,12,8,@ZK_ID)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ZKD_CODIGO", result);
                        command.Parameters.AddWithValue("ZK_ID", ID);
                        int result2 = command.ExecuteNonQuery();

                    }
                }
                connection.Close();
            }


              


        }
    }
}
