using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppTCC.Controller
{
    public class PedidoCon
    {
        static string conn = @"server=rsxrepresentacoes.com.br;port=3306;database=rsxrep_tcc_pedidos;user=rsxrep_tcc2023;password=h#2UbmY(vteD;charset=utf8";

        public static void InserirPedido(int id_cliente, int id_item, int quantidade, Double total)
        {
            string sql = "INSERT INTO pedido(id_cliente, id_item,quantidade,total,data_pedido ) VALUES (@id_cliente,@id_item,@quantidade,@total,NOW())";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id_cliente", MySqlDbType.Int32).Value = id_cliente;
                    cmd.Parameters.Add("@id_item", MySqlDbType.Int32).Value = id_item;
                    cmd.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = quantidade;
                    cmd.Parameters.Add("@total", MySqlDbType.Double).Value = total;    
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }


    }
}
