namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;
using System.Text;
public partial class PayLoan : Popup
{
    public List<LoanType> LoanTypesList { get; set; } = new List<LoanType>();
    string loanPaymentUrl = "https://localhost:7231/api/Loan/loanpayment";
    LoanPaymentModel loanPayment = new LoanPaymentModel();
    int loanId;
    static HttpClient client;
    double sharesOwned;
    decimal amountPaid;
    public PayLoan()
	{
		InitializeComponent();
	}
}