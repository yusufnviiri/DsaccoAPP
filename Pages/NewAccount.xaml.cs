using CommunityToolkit.Maui.Views;

namespace DsaccoAPP.Pages;

public partial class NewAccount : Popup
{
	public NewAccount()
	{
		InitializeComponent();
		
	}

    private void closepopup(object sender, EventArgs e)
    {
		Close();
    }
}