namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;

using DsaccoAPP.Model.BaseClasses;
using System.Collections.ObjectModel;

public partial class DepositPage : Popup
{
    public ObservableCollection<Account> memberAccounts { get; set; } = new ObservableCollection<Account>();

    public List<Account> Accounts { get; set; }
	public DepositPage(List<Account> AccountParams)
	{
		InitializeComponent();
		Accounts = AccountParams;
        accountTypePicker.ItemsSource = Accounts;
        accountTypePicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
    }
    private void OnPickerSelectedIndexChanged(object sender, System.EventArgs e)
    {
        // Get the selected item
        var selectedItem = (Account)accountTypePicker.SelectedItem;

        // Display the selected item
        if (selectedItem != null)
        {
            selectedItemLabel.Text = $"Selected Item: {selectedItem.AccountDescription} index {selectedItem.AccountId}";
        }
    }
}