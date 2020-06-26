using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ICS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            
            
            
           
        }       

        protected override void OnAppearing()
        {
            object login = "";
            if (!App.Current.Properties.TryGetValue("phone", out login))
            {
                Navigation.PushModalAsync(new modalAuth());
                
            }            
        }

    }
}
