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
            con.CreateTable<Models.Pacijent1>();

            var queryS = con.Table<Models.Karton>();
           
                foreach (var karton in queryS)
                {
                Models.Termin tt = new Models.Termin();
                tt.Datum = karton.Datum;
                tt.idPacijenta = karton.idPacijenta;
                tt.idStomatologa = karton.idStomatologa;
                tt.Novosti = karton.Novosti;
                tt.Zauzet = karton.Zauzet;
                Models.SviTermini.Svi.Add(tt);
                }
            


        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {         
            string us = txtBoxUsername.Text;
            string pass = pwBox.Password;
            bool pronasao = false;
            if (us == admin.User_name && pass == admin.Lozinka)
            {
                this.Frame.Navigate(typeof(Administrator));
                pronasao = true;
            }
           
            var query = con.Table<Models.Pacijent1>();
            if (pronasao == false)
            {
                foreach (var pacijent in query)
                {
                    if (pacijent.User_name == us && pacijent.Lozinka == pass)
                    {
                        //Debug.WriteLine(pacijent.Id);
                        this.Frame.Navigate(typeof(Pacijent), pacijent);
                        pronasao = true;
                    }
                }
            }
            var queryS = con.Table<Models.Stomatolog>();
            if (pronasao == false)
            {
                foreach (var stomatolog in queryS)
                {
                    if (stomatolog.User_name == us && stomatolog.Lozinka == pass)
                    {
                        this.Frame.Navigate(typeof(Stomatolog1), stomatolog);
                        

                        pronasao = true;
                    }
                }
            }
            if (pronasao == false)
            {
                txtBoxUsername.Text = String.Empty;
                 pwBox.Password = String.Empty;
                var dialog = new MessageDialog("Neuspjesana prijava!", "Pogresno ste unijeli username/sifru.");
                await dialog.ShowAsync();
                
                
            }
            Debug.WriteLine(path);
        }

        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pocetna));
        }

        private void txtBoxUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    
}
