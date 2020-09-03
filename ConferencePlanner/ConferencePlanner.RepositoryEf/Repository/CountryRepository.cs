using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly untoldContext _untoldContext;

        public CountryRepository(untoldContext untoldContext)
        {
            //_dbContext = dbContext;
            _untoldContext = untoldContext;
        }

        
        public BindingList<CountryModel> GetCountriesList()
        {
            List<DictionaryCountry> country = _untoldContext.DictionaryCountry.ToList();
            List<CountryModel> countryModels = country.Select(c => new CountryModel()
            {
                DictionaryCountryId = c.DictionaryCountryId,
                CountryCode = c.CountryCode,
                CountryName = c.CountryName
            }).ToList();
            BindingList<CountryModel> countriesBindingList = new BindingList<CountryModel>(countryModels);

            return countriesBindingList;

        }

        public int GetCountryIdByConferenceId(int id)
        {
            throw new NotImplementedException();
        }

        /*
        
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


         */

        public List<CountryModel> GetListCountry()
        {
            throw new NotImplementedException();
        }

        public void InsertCountry(CountryModel countryModel)
        {
            var country = new DictionaryCountry()
            {
                DictionaryCountryId = countryModel.DictionaryCountryId,
                CountryName = countryModel.CountryName,
                CountryCode = countryModel.CountryCode
                
            };

            _untoldContext.DictionaryCountry.Add(country);
            _untoldContext.SaveChanges();

        }

        public void UpdateCountry(CountryModel Country)
        {
            var country = _untoldContext.DictionaryCountry.Find(Country.DictionaryCountryId);
            country.CountryName = Country.CountryName;
            country.CountryCode = Country.CountryCode;
            _untoldContext.SaveChanges();
        }

        public string DeleteCountry(int objectId)
        {
            string error = "";

            try
            {
                var country = _untoldContext.DictionaryCountry.Where(c => c.DictionaryCountryId == objectId).FirstOrDefault();

                _untoldContext.DictionaryCountry.Remove(country);

            }
            catch (Exception e)
            {
                error += "error";
            }
            _untoldContext.SaveChanges();
            return error;
        }



    }
}
