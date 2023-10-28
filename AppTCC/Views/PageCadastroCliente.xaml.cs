using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTCC.Controller;
using AppTCC.Models;

namespace AppTCC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCadastroCliente : ContentPage
	{
		public List<string> estados = new List<string>() 
		{ 
			"AC", "AL", "AP", "AM", "BA",
			"CE","DF", "ES", "GO", "MA", "MT",
			"MS", "MG", "PA", "PB", "PR",
			"PE", "PI", "RJ", "RN", "RS" ,
			"RO","RR","SC","SP","SE","TO"
		};
		public string estadoSelecionado = "PR";
		public string cidadeSelecionada = "";
		
		
		public PageCadastroCliente()
		{
			InitializeComponent();
			estadosPiker.ItemsSource = estados;	

		}


        private void estadosPiker_SelectedIndexChanged(object sender, EventArgs e)
        {
			var piker = (Picker)sender;
			estadoSelecionado = (string)piker.SelectedItem;
            List<Municipios> municipios = Municipios.BuscarMunicipios(estadoSelecionado);
            cidadesPiker.ItemsSource = municipios.Select(cidade => cidade.Nome).ToList();
        }
        
        private void cidadesPiker_SelectedIndexChanged(object sender, EventArgs e)
        {
			var piker = (Picker)sender;
			cidadeSelecionada = (string)piker.SelectedItem;
        }
		private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
			
            Conexao.InserirCliente(txtNome.Text ??"", txtCnpj.Text ?? "", txtInscricao.Text ?? "", txtEmail.Text ?? "", txtendereco.Text ?? "", txtNumero.Text ?? "", txtTelefone.Text ?? "", cidadeSelecionada, estadoSelecionado);
			DisplayAlert("Cadastro", "Cliente cadastrado com sucesso!!", "OK");
			Navigation.PushAsync(new PageCliente());
			
        }

    }
}