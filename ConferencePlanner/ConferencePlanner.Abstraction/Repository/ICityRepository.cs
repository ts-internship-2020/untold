﻿using ConferencePlanner.Abstraction.Model;
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

        public void InsertCity(CityModel cityModel);

        public void UpdateCity(CityModel cityModel);

        public int LastDictionaryCityId();

        public int GetCityIdByConferenceId(int conferenceId); 
    }
}
