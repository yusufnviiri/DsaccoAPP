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
    public List<Withdraw> MemberWithdraws { get; set; }
    public List<Transaction> WithdrawTransactions { get; set; }
    public WithdrawDetails()
	{
		InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
        if (WithdrawTransactions.Any())
        {

        }
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
    }

    private void closepopup(object sender, EventArgs e)
    {
        Close();
    }
}