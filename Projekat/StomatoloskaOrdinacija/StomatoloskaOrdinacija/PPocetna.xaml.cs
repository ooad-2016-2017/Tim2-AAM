using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StomatoloskaOrdinacija
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PPocetna : Page
    {
        public PPocetna()
        {
            this.InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            var korisnickoIme = txtBoxUsername.Text;
            var sifra = pwBox.Password;
            //var korisnik = datasourcemenumd.provjerakorisnika(korisnickoime, sifra);
            //if (korisnik != null && korisnik.korisnikid > 0)
            //{
            //    this.frame.navigate(typeof(mainpage), korisnik);
            //}
            //else
            //{
            //    var dialog = new messagedialog("pogrešno korisničko ime/šifra!", "neuspješna prijava");

            //    await dialog.showasync();
            //}
            this.Frame.Navigate(typeof(Pocetna));

            var dialog = new MessageDialog("pogrešno korisničko ime/šifra!", "neuspješna prijava");

            await dialog.ShowAsync();
        }
    }
    
}
