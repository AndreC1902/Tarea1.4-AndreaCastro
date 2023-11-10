namespace Tarea1._4_AndreaCastro.Views;

public partial class PageImagenDetail : ContentPage
{
    public PageImagenDetail()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ScreenImg.Source = ImageSource.FromStream(() => new MemoryStream(ImagenListPage.Imag));
    }
}