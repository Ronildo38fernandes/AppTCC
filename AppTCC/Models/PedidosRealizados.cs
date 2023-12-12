using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
    public class PedidosRealizados
    {
        public string nome {  get; set; }

        public string nomeProduto { get; set; }

        public string cor {  get; set; }

        public int quantidade { get; set; }

        public Double total {  get; set; }

        public DateTime data {  get; set; }
    }
}
