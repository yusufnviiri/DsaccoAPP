namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;

public partial class WithdrawDetails : Popup
{
    public ObservableCollection<Transaction> CashWithdraws{ get; set; } = new ObservableCollection<Transaction>();
    string baseUrl = "https://localhost:7231/api/Account/withdraws";
    static HttpClient client;
    public List<Transaction> WithdrawTransactions { get; set; } = new List<Transaction>();
    public WithdrawDetails()
	{
		InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
        BindingContext=this;
     
    }

    private async void GetMemberWithdraws(object sender, EventArgs e)
    {
        var response = await client.GetStringAsync(baseUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<Withdraw>>(response);

        foreach (var item in res)
        {
            Transaction transaction = new Transaction() 
            { Reason=item.Reason,
            Amount=item.Amount,
            TransactionDate=item.StringDate,
            };
            WithdrawTransactions.Add(transaction);
        }
        if (WithdrawTransactions.Any())
        {
            withdarawsView.ItemsSource = WithdrawTransactions;
        }
    }

    private void closepopup(object sender, EventArgs e)
    {
        Close();
    }
}