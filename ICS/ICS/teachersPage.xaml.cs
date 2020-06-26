using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICS
{

    [DesignTimeVisible(false)]
    public partial class teachersPage : ContentPage
    {
        public teachersPage()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void send_mail(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("mailto:mrmagpie4@gmail.com"));
        }
        private void send_mail_suprun(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("mailto:slav.pgt@gmail.com"));
        }


    }
}
