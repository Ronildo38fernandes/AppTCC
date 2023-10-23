using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;
using AppTCC.Models;



namespace AppTCC.Controller
{
    public class Conexao
    {
        static string conn = @"server=mysql744.umbler.com;port=41890;database=ronildotcc;user id=ronildo;password=cebola171;charset=utf8";
        public static List<Cliente> ListarClientes()
        {
            List<Cliente> listaclientes = new List<Cliente>();
            string sql = "SELECT * FROM cliente";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente()
                            {
                                id = reader.GetInt32(0),
                                nome = reader.GetString(1),
                                cnpj = reader.GetString(2)
                            };
                            listaclientes.Add(cliente);
                        }
                    }
                }
                con.Close();
                return listaclientes;
            }
        }
        public static void InserirCliente(string nome, string cnpj)
        {
            string sql = "INSERT INTO cliente(nome, cnpj) VALUES (@nome, @cnpj)";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                    cmd.Parameters.Add("@cnpj", MySqlDbType.VarChar).Value = cnpj;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }


        public static void AtualizarCliente(Cliente cliente)
        {
            string sql = "UPDATE cliente SET nome=@nome, cnpj=@cnpj WHERE id=@id";
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cliente.nome;
                        cmd.Parameters.Add("@cnpj", MySqlDbType.VarChar).Value = cliente.cnpj;
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = cliente.id;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }



        public static void ExcluirCliente(Cliente cliente)
        {
            string sql = "DELETE FROM cliente WHERE id=@id";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = cliente.id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }




        }
    }

}
