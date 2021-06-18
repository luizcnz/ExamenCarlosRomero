using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using PM2EX201730110111.Modelos;

namespace PM2EX201730110111
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listado : ContentPage
    {

        private int     ItemID = 0;
        private String  ItemLatitud;
        private String  ItemLongitud;
        private String  ItemDesc;
        private String  ItemDescCorta;

        public Listado()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
            conexion.CreateTable<Localizacion>();
            var listalugares = conexion.Table<Localizacion>().ToList();
            ListaUbicaciones.ItemsSource = listalugares;
            conexion.Close();

        }

        private void ListaUbicaciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var almacenar = e.SelectedItem as Localizacion;

            ItemID = almacenar.L_ID;
            ItemLatitud = almacenar.L_Latitud;
            ItemLongitud = almacenar.L_Longitud;
            ItemDesc = almacenar.L_Descripcion;
            ItemDescCorta = almacenar.L_Desc_Corta;

            seleccionado.Text = ItemDescCorta;

            DisplayAlert("Aviso", "Has seleccionado " + ItemDescCorta + " de la lista ", "Ok");

        }

        private async void Mapa_Clicked(object sender, EventArgs e)
        {
            var Datos = new ParaelMapa
            {
                PEM_ID = ItemID,
                PEM_Latitud = ItemLatitud,
                PEM_Longitud = ItemLongitud,
                PEM_Descripcion = ItemDesc,
                PEM_Desc_Corta = ItemDescCorta
            };

            var inf = new MapPage(); inf.BindingContext = Datos; await Navigation.PushAsync(inf);
        }

        private void Borrar_Clicked(object sender, EventArgs e)
        {
            string x = Convert.ToString(ItemID);

            SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
            var borrarpersonas = conexion.Query<Localizacion>($"Delete FROM Localizacion WHERE L_ID = '" + x + "' ");
            conexion.Close();

            if (ItemID != 0)
            {
                DisplayAlert("Aviso", "" + ItemID + " ha sido eliminado de la lista de personas", "Ok");
            }
            else
            {
                DisplayAlert("Aviso", "No ha seleccionado ningun elemento para borrar!", "Ok");
            }
            
        }
    }
}