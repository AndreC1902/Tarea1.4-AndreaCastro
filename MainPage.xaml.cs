using Plugin.Media;
using Tarea1._4_AndreaCastro.Models;
using Tarea1._4_AndreaCastro.Views;

namespace Tarea1._4_AndreaCastro
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        Plugin.Media.Abstractions.MediaFile img = null;

        public byte[] imageToArrayByte()
        {
            if (img != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = img.GetStream();
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();
                    return data;
                }
            }
            return null;
        }

        private async void btnTomarFoto(object sender, EventArgs e)
        {
            try
            {
                img = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "MyImages",
                    Name = "Img.jpg",
                    SaveToAlbum = true
                });

                if (img != null)
                {
                    foto.Source = ImageSource.FromStream(() =>
                    {
                        return img.GetStream();
                    });
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void btnGuardar(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtDescripcion.Text) && 
                img != null)
            {
                var imagen = new Imagen
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Image = imageToArrayByte(),
                };

                if(await App.Instancia.GuardarImagen(imagen) > 0)
                {
                    await DisplayAlert("Aviso", "¡La imagen se ha guardado con éxito!", "OK");

                    txtNombre.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    foto.Source = null;
                }
                else
                    await DisplayAlert("Alerta", "Por favor, tome una foto y/o llene todos los campos.", "OK");
                }
            else
            {
                await DisplayAlert("Alerta", "Por favor, tome una foto y/o llene todos los campos.", "OK");
            }
        }

        private async void btnLista(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImagenListPage());
        }
    }
}