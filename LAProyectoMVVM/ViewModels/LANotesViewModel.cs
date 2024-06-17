using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using LAProyectoMVVM.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace LAProyectoMVVM.ViewModels;

internal class LANotesViewModel: IQueryAttributable
{
    public ObservableCollection<ViewModels.LANoteViewModel> AllNotes { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectNoteCommand { get; }

    public LANotesViewModel()
    {
        AllNotes = new ObservableCollection<ViewModels.LANoteViewModel>(Models.LANote.LoadAll().Select(n => new LANoteViewModel(n)));
        NewCommand = new AsyncRelayCommand(NewNoteAsync);
        SelectNoteCommand = new AsyncRelayCommand<ViewModels.LANoteViewModel>(SelectNoteAsync);
    }
    private async Task NewNoteAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.LANotePage));
    }

    private async Task SelectNoteAsync(ViewModels.LANoteViewModel note)
    {
        if (note != null)
            await Shell.Current.GoToAsync($"{nameof(Views.LANotePage)}?load={note.Identifier}");
    }
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("deleted"))
        {
            string noteId = query["deleted"].ToString();
            LANoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

            // If note exists, delete it
            if (matchedNote != null)
                AllNotes.Remove(matchedNote);
        }
        else if (query.ContainsKey("saved"))
        {
            string noteId = query["saved"].ToString();
            LANoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

            // If note is found, update it
            if (matchedNote != null)
                matchedNote.Reload();

            // If note isn't found, it's new; add it.
            else
                AllNotes.Add(new LANoteViewModel(LANote.Load(noteId)));
        }
    }
}
