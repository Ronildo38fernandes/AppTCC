using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
    public class ItemPedido
    {
        public int id_item { get; set; }

        public int id_produto { get; set; }


        public int quantidade { get; set; }

        public double totalItem { get; set; }

    }
}
