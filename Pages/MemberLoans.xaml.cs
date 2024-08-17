namespace DsaccoAPP.Pages;
using CommunityToolkit.Maui.Views;

using DsaccoAPP.Model.BaseClasses;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text;
using DsaccoAPP.Model.Mapper;

public partial class MemberLoans : Popup
{
    public ObservableCollection<LoanData> CashWithdraws { get; set; } = new ObservableCollection<LoanData>();
    string baseUrl = "https://localhost:7231/api/Loan/loans";
    static HttpClient client;
    public List<LoanData> MemberLoanData { get; set; } = new List<LoanData>();
    public MemberLoans()
	{
        InitializeComponent();
        client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
        BindingContext = this;
    }

    private async void GetMemberLoans(object sender, EventArgs e)
    {
        var response = await client.GetStringAsync(baseUrl);
        var res = JsonConvert.DeserializeObject<IEnumerable<Loan>>(response);

        foreach (var item in res)
        {
            LoanData loanData = new LoanData()
            {
                LoanTypeDescription = item.LoanType.Description,
                FirstWitnessName=item.LoanWitness.FirstWitnessName,
                FirstWitnessAddress=item.LoanWitness.FirstWitnessAddress,
                FirstWitnessContact=item.LoanWitness.FirstWitnessContact,
                SecondWitnessName= item.LoanWitness.SecondWitnessName,
                SecondWitnessAddress=item.LoanWitness.SecondWitnessAddress,
                SecondWitnessContact=item.LoanWitness.SecondWitnessContact,
                NumberOfInstallments=item.NumberOfInstallments,
                NumberOfPayments=item.NumberOfPayments,
                PayAmount=item.PayAmount,
                OutstandingBalance=item.OutstandingBalance,
                LoanInterest=item.LoanInterest,
                Status=item.Status,
                Iscompleted=item.IsCompleted,
                PrincipleAmount=item.PrincipleAmount,
                Security=item.Security,
                LoanPeriod=item.LoanPeriod,
              
            };
            MemberLoanData.Add(loanData);
        }
        if (MemberLoanData.Any())
        {
            loanDetailsView.ItemsSource = MemberLoanData;
        }
    }
    private void closepopup(object sender, EventArgs e)
    {
        Close();
    }

    private void BackToHome(object sender, EventArgs e)
    {

    }
}