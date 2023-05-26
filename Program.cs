using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace TFC_Benjamin
{
    class Program
    {
        

        static async Task Main(string[] args)
        {
            ObtenerDatos datos = new ObtenerDatos();
            InfoNutricionalIngrediente infoIngrediente = new InfoNutricionalIngrediente();
            //InsertBD operacionesInsert = new InsertBD();
            VentanaPrincipal vtaMain = new VentanaPrincipal();

            Application.Run(vtaMain);

            infoIngrediente = await datos.ObtenerValoresAlimento();
            //operacionesInsert.InsertInfoIngrediente(infoIngrediente);

            

            
        }
    }
}
