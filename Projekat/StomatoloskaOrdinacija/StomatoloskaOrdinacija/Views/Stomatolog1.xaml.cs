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
using StomatoloskaOrdinacija.Models;
using Microsoft.WindowsAzure.MobileServices;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StomatoloskaOrdinacija
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Stomatolog1 : Page
    {

        Models.Stomatolog ja;
        
        
        string path;
        SQLite.Net.SQLiteConnection con;
        IMobileServiceTable<Karton> userTableObj1 = App.MobileService.GetTable<Karton>();
        IMobileServiceTable<Termin> userTableObj2 = App.MobileService.GetTable<Termin>();
        public Stomatolog1()
        {
            this.InitializeComponent();


            //Debug.WriteLine("Tamo je gdje treba1");
            this.path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db2.sqlite");
            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            con.CreateTable<Karton>();
            //Debug.WriteLine("Tamo je gdje treba2");
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Debug.WriteLine("Tamo je gdje treba");
            base.OnNavigatedTo(e);
            ja = (Models.Stomatolog)e.Parameter;
            popuniPrvuStranu();

        }

        private void popuniPrvuStranu()
        {
            int k = 0;
            for(int i = 0; i < SviTermini.Svi.Count; i++)
            {
                if (k >=3) break;
                if(SviTermini.Svi[i].idStomatologa == ja.Id)
                {
                    var query = con.Table<Pacijent1>();
                    foreach (var pacijent in query)
                    {
                        if (pacijent.Id == SviTermini.Svi[i].idPacijenta)
                        {
                            if(k == 0)
                            {
                                txtDatum1.Text = SviTermini.Svi[i].datumToString();
                                txtVrijeme1.Text = SviTermini.Svi[i].vrijemeToString();
                                txtIme1.Text = pacijent.Ime + " " + pacijent.Prezime;

                                txtDatum4.Text = SviTermini.Svi[i].datumToString();
                                txtVrijeme4.Text = SviTermini.Svi[i].vrijemeToString();
                                txtIme4.Text = pacijent.Ime + " " + pacijent.Prezime;
                            }
                            else if(k == 1)
                            {
                                txtDatum2.Text = SviTermini.Svi[i].datumToString();
                                txtVrijeme2.Text = SviTermini.Svi[i].vrijemeToString();
                                txtIme2.Text = pacijent.Ime + " " + pacijent.Prezime;

                                txtDatum5.Text = SviTermini.Svi[i].datumToString();
                                txtVrijeme5.Text = SviTermini.Svi[i].vrijemeToString();
                                txtIme5.Text = pacijent.Ime + " " + pacijent.Prezime;
                            }
                            else if(k == 2)
                            {
                                txtDatum3.Text = SviTermini.Svi[i].datumToString();
                                txtVrijeme3.Text = SviTermini.Svi[i].vrijemeToString();
                                txtIme3.Text = pacijent.Ime + " " + pacijent.Prezime;

                                txtDatum6.Text = SviTermini.Svi[i].datumToString();
                                txtVrijeme6.Text = SviTermini.Svi[i].vrijemeToString();
                                txtIme6.Text = pacijent.Ime + " " + pacijent.Prezime;
                            }
                            k++;
                        }

                    }
                }
            }
            
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PPocetna));
            var dialog = new MessageDialog("Odjava!", "Uspjesno ste se odjavili sa sistema.");
            await dialog.ShowAsync();
        }

        private async void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PPocetna));
            var dialog = new MessageDialog("Odjava!", "Uspjesno ste se odjavili sa sistema.");
            await dialog.ShowAsync();
        }

        private async void button15_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PPocetna));
            var dialog = new MessageDialog("Odjava!", "Uspjesno ste se odjavili sa sistema.");
            await dialog.ShowAsync();

        }

        private async void button3_Click(object sender, RoutedEventArgs e)
        {
            //ovo mi je dodavanje onih termina kao kartona bez icega itd. 
            var date = pickerDatum.Date;
            DateTime time = date.Value.DateTime;
            var timep = vrijemePicker.Time;
            time.AddHours(timep.Hours);
            time.AddMinutes(timep.Minutes);
            time.AddSeconds(timep.Seconds);
            Karton tt = new Karton();
            tt.Datum = time;
            Debug.WriteLine(ja.Id);
            tt.idStomatologa = ja.Id;
            tt.idPacijenta = -1;
            tt.Zauzet = false;
            tt.Novosti = "nista";
            Termin tp = new Termin();
            tt.Datum = time;
            tt.idStomatologa = ja.Id;
            tt.idPacijenta = -1;
            tt.Zauzet = false;
            tt.Novosti = "nista";
            userTableObj1.InsertAsync(tt);

            SviTermini.Svi.Add(tp);
            var adr = con.Insert(tt);
            var dialog2 = new MessageDialog("Uspjesno dodavanje!", "Uspjesno ste dodali termin.");
            await dialog2.ShowAsync();








        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            con.CreateTable<Termin>();

            string ime_i_prezime = txtIme.Text;
            string nov = txtAzuriranje.Text;
            var date = datumterminaCalendarDatePicker.Date;
            DateTime time = date.Value.DateTime;
            Termin tt = new Termin();
            
            tt.Datum = time;
            tt.Novosti = nov;
            tt.idStomatologa = ja.Id;
            Pacijent1 pac = new Pacijent1();
            var query = con.Table<Pacijent1>();
            foreach (var pacijent in query)
            {
                if(pacijent.Ime+" " +pacijent.Prezime == ime_i_prezime)
                {
                    tt.idPacijenta = pacijent.Id;
                    pac = pacijent;
                    break;
                }
            
            }
            tt.Zauzet = true;

            userTableObj2.InsertAsync(tt);
            var adr = con.Insert(tt);
            var dialog2 = new MessageDialog("Azuriranje", "Uspjesno ste azurirali karton pacijenta.");
            await dialog2.ShowAsync();
            listBox.Items.Clear();
            var queryS = con.Table<Termin>();
            foreach (var termin in queryS)
            {
                if (termin.idPacijenta == pac.Id)
                {
                    listBox.Items.Add(termin.toStringMoja() + ": " + termin.Novosti);
                }
            }
            txtAzuriranje.Text = String.Empty;
            txtIme.Text = String.Empty;
            


        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            string ime_i_prezime = txtIme.Text;
            bool nasao = false;
            var query = con.Table<Pacijent1>();
            var queryS = con.Table<Termin>();
            foreach (var pacijent in query)
            {
                if (pacijent.Ime + " " + pacijent.Prezime == ime_i_prezime)
                {
                    button.IsEnabled = true;
                    txtAzuriranje.IsEnabled = true;
                    datumterminaCalendarDatePicker.IsEnabled = true;
                    datumterminNaredniCalendarDatePicker.IsEnabled = true;
                    listBox.Items.Clear();
                    foreach(var termin in queryS)
                    {
                        if(termin.idPacijenta == pacijent.Id )
                        {
                            listBox.Items.Add(termin.toStringMoja()+ ": " + termin.Novosti);
                        }
                    }
                    nasao = true;
                    break;
                }

            }
            if(nasao == false)
            {
                var dialog2 = new MessageDialog("Pokusajte ponovo!", "Ne postoji pacijent sa tim imenom i prezimenom.");
                await dialog2.ShowAsync();
            }
            
        }
    }
}
