using CommunityToolkit.Maui.Views;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;
using System.Text;

namespace DsaccoAPP.Pages;

public partial class LoanApplication : Popup
{
    public List<LoanType> LoanTypesList { get; set; } = new List<LoanType>();
    string loanUrl = "https://localhost:7231/api/Loan/loan";
    static HttpClient client;
    public LoanApplication(List<LoanType>loantypes)
	{
		InitializeComponent();
        BindingContext = this;
        LoanTypesList = loantypes;
        loanTypePicker.ItemsSource = LoanTypesList;
       loanTypePicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
    }

    int loanType;
    int numberOfInstallments;
    decimal principleAmount;
    string security;
    int loanPeriod;
    string firstWitnessName;
    string firstWitnessAddress;
    string firstWitnessContact;
    string secondWitnessName;
    string secondWitnessAddress;
    string secondWitnessContact;

    public LoanType loanTypeSelected { get; set; } = new LoanType();
   public int LoanType
    {        get { return loanType; }
        set { loanType = value; OnPropertyChanged(); } }
    public int NumberOfInstallments { 
         get { return numberOfInstallments; }
set { numberOfInstallments = value; OnPropertyChanged(); } }
  public  decimal PrincipleAmount
    {
        get { return principleAmount; }
        set { principleAmount = value; OnPropertyChanged(); }
    
}
   public string Security
    {  get { return security; }
       set { security = value; OnPropertyChanged(); }       
    }
   public int LoanPeriod
    {
        get { return loanPeriod; }
        set { loanPeriod = value; OnPropertyChanged(); }
    }
  
    public string FirstWitnessName
    {
        get { return firstWitnessName ; }
        set { firstWitnessName = value; OnPropertyChanged(); }
    }
    public string FirstWitnessAddress
    {
        get { return firstWitnessAddress; }
        set { firstWitnessAddress = value; OnPropertyChanged(); }
    }
    public string FirstWitnessContact
    {
        get { return firstWitnessAddress; }
        set { firstWitnessAddress = value; OnPropertyChanged(); }
    }
    public string SecondWitnessName
    {
        get { return secondWitnessName; }
        set { secondWitnessName = value; OnPropertyChanged(); }
    }
    public string SecondWitnessAddress
    {
        get { return firstWitnessAddress; }
        set { firstWitnessAddress = value; OnPropertyChanged(); }
    }
    public string SecondWitnessContact
    {
        get { return secondWitnessContact; }
        set { secondWitnessContact = value; OnPropertyChanged(); }
    }


    private void OnPickerSelectedIndexChanged(object sender, System.EventArgs e)
    {
        // Get the selected item
        var selectedItem = (LoanType)loanTypePicker.SelectedItem;

        // Display the selected item
        if (selectedItem != null)
        {
            selectedItemLabel.Text = $"loan type: {selectedItem.Description}";
            LoanType= selectedItem.LoanTypeId;
           
        }
    }
    private void closepopup(object sender, EventArgs e)
    {
        Close();
    }

   
    private async void ApplyForLoan(object sender, EventArgs e)
    {
        LoanModel newLoanModel = new() { LoanType=LoanType ,NumberOfInstallments =NumberOfInstallments,PrincipleAmount=PrincipleAmount,Security=Security,LoanPeriod=LoanPeriod,FirstWitnessAddress=FirstWitnessAddress,FirstWitnessContact=FirstWitnessContact,FirstWitnessName= FirstWitnessName,SecondWitnessAddress= SecondWitnessAddress,SecondWitnessContact=SecondWitnessContact,SecondWitnessName = SecondWitnessName };
        var json = JsonConvert.SerializeObject(newLoanModel);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var res = await client.PostAsync(loanUrl, postData);
        if (!res.IsSuccessStatusCode)
        {
            var route = $"{nameof(Login)}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            var route = $"{nameof(Register)}";
            await Shell.Current.GoToAsync(route);
            Close();
        }


    }
}