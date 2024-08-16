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
    static HttpClient clientShares;

    private UserDto _userDataInjector { get; set; }
    string baseUrl = "https://localhost:7231/api/Login/login";
	string userUrl = "https://localhost:7231/api/Login/user";
    string loanTypeUrl = "https://localhost:7231/api/Loan/loantypes";
    string accountUrl = "https://localhost:7231/api/Account/accounts";
    string sharesUrl = "https://localhost:7231/api/Account/membershares";
    MemberShares memberShares { get; set; } = new MemberShares();


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
        clientShares = new HttpClient
        {
            BaseAddress = new Uri(sharesUrl)
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
    public async Task<MemberShares> GetMemberShares()
    {
        var response = await client.GetStringAsync(sharesUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<MemberShares>>(response);
        return res.FirstOrDefault();

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

    public async Task<List<LoanType>> GetLoanTypes()
    {
        var response = await client.GetStringAsync(loanTypeUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<LoanType>>(response);
        List<LoanType> loanTypes = new List<LoanType>();


        foreach (var item in res)
        {
            loanTypes.Add(item);
        }
        return loanTypes;
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

    private async void LoanApplicatation(object sender, EventArgs e)
    {
        var loanTypes = await GetLoanTypes();

        if (loanTypes.Any())
        {
            await this.ShowPopupAsync(new LoanApplication(loanTypes));
        }
        else
        {
            await DisplayAlert("warning", "You need to create an account", "Ok");

            this.ShowPopupAsync(new NewAccount());

        }
    }

    private async void PurchaseShares(object sender, EventArgs e)
    {
        
        memberShares = await GetMemberShares();

        this.ShowPopupAsync(new BuyShares(memberShares));

    }

    private async void SellMemberShares(object sender, EventArgs e)
    {
        memberShares = await GetMemberShares();
        this.ShowPopupAsync(new SellShares(memberShares));

    }

    private void GetMemberLoans(object sender, EventArgs e)
    {
        this.ShowPopupAsync(new MemberLoans());

    }
}

