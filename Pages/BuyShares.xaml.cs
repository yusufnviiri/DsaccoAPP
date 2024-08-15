namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using DsaccoAPP.Model.BaseClasses;
using DsaccoAPP.Model.Mapper;
using Newtonsoft.Json;

public partial class BuyShares : Popup
{
    public List<LoanType> LoanTypesList { get; set; } = new List<LoanType>();
    string loanUrl = "https://localhost:7231/api/Loan/loan";
    static HttpClient client;
    public BuyShares()
	{
		InitializeComponent();
        InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(loanUrl)
        };
        BindingContext = this;
    }
}