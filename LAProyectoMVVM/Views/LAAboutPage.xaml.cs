namespace LAProyectoMVVM.Views;

public partial class LAAboutPage : ContentPage
{
    public LAAboutPage()
    {
       InitializeComponent();
    }

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.LAAbout about)
        {
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
            
    }
}