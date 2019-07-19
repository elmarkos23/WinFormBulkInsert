using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormBulkInsert
{
    public class ZK_PRUEBA
    {
        public int ZK_ID { get; set; }
        public string ZK_NAME { get; set; }
        public DateTime ZK_FECHA { get; set; }
        public bool ZK_ESTADO { get; set; }

        public ZK_PRUEBA() { }

        public static List<ZK_PRUEBA> getData(int registros)
        {
            List<ZK_PRUEBA> ls = new List<ZK_PRUEBA>();
            for (int i = 0; i < registros; i++)
            {
                ls.Add(new ZK_PRUEBA { ZK_NAME = "CONFISOFT "+ i.ToString(),
                    ZK_ESTADO = true,
                    ZK_FECHA = DateTime.Now });
            }
            return ls;
        }
      


    }
}
