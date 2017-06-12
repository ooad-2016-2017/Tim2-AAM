using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class Administrator : Page
    {

        string path;
        SQLite.Net.SQLiteConnection con;
        IMobileServiceTable<Stomatolog> userTableObj1 = App.MobileService.GetTable<Stomatolog>();
        public Administrator()
        {
            this.InitializeComponent();
            this.path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db2.sqlite");
            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            con.CreateTable<Stomatolog>();
        }


        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            Stomatolog s = new Stomatolog();
            s.Ime = textBox6.Text;
            s.Prezime = textBox8.Text;
            s.User_name = textBox4.Text;
            userTableObj1.InsertAsync(s);
            s.Lozinka = textBox3.Text;
            s.Adresa = textBox7.Text;
            s.Email = textBox5.Text;
            var adr = con.Insert(s);
            var dialog = new MessageDialog("Stomatolog uspjesno dodan!", "Uspjesno ste dodali stomatologa.");
            await dialog.ShowAsync();
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            // Brisanje stomatologa
            Stomatolog s = new Stomatolog();
            s.Ime = textBox.Text;
            s.Prezime = textBox1.Text;
            s.User_name = textBox2.Text;

            bool pronasao = false;
            var queryS = con.Table<Models.Stomatolog>();
            if (pronasao == false)
            {
                foreach (var stomatolog in queryS)
                {
                    if (stomatolog.User_name == s.User_name)
                    {

                        var dialog = new MessageDialog("Uspjesno obrisan!", "Uspjesno ste obrisali stomatologa.");
                        await dialog.ShowAsync();

                        pronasao = true;
                    }
                }
            }
            if (pronasao == false)
            {               
                var dialog = new MessageDialog("Greska!", "Stomatolog nije pronadjen.");
                await dialog.ShowAsync();            

            }
            textBox.Text = String.Empty;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }

        private async void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PPocetna));
            var dialog = new MessageDialog("Odjava!", "Uspjesno ste se odjavili sa sistema.");
            await dialog.ShowAsync();
        }
    }
}
