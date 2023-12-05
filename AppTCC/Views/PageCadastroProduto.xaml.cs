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
	public partial class PageCadastroProduto : ContentPage
	{
		public PageCadastroProduto()
		{
			InitializeComponent();
		}

		private void btnCadastrarProduto_Clicked(object sender, EventArgs e)
		{
			ProdutoCon.InserirProduto(txtproduto.Text,txtcor.Text,Convert.ToInt16(txtquantidade.Text),Convert.ToDouble(txtpreco.Text));
			DisplayAlert("Cadastro", "Produto cadastrado com sucesso!!", "OK");
			Navigation.PushAsync(new PageProduto());
		}
	}
}