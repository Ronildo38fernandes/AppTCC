using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using AppTCC.Models;
using AppTCC.Controller;
using System.Data;
using System.Runtime.ConstrainedExecution;



namespace AppTCC.Controller
{
	public class ProdutoCon
	{
		static string conn = @"server=rsxrepresentacoes.com.br;port=3306;database=rsxrep_tcc_pedidos;user=rsxrep_tcc2023;password=h#2UbmY(vteD;charset=utf8";

		public static List<Produto> ListarProdutos()
		{
			List<Produto> listaProduto = new List<Produto>();
			string sql = "SELECT * FROM produto";
			using (MySqlConnection con = new MySqlConnection(conn))
			{
				con.Open();
				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					using (MySqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Produto produto = new Produto()
							{
								id_produto = reader.GetInt32(0),
								nomeProduto = reader.GetString(1) ?? " ",
								cor = reader.GetString(2) ?? " ",
								preco = reader.GetDouble(3),
								quantidade = reader.GetInt32(4)

							};
							listaProduto.Add(produto);
						}
					}
				}
				con.Close();
				return listaProduto;
			}
		}
        public static List<Produto> ListarProdutosNome(string nome)
        {
            List<Produto> listaProduto = new List<Produto>();
            string sql = "SELECT * FROM produto where nomeProduto = @nome";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
					cmd.Parameters.Add("@nome",MySqlDbType.VarChar).Value = nome;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto()
                            {
                                id_produto = reader.GetInt32(0),
                                nomeProduto = reader.GetString(1) ?? " ",
                                cor = reader.GetString(2) ?? " ",
                                preco = reader.GetDouble(3),
                                quantidade = reader.GetInt32(4)

                            };
                            listaProduto.Add(produto);
                        }
                    }
                }
                con.Close();
                return listaProduto;
            }
        }

        public static void InserirProduto(string nomeProduto, string cor, int quantidade, Double preco)
		{
			string sql = "INSERT INTO produto(nomeProduto, cor,quantidade,preco) VALUES (@nomeProduto,@cor,@quantidade,@preco)";

			using (MySqlConnection con = new MySqlConnection(conn))
			{
				con.Open();
				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@nomeProduto", MySqlDbType.VarChar).Value = nomeProduto;
					cmd.Parameters.Add("@cor", MySqlDbType.VarChar).Value = cor;
					cmd.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = quantidade;
					cmd.Parameters.Add("@preco", MySqlDbType.Double).Value = preco;
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();
				}
				con.Close();
			}
		}
	
		public static void AtualizarProduto(Produto produto)
		{
			string sql = "UPDATE produto SET nomeProduto=@nomeProduto, cor=@cor,quantidade=@quantidade,preco=@preco where id_produto = @id_produto";
			try
			{
				using (MySqlConnection con = new MySqlConnection(conn))
				{
				con.Open();
				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@nomeProduto", MySqlDbType.VarChar).Value = produto.nomeProduto;
					cmd.Parameters.Add("@cor", MySqlDbType.VarChar).Value = produto.cor;
					cmd.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = produto.quantidade;
					cmd.Parameters.Add("@preco", MySqlDbType.Double).Value = produto.preco;
					cmd.Parameters.Add("@id_produto", MySqlDbType.VarChar).Value = produto.id_produto;
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

		public static void ExcluirProduto(Produto produto)
		{
			string sql = "DELETE FROM produto WHERE id_produto=@id_produto";
			using (MySqlConnection con = new MySqlConnection(conn))
			{
				con.Open();
				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@id_produto", MySqlDbType.Int32).Value = produto.id_produto;
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();
				}
				con.Close();
			}


		}

        public static List<Produto> ListarProdutosAgrupados()
        {
            List<Produto> listaProdutoAgrupado = new List<Produto>();
            string sql = "SELECT * FROM produto GROUP BY nomeProduto";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto()
                            {
                                id_produto = reader.GetInt32(0),
                                nomeProduto = reader.GetString(1) ?? " ",
                                cor = reader.GetString(2) ?? " ",
                                preco = reader.GetDouble(3),
                                quantidade = reader.GetInt32(4)

                            };
                            listaProdutoAgrupado.Add(produto);
                        }
                    }
                }
                con.Close();
                return listaProdutoAgrupado;
            }
        }

    }

}
