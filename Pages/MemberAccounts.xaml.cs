namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using DsaccoAPP.Model.BaseClasses;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;


public partial class MemberAccounts : Popup
{
    public ObservableCollection<Account> memberAccounts { get; set; } = new ObservableCollection<Account>();

    string baseUrl = "https://localhost:7231/api/Account/accounts";
    static HttpClient client;
    decimal currentBalance;
    decimal initialDeposit ;
    decimal openingAmount;
    string openingDate;
    public MemberAccounts()
    {
        InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
    }

    private async Task<MemberAccounts> InitializeAsync()
    {
        await GetMemberAccounts(); 
        return this;
    }

    //public async Task InitializeAsync()
    //{
    //    // Perform asynchronous operations here
    //    await GetMemberAccounts();
    //}
    public decimal CurrentBalance
    {
        get
        {
            return currentBalance;
        }
        set { currentBalance = value; OnPropertyChanged(); }
    }
    public decimal InitialDeposit
    {
        get
        {
            return initialDeposit;
        }
        set { initialDeposit = value; OnPropertyChanged(); }
    }
    public decimal OpeningAmount
    {
        get
        {
            return openingAmount;
        }
        set { openingAmount = value; OnPropertyChanged(); }
    }
    public string OpeningDate
    {
        get { return openingDate; }
        set { openingDate = value; OnPropertyChanged(); }
    }

    //public async Task GetMemberAccounts()
        public async Task<List<Account>>GetMemberAccounts()
    {
        var response = await client.GetStringAsync(baseUrl);
        var res = JsonConvert.DeserializeObject<Account>(response);
        List<Account> accounts = new List<Account>();

    return accounts;



    }

}
