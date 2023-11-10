using System.Collections.Generic;
using Tarea1._4_AndreaCastro.Models;

namespace Tarea1._4_AndreaCastro.Views;

public partial class ImagenListPage : ContentPage
{
    private Imagen s_image;
    public static byte[] Imag; 

    public ImagenListPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        ListaImagen.ItemsSource = await App.Instancia.ObtenerlistaImagen();
    }

    private void Imagen_OnItemTapped(Object sender, SelectionChangedEventArgs e)
    {
        s_image = e.CurrentSelection.FirstOrDefault() as Imagen;
        Imag = s_image.Image;
    }

    private async void btnver(object sender, EventArgs e)
    {
        if (s_image != null)
        {
            await Navigation.PushAsync(new PageImagenDetail());
            s_image = null;
        }
        else
        {
            await DisplayAlert("Alerta", "Por favor, Seleccione una imagen", "Ok");
        }
    }
}