using System;
using System.Collections.Generic;
using System.Text;

namespace AppBusca_CEP.Model
{
    public class Cidade
    {
        public int idCidade { get; set; }
        public string descCidade { get; set; }
        public string uf { get; set; }
        public int codigoIbge { get; set; }
        public int ddd { get; set; }
    }
}
