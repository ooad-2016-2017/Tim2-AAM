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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StomatoloskaOrdinacija
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Administrator : Page
    {

        string path;
        SQLite.Net.SQLiteConnection conn;
        public Administrator()
        {
            this.InitializeComponent();
            this.path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db2.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Models.Stomatolog>();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Models.Stomatolog s = new Models.Stomatolog();
            s.Ime = textBox6.Text;
            s.Prezime = textBox8.Text;
            s.User_name = textBox4.Text;
            s.Lozinka = textBox3.Text;
            s.Adresa = textBox7.Text;
            s.Email = textBox5.Text;
            var add = conn.Insert(s);
            Debug.WriteLine(path);
        }
    }
}
