using MangaInTime.ViewModel;
namespace MangaInTime.View;

public partial class SearchMangaView : ContentPage
{
	private SearchMangaViewModel vm = new();
	public SearchMangaView()
	{
		BindingContext = vm;
		InitializeComponent();
    }


    protected override bool OnBackButtonPressed()
    {
        if (Browser.CanGoBack)
        {
            Browser.GoBack();
            return true;
        }
        else
        {
            base.OnBackButtonPressed();
            return false;
        }
    }
    private void Browser_Navigated(object sender, WebNavigatedEventArgs e)
    {
       var url = e.Url;
       vm.BaseUrl = url.ToString();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        vm.RemindLastPage();

    }

    
}