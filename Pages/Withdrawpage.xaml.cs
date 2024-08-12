
namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;

using DsaccoAPP.Model.BaseClasses;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text;
using DsaccoAPP.Model.Mapper;

public partial class Withdrawpage : Popup
{

    public List<Account> Accounts { get; set; }
    string depositUrl = "https://localhost:7231/api/Account/withdraw";
    static HttpClient client;
    public Withdrawpage(List<Account> AccountParams)
    {
        InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(depositUrl)
        };
        BindingContext = this;
        Accounts = AccountParams;
        accountTypePicker.ItemsSource = Accounts;
        accountTypePicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
    }

    decimal amount;
    int accountId;
    public int AccountId
    {
        get { return accountId; }
        set { accountId = value; OnPropertyChanged(); }
    }
    public decimal Amount { get { return amount; } set { amount = value; OnPropertyChanged(); } }
    private void OnPickerSelectedIndexChanged(object sender, System.EventArgs e)
    {
        // Get the selected item
        var selectedItem = (Account)accountTypePicker.SelectedItem;

        // Display the selected item
        if (selectedItem != null)
        {
            selectedItemLabel.Text = $"Account: {selectedItem.AccountDescription}";
            AccountId = selectedItem.AccountId;
        }
    }

    private void closepopup(object sender, EventArgs e)
    {
        Close();
    }

    private async void WithdrawAmount(object sender, EventArgs e)
    {
        AccountOperationsModel AccountModel = new() { AccountId = AccountId, Amount = Amount };
        var json = JsonConvert.SerializeObject(AccountModel);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var res = await client.PostAsync(depositUrl, postData);
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
