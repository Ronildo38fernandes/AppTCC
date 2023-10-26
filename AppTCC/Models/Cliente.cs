using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string nome { get; set; }
        public string cnpj { get; set; }

        public string inscricao {  get; set; }

        public string email { get; set; }

        public string endereco { get; set;}

        public string numero { get; set; }

        public string telefone { get; set;}

        public string cidade { get; set; }

        public string estado { get; set;}
    }

  
}
