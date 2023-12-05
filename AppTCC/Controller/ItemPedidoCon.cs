using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppTCC.Controller
{

    public class ItemPedidoCon
    {
        static string conn = @"server=rsxrepresentacoes.com.br;port=3306;database=rsxrep_tcc_pedidos;user=rsxrep_tcc2023;password=h#2UbmY(vteD;charset=utf8";

        public static int InserirItempedido(int id_produto, int quantidade, Double totalItem)
        {
            string sql = "INSERT INTO itemPedido(id_produto,quantidade,totalItem) VALUES (@id_produto,@quantidade,@totalItem) ; SELECT LAST_INSERT_ID();";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id_produto", MySqlDbType.VarChar).Value = id_produto;
                    cmd.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = quantidade;
                    cmd.Parameters.Add("@totalItem", MySqlDbType.Double).Value = totalItem;
                    // ExecuteScalar retorna o primeiro resultado da consulta (o último ID inserido)
                    int ultimoIdInserido = Convert.ToInt32(cmd.ExecuteScalar());

                    return ultimoIdInserido;
                }
                con.Close();
            }
        }

        public static int ObterUltimoIDInserido()
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                string sql = "SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    // ExecuteScalar retorna o primeiro resultado da consulta (o último ID inserido)
                    int ultimoIdInserido = Convert.ToInt32(cmd.ExecuteScalar());

                    return ultimoIdInserido;
                }
            }
        }
    }
}
