namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using DsaccoAPP.Model.BaseClasses;
using System.Collections.ObjectModel;

public partial class MemberAccounts : Popup
{
    public ObservableCollection<Account> memberAccounts { get; set; } = new ObservableCollection<Account>();

    string baseUrl = "https://localhost:7231/api/Account/openaccount";
    static HttpClient client;
    decimal CurrentBalance;
   decimal InitialDeposit ;
  decimal OpeningAmount;
    string OpeningDate;
    public MemberAccounts()
	{
		InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };

    }
}