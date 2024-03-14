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
using static SQLite.SQLite3;

namespace MangaInTime.ViewModel
{
    [QueryProperty(nameof(Url), "url")]
    [QueryProperty(nameof(Title), "title")]
    //[QueryProperty(nameof(FavManga), "FavManga")]
    public partial class MangaViewModel : BaseViewModel
    {
        [ObservableProperty] private string? url;
        [ObservableProperty] private string? title;

        private readonly MangaInTimeDatabase database;

        public MangaViewModel()
        {
            database = new();
        }

        [RelayCommand]
        private async Task UpdateCurrentMangaUrl()
        {
            await UpdateCurrentMangaByTitle();
        }
        
        private async Task UpdateCurrentMangaByTitle()
        {

            var item = await database.GetFavoriteMangaByTitle(Title);
            if (item != null)
            {
                item.UrlToManga = Url;
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                await Toast.Make($"Update: {item.Title}", ToastDuration.Long, 5).Show(cancellationTokenSource.Token);
                await database.SaveFavoriteManga(item);
            }
        }


    }
}
