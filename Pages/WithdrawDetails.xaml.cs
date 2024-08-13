namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;

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
    }

    private async void GetMemberWithdraws(object sender, EventArgs e)
    {

    }

    private void closepopup(object sender, EventArgs e)
    {
        Close();
    }
}