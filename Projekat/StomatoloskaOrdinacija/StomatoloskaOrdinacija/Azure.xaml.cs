using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StomatoloskaOrdinacija.Models;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StomatoloskaOrdinacija
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Azure : Page
    {
        IMobileServiceTable<Pacijent1> userTableObj= App.MobileService.GetTable<Pacijent1>();
        public Azure()
        {
            this.InitializeComponent();
        }

        private void btnSpasi_Click(object sender, RoutedEventArgs e)
        {
            try { 
                Pacijent1 p = new Pacijent1();
                p.Ime = txtIme.Text;
                p.Prezime = txtPrezime.Text;
                p.User_name = txtUser.Text;
                userTableObj.InsertAsync(p);
                MessageDialog msgDialog = new MessageDialog("Uspješno ste unijeli novog pacijenta.");

                msgDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                 msgDialogError.ShowAsync();
            }
}
    }
}
