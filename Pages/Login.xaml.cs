namespace DsaccoAPP.Pages;
using DsaccoAPP.Model.Mapper;
using DsaccoAPP.Model.BaseClasses;

using DsaccoAPP.Model;
using Newtonsoft.Json;
using System.Text;
using CommunityToolkit.Maui.Views;

public partial class Login : ContentPage
{
    static HttpClient client;
	private UserDto _userDataInjector { get; set; }
    string baseUrl = "https://localhost:7231/api/Login/login";
	string userUrl = "https://localhost:7231/api/Login/user";
    string accountUrl = "https://localhost:7231/api/Account/accounts";


    string email;
	string password;
	//public Login(UserDto userdata)
	//{
	//	_userDataInjector = userdata;
	//	InitializeComponent();
	//	BindingContext = this;
	//	client = new HttpClient
	//	{
	//		BaseAddress = new Uri(baseUrl)
	//	};
	//}
	public Login()
	{
		InitializeComponent();
		BindingContext = this;
		client = new HttpClient
		{
			BaseAddress = new Uri(baseUrl)
		};
	}
	public string Names { get; set; } 
    public string Email
	{
		get { return email; }
		set { email = value; OnPropertyChanged();
        }
    }
	public string Password
	{
		get { return password; }
		set { password = value;
			OnPropertyChanged();
		}
	}
	
    private async void loginUser(object sender, EventArgs e)
    {
		UserLogin loginData= new UserLogin { Email=Email,Password=Password};
		var json = JsonConvert.SerializeObject(loginData);
		var postData= new StringContent(json,Encoding.UTF8,"application/json");
		var res = await client.PostAsync(baseUrl, postData);
        if (!res.IsSuccessStatusCode)
        {
            DisplayAlert("warning", "Incorrect Password or Email", "Ok");
		}
		else
		{
            UserViewModel viewModel = new UserViewModel();
			viewModel = await GetUser();
          
			Names = $"{viewModel.LName} {viewModel.FName}";
			Email = "";
			Password = "";
			var pageParams = new Dictionary<string, object> { { "usermodel",viewModel } };

       var route = $"{nameof(AccountData)}";
			await Shell.Current.GoToAsync(route,pageParams);
		}

    }

	public async Task<UserViewModel> GetUser()
	{
		var response = await client.GetStringAsync(userUrl);
		var res = JsonConvert.DeserializeObject<UserViewModel>(response);
		return res;

	}
    public async Task<List<Account>> GetMemberAccounts()
    {
        var response = await client.GetStringAsync(accountUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<Account>>(response);
        List<Account> accounts = new List<Account>();


        foreach (var item in res)
		{
			accounts.Add(item);
		}
		return accounts;
    }
        private void CreateAccount(object sender, EventArgs e)
    {
		this.ShowPopupAsync(new NewAccount());
    }
	private async void GetAccounts(object sender, EventArgs e)
	{
		var accountsList = await GetMemberAccounts();
		if (accountsList.Any())
		{
			await this.ShowPopupAsync(new MemberAccounts(accountsList));
		}
		else
		{
           await DisplayAlert("warning", "You need to create an account", "Ok");

            this.ShowPopupAsync(new NewAccount());

        }
    }

    private async void CashDeposit(object sender, EventArgs e)
    {
        var accountsList = await GetMemberAccounts();

        if (accountsList.Any())
        {
            await this.ShowPopupAsync(new DepositPage(accountsList));
        }
        else
        {
            await DisplayAlert("warning", "You need to create an account", "Ok");

            this.ShowPopupAsync(new NewAccount());

        }
    }

    private async void CashWithdraw(object sender, EventArgs e)
    {
        var accountsList = await GetMemberAccounts();

        if (accountsList.Any())
        {
            await this.ShowPopupAsync(new Withdrawpage(accountsList));
        }
        else
        {
            await DisplayAlert("warning", "You need to create an account", "Ok");

            this.ShowPopupAsync(new NewAccount());

        }
    }

    private async void GetWithdraws(object sender, EventArgs e)
    {
        var accountsList = await GetMemberAccounts();

        if (accountsList.Any())
        {
            this.ShowPopupAsync(new WithdrawDetails());

        }
        else
        {
            await DisplayAlert("warning", "You need to create an account", "Ok");
            this.ShowPopupAsync(new NewAccount());
                    }
    }

    private async void GetDeposits(object sender, EventArgs e)
    {

        var accountsList = await GetMemberAccounts();

        if (accountsList.Any())
        {
            this.ShowPopupAsync(new DepositDetails());
                    }
        else
        {
            await DisplayAlert("warning", "You need to create an account", "Ok");
            this.ShowPopupAsync(new NewAccount());


        }
    }
}
