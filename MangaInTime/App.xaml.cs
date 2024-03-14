using MangaInTime.View;

namespace MangaInTime
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Routing.RegisterRoute("mangaview",
             typeof(MangaView));
        }
    }
}
