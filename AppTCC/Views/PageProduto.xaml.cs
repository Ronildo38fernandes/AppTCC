using AppTCC.Controller;
using AppTCC.Models;
using AppTCC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageProduto : ContentPage
    {
		List<Produto> produtos = ProdutoCon.ListarProdutos();
        public PageProduto()
        {
            InitializeComponent();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			ProdutoListView.ItemsSource = ProdutoCon.ListarProdutos();
		}

		private void ProdutoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				NavegaProduto(e.SelectedItem as Produto);
			}

		}

		private void Produtos_TextChanged(object sender, TextChangedEventArgs e)
		{
			var texto = Produtos.Text;

			ProdutoListView.ItemsSource = produtos.Select(produto => produto).ToList().Where(x => x.nomeProduto.ToLower().Contains(texto.ToLower()));
		}

		private void ToolbarItem_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new PageCadastroProduto());
		}

		void NavegaProduto(Produto produto)
		{
			PageUpProduo upDel = new PageUpProduo();

			upDel.produto = produto;
			Navigation.PushAsync(upDel);
		}
	}
}