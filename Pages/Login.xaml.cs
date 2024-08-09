namespace DsaccoAPP.Pages;

using DsaccoAPP.Model;
using Newtonsoft.Json;
using System.Text;

public partial class Login : ContentPage
{
    static HttpClient client;
    string baseUrl = "https://localhost:7231/api/Login/login";

    string email;
	string password;
	public Login()
	{
		InitializeComponent();
		BindingContext=this;
        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
    }
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
            DisplayAlert("warning", "Check staff data", "Ok");
		}
		else
		{ var route = $"{nameof(AccountData)}";
			await Shell.Current.GoToAsync(route);
		}

    }
}