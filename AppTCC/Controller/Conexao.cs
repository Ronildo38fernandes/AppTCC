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
        static string conn = @"server=rsxrepresentacoes.com.br;port=3306;database=rsxrep_tcc_pedidos;user=rsxrep_tcc2023;password=h#2UbmY(vteD;charset=utf8";
       
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
                                id_cliente = reader.GetInt32(0),
                                nome = reader.GetString(1) ??" ",
                                cnpj = reader.GetString(2)?? " ",
                                inscricao = reader.GetString(3) ?? " ",
                                email = reader.GetString(4) ?? " ",
                                endereco = reader.GetString(5) ?? " ",
                                numero = reader.GetString(6) ?? " ",
                                telefone =  reader.GetString(7) ?? " ",
                                cidade =reader.GetString(8) ?? " ",
                                estado = reader.GetString(9) ?? " " 
                            };
                            listaclientes.Add(cliente);
                        }
                    }
                }
                con.Close();
                return listaclientes;
            }
        }

        public static void InserirCliente(string nome, string cnpj, string inscricao,string email,string endereco, string numero, string telefone, string cidade, string estado)
        {
            string sql = "INSERT INTO cliente(nome, cnpj,inscricao,email,endereco,numero,telefone,cidade,estado) VALUES (@nome, @cnpj,@inscricao,@email,@endereco,@numero,@telefone,@cidade,@estado)";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                    cmd.Parameters.Add("@cnpj", MySqlDbType.VarChar).Value = cnpj;
                    cmd.Parameters.Add("@inscricao", MySqlDbType.VarChar).Value = inscricao;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@endereco", MySqlDbType.VarChar).Value = endereco;
                    cmd.Parameters.Add("@numero", MySqlDbType.VarChar).Value = numero;
                    cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = telefone;
                    cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = cidade;
                    cmd.Parameters.Add("@estado", MySqlDbType.VarChar).Value = estado;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }


        public static void AtualizarCliente(Cliente cliente)
        {
            string sql = "UPDATE cliente SET nome=@nome, cnpj=@cnpj,inscricao=@inscricao,email=@email,endereco=@endereco,numero=@numero,telefone=@telefone,cidade=@cidade,estado=@estado WHERE id_cliente=@id_cliente";
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@id_cliente", MySqlDbType.Int32).Value = cliente.id_cliente;
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cliente.nome;
                        cmd.Parameters.Add("@cnpj", MySqlDbType.VarChar).Value = cliente.cnpj;
                        cmd.Parameters.Add("@inscricao", MySqlDbType.VarChar).Value = cliente.inscricao;
                        cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cliente.email;
                        cmd.Parameters.Add("@endereco", MySqlDbType.VarChar).Value = cliente.endereco;
                        cmd.Parameters.Add("@numero", MySqlDbType.VarChar).Value = cliente.numero;
                        cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = cliente.telefone;
                        cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = cliente.cidade;
                        cmd.Parameters.Add("@estado", MySqlDbType.VarChar).Value = cliente.estado;
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
            string sql = "DELETE FROM cliente WHERE id_cliente=@id_cliente";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id_cliente", MySqlDbType.Int32).Value = cliente.id_cliente;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }




        }
    }

}



