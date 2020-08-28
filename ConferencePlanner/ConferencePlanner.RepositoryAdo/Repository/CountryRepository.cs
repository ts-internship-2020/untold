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
            sqlCommandCountry.CommandText = "select DictionaryCountryId, CountryCode, CountryName from DictionaryCountry order by CountryName";
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

        public int GetCountryIdByConferenceId(int id)
        {
            
            string commandText = "select DictionaryCountryId from Conference C " +
                "join vwLocationIds vwL on C.LocationId = vwL.LocationId " +
                "where ConferenceId = @ConferenceId";
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            
            sqlCommand.Parameters.Add("@ConferenceId", SqlDbType.Int);
            sqlCommand.Parameters["@ConferenceId"].Value = id;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int ID = 0;
            if (sqlDataReader.Read())
            {
                ID =(int)sqlDataReader.GetInt32("DictionaryCountryId");
            }
           
            sqlDataReader.Close();

            return ID;

        }


        public BindingList<CountryModel> GetCountriesList()
        {
            SqlCommand sqlCommandCountry = _sqlConnection.CreateCommand();
            sqlCommandCountry.CommandText = "select DictionaryCountryId, CountryCode, CountryName from DictionaryCountry order by CountryName";
            SqlDataReader sqlDataReader = sqlCommandCountry.ExecuteReader();
            BindingList<CountryModel> countrylist = new BindingList<CountryModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    countrylist.Add(new CountryModel()
                    {
                        DictionaryCountryId = sqlDataReader.GetInt32("DictionaryCountryId"),
                        CountryCode = sqlDataReader.GetString("CountryCode"),
                        CountryName = sqlDataReader.GetString("CountryName")

                    });
                }
            }

            sqlDataReader.Close();
            return countrylist;
        }
    }
}
