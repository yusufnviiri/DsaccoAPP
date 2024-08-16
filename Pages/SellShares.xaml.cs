namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;
using System.Text;

public partial class SellShares : Popup
{
    public List<LoanType> LoanTypesList { get; set; } = new List<LoanType>();
    string sharesUrl = "https://localhost:7231/api/Account/sellshares";
    SharesDto sharesDto = new SharesDto();
    double sharesQuantity;
    static HttpClient client;
    double sharesOwned;
    decimal shareValue;
    MemberShares MemberShares { get; set; } = new MemberShares();
    public SellShares(MemberShares shares)
    {
        InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(sharesUrl)
        };
        MemberShares = shares;
        SharesOwned = shares.NumberOfShares;
        SharesValue = shares.ValueOfShare;
        BindingContext = this;
    }
    public decimal SharesValue
    {
        get { return shareValue; }
        set
        {
            shareValue = value; OnPropertyChanged();
        }
    }
    public double SharesOwned
    {
        get { return sharesOwned; }
        set
        {
            sharesOwned = value; OnPropertyChanged();
        }
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