namespace LAProyectoMVVM.Views;

public partial class LAAllNotesPage : ContentPage
{

    public LAAllNotesPage()
	{
		InitializeComponent();
        BindingContext = new Models.LAAllNotes();
    }
    protected override void OnAppearing()
    {
        ((Models.LAAllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LANotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.LANote)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(LANotePage)}?{nameof(LANotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}