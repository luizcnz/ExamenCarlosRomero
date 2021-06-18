using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using PM2EX201730110111.Modelos;
using Plugin.Geolocator;

namespace PM2EX201730110111
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public int llave =0;
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var estado = CrossGeolocator.Current;
            if (!estado.IsGeolocationEnabled)
            {
                DisplayAlert("Aviso", "El gps esta desactivado, Activelo e intentelo de nuevo!", "Ok");
            }
            else
            {
                Double Lat = Convert.ToDouble(M_Lat.Text);
                Double Lon = Convert.ToDouble(M_Lon.Text);


                Pin ubicacion = new Pin();
                {
                    ubicacion.Label = M_Desc_C.Text;
                    ubicacion.Address = M_Desc.Text;
                    ubicacion.Position = new Position(Lat, Lon);
                }

                mapa.Pins.Add(ubicacion);

                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Lat, Lon), Distance.FromKilometers(1)));
            }
            

            

        }


    }
}