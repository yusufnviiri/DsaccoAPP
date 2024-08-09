namespace DsaccoAPP.Pages;
using DsaccoAPP.Model.Mapper;

using DsaccoAPP.Model;
using Newtonsoft.Json;
using System.Text;

public partial class Login : ContentPage
{
    static HttpClient client;
	private UserDto _userDataInjector { get; set; }
    string baseUrl = "https://localhost:7231/api/Login/login";
	string userUrl = "https://localhost:7231/api/Login/user";

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
}