using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly SqlConnection _sqlConnection;

        public CountryRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public List<CountryModel> GetListCountry()
        {
            SqlCommand sqlCommandCountry = _sqlConnection.CreateCommand();
            sqlCommandCountry.CommandText = "select DictionaryCountryId, CountryCode, CountryName from DictionaryCountry ";
            SqlDataReader sqlDataReader = sqlCommandCountry.ExecuteReader();

            List<CountryModel> countrylist = new List<CountryModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    countrylist.Add(new CountryModel()
                    {
                        DictionaryCountryId = sqlDataReader.GetInt32("DictionaryCountryId"),
                        CountryCode = sqlDataReader.GetString("CountryCode"),
                        CountryName = sqlDataReader.GetString("CountryName")

                    }) ;
                }
            }

            sqlDataReader.Close();
            return countrylist;
        }
    }
}
