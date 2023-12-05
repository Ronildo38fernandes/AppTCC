using AppTCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTCC.Controller;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageUpProduo : ContentPage
	{
		public Produto produto;
		public PageUpProduo()
		{
			InitializeComponent();
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			BindingContext = this.produto;

		}

		private void btnAtualizar_Clicked(object sender, EventArgs e)
		{

			ProdutoCon.AtualizarProduto(produto);
			Navigation.PopAsync();

		}

		private void btnDeletar_Clicked(object sender, EventArgs e)
		{
			if (produto.id_produto != 0) 
			{
				ProdutoCon.ExcluirProduto(produto);
				Navigation.PopAsync();
			}
		}
	}
}