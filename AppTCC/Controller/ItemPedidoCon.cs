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

        public static void InserirItempedido(int id_produto, int quantidade, Double totalItem)
        {
            string sql = "INSERT INTO itemPedido(id_produto,quantidade,totalItem) VALUES (@id_produto,@quantidade,@totalItem);";
            // SELECT LAST_INSERT_ID();
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id_produto", MySqlDbType.VarChar).Value = id_produto;
                    cmd.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = quantidade;
                    cmd.Parameters.Add("@totalItem", MySqlDbType.Double).Value = totalItem;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();


                    // ExecuteScalar retorna o primeiro resultado da consulta (o último ID inserido)
                    // int ultimoIdInserido = Convert.ToInt32(cmd.ExecuteScalar());

                    //return ultimoIdInserido;
                }
                con.Close();
            }
        }

       public static int ObterUltimoIdItem()
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();

                string sql = "SELECT id_item FROM itemPedido ORDER BY id_item DESC LIMIT 1"; // ou "SELECT TOP 1 id FROM pedido ORDER BY id DESC" para SQL Server

                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32("id_item");
                        }
                        else
                        {
                            return -1; // Indica que a tabela está vazia
                        }
                    }
                }
            }
        }





       
    }
}
