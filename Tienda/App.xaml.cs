namespace Tienda
{
    public partial class App : Application
    {
        public static ClienteService ClienteService { get; set; }
        public App()
        {
            InitializeComponent();
            ClienteService = new ClienteService();
            MainPage = new AppShell();
        }
    }
}