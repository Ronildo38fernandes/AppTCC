using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AppTCC.Models;
using AppTCC.Controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastroPedido : ContentPage
    {
        private ObservableCollection<Produto> productsInCart = new ObservableCollection<Produto>();
        private List<Produto> produtosFromDatabase;
        private List<Produto> coresdosprodutos;
        private List<ItemPedido> listaItem = new List<ItemPedido>();
        private List<Cliente> clientes = Conexao.ListarClientes();
        private Cliente clienteSelecionado;

        public PageCadastroPedido()
        {
            InitializeComponent();

            produtosFromDatabase = ProdutoCon.ListarProdutosAgrupados();

            foreach (var produto in produtosFromDatabase)
            {
                productPicker.Items.Add(produto.nomeProduto);
            }

            foreach (var cliente in clientes)
            {
                clientePicker.Items.Add(cliente.nome);
            }

            cartListView.ItemsSource = productsInCart;
        }

        private void AddToCart_Clicked(object sender, EventArgs e)
        {
            if (productPicker.SelectedIndex >= 0 && clienteSelecionado != null && colorProdutoPicker.SelectedIndex >= 0)
            {
                var selectedProduct = produtosFromDatabase[productPicker.SelectedIndex];
                var preco_original = selectedProduct.preco;

                selectedProduct.quantidade = Convert.ToInt32(txtQuantidade.Text);
                selectedProduct.preco = selectedProduct.preco * selectedProduct.quantidade;

                // Associar o cliente selecionado ao pedido
               // selectedProduct.ClienteAssociado = clienteSelecionado;

                // Associar a cor selecionada ao pedido
                selectedProduct.cor = coresdosprodutos[colorProdutoPicker.SelectedIndex].cor;

                productsInCart.Add(selectedProduct);

                ItemPedido itemPedido = new ItemPedido();
                itemPedido.id_produto = selectedProduct.id_produto;
                itemPedido.quantidade = selectedProduct.quantidade;
                itemPedido.totalItem = selectedProduct.preco;

                itemPedido.id_item = ItemPedidoCon.InserirItempedido(itemPedido.id_produto, itemPedido.quantidade, itemPedido.totalItem);
               
                
                
                listaItem.Add(itemPedido);
                //resetando o preco
                selectedProduct.preco = preco_original;

               
            }
        }

        private void clientePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientePicker.SelectedIndex >= 0)
            {
                clienteSelecionado = clientes[clientePicker.SelectedIndex];
            }
        }

        private void productPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorProdutoPicker.Items.Clear();
            var piker = (Picker)sender;

            coresdosprodutos = ProdutoCon.ListarProdutosNome((string)piker.SelectedItem);

            foreach (var cores in coresdosprodutos)
            {
                colorProdutoPicker.Items.Add(cores.cor);
            }
        }

        private void colorProdutoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorProdutoPicker.SelectedIndex >= 0)
            {
                string corSelecionada = coresdosprodutos[colorProdutoPicker.SelectedIndex].cor;

            }
        }

        private void btnCadastrarPedido_Clicked(object sender, EventArgs e)
        {
            

        }
    }
}
