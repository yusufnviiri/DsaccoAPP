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
            Routing.RegisterRoute(nameof(AllLoans), typeof(AllLoans));
            Routing.RegisterRoute(nameof(IndexPage), typeof(IndexPage));


            MainPage = new AppShell();
        }
    }
}
