using MangaInTime.ViewModel;
using System.Web;

namespace MangaInTime.View;

public partial class MangaView : ContentPage
{
	private MangaViewModel vm = new();
    public MangaView()
	{
		BindingContext = vm;
		InitializeComponent();
	}

    private void Browser_Navigated(object sender, WebNavigatedEventArgs e)
    {
        var url = e.Url;
        vm.Url = url.ToString();
    }
}