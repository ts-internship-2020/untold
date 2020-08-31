using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ICityRepository
    {
        public BindingList<CityModel> GetCitiesByCountyId(int countyId);

        public string DeleteCity(int CityId);
    }
}
