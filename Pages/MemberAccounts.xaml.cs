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
    private readonly Lazy<Task> _initialization;
    string baseUrl = "https://localhost:7231/api/Account/accounts";
    static HttpClient client;
    decimal currentBalance;
    decimal initialDeposit ;
    decimal openingAmount;
    string openingDate;
    List<Account> accounts;
    public List<Account> Accounts { get { return accounts; }
        set { accounts = value; OnPropertyChanged(); }
    }
    public MemberAccounts(List<Account> myAccount)
    {
        InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
        Accounts= myAccount;
        updateList();

        accountsList.ItemsSource = memberAccounts;     
    }
    public void updateList()
    {
        if (Accounts.Any())
        {
            foreach (var item in Accounts)
            {
                memberAccounts.Add(item);
            }
        }
    }
       
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

    private void seeAccounts(object sender, EventArgs e)
    {
        Accounts.Count();
    }
    private void closepopup(object sender, EventArgs e)
    {
        Close();
    }
}
