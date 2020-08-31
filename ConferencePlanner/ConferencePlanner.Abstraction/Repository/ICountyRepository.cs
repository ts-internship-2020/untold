using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ICountyRepository
    {
        BindingList<CountyModel> GetCountyList(int CountryId);

        void InsertCounty(CountyModel County);
        void UpdateCounty(CountyModel County);
        string DeleteCounty(int objectId);
    }
}
