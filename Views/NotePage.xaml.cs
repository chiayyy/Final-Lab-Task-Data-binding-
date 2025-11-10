using NotesApp.ViewModels;

namespace NotesApp.Views;

public partial class NotePage : ContentPage
{
    public NotePage()
    {
        InitializeComponent();
        BindingContext = new NoteViewModel();
    }
}
