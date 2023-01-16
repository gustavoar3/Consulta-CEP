namespace ConsultaCEP.Models
{
    class DadosCEP
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }

        public static explicit operator string(DadosCEP cep)
            => $"{cep.cep},{cep.logradouro},{cep.complemento}, {cep.bairro}, {cep.localidade}, {cep.uf}";
    }
}
