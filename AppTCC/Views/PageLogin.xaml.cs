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
    public partial class PageLogin : ContentPage
    {
        public PageLogin()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btLogin_Clicked(object sender, EventArgs e)
        {
            if (txtLogin.Text == "teste" && txtSenha.Text == "teste"|| txtLogin.Text=="ronildo" && txtSenha.Text=="123")
            {
                Navigation.PushAsync(new MainPage());
            }
        }
    }
}