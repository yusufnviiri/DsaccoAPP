namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;

public partial class WithdrawDetails : Popup
{
    public ObservableCollection<Withdraw> CashWithdraws{ get; set; } = new ObservableCollection<Withdraw>();
    public WithdrawDetails()
	{
		InitializeComponent();
	}
}