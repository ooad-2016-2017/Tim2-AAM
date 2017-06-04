using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Models.Administrator admin;
        string path;
        SQLite.Net.SQLiteConnection con;
        //SQLite.Net.SQLiteConnection conn;

        public PPocetna()
        {
            this.InitializeComponent();
            admin = new Models.Administrator();
            admin.User_name = "admin";
            admin.Lozinka = "admin";
            this.path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db2.sqlite");
            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            //conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            con.CreateTable<Models.Pacijent>();
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
            /*OVO TI JE DA VIDIS KAKO CES POKUPITI IZ BAZE*/
            //var query = conn.Table<Models.Stomatolog>();
            string us = txtBoxUsername.Text;
            string pass = pwBox.Password;
            //    foreach (var item in query)
            //    {
            //        if(item.User_name == us && item.Lozinka == pass)
            //    {
            //        Debug.WriteLine("nasao");
            //    }

            //    }
            if (us == admin.User_name && pass == admin.Lozinka)
            {
                this.Frame.Navigate(typeof(Administrator));
            }
            else
            {
                this.Frame.Navigate(typeof(PPocetna));



                var dialog = new MessageDialog("pogrešno korisničko ime/šifra!", "neuspješna prijava");

                await dialog.ShowAsync();
            }
        }
    }
    
}
