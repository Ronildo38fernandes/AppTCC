using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
    public class Pedido
    {
        public int id_Pedido { get; set; }

        public int id_cliente { get; set; }

        public int id_item { get; set; }

        public int quantidade { get; set; }

        public double total { get; set; }   

        public DateTime data_pedido { get; set; }   

    }
}
