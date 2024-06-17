namespace LAProyectoMVVM.Views;

public partial class LAAllNotesPage : ContentPage
{

    public LAAllNotesPage()
	{
		InitializeComponent();
        
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }

}