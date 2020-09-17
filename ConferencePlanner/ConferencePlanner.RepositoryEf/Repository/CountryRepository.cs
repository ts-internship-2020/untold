using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
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

            Conference conference = _untoldContext.Conference.Where(c => c.ConferenceId == id)
                .Include(x => x.Location)
                 .ThenInclude(x => x.City)
                 .ThenInclude(x => x.County)
                 .ThenInclude(x => x.Country)
                 .FirstOrDefault();

            return conference.Location.City.County.Country.DictionaryCountryId;

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
