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
    public class CityRepository : ICityRepository
    {
        private readonly SqlConnection _sqlConnection;
        public CityRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public BindingList<CityModel> GetCitiesByCountyId(int countyId)
        {
            string commandText = "select DictionaryCityId, CityName, CountyId from DictionaryCity where CountyId = @CountyId";
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@CountyId", SqlDbType.Int);
            sqlCommand.Parameters["@CountyId"].Value = countyId;
            BindingList<CityModel> CityList = new BindingList<CityModel>();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    CityList.Add(new CityModel()
                    {
                        DictionaryCityId = sqlDataReader.GetInt32("DictionaryCityId"),
                        CityName = sqlDataReader.GetString("CityName"),
                        CountyId = sqlDataReader.GetInt32("CountyId")
                    });
                }
            }
            sqlDataReader.Close();
            return CityList;
        }

        public string DeleteCity(int cityId)
        {
            string errorMessage = "";
            string commandText = "delete from DictionaryCity where DictionaryCityId = @Id";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = cityId;
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                errorMessage += "error";
            }
            return errorMessage;
        }

        public void InsertCity(CityModel cityModel)
        {
            string commandText = "insert into DictionaryCity values(@DictionaryCityId, @CityName, @CountyId)";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@DictionaryCityId", SqlDbType.Int);
            sqlCommand.Parameters["@DictionaryCityId"].Value = cityModel.DictionaryCityId;
            sqlCommand.Parameters.Add("@CityName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CityName"].Value = cityModel.CityName;
            sqlCommand.Parameters.Add("@CountyId", SqlDbType.Int);
            sqlCommand.Parameters["@CountyId"].Value = cityModel.CountyId;
            sqlCommand.ExecuteNonQuery();
        }

        public void UpdateCity(CityModel cityModel)
        {
            string commandText = "update DictionaryCity set CityName = @CityName where DictionaryCityId = @Id";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@CityName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CityName"].Value = cityModel.CityName;
            sqlCommand.Parameters.Add("@Id", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Id"].Value = cityModel.DictionaryCityId;


            sqlCommand.ExecuteNonQuery();
        }

        public int LastDictionaryCityId ()
        {
            int dictionaryCityId = 0;
            string commandText = "SELECT TOP 1 DictionaryCityId FROM DictionaryCity ORDER BY DictionaryCityId DESC ";
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            dictionaryCityId = sqlDataReader.GetInt32("DictionaryCityId");
            sqlDataReader.Close();
            return dictionaryCityId;
        }

        public int GetCityIdByConferenceId(int conferenceId)
        {
            throw new NotImplementedException();
        }
    }
}
