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


        public BindingList<CountryModel> GetCountriesList()//-----
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

        public void InsertCountry(CountryModel Country)
        {
            string SqlText = "insert into DictionaryCountry values(@DictionaryCountryId, @CountryName, @CountryCode)";

            SqlCommand sqlCommand = new SqlCommand(SqlText, _sqlConnection);
            sqlCommand.Parameters.Add("@DictionaryCountryId", SqlDbType.Int);
            sqlCommand.Parameters["@DictionaryCountryId"].Value = Country.DictionaryCountryId;
            sqlCommand.Parameters.Add("@CountryName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CountryName"].Value = Country.CountryName;
            sqlCommand.Parameters.Add("@CountryCode", SqlDbType.Int);
            sqlCommand.Parameters["@CountryCode"].Value = Country.CountryCode;

            sqlCommand.ExecuteNonQuery();
        }

        public void UpdateCountry(CountryModel Country)
        {
            string SqlText = "update DictionaryCountry" +
                " set CountryName = @CountryName" +
                " where DictionaryCountryId = @DictionaryCountryId";
            SqlCommand sqlCommand = new SqlCommand(SqlText, _sqlConnection);
            sqlCommand.Parameters.Add("@CountryName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CountryName"].Value = Country.CountryName;
            sqlCommand.Parameters.Add("@DictionaryCountryId", SqlDbType.Int);
            sqlCommand.Parameters["@DictionaryCountryId"].Value = Country.DictionaryCountryId;


            sqlCommand.ExecuteNonQuery();
        }

        public string DeleteCountry(int objectId)
        {
            string error = "";
            string SqlText = "delete from DictionaryCountry" +
                " where DictionaryCountryId = @DictionaryCountryId";
            SqlCommand sqlCommand = new SqlCommand(SqlText, _sqlConnection);
            sqlCommand.Parameters.Add("@DictionaryCountryId", SqlDbType.NVarChar);
            sqlCommand.Parameters["@DictionaryCountryId"].Value = objectId;

            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error += "error";
            }
            return error;
        }

    }
}
