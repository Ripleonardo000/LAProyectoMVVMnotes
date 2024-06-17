using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace LAProyectoMVVM.ViewModels
{
    internal class LANoteViewModel : ObservableObject, IQueryAttributable
    {
        private Models.LANote _note;
    }
}
