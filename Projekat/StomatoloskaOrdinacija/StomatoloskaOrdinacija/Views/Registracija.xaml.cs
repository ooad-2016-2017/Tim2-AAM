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
    public sealed partial class Pocetna : Page
    {
        string path;
        SQLite.Net.SQLiteConnection con;
        public Pocetna()
        {
            this.InitializeComponent();
            this.path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db2.sqlite");
            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            con.CreateTable<Models.Pacijent>();
        }
    

        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            Models.Pacijent p = new Models.Pacijent();
            p.Ime = txtFirstName.Text;
            p.Prezime = txtLastName.Text;
            p.Lozinka = txtLozinka.Text;
            p.Email = txtEmail.Text;
            p.User_name = txtKorisnickoIme.Text;
            //dodati za jmbg
            var adr = con.Insert(p);
            Debug.WriteLine(path);
        }

        
    }
}
