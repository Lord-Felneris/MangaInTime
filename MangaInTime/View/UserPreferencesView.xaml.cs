using MangaInTime.ViewModel;

namespace MangaInTime.View;

public partial class UserPreferencesView : ContentPage
{
	private UserPreferencesViewModel vm = new();
    public UserPreferencesView()
	{
		BindingContext = vm;
		InitializeComponent();
	}
}