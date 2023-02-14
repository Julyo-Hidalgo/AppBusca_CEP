using System;
using System.Collections.Generic;
using System.Text;
using AppBusca_CEP.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AppBusca_CEP.Service
{
    public class DataService
    {
        public static async Task<Endereco> getEnderecoByCep(string cep)
        {

            Endereco endereco;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/endereco/by-cep?cep=" + cep);
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    endereco = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return endereco;
        }

        public static async Task<List<Bairro>> getBairroByIdCidade(int id_cidade)
        {
            List<Bairro> listaBairro = new List<Bairro>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/bairro/by-id_cidade?id_cidade" + id_cidade);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    listaBairro = JsonConvert.DeserializeObject<List<Bairro>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return listaBairro;
        }
    }
}