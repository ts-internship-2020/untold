using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ICountryRepository
    {
        List<CountryModel> GetListCountry();

        int GetCountryIdByConferenceId(int id);
        BindingList<CountryModel> GetCountriesList();

        void InsertCountry(CountryModel Country);

        void UpdateCountry(CountryModel Country);

        string DeleteCountry(int objectId);

    }
}
