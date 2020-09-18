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
    public class CityRepository : ICityRepository
    {

        private readonly untoldContext _untoldContext;

        public CityRepository(untoldContext untoldContext)
        {
            _untoldContext = untoldContext;
        }

        public BindingList<CityModel> GetCitiesByCountyId(int countyId)
        {
            List<DictionaryCity> dictionaryCities = _untoldContext.DictionaryCity.Where(c => c.CountyId == countyId).ToList();
            List<CityModel> cityModels = dictionaryCities.Select(cM => new CityModel()
            {
                DictionaryCityId = cM.DictionaryCityId,
                CityName = cM.CityName,
                CountyId = cM.CountyId
            }).ToList();

            BindingList<CityModel> cityModels1 = new BindingList<CityModel>(cityModels);
            return cityModels1;
        }

        public String DeleteCity(int CityId)
        {
            string error = "";
            try
            {
                DictionaryCity dictionaryCity = _untoldContext.DictionaryCity.Where(c => c.DictionaryCityId == CityId).FirstOrDefault();
                _untoldContext.DictionaryCity.Remove(dictionaryCity);
            }
            catch (Exception e)
            {
                error += "error";
            }
            _untoldContext.SaveChanges();
            return error;
            }

        public void InsertCity(CityModel cityModel)
        {
            DictionaryCity dictionaryCity = new DictionaryCity()
            {
                DictionaryCityId = cityModel.DictionaryCityId,
                CityName = cityModel.CityName,
                CountyId = cityModel.CountyId
            };

            _untoldContext.DictionaryCity.Add(dictionaryCity);
            _untoldContext.SaveChanges();
        }

        public int LastDictionaryCityId()
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(CityModel cityModel)
        {
            DictionaryCity dictionaryCity = _untoldContext.DictionaryCity.Find(cityModel.DictionaryCityId);
            dictionaryCity.CityName = cityModel.CityName;
            dictionaryCity.CountyId = cityModel.CountyId;
            _untoldContext.SaveChanges();
        }

        public int GetCityIdByConferenceId(int conferenceId)
        {
            Conference conference = _untoldContext.Conference.Where(c => c.ConferenceId == conferenceId)
                .Include(x => x.Location)
                .ThenInclude(x => x.City)
                .FirstOrDefault();

            return conference.Location.City.DictionaryCityId;
        }
    }
}
