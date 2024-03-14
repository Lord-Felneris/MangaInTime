using MangaInTime.ViewModel;

namespace MangaInTime.View;

public partial class FavoriteMangaView : ContentPage
{
	private FavoriteMangaViewModel vm;
	public FavoriteMangaView()
	{
		vm = new FavoriteMangaViewModel();
		BindingContext = vm;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await vm.InitData();
    }

}