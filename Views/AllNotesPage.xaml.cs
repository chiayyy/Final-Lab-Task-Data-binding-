using NotesApp.ViewModels;

namespace NotesApp.Views;

public partial class AllNotesPage : ContentPage
{
    public AllNotesPage()
    {
        InitializeComponent();
        BindingContext = new NotesViewModel();
    }
}
