namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;

using DsaccoAPP.Model.BaseClasses;
public partial class DepositPage : Popup
{
	public List<Account> Accounts { get; set; }
	public DepositPage(List<Account> AccountParams)
	{
		InitializeComponent();
		Accounts = AccountParams;
	}
}