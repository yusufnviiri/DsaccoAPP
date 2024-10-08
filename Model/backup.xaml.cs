namespace DsaccoAPP.Model;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;
using System.Text;

public partial class backup : ContentPage
{
    string loanUrl = "https://localhost:7231/api/Loan/allloans";
    static HttpClient client;
    public ObservableCollection<Loan> LoansBindableList { get; set; } = new ObservableCollection<Loan>();
    private IEnumerable<Loan> loansfromDb { get; set; } = new List<Loan>();
    public backup()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var response = await client.GetStringAsync(loanUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<Loan>>(response);
        loansfromDb = res;
        foreach (var item in loansfromDb)
        {
            LoansBindableList.Add(item);


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
        var response = await client.GetStringAsync(loanUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<Loan>>(response);
        loansfromDb = res;
        foreach (var item in loansfromDb)
        {
            LoansBindableList.Add(item);
        }

    }

    private async void BackToHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");

    }
}