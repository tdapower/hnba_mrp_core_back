using Dapper;
using Microsoft.Extensions.Configuration;
using MRPSystemBackend.API.LifeAssure;
using MRPSystemBackend.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace MRPSystemBackend.API.Main
{
    public class MainRepository : IMainRepository
    {
        IConfiguration configuration;


        public MainRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("OracleConStr").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }



        public MainSaveReturnObj AddMainRecord(Main assure)
        {
            MainSaveReturnObj mainSaveReturnObj = new MainSaveReturnObj();

            try
            {
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var parameters = new DynamicParameters();
                parameters.Add("IPQuotationNo ", assure.QuotationNo);
                parameters.Add("IPRevisionNo ", assure.RevisionNo);
                parameters.Add("IPProposalNo ", assure.ProposalNo);
                parameters.Add("IPMedicalType ", assure.MedicalType);
                parameters.Add("IPPolicyNo ", assure.PolicyNo);
                parameters.Add("IPLoanAmount ", assure.LoanAmount);
                parameters.Add("IPInterest ", assure.Interest);
                parameters.Add("IPTerm ", assure.Term);
                parameters.Add("IPFullTermInMonths ", assure.FullTermInMonths);
                parameters.Add("IPGracePeriod ", assure.GracePeriod);
                parameters.Add("IPCompanyBufferId ", assure.CompanyBufferId);
                parameters.Add("IPCurrentAwplr ", assure.CurrentAwplr);
                parameters.Add("IPAdditionToAwplr ", assure.AdditionToAwplr);
                parameters.Add("IPTermOfFixedInterest ", assure.TermOfFixedInterest);
                parameters.Add("IPBankId ", assure.BankId);
                parameters.Add("IPBranchId ", assure.BranchId);
                parameters.Add("IPCurrencyId ", assure.CurrencyId);
                parameters.Add("IPInterestRateType ", assure.InterestRateType);
                parameters.Add("IPHnbaBranchCode ", assure.HnbaBranchCode);
                parameters.Add("IPBrokerCode ", assure.BrokerCode);
                parameters.Add("IPChannelCode ", assure.ChannelCode);
                parameters.Add("IPIsReInsurance ", assure.IsReInsurance);
                parameters.Add("IPLoanTypeId ", assure.LoanTypeId);
                parameters.Add("IPReInsCompanyId ", assure.ReInsCompanyId);
                parameters.Add("IPExchangeRate ", assure.ExchangeRate);
                parameters.Add("IPDateOfCommence ", assure.DateOfCommence);
                parameters.Add("IPDateOfProposal ", assure.DateOfProposal);
                parameters.Add("IPPremium ", assure.Premium);
                parameters.Add("IPPremiumWithPolicyFee ", assure.PremiumWithPolicyFee);
                parameters.Add("IPStatus ", assure.Status);
                parameters.Add("IPUserId ", assure.UserId);
                parameters.Add("IPProposalSendingMethod ", assure.ProposalSendingMethod);
                // parameters.Add("IPSystemDate ", assure.SystemDate);
                parameters.Add("IPIsValidated ", assure.IsValidated);
                parameters.Add("IPTempMainSeqId", assure.TempMainSeqId);
                parameters.Add("IPLife1HnbaRefNo ", assure.Life1HnbaRefNo);
                parameters.Add("IPLife1RiRefNo ", assure.Life1RiRefNo);
                parameters.Add("IPLife1HealthExtraBasic ", assure.Life1HealthExtraBasic);
                parameters.Add("IPLife1HealthExtraTpd ", assure.Life1HealthExtraTpd);
                parameters.Add("IPLife1OccuExtraBasic ", assure.Life1OccuExtraBasic);
                parameters.Add("IPLife1OccuExtraTpd ", assure.Life1OccuExtraTpd);
                parameters.Add("IPLife1OccuExtraPmileBasic ", assure.Life1OccuExtraPmileBasic);
                parameters.Add("IPLife1OccuExtraPmileTpd ", assure.Life1OccuExtraPmileTpd);
                parameters.Add("IPLife1Discount ", assure.Life1Discount);
                parameters.Add("IPLife1Loadings ", assure.Life1Loadings);
                parameters.Add("IPLife1IsTpd ", assure.Life1IsTpd);
                parameters.Add("IPLife1TpdOption ", assure.Life1TpdOption);
                parameters.Add("IPLife2HnbaRefNo ", assure.Life2HnbaRefNo);
                parameters.Add("IPLife2RiRefNo ", assure.Life2RiRefNo);
                parameters.Add("IPLife2HealthExtraBasic ", assure.Life2HealthExtraBasic);
                parameters.Add("IPLife2HealthExtraTpd ", assure.Life2HealthExtraTpd);
                parameters.Add("IPLife2OccuExtraBasic ", assure.Life2OccuExtraBasic);
                parameters.Add("IPLife2OccuExtraTpd ", assure.Life2OccuExtraTpd);
                parameters.Add("IPLife2OccuExtraPMileBasic ", assure.Life2OccuExtraPMileBasic);
                parameters.Add("IPLife2OccuExtraPMileTpd ", assure.Life2OccuExtraPMileTpd);
                parameters.Add("IPLife2Discount ", assure.Life2Discount);
                parameters.Add("IPLife2Loadings ", assure.Life2Loadings);
                parameters.Add("IPLife2IsTpd ", assure.Life2IsTpd);
                parameters.Add("IPLife2TpdOption ", assure.Life2TpdOption);
                parameters.Add("IPLifeAssure1Id ", assure.LifeAssure1Id);
                parameters.Add("IPLifeAssure2Id ", assure.LifeAssure2Id);

                parameters.Add("OPNewSeqNo", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);
                parameters.Add("OPNewJobNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

                if (conn.State == ConnectionState.Open)
                {
                    conn.ExecuteScalar<int>("InsertMRPSMain", parameters, commandType: CommandType.StoredProcedure);
                    mainSaveReturnObj.SeqId = parameters.Get<int>("OPNewSeqNo");
                    mainSaveReturnObj.JobNo = parameters.Get<string>("OPNewJobNo");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mainSaveReturnObj;
        }

        public MainSaveReturnObj AddMainRecordWithTransaction(Main assure, IDbConnection connection)
        {
            MainSaveReturnObj mainSaveReturnObj = new MainSaveReturnObj();

            try
            {
                var conn = connection;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var parameters = new DynamicParameters();
                parameters.Add("IPQuotationNo ", assure.QuotationNo);
                parameters.Add("IPRevisionNo ", assure.RevisionNo);
                //parameters.Add("IPProposalNo ", assure.ProposalNo);
                parameters.Add("IPMedicalType ", assure.MedicalType);
                parameters.Add("IPPolicyNo ", assure.PolicyNo);
                parameters.Add("IPLoanAmount ", assure.LoanAmount);
                parameters.Add("IPInterest ", assure.Interest);
                parameters.Add("IPTerm ", assure.Term);
                parameters.Add("IPFullTermInMonths ", assure.FullTermInMonths);
                parameters.Add("IPGracePeriod ", assure.GracePeriod);
                parameters.Add("IPCompanyBufferId ", assure.CompanyBufferId);
                parameters.Add("IPCurrentAwplr ", assure.CurrentAwplr);
                parameters.Add("IPAdditionToAwplr ", assure.AdditionToAwplr);
                parameters.Add("IPTermOfFixedInterest ", assure.TermOfFixedInterest);
                parameters.Add("IPBankId ", assure.BankId);
                parameters.Add("IPBranchId ", assure.BranchId);
                parameters.Add("IPCurrencyId ", assure.CurrencyId);
                parameters.Add("IPInterestRateType ", assure.InterestRateType);
                parameters.Add("IPHnbaBranchCode ", assure.HnbaBranchCode);
                parameters.Add("IPBrokerCode ", assure.BrokerCode);
                parameters.Add("IPChannelCode ", assure.ChannelCode);
                parameters.Add("IPIsReInsurance ", assure.IsReInsurance);
                parameters.Add("IPLoanTypeId ", assure.LoanTypeId);
                parameters.Add("IPReInsCompanyId ", assure.ReInsCompanyId);
                parameters.Add("IPExchangeRate ", assure.ExchangeRate);
                parameters.Add("IPDateOfCommence ", assure.DateOfCommence);
                parameters.Add("IPDateOfProposal ", assure.DateOfProposal);
                parameters.Add("IPPremium ", assure.Premium);
                parameters.Add("IPPremiumWithPolicyFee ", assure.PremiumWithPolicyFee);
                parameters.Add("IPStatus ", assure.Status);
                parameters.Add("IPUserId ", assure.UserId);
                parameters.Add("IPProposalSendingMethod ", assure.ProposalSendingMethod);
                // parameters.Add("IPSystemDate ", assure.SystemDate);
                parameters.Add("IPIsValidated ", assure.IsValidated);
                parameters.Add("IPTempMainSeqId", assure.TempMainSeqId);
                parameters.Add("IPLife1HnbaRefNo ", assure.Life1HnbaRefNo);
                parameters.Add("IPLife1RiRefNo ", assure.Life1RiRefNo);
                parameters.Add("IPLife1HealthExtraBasic ", assure.Life1HealthExtraBasic);
                parameters.Add("IPLife1HealthExtraTpd ", assure.Life1HealthExtraTpd);
                parameters.Add("IPLife1OccuExtraBasic ", assure.Life1OccuExtraBasic);
                parameters.Add("IPLife1OccuExtraTpd ", assure.Life1OccuExtraTpd);
                parameters.Add("IPLife1OccuExtraPmileBasic ", assure.Life1OccuExtraPmileBasic);
                parameters.Add("IPLife1OccuExtraPmileTpd ", assure.Life1OccuExtraPmileTpd);
                parameters.Add("IPLife1Discount ", assure.Life1Discount);
                parameters.Add("IPLife1Loadings ", assure.Life1Loadings);
                parameters.Add("IPLife1IsTpd ", assure.Life1IsTpd);
                parameters.Add("IPLife1TpdOption ", assure.Life1TpdOption);
                parameters.Add("IPLife2HnbaRefNo ", assure.Life2HnbaRefNo);
                parameters.Add("IPLife2RiRefNo ", assure.Life2RiRefNo);
                parameters.Add("IPLife2HealthExtraBasic ", assure.Life2HealthExtraBasic);
                parameters.Add("IPLife2HealthExtraTpd ", assure.Life2HealthExtraTpd);
                parameters.Add("IPLife2OccuExtraBasic ", assure.Life2OccuExtraBasic);
                parameters.Add("IPLife2OccuExtraTpd ", assure.Life2OccuExtraTpd);
                parameters.Add("IPLife2OccuExtraPMileBasic ", assure.Life2OccuExtraPMileBasic);
                parameters.Add("IPLife2OccuExtraPMileTpd ", assure.Life2OccuExtraPMileTpd);
                parameters.Add("IPLife2Discount ", assure.Life2Discount);
                parameters.Add("IPLife2Loadings ", assure.Life2Loadings);
                parameters.Add("IPLife2IsTpd ", assure.Life2IsTpd);
                parameters.Add("IPLife2TpdOption ", assure.Life2TpdOption);
                parameters.Add("IPLifeAssure1Id ", assure.LifeAssure1Id);
                parameters.Add("IPLifeAssure2Id ", assure.LifeAssure2Id);

                parameters.Add("OPNewSeqNo", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);
                parameters.Add("OPNewJobNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

                parameters.Add("OPNewProposalNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);


                if (conn.State == ConnectionState.Open)
                {
                    conn.ExecuteScalar<int>("InsertMRPSMain", parameters, commandType: CommandType.StoredProcedure);
                    mainSaveReturnObj.SeqId = parameters.Get<int>("OPNewSeqNo");
                    mainSaveReturnObj.JobNo = parameters.Get<string>("OPNewJobNo");
                    mainSaveReturnObj.ProposalNo = parameters.Get<string>("OPNewProposalNo");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mainSaveReturnObj;
        }



        public IEnumerable<Main> GetAllMainRecords()
        {
            throw new NotImplementedException();
        }

        public Main GetMainRecordById(int assureId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMainRecord(Main assure)
        {
            throw new NotImplementedException();
        }


        public string GenerateProposalNo(string bankCode)
        {
            string newProposalNo = "";
            try
            {

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var p = new DynamicParameters();
                p.Add("V_BANK_CODE", bankCode);

                p.Add("V_PROPOSAL_NO", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

                if (conn.State == ConnectionState.Open)
                {
                    conn.Execute("MRPS_GENERATE_PROPOSAL_NO", p, commandType: CommandType.StoredProcedure);
                    newProposalNo = p.Get<string>("V_PROPOSAL_NO");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return newProposalNo;




        }



        public MainSaveReturnObj SaveMain(Main main, Assure assure1, Assure assure2)
        {
            MainSaveReturnObj mainSaveReturnObj = new MainSaveReturnObj();

            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }


            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    mainSaveReturnObj = AddMainRecordWithTransaction(main, conn);


                    AssureRepository assureRepository = new AssureRepository(configuration);

                    int assure1Id = 0;
                    assure1Id = assureRepository.AddAssureWithTransaction(assure1, conn);
                    UpdateCustomerIdInMain(mainSaveReturnObj.SeqId, 1, assure1Id, conn);
                    if (assure2.Name != null)
                    {
                        if (assure2.Name != "")
                        {
                            int assure2Id = 0;
                            assure2Id = assureRepository.AddAssureWithTransaction(assure2, conn);
                            UpdateCustomerIdInMain(mainSaveReturnObj.SeqId, 2, assure2Id, conn);
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }

            }

            return mainSaveReturnObj;

        }

        public void UpdateCustomerIdInMain(int mainId, int assureType, int assureId, IDbConnection connection)
        {

            try
            {
                var conn = connection;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var p = new DynamicParameters();
                p.Add("IPSeqId", mainId);
                p.Add("IPAssureType", assureType);
                p.Add("IPLifeAssureId", assureId);


                if (conn.State == ConnectionState.Open)
                {
                    conn.Execute("UpdateMRPSMainAssureId", p, commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
