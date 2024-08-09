namespace DsaccoAPP.Pages;

public partial class Register : ContentPage
{
     string firstName; 
    string lastName;
    string email; 
    string role;
    string password;
    int age;
    bool isPermitted;
    public Register()
	{
		InitializeComponent();
        BindingContext = this;
	}
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
     public string Email
    {
    get { return email; }
    set { email = value; }
}
public string Password
{
    get { return password; }
    set {password  = value; }
}
public int Age
{
    get { return age; }
    set { age = value; }
}
public bool IsPermitted
{
    get { return isPermitted; }
    set { isPermitted = value; }
}

}