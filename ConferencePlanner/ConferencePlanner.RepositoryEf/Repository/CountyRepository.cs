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
    public class CountyRepository : ICountyRepository
    {

        private readonly untoldContext _untoldContext;

        public CountyRepository(untoldContext untoldContext)
        {
            _untoldContext = untoldContext;
        }

        public string DeleteCounty(int objectId)
        {
            string error = "";
            var County = _untoldContext.DictionaryCounty.Where(c => c.DictionaryCountyId == objectId).FirstOrDefault();
            try
            {
                _untoldContext.DictionaryCounty.Remove(County);
                _untoldContext.SaveChanges();
            }
            catch
            {
                error += "error";
            }
            return error;
        }

        public BindingList<CountyModel> GetCountyList(int CountryId)
        {
            List<DictionaryCounty> counties = _untoldContext.DictionaryCounty.Where(c => c.CountryId == CountryId).ToList();
            List<CountyModel> countyModels = counties.Select(c => new CountyModel()
            {
                CountyId = c.DictionaryCountyId,
                CountyName = c.CountyName,
                CountryId = c.CountryId
            }).ToList();
            BindingList<CountyModel> countyModelsList = new BindingList<CountyModel>(countyModels);
            return countyModelsList;
        }

        public int GetLastCountyId()
        {
            int LastId = _untoldContext.DictionaryCounty.OrderByDescending(c => c.DictionaryCountyId).Select(c => c.DictionaryCountyId).FirstOrDefault();
            return LastId;
        }

        public void InsertCounty(CountyModel county)
        {
            var County = new DictionaryCounty()
            {
                DictionaryCountyId = county.CountyId,
                CountyName = county.CountyName,
                CountryId = county.CountryId
            };

            _untoldContext.DictionaryCounty.Add(County);
            _untoldContext.SaveChanges();
        }

        public void UpdateCounty(CountyModel County)
        {
            var county = _untoldContext.DictionaryCounty.Find(County.CountyId);
            county.CountyName = County.CountyName;
            _untoldContext.SaveChanges();
        }
    }
}
