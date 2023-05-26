using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace TFC_Benjamin
{
    class ObtenerDatos
    {
        public async Task<InfoNutricionalIngrediente> ObtenerValoresAlimento()
        {
            string appID = "54a781a7";
            string apiKey = "89588f9f3c0bb48f6d8b83d1b3b6a8c9";
            string nombreIngrediente = "100 g chorizo";
            InfoNutricionalIngrediente infoIngrediente = new InfoNutricionalIngrediente();

            string url = $"https://api.edamam.com/api/nutrition-data?app_id={appID}&app_key={apiKey}&ingr={Uri.EscapeDataString(nombreIngrediente)}";

            try
            {
                HttpClient httpCliente = new HttpClient();
                HttpResponseMessage response = await httpCliente.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();

                    JObject respuesta = JObject.Parse(responseString);
                    if (respuesta["totalNutrients"]["PROCNT"] != null)
                    {
                        double proteinas = (double)respuesta["totalNutrients"]["PROCNT"]["quantity"];
                        double proteinasRedondeadas = Math.Round(proteinas, 2);
                        infoIngrediente.proteinas = proteinasRedondeadas;
                    }
                    else
                    {
                        infoIngrediente.proteinas = 0;
                    }
                    

                    if (respuesta["totalNutrients"]["CHOCDF.net"] != null)
                    {
                        double carbohidratos = (double)respuesta["totalNutrients"]["CHOCDF.net"]["quantity"];
                        double hidratosRedondeados = Math.Round(carbohidratos, 2);
                        infoIngrediente.carbohidratos = hidratosRedondeados;
                    }
                    else
                    {
                        infoIngrediente.carbohidratos = 0;
                    }
                    

                    if (respuesta["totalNutrients"]["FAT"] != null)
                    {
                        double grasas = (double)respuesta["totalNutrients"]["FAT"]["quantity"];
                        double grasasRedondeadas = Math.Round(grasas, 2);
                        infoIngrediente.grasas = grasasRedondeadas;
                    }
                    else
                    {
                        infoIngrediente.grasas = 0;
                    }

                    double calorias = (double)respuesta["totalNutrients"]["ENERC_KCAL"]["quantity"];
                    double caloriasRedondeadas = Math.Round(calorias, 2);
                    infoIngrediente.calorias = caloriasRedondeadas;

                }
                else
                {
                    Console.WriteLine("Error al realizar la solicitud a la API.");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine(httpEx.Message);
            }
            catch (ArgumentNullException argEX)
            {
                Console.WriteLine(argEX.Message);
            }

            return infoIngrediente;
        }
    }
}
