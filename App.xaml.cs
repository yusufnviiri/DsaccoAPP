using DsaccoAPP.Pages;

namespace DsaccoAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AccountData), typeof(AccountData));
            Routing.RegisterRoute(nameof(Login), typeof(Login));            
            Routing.RegisterRoute(nameof(Register), typeof(Register));

            MainPage = new AppShell();
        }
    }
}
