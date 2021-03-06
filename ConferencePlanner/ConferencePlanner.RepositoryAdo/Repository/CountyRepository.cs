﻿using ConferencePlanner.Abstraction.Model;
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


        public BindingList<CountyModel> GetCountyList(int countryId)
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

        public void InsertCounty(CountyModel County)
        {
            string SqlText = "insert into DictionaryCounty values(@DictionaryCountyId, @CountyName, @CountryId)";

            SqlCommand sqlCommand = new SqlCommand(SqlText, _sqlConnection);
            sqlCommand.Parameters.Add("@DictionaryCountyId", SqlDbType.Int);
            sqlCommand.Parameters["@DictionaryCountyId"].Value = County.CountyId;
            sqlCommand.Parameters.Add("@CountyName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CountyName"].Value = County.CountyName;
            sqlCommand.Parameters.Add("@CountryId", SqlDbType.Int);
            sqlCommand.Parameters["@CountryId"].Value = County.CountryId;

            sqlCommand.ExecuteNonQuery();
        }


        public void UpdateCounty(CountyModel County)
        {
            string SqlText = "update DictionaryCounty" +
                " set CountyName = @CountyName" +
                " where DictionaryCountyId = @DictionaryCountyId";
            SqlCommand sqlCommand = new SqlCommand(SqlText, _sqlConnection);
            sqlCommand.Parameters.Add("@CountyName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CountyName"].Value = County.CountyName;
            sqlCommand.Parameters.Add("@DictionaryCountyId", SqlDbType.Int);
            sqlCommand.Parameters["@DictionaryCountyId"].Value = County.CountyId;


            sqlCommand.ExecuteNonQuery();
        }




        public string DeleteCounty(int objectId)
        {
            string error= "";
            string SqlText = "delete from DictionaryCounty" +
                " where DictionaryCountyId = @DictionaryCountyId";
            SqlCommand sqlCommand = new SqlCommand(SqlText, _sqlConnection);
            sqlCommand.Parameters.Add("@DictionaryCountyId", SqlDbType.NVarChar);
            sqlCommand.Parameters["@DictionaryCountyId"].Value = objectId;

            try{
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                error += "error";
            }
            return error;
        }


        public int GetLastCountyId()
        {
            int DistionaryCountyId = 0;
            string CommandText = "Select Top 1 DictionaryCountyId from DictionaryCounty order by DictionaryCountyId desc";
            SqlCommand sqlCommand = new SqlCommand(CommandText, _sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            DistionaryCountyId = sqlDataReader.GetInt32("DictionaryCountyId");
            sqlDataReader.Close();
            return DistionaryCountyId;
        }

        BindingList<CountyModel> ICountyRepository.GetCountyList(int CountryId)
        {
            throw new NotImplementedException();
        }

        void ICountyRepository.InsertCounty(CountyModel County)
        {
            throw new NotImplementedException();
        }

        void ICountyRepository.UpdateCounty(CountyModel County)
        {
            throw new NotImplementedException();
        }

        string ICountyRepository.DeleteCounty(int objectId)
        {
            throw new NotImplementedException();
        }

        int ICountyRepository.GetLastCountyId()
        {
            throw new NotImplementedException();
        }

        int ICountyRepository.GetCountyIdByCounferenceId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
