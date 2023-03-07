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

        public static async Task<List<CEP>> getCepByLogradouro(string logradouro)
        {
            List<CEP> listCep = new List<CEP>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/cep/by-logradouro?logradouro=" + logradouro);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    listCep = JsonConvert.DeserializeObject<List<CEP>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return listCep;
        }

        public static async Task<List<Cidade>> getCidadeByUF(string uf)
        {
            List<Cidade> cidade = new List<Cidade>();

            using (HttpClient client = new HttpClient()) {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/cidade/by-uf?uf=" + uf);
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    cidade = JsonConvert.DeserializeObject<List<Cidade>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());

            }

            return cidade;
        }

        public static async Task<List<Logradouro>> getLogradouroByCidadeAndBairro(int id_cidade, string bairro)
        {
            List<Logradouro> listaLogradouro = new List<Logradouro>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/logradouro/by-bairro?id_cidade="+ id_cidade + "&bairro=" + bairro);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    listaLogradouro = JsonConvert.DeserializeObject<List<Logradouro>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }

            return listaLogradouro;
        }

        /*
            https://cep.metoda.com.br/endereco/by-cep?cep=17210580
            https://cep.metoda.com.br/logradouro/by-bairro?id_cidade=487&bairro=Jardim
            https://cep.metoda.com.br/cep/by-logradouro?logradouro=
            https://cep.metoda.com.br/cidade/by-uf?uf=SP
            https://cep.metoda.com.br/bairro/by-cidade?id=4874

            https://cep.metoda.com.br/Banco/Dados.zip
            https://cep.metoda.com.br/Banco/Modelagem.mwb
         */
    }
}