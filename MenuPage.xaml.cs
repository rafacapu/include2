using System;
using Xamarin.Forms;
using App_Secao07.Views;
using App_Secao07.Pages;
using App_Secao07.ViewModels;

namespace App_Secao07.Views
{
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private void GoPaginaXamarin( object sender, EventArgs args)
        {
            Navigation.PushAsync(new XamarinPage());
        }
        private void GoPaginaPerfil(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Perfil());
        }
    }
}
