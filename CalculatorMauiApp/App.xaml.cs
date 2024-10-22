namespace CalculatorMauiApp
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
                    mainPage.Window.MaximumWidth = 700;
                    mainPage.Window.MaximumHeight = 800;
                    mainPage.Window.MinimumWidth = 700;
                    mainPage.Window.MinimumHeight = 800;
                }
            });

            MainPage = mainPage;

        }
    }
}
