using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTCC.Controller;

namespace AppTCC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCadastroCliente : ContentPage
	{
		public PageCadastroCliente()
		{
			InitializeComponent();
		}

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Conexao.InserirCliente(txtNome.Text, txtCnpj.Text,txtInscricao.Text,txtEmail.Text,txtendereco.Text,txtNumero.Text,txtTelefone.Text,txtCidade.Text,txtEstado.Text);
			DisplayAlert("Cadastro", "Cliente cadastrado com sucesso!!", "OK");
			Navigation.PushAsync(new PageCliente());
        }
    }
}