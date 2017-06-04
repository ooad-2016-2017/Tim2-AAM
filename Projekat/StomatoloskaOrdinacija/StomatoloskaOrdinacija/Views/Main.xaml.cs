using StomatoloskaOrdinacija.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class Main : Page
    {
        public Library Library = new Library();
        public int indexPosition = 1;

        public Main()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            Geopoint myPoint = await Library.Position();
            myMap.ZoomLevel = 16;
            myMap.Center = myPoint;
            addIconToLocation(myPoint, "Position: " + indexPosition);
            indexPosition++;
        }
        private void addIconToLocation(Geopoint location, string name)
        {
            MapIcon mapIcon = new MapIcon();
            mapIcon.Location = location;
            mapIcon.Title = String.Format("{0}\nLatLng:{1}\nLongLng:{2}", name, location.Position.Latitude, location.Position.Longitude);
            mapIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx://Assets/pushpin.png"));
            mapIcon.ZIndex = 0;
            myMap.MapElements.Add(mapIcon);


        }
        private async void ShowRouteOnMap(Geopoint startPoint, Geopoint endPoint)
        {
            MapRouteFinderResult routeResult = await MapRouteFinder.GetDrivingRouteAsync(startPoint, endPoint, MapRouteOptimization.Time, MapRouteRestrictions.None);

            if(routeResult.Status == MapRouteFinderStatus.Success)
            {
                myMap.Routes.Clear();
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.Yellow;
                viewOfRoute.OutlineColor = Colors.Black;
                myMap.Routes.Add(viewOfRoute);
                await myMap.TrySetViewBoundsAsync(routeResult.Route.BoundingBox, null, MapAnimationKind.None);
            }
            else
            {
                var message = new MessageDialog("Ruta nije pronadjena");
                await message.ShowAsync();
            }
        }
        
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            /*Geopoint position = await Library.Position();
            //DependencyObject marker = Library.Marker();
            //myMap.Children.Add(marker);
            //MapControl.SetLocation(marker, position);
            //MapControl.SetNormalizedAnchorPoint(marker, new Point(0.5, 0.5));
            myMap.ZoomLevel = 12;
            myMap.Center = position;*/

        }

        private async void myMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            addIconToLocation(args.Location, "Position: " + indexPosition);
            indexPosition++;
            Geopoint startPoint = await Library.Position();
            ShowRouteOnMap(startPoint, args.Location);
        }
    }
}
