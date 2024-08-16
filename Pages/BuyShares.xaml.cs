namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;
using System.Text;

public partial class BuyShares : Popup
{
    public List<LoanType> LoanTypesList { get; set; } = new List<LoanType>();
    string loanUrl = "https://localhost:7231/api/Account/buyshares";
    SharesDto sharesDto = new SharesDto();
    double sharesQuantity;
    static HttpClient client;
    public BuyShares()
    {
        InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(loanUrl)
        };
        BindingContext = this;
    }
    public double SharesQuantity
    {
        get { return sharesQuantity; }
        set { sharesQuantity = value; OnPropertyChanged(); }
    }


    private async void PuchaseShares(object sender, EventArgs e)
    {
        SharesDto shares = new() { SharesQuantity = SharesQuantity };
        var json = JsonConvert.SerializeObject(shares);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var res = await client.PostAsync(loanUrl, postData);
        if (!res.IsSuccessStatusCode)
        {
            var route = $"{nameof(Login)}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            var route = $"{nameof(Register)}";
            await Shell.Current.GoToAsync(route);
            Close();
        }

    }

    private void closepopup(object sender, EventArgs e)
    {
        Close();

    }
}