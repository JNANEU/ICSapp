using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class personalArea : ContentPage
    {
        public personalArea()
        {
            InitializeComponent();
            exitButton.Clicked += ExitButton_Clicked;
            
        }

        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties.Remove("phone");
            App.Current.Properties.Remove("name");
            App.Current.Properties.Remove("password");
            Navigation.PushModalAsync(new modalAuth(), false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            object phone = "";
            App.Current.Properties.TryGetValue("phone", out phone);
            Phone.Text = phone.ToString();
            App.Current.Properties.TryGetValue("name", out phone);
            Name.Text = phone.ToString();
        }
    }
}