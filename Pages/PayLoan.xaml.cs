namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;
using System.Text;

public partial class PayLoan : Popup
{
    public Loan memberLoan { get; set; } = new ();
    string loanPaymentUrl = "https://localhost:7231/api/Loan/loanpayment";
    int loanId;
    static HttpClient client;
   
    decimal amountPaid;
    public PayLoan(Loan loan)
    {
        InitializeComponent();
        this.LoanId = loan.LoanId;
        BindingContext = this;
    }
    public decimal AmountPaid
    {
        get { return amountPaid; }
        set
        {
            amountPaid = value; OnPropertyChanged();
        }
    }
    public int LoanId
    {
        get { return loanId; }
        set
        {
            loanId = value; OnPropertyChanged();
        }
    }


    private async void PayMemberLoan(object sender, EventArgs e)
    {
        LoanPaymentModel loanPayment = new LoanPaymentModel() { AmountPaid=AmountPaid,LoanId=LoanId};
        var json = JsonConvert.SerializeObject(loanPayment);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var res = await client.PostAsync(loanPaymentUrl, postData);
        if (!res.IsSuccessStatusCode)
        {
            await Shell.Current.GoToAsync(nameof(Login));
        }
        else
        {
            await Shell.Current.GoToAsync(nameof(AllLoans));

            Close();
        }

    }

    private void closepopup(object sender, EventArgs e)
    {
        Close();

    }



}