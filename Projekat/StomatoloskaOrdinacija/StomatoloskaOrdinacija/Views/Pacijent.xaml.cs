using Microsoft.WindowsAzure.MobileServices;
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
using System.Diagnostics;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StomatoloskaOrdinacija
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    

    public sealed partial class Pacijent : Page
    {
        Models.Pacijent1 ja;
        string path;
        SQLite.Net.SQLiteConnection con;
        IMobileServiceTable<Termin> userTableObj1 = App.MobileService.GetTable<Termin>();
        public Pacijent()
        {
            this.InitializeComponent();
            Debug.WriteLine("Tamo je gdje treba1");
            this.path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db2.sqlite");
            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            con.CreateTable<Termin>();
            listBox.Items.Clear();
            foreach(var x in SviTermini.Svi){
                if (x.Zauzet == false)
                {
                    listBox.Items.Add(x.toStringMoja());
                }
            }


            //Popunjavanje liste sa terminima
            //Debug.WriteLine("Pri kraju");
           // popuniListu();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Debug.WriteLine("Tamo je gdje treba2");
            base.OnNavigatedTo(e);
            ja = (Models.Pacijent1)e.Parameter;
            popuniListu();
        }

       
        private void popuniListu()
        {
            
            var queryS = con.Table<Termin>();
            
                foreach (var termin in queryS)
                {
                    if(termin.idPacijenta == ja.Id)
                    {
                    listBox1.Items.Add(termin.toStringMoja());
                    }
                }
        }
        private async void button16_Click(object sender, RoutedEventArgs e)
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

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            var item_pok = listBox.SelectedItem;
            
            for(int ii = 0; ii < SviTermini.Svi.Count; ii++)
            {
                //Debug.WriteLine("Prvi termin: "+SviTermini.Svi[ii].toStringMoja()+" drugi termin: "+ item_pok.ToString());
                if(SviTermini.Svi[ii].toStringMoja() == item_pok.ToString())
                {
                    //Debug.WriteLine("Prvi termin: " + SviTermini.Svi[ii].toStringMoja() + " drugi termin: " + item_pok.ToString());
                    SviTermini.Svi[ii].idPacijenta = ja.Id;
                    SviTermini.Svi[ii].Zauzet = true;
                    listBox.Items.Clear();
                    foreach (var x in SviTermini.Svi)
                    {
                        
                        if (x.Zauzet == false)
                        {
                  
                            listBox.Items.Add(x.toStringMoja());
                        }
                    }
                    var dialog = new MessageDialog("Uspjesan odabir!", "Uspjesno ste odabrali termin.");
                    await dialog.ShowAsync();
                    break;
                }
                
            }
            
                
            //}
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            var queryS = con.Table<Models.Termin>();
            foreach (var termin in queryS)
            {
                if (termin.toStringMoja() == curItem)
                {
                    textBox.Text = termin.Novosti;
                    break;
                }
            }
        }
    }
    
}
