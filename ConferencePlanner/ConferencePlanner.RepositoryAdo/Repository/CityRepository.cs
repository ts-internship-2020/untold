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
            string commandText = "select DictionaryCityId, CityName from DictionaryCity where CountyId = @CountyId";
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
                        CityName = sqlDataReader.GetString("CityName")
                    });
                }
            }
            sqlDataReader.Close();
            return CityList;
        }
    }
}
