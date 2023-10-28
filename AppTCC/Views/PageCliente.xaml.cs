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
    public partial class PageCliente : ContentPage
    {
        List<Cliente> clientes = Conexao.ListarClientes();

			
		public PageCliente()
        {
            InitializeComponent();
			
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ClientesListView.ItemsSource = Conexao.ListarClientes(); ;
        }

        private void Clientes_TextChanged(object sender, TextChangedEventArgs e)
		{
			var texto = Clientes.Text;

			ClientesListView.ItemsSource = clientes.Select(cliente => cliente).ToList().Where(x => x.nome.ToLower().Contains(texto.ToLower()));

		}
		private void ToolbarItem_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new PageCadastroCliente());
		}

        private void ClientesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                NavegaCliente(e.SelectedItem as Cliente);
            }

        }


        void NavegaCliente(Cliente cliente)
        {
            PageUpCliente upDel = new PageUpCliente();
            upDel.cliente = cliente;
            Navigation.PushAsync(upDel);
            
        }
    }
}