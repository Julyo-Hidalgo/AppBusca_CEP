using System;
using System.Collections.Generic;
using System.Text;

namespace AppBusca_CEP.Model
{
    public class Endereco
    {
        public int idLogradouro { get; set; }
        public int idCidade { get; set; }
        public string tipo { get; set; }
        public string descEnderco { get; set; }
        public string uf { get; set; }
        public string complemento { get; set; }
        public string descSemEndereco { get; set; }
        public string descCidade { get; set; }
        public string codigoCidadeIbge { get; set; }
        public string descBairro { get; set; }
        public object rows { get; set; }
        public int CEP { get; set; }
        public string UF { get; set; }
    }
}