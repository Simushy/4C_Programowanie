namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CreateMainPage();
        }

        private void CreateMainPage()
        {
            var mainPage = new NavigationPage(new MainPage());

            // Ensure the window is initialized properly
            this.Dispatcher.Dispatch(() =>
            {
                if (mainPage.Window != null)
                {
                    mainPage.Window.MaximumWidth = 280;
                    mainPage.Window.MaximumHeight = 400;
                    mainPage.Window.MinimumWidth = 280;
                    mainPage.Window.MinimumHeight = 400;
                }
            });

            MainPage = mainPage;

        }
    }
}