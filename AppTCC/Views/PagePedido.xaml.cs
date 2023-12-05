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
    public partial class PagePedido : ContentPage
    {
        public PagePedido()
        {
            InitializeComponent();
        }

		private void ToolbarItem_Clicked(object sender, EventArgs e)
		{
            Navigation.PushAsync(new PageCadastroPedido());
		}
	}


}



