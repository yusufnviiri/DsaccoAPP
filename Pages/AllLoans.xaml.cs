namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;
using System.Text;

public partial class AllLoans : ContentPage
{
    string loanUrl = "https://localhost:7231/api/Loan/allloans";
    static HttpClient client;
    public ObservableCollection<Loan> LoansBindableList { get; set; }= new ObservableCollection<Loan>();
    private IEnumerable<Loan> loansfromDb {  get; set; }= new List<Loan>();

    public AllLoans()
    {
		InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(loanUrl)
        };
      loanDetailsView.ItemsSource = LoansBindableList;
        BindingContext = this;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var response = await client.GetStringAsync(loanUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<Loan>>(response);
        loansfromDb = res;
        foreach(var item in loansfromDb)
        {
            LoansBindableList.Add(item);
        }

    }
}