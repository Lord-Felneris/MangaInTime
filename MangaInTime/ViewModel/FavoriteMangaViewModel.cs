using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MangaInTime.Database;
using MangaInTime.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using static SQLite.SQLite3;

namespace MangaInTime.ViewModel
{
    public partial class FavoriteMangaViewModel : BaseViewModel
    {
        private readonly MangaInTimeDatabase database;
        [ObservableProperty] private List<FavoriteManga>? mangas;

        [ObservableProperty] private string filePickerImg = string.Empty;

        public FavoriteMangaViewModel() 
        {
            database = new();
        }

        public ICommand ItemSelected => new Command(async selectedItem =>
        {
            var selectedManga = selectedItem as FavoriteManga;
            if (selectedManga != null)
            {
                var url = selectedManga.UrlToManga;
                var title = selectedManga.Title;
                await Navigation.NavigateTo($"mangaview?url={url}&&title={title}");
                //await Navigation.NavigateTo($"mangaview",navParam);
            }
        });

        public ICommand ItemSelectedRemove => new Command(async selectedItem =>
        {
            var selectedManga = selectedItem as FavoriteManga;
            if(selectedManga != null)
            {
                await database.DeleteFavoriteManga(selectedManga);
            }
            await InitData();
        });

        public ICommand ItemSelectedModify => new Command(async selectedItem =>
        {
            var selectedManga = selectedItem as FavoriteManga;
            if (selectedManga != null)
            {
                await PickFavoriteManga();
                selectedManga.MangaImg = FilePickerImg;
                await database.SaveFavoriteManga(selectedManga);
                await InitData();
            }
        });


        private async Task PickFavoriteManga()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick a Image Please!",
                FileTypes = FilePickerFileType.Images
            });
            if (result == null)
                return;

            FilePickerImg = result.FullPath;
        }

        public async Task InitData()
        {
            Mangas = await database.GetFavoriteManga();
        }
    }
}
