using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
	public class Produto
	{
        

        public int id_produto { get; set; }
		public string nomeProduto{ get; set;}
		public string cor { get; set;}
		public int quantidade { get; set; }
		public double preco { get; set;}
        
    }
}
