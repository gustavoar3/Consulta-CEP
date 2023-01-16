using ConsultaCEP.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace ConsultaCEP.Services
{
    class ConsultaService
    {
        private bool VerificaCEP(string cep)
        {
            if (string.IsNullOrEmpty(cep)
                || !int.TryParse(cep, out var n)
                || cep.Length != 8) return false;

            return true;
        }

        private Models.DadosCEP ConsultaCEP(string cep)
        {
            string URL = "https://viacep.com.br/ws/" + cep + "/json/";

            HttpClient _httpClient = new HttpClient();
            HttpResponseMessage result =
                _httpClient.GetAsync(URL).Result;

            string JSONcep =
                   result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Models.DadosCEP>(JSONcep);
        }

        private void SalvarDados(List<Models.DadosCEP> cep)
            => File.WriteAllLines("Data\\Dados.csv", cep.Select(item => (string)item).ToList());

        public void ConsultaAPI()
        {
            var file = new Connection().ReadFile();
            var lista = new List<Models.DadosCEP>();

            foreach (var cep in file)
            {
                if (VerificaCEP(cep))
                {
                    var dados = ConsultaCEP(cep);

                    if (dados.cep != null)
                        lista.Add(dados);
                }
            }

            SalvarDados(lista);
        }

    }
}
