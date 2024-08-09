using DsaccoAPP.Model;
namespace DsaccoAPP.Pages;
[QueryProperty("UserModel",("usermodel"))]
public partial class AccountData : ContentPage
{
    UserViewModel _userModel;
	public AccountData()
	{
		InitializeComponent();
        BindingContext = this;
	}
    public UserViewModel UserModel
    {
        get {  return _userModel; }
        set { _userModel = value;
        Email = _userModel.Email;
           LName = _userModel.LName;
            FName = _userModel.FName;
            isPermitted = _userModel.IsPermitted;
            Role = _userModel.Role;

        }

    }

    string fName;
    string lName;
    string email;
    string role ;
     bool isPermitted ;
    public string FName { get{ return fName; } set { fName = value;OnPropertyChanged(); } }
    public string LName { get { return lName; } set{ lName = value; OnPropertyChanged(); } }
    public string Email { get { return email; } set { email = value; OnPropertyChanged(); } }
    public string Role { get { return role; } set { email = value; OnPropertyChanged(); } } 
    public bool IsPermitted { get { return isPermitted; } set { isPermitted= value; OnPropertyChanged(); } }














    private async void loginUser(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");

    }

    private async void tologinUser(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Login));
    }
}