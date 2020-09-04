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
            throw new NotImplementedException();
        }

        public int LastDictionaryCityId()
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(CityModel cityModel)
        {
            throw new NotImplementedException();
        }
    }
}
