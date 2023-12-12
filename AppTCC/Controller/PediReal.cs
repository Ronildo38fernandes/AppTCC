using AppTCC.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Controller
{
    public class PediReal
    {
        static string conn = @"server=rsxrepresentacoes.com.br;port=3306;database=rsxrep_tcc_pedidos;user=rsxrep_tcc2023;password=h#2UbmY(vteD;charset=utf8";
        
         public static List<PedidosRealizados> ListarPedidosRealizados()
         {
             List<PedidosRealizados> listaPedidosRealizados = new List<PedidosRealizados>();
             string sql = "SELECT cl.nome, pdt.nomeProduto, pdt.cor, SUM(ipd.quantidade) as totalQuantidade, pd.total, pd.data_pedido FROM pedido AS pd JOIN itemPedido AS ipd ON ipd.id_item = pd.id_item JOIN cliente AS cl ON pd.id_cliente = cl.id_cliente JOIN produto AS pdt ON pdt.id_produto = ipd.id_produto WHERE pd.data_pedido >= CURDATE() - INTERVAL 2 DAY GROUP BY pdt.nomeProduto, cl.nome, pdt.cor, pd.total, pd.data_pedido;";
             using (MySqlConnection conn = new MySqlConnection(PediReal.conn))
             {
                 conn.Open();
                 using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                 {
                     using (MySqlDataReader reader = cmd.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             PedidosRealizados pedidosRealizados = new PedidosRealizados()
                             {
                                 
                                 nome = reader.GetString(0) ??" ",
                                 nomeProduto = reader.GetString(1)?? " ",
                                 cor = reader.GetString(2) ?? " ",
                                 quantidade = reader.GetInt32(3),
                                 total = reader.GetDouble(4),
                                 data = reader.GetDateTime(5) 
                             };
                             listaPedidosRealizados.Add(pedidosRealizados);
                         }
                     }
                 }
                 conn.Close();
                 return listaPedidosRealizados;
             }
         }
        
    }
}
