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
                    mainPage.Window.MaximumWidth = 400;
                    mainPage.Window.MaximumHeight = 500;
                    mainPage.Window.MinimumWidth = 400;
                    mainPage.Window.MinimumHeight = 500;
                }
            });

            MainPage = mainPage;

        }
    }
}
