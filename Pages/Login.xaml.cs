namespace DsaccoAPP.Pages;
using DsaccoAPP.Model.Mapper;
using DsaccoAPP.Model.BaseClasses;

using DsaccoAPP.Model;
using Newtonsoft.Json;
using System.Text;
using CommunityToolkit.Maui.Views;
using System.Data;

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
        UserLogin loginData = new UserLogin { Email = Email, Password = Password };
        var json = JsonConvert.SerializeObject(loginData);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var res = await client.PostAsync(baseUrl, postData);
        if (!res.IsSuccessStatusCode)
        {
            DisplayAlert("warning", $"Incorrect Password or Email {Email} ,{Password}", "Ok");
        }
        else
        {
            await Shell.Current.GoToAsync(nameof(IndexPage));
        }

    } 
 

    private async void registerUser(object sender, EventArgs e)
    {
        var route = $"{nameof(Register)}";
        await Shell.Current.GoToAsync(route);
    }
}

