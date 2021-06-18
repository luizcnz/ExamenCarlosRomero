using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using PM2EX201730110111.Modelos;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;
using Plugin.Geolocator;
using System.Diagnostics;

namespace PM2EX201730110111
{
    public partial class MainPage : ContentPage
    {
        

        
        public MainPage()
        {
            InitializeComponent();

            
        }


        protected async override void OnAppearing()
        {
            var estado = CrossGeolocator.Current;


            if (estado.IsGeolocationEnabled)
            {
                DisplayAlert("Aviso", "El gps esta activado", "Ok");
            }
            else
            {
                DisplayAlert("Aviso", "El gps esta desactivado! Por Favor activelo y reinicie la app", "Ok");
                
            }

        }

    

        private async void x_nueva_u_Clicked(object sender, EventArgs e)
        {
            
            var estado = CrossGeolocator.Current;


            if (estado.IsGeolocationEnabled)
            {
                x_descripcion.Text = null;
                x_desc_corta.Text = null;

                var ubicacion = await Geolocation.GetLocationAsync();

                x_latitud.Text = Convert.ToString(ubicacion.Latitude);
                x_longitud.Text = Convert.ToString(ubicacion.Longitude);
            }
            else
            {
                DisplayAlert("Aviso", "El gps esta desactivado, Activalo y reinicia la app para usar esta Funcion", "Ok");
            }

        }

        private async void x_ver_u_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listado());
        }

        private void btn_salvar_Clicked(object sender, EventArgs e)
        {
            String Main_Latitud =       x_latitud.Text;
            String Main_Longitud =      x_longitud.Text;
            String Main_Descripcion =   x_descripcion.Text;
            String Main_Desc_C =        x_desc_corta.Text;

            
            if (Main_Latitud == null)
            {
                DisplayAlert("Aviso", "La Latitud no puede estar vacia!", "Ok");
            }
            else if (Main_Longitud == null)
            {
                DisplayAlert("Aviso", "La Longitud no puede estar vacia!", "Ok");
            }
            else if (Main_Descripcion == null)
            {
                DisplayAlert("Aviso", "Debes describir la ubicacion!", "Ok");
            }
            else if (Main_Desc_C == null)
            {
                DisplayAlert("Aviso", "Debes añadir una descripcion corta a la ubicacion!", "Ok");
            }
            else
            {
                Int32 resultado = 0;

                var lugar = new Localizacion
                {
                    L_Latitud = Main_Latitud,
                    L_Longitud = Main_Longitud,
                    L_Descripcion = Main_Descripcion,
                    L_Desc_Corta = Main_Desc_C
                };

                using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
                {
                    conexion.CreateTable<Localizacion>();
                    resultado = conexion.Insert(lugar);

                    if (resultado > 0)
                        DisplayAlert("Aviso", "Adicionado", "Ok");
                    else
                        DisplayAlert("Aviso", "Error", "Ok");
                }
            }

            

        }

        private async void btn_lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listado());
        }

        private void Prueba_Clicked(object sender, EventArgs e)
        {
            Int32 res_prueba = 0;
            var x1 = new Localizacion
            {
                L_Latitud = "14.068440034858604",
                L_Longitud = "-87.20938102362277",
                L_Descripcion = "Col El Pedregal",
                L_Desc_Corta = "Era mi casa XD"
            };

            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                conexion.CreateTable<Localizacion>();
                res_prueba = conexion.Insert(x1);
            }

            res_prueba = 0;
            var x2 = new Localizacion
            {
                L_Latitud = "13.167521349085408",
                L_Longitud = "-87.43221333796608",
                L_Descripcion = "Playa Sur de Cedenio",
                L_Desc_Corta = "Cedenio"
            };

            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                conexion.CreateTable<Localizacion>();
                res_prueba = conexion.Insert(x2);
            }

            res_prueba = 0;
            var x3 = new Localizacion
            {
                L_Latitud = "13.309181843115535",
                L_Longitud = "-87.18962923191897",
                L_Descripcion = "Universidad Tecnologica de Honduras",
                L_Desc_Corta = "UTH"
            };

            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                conexion.CreateTable<Localizacion>();
                res_prueba = conexion.Insert(x3);
            }

            res_prueba = 0;
            var x4 = new Localizacion
            {
                L_Latitud = "13.29028568033213",
                L_Longitud = "-87.30128080144594",
                L_Descripcion = "Col Marcovia, Choluteca",
                L_Desc_Corta = "Donde vive mi tio"
            };

            using (SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB))
            {
                conexion.CreateTable<Localizacion>();
                res_prueba = conexion.Insert(x4);
            }

            DisplayAlert("Aviso", "Se han adicionado las ubicaciones de prueba", "Ok");
        }
    }
}
