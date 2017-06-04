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
using StomatoloskaOrdinacija.Models;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StomatoloskaOrdinacija
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pocetna : Page
    {
        string path;
        SQLite.Net.SQLiteConnection con;
        IMobileServiceTable<Pacijent1> userTableObj = App.MobileService.GetTable<Pacijent1>();
        public Pocetna()
        {
            this.InitializeComponent();
            this.path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db2.sqlite");
            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            con.CreateTable<Pacijent1>();
            
        }
    

        private async void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            Pacijent1 p = new Pacijent1();
            p.Ime = txtFirstName.Text;
            p.Prezime = txtLastName.Text;
            p.User_name = txtKorisnickoIme.Text;
            userTableObj.InsertAsync(p);
            p.Lozinka = txtLozinka.Text;
            p.Email = txtEmail.Text;
            
            p.JMBG1 = txtJmbg.Text;
            
            var adr = con.Insert(p);
           

            var dialog = new MessageDialog("Uspjesna registracija!", "Uspjesno ste se registrovali, sada se logujte.");
            this.Frame.Navigate(typeof(PPocetna));
            await dialog.ShowAsync();
            
            Debug.WriteLine(path);
        }

        
    }
}
