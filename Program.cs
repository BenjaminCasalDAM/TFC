using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace TFC_Benjamin
{
    class Program
    {
        

        static async Task Main(string[] args)
        {
            ObtenerDatos datos = new ObtenerDatos();
            InfoNutricionalIngrediente infoIngrediente = new InfoNutricionalIngrediente();
            infoIngrediente = await datos.ObtenerValoresAlimento();
        }
    }
}
