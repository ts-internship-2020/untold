using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class CountyRepository : ICountyRepository
    {
        private readonly SqlConnection _sqlConnection;

        public CountyRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public List<CountyModel> GetCountyList(int countryId)
        {
            List<CountyModel> CountyList = new List<CountyModel>();
            
            string CommandText = "select DictionaryCountyId, CountyName, CountryId from DictionaryCounty" + 
                "where CountryId = @CountryId";
            SqlCommand sqlCommand = new SqlCommand(CommandText, _sqlConnection);
            sqlCommand.Parameters.Add("@CountryId", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CountryId"].Value = countryId;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    CountyList.Add(new CountyModel()
                    {
                        CountyId=sqlDataReader.GetInt32("DictionaryCountyId"),
                        CountyName=sqlDataReader.GetString("ContyName"),
                        CountryId=sqlDataReader.GetInt32("ContryName")
                    });
                }
            }
            sqlDataReader.Close();
            return CountyList;
        }

        public BindingList<CountyModel> GetCountyListBind(int countryId)
        {
            string CommandText = "select DictionaryCountyId, CountyName, CountryId from DictionaryCounty " +
            "where CountryId = @CountryId AND DictionaryCountyId!=0";
            SqlCommand sqlCommand = new SqlCommand(CommandText, _sqlConnection);
            sqlCommand.Parameters.Add("@CountryId", SqlDbType.Int);
            sqlCommand.Parameters["@CountryId"].Value = countryId;
            BindingList<CountyModel> CountyList = new BindingList<CountyModel>();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    CountyList.Add(new CountyModel()
                    {
                        CountyId = sqlDataReader.GetInt32("DictionaryCountyId"),
                        CountyName = sqlDataReader.GetString("CountyName"),
                        CountryId = countryId
                    });
                }
            }
            sqlDataReader.Close();
            return CountyList;
        }

        public BindingList<CountyModel> GetCountyList()
        {
            throw new NotImplementedException();
        }
    }
}
