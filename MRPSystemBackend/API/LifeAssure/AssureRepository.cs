
using Dapper;
using Microsoft.Extensions.Configuration;
using MRPSystemBackend.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace MRPSystemBackend.API.LifeAssure
{
    public class AssureRepository : IAssureRepository
    {
        IConfiguration configuration;

        public AssureRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

  

        public int AddAssure(Assure assure)
        {
            int customerID =0;

            try
            {
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var parameters = new DynamicParameters();
                parameters.Add("IPAssureType", assure.AssureType);
                parameters.Add("IPName", assure.Name);
                parameters.Add("IPDOB", assure.DOB);
                parameters.Add("IPAge", assure.Age);
                parameters.Add("IPGender", assure.Gender);
                parameters.Add("IPNIC", assure.NIC);
                parameters.Add("IPNationalityId", assure.NationalityId);
                parameters.Add("IPOccupation", assure.Occupation);
                parameters.Add("IPContactNo", assure.ContactNo);
                parameters.Add("IPEmail", assure.Email);
                parameters.Add("IPAddress", assure.Address);
                parameters.Add("IPHeightCm", assure.HeightCm);
                parameters.Add("IPHeightInch", assure.HeightInch);
                parameters.Add("IPWeightKg", assure.WeightKg);
                parameters.Add("IPWeightLbs", assure.WeightLbs);
                parameters.Add("IPBMI", assure.BMI);
                parameters.Add("IPPreviousPolicyAmount", assure.PreviousPolicyAmount);
                parameters.Add("IPIsAgeAdmitted", assure.IsAgeAdmitted);
                parameters.Add("IPIsSmoker", assure.IsSmoker);
                parameters.Add("IPIsFemaleRebate", assure.IsFemaleRebate);
                parameters.Add("IPIsVIP", assure.IsVIP);


                parameters.Add("OPCustomerId", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);

                if (conn.State == ConnectionState.Open)
                {
                    conn.ExecuteScalar<int>("InsertMRPSAssure", parameters, commandType: CommandType.StoredProcedure);
                    customerID = parameters.Get<int>("OPCustomerId");

                }

            }catch(Exception ex)
            {
                throw ex;
            }
            return customerID;
        }


        public int AddAssureWithTransaction(Assure assure, IDbConnection connection)
        {
            int customerID = 0;

            try
            {
                var conn = connection;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var parameters = new DynamicParameters();
                parameters.Add("IPAssureType", assure.AssureType);
                parameters.Add("IPName", assure.Name);
                parameters.Add("IPDOB", assure.DOB);
                parameters.Add("IPAge", assure.Age);
                parameters.Add("IPGender", assure.Gender);
                parameters.Add("IPNIC", assure.NIC);
                parameters.Add("IPNationalityId", assure.NationalityId);
                parameters.Add("IPOccupation", assure.Occupation);
                parameters.Add("IPContactNo", assure.ContactNo);
                parameters.Add("IPEmail", assure.Email);
                parameters.Add("IPAddress", assure.Address);
                parameters.Add("IPHeightCm", assure.HeightCm);
                parameters.Add("IPHeightInch", assure.HeightInch);
                parameters.Add("IPWeightKg", assure.WeightKg);
                parameters.Add("IPWeightLbs", assure.WeightLbs);
                parameters.Add("IPBMI", assure.BMI);
                parameters.Add("IPPreviousPolicyAmount", assure.PreviousPolicyAmount);
                parameters.Add("IPIsAgeAdmitted", assure.IsAgeAdmitted);
                parameters.Add("IPIsSmoker", assure.IsSmoker);
                parameters.Add("IPIsFemaleRebate", assure.IsFemaleRebate);
                parameters.Add("IPIsVIP", assure.IsVIP);


                parameters.Add("OPCustomerId", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);

                if (conn.State == ConnectionState.Open)
                {


                    conn.ExecuteScalar<int>("InsertMRPSAssure", parameters, commandType: CommandType.StoredProcedure);
                    customerID = parameters.Get<int>("OPCustomerId");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerID;
        }

        public Assure GetAssureById(int assureId)
        {
            Assure result = null;
          

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("IPAssureId", OracleDbType.Int32, ParameterDirection.Input, assureId);
                dyParam.Add("OPAssureCursor", OracleDbType.RefCursor, ParameterDirection.Output);



                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSGetAssureByID";

                    result = SqlMapper.QueryFirst<Assure>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;




        }

        public IEnumerable<Assure> GetAssures()
        {
            IEnumerable<Assure> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("AssureCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "GetAllAssures";

                    result = SqlMapper.Query<Assure>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public IEnumerable<Assure> SearchAssures(SearchAssure searchAssure)
        {
            IEnumerable<Assure> result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("IPName", OracleDbType.Varchar2, ParameterDirection.Input, searchAssure.Name);
                dyParam.Add("IPNIC", OracleDbType.Varchar2, ParameterDirection.Input, searchAssure.NIC);
                dyParam.Add("IPAddress", OracleDbType.Varchar2, ParameterDirection.Input, searchAssure.Address);


                dyParam.Add("OPAssureCursor", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "MRPSSearchAssures";

                    result = SqlMapper.Query<Assure>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public int UpdateAssure(Assure assure)
        {
            int result = 0;
            try
            {
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                var parameters = new DynamicParameters();
                parameters.Add("IPSeqId", assure.SeqId);
                parameters.Add("IPAssureType", assure.AssureType);
                parameters.Add("IPName", assure.Name);
                parameters.Add("IPDOB", assure.DOB);
                parameters.Add("IPAge", assure.Age);
                parameters.Add("IPGender", assure.Gender);
                parameters.Add("IPNIC", assure.NIC);
                parameters.Add("IPNationalityId", assure.NationalityId);
                parameters.Add("IPOccupation", assure.Occupation);
                parameters.Add("IPContactNo", assure.ContactNo);
                parameters.Add("IPEmail", assure.Email);
                parameters.Add("IPAddress", assure.Address);
                parameters.Add("IPHeightCm", assure.HeightCm);
                parameters.Add("IPHeightInch", assure.HeightInch);
                parameters.Add("IPWeightKg", assure.WeightKg);
                parameters.Add("IPWeightLbs", assure.WeightLbs);
                parameters.Add("IPBMI", assure.BMI);
                parameters.Add("IPPreviousPolicyAmount", assure.PreviousPolicyAmount);
                parameters.Add("IPIsAgeAdmitted", assure.IsAgeAdmitted);
                parameters.Add("IPIsSmoker", assure.IsSmoker);
                parameters.Add("IPIsFemaleRebate", assure.IsFemaleRebate);
                parameters.Add("IPIsVIP", assure.IsVIP);

                

                if (conn.State == ConnectionState.Open)
                {
                    conn.Execute("UpdateMRPSAssure", parameters, commandType: CommandType.StoredProcedure);

                    result = 1;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("OracleConStr").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }

      
    }
}
