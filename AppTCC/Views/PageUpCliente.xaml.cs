using AppTCC.Models;
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
    public partial class PageUpCliente : ContentPage
    {
        public Cliente cliente;
        public PageUpCliente()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = this.cliente;

        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)

        {
         
            Conexao.AtualizarCliente(cliente);
            Navigation.PopAsync();
        }

        private void btnDeletar_Clicked(object sender, EventArgs e)
        {
            if (cliente.id_cliente != 0)
            {
                Conexao.ExcluirCliente(cliente);
                Navigation.PopAsync();
            }
        }
    }
}