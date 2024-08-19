namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;
using System.Text;
using DsaccoAPP.Model;

public partial class AllLoans : ContentPage
{
    string loanUrl = "https://localhost:7231/api/Loan/allloans";
    string loanUpdateUrl = "https://localhost:7231/api/Loan/approveloan";
    static HttpClient client;
    public ObservableCollection<Loan> LoansBindableList { get; set; }= new ObservableCollection<Loan>();
    private IEnumerable<Loan> loansfromDb {  get; set; }= new List<Loan>();

    public AllLoans()
    {
		InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(loanUrl)
        };
        BindingContext = this;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var response = await client.GetStringAsync(loanUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<Loan>>(response);
        loansfromDb = res;
        foreach (var item in loansfromDb)
        {
            if (item.IsCompleted)
            {
                item.loanCompletiton = "True";
            }
            else
            {
                item.loanCompletiton = "False";

            }
            if (LoansBindableList.Count()==res.Count()) { return; }
            else
            {
                LoansBindableList.Add(item);
            }


        
            //var frame = new Frame
            //{
            //    BorderColor = Colors.Gray,
            //    Padding = new Thickness(10),
            //    Content = new Label { Text = item.LoanType.Description },
            //    Margin = new Thickness(5)
            //};
            //flexView.Children.Add(frame);
        }
  

    }

    private async void GetallLoans(object sender, EventArgs e)
    {

        LoansBindableList.Clear();
        var response = await client.GetStringAsync(loanUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<Loan>>(response);
        loansfromDb = res;
        foreach (var item in loansfromDb)
        {
            if (item.IsCompleted)
            {
                item.loanCompletiton = "True";
            }
            else
            {
                item.loanCompletiton = "False";

            }
            if (LoansBindableList.Count() == res.Count()) { return; }
            else
            {
                LoansBindableList.Add(item);
            }

        }
    }

    private async void BackToHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");

    }

    private async Task UpdateLoanStatus(ParamId paramId)
    {
        var json = JsonConvert.SerializeObject(paramId);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var res = await client.PostAsync(loanUpdateUrl, postData);
        if (!res.IsSuccessStatusCode)
        {
            var route = $"{nameof(Login)}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            var route = $"{nameof(Register)}";
            await Shell.Current.GoToAsync(route);
        }

    }

    private async void OnApproveLoan(object sender, EventArgs e)
    {
        var button = sender as Button;
        var selectedItem = button.BindingContext as Loan;
        if (selectedItem != null)
        {
            DisplayAlert("Item Selected", selectedItem.LoanType.Description + " "+ selectedItem.LoanId, "OK");
            ParamId paramId = new ParamId() { RefId=selectedItem.LoanId,Status="Approved"};
            await UpdateLoanStatus(paramId);
        }
    }
    private async void OnRejectLoan(object sender, EventArgs e)
    {
        var button = sender as Button;
        var selectedItem = button.BindingContext as Loan;
        if (selectedItem != null)
        {
            DisplayAlert("Item Selected", selectedItem.User.LastName + " " + selectedItem.User.FirstName, "OK");
            ParamId paramId = new ParamId() { RefId = selectedItem.LoanId, Status = "Rejected" };
            await UpdateLoanStatus(paramId);
        }
    }
}