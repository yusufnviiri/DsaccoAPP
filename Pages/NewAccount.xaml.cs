using CommunityToolkit.Maui.Views;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;
using System.Text;
namespace DsaccoAPP.Pages;

public partial class NewAccount : Popup
{
   

    decimal currentBalance;
    decimal openingAmount;
    string accountDescription;
    string baseUrl = "https://localhost:7231/api/Account/openaccount";
    static HttpClient client;
    public NewAccount()
	{
		InitializeComponent();
        BindingContext = this;
        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };

    }
    public decimal CurrentBalance
    {
        get { return currentBalance; }
        set
        {
            currentBalance = value;
            OnPropertyChanged();
        }
    }
    public decimal OpeningAmount
    {
        get { return openingAmount; }
        set
        {
            openingAmount = value;
            OnPropertyChanged();
        }
    }
    public string AccountDescription
    {
        get { return accountDescription; }
        set { accountDescription = value; OnPropertyChanged(); }
    }

  

    private void closepopup(object sender, EventArgs e)
    {
		Close();
    }

    private async void CreateAccount(object sender, EventArgs e)
    {
        AccountModel AccountModel = new() { AccountDescription = accountType.SelectedItem.ToString(), OpeningAmount = OpeningAmount, CurrentBalance = CurrentBalance };
        var json = JsonConvert.SerializeObject(AccountModel);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var res = await client.PostAsync(baseUrl, postData);
        if (!res.IsSuccessStatusCode)
        {
            var route = $"{nameof(Register)}";
            await Shell.Current.GoToAsync(route);

        }
        else
        {
            var route = $"{nameof(Login)}";
            await Shell.Current.GoToAsync(route);
            Close();
        }


        }
}