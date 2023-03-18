using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Newtonsoft.Json;

namespace AppLogic
{
    public class SINPAGManager
    {
        public string SubscribeClient() 
        {
            var urlSINPAG = "https://sinpag-app.azurewebsites.net/";
            var urlMethod = "/api/Subscriptor/Subscribe";
            
            var urlFinal = urlSINPAG + urlMethod;

            var subscriptor = new Subscriptor()
            {
                Id = "202317",
                Name = "MercaditoAviario",
                BaseURL = "https://mercaditoaviario.azurewebsites.net",
                Representative = "Ivan Rojas Salazar",
                Email = "irojass@ucenfotec.ac.cr",
                Phone = "+50622333333"
            };

            //Comenzzamos el llamado al HTTP API

            var client = new HttpClient(); 
            client.BaseAddress = new Uri(urlFinal);

            // se indica al cliente el tipo de headers que va a recibir/aceptar
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //convertir el objeto "Subscriptor" a un JSON que podamos enviarle al API
            var jsonData = JsonConvert.SerializeObject(subscriptor);

            //Agregamos mas detalles al contenido, para indicar en que formato y codificacion se envia
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");

            //Enviamos el requst al API, con el contenido
            var response = client.PostAsync(urlFinal, content).Result;


            if (response.IsSuccessStatusCode)
                return "Susbscripcion correcta";
            else
                return "Error al suscribir cliente";


        }

        public List<Subscriptor> GetAllSubscribers()
        {
            var urlSINPAG = "https://sinpag-app.azurewebsites.net/";
            var urlMethod = "/api/Subscriptor/GetAllSubscribers";

            var urlFinal = urlSINPAG + urlMethod;

            var client = new HttpClient();
            client.BaseAddress = new Uri(urlFinal);

            //Llamamos al API que nos va retornar los datos
            var result = client.GetAsync(urlFinal).Result;

            if (result.IsSuccessStatusCode)
            {
                var jsonObject = result.Content.ReadAsStringAsync().Result;

                var dataObject = JsonConvert.DeserializeObject<List<Subscriptor>>(jsonObject);

                return dataObject;
            }
            else
                return null;

        }

        public Offer GetOfferDetails(string OfferId)
        {
            var urlSINPAG = "https://sinpag-app.azurewebsites.net/";
            var urlMethod = "/api/Offer/GetOffer?offerId=" + OfferId;

            var urlFinal = urlSINPAG + urlMethod;

            var client = new HttpClient();
            client.BaseAddress = new Uri(urlFinal);

            var result = client.GetAsync(urlFinal).Result;

            if (result.IsSuccessStatusCode)
            {
                var jsonObject = result.Content.ReadAsStringAsync().Result;

                var dataObject = JsonConvert.DeserializeObject<Offer>(jsonObject);

                return dataObject;

            }
            else 
            {
                return null;
            
            }

        }

        public List<Offer> GetAllOffers()
        {
            var urlSSINPAG = "https://sinpag-app.azurewebsites.net";
            //var urlSSINPAG = "https://localhost:44325";

            var urlMethod = "/api/Offer/GetOffers";
            var urlFinal = urlSSINPAG + urlMethod;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(urlFinal);

            var resultado = cliente.GetAsync(urlFinal).Result;

            if (resultado.IsSuccessStatusCode)
            {
                var jsonObject = resultado.Content.ReadAsStringAsync().Result;

                //var apiResponse = JsonConvert.DeserializeObject<List<Offer>>(jsonObject);
                var apiResponse = JsonConvert.DeserializeObject<List<Offer>>(jsonObject);

                return apiResponse;
            }
            return null;
        }

        public void CreateOffer(Offer ofr)
        {
            var url = "https://sinpag-app.azurewebsites.net";
            url = url + "/api/Offer/CreateOffer";

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string jsonData = JsonConvert.SerializeObject(ofr);

            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var result = cliente.PostAsync(url, content).Result;

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.Content.ReadAsStringAsync().Result);
            }
        }


    }
}
