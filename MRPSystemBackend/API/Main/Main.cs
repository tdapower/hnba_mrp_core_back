using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Main
{
    public class Main
    {
        [Required]
        public int SeqId { get; set; }
        public string JobNo { get; set; }
        public string QuotationNo { get; set; }
        public int RevisionNo { get; set; }
        public string ProposalNo { get; set; }
        public string MedicalType { get; set; }
        public string PolicyNo { get; set; }
        public double LoanAmount { get; set; }
        public double Interest { get; set; }
        public int Term { get; set; }
        public int FullTermInMonths { get; set; }
        public int GracePeriod { get; set; }
        public int CompanyBufferId { get; set; }
        public double CurrentAwplr { get; set; }
        public double AdditionToAwplr { get; set; }
        public int TermOfFixedInterest { get; set; }
        public int BankId { get; set; }
        public int BranchId { get; set; }
        public int CurrencyId { get; set; }
        public string InterestRateType { get; set; }
        public string HnbaBranchCode { get; set; }
        public int BrokerCode { get; set; }
        public int ChannelCode { get; set; }
        public int IsReInsurance { get; set; }
        public int LoanTypeId { get; set; }
        public int ReInsCompanyId { get; set; }
        public double ExchangeRate { get; set; }
        public string DateOfCommence { get; set; }
        public string DateOfProposal { get; set; }
        public double Premium { get; set; }
        public double PremiumWithPolicyFee { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public string ProposalSendingMethod { get; set; }
        public string SystemDate { get; set; }
        public int IsValidated { get; set; }
        public string TempMainSeqId { get; set; }
        public string Life1HnbaRefNo { get; set; }
        public string Life1RiRefNo { get; set; }
        public double Life1HealthExtraBasic { get; set; }
        public double Life1HealthExtraTpd { get; set; }
        public double Life1OccuExtraBasic { get; set; }
        public double Life1OccuExtraTpd { get; set; }
        public double Life1OccuExtraPmileBasic { get; set; }
        public double Life1OccuExtraPmileTpd { get; set; }
        public double Life1Discount { get; set; }
        public double Life1Loadings { get; set; }
        public int Life1IsTpd { get; set; }
        public int Life1TpdOption { get; set; }
        public string Life2HnbaRefNo { get; set; }
        public string Life2RiRefNo { get; set; }
        public double Life2HealthExtraBasic { get; set; }
        public double Life2HealthExtraTpd { get; set; }
        public double Life2OccuExtraBasic { get; set; }
        public double Life2OccuExtraTpd { get; set; }
        public double Life2OccuExtraPMileBasic { get; set; }
        public double Life2OccuExtraPMileTpd { get; set; }
        public double Life2Discount { get; set; }
        public double Life2Loadings { get; set; }
        public int Life2IsTpd { get; set; }
        public int Life2TpdOption { get; set; }


        public int LifeAssure1Id { get; set; }
        public int LifeAssure2Id { get; set; }
    }
}
