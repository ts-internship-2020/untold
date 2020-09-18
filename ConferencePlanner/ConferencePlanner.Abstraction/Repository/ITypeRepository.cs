using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ITypeRepository
    {

        BindingList<TypeModel> GetConferenceType();
        TypeModel GetTypeById(int id);
        
        void UpdateType(TypeModel type);
        void InsertType(TypeModel type);

        int LastTypeId();

        void DeleteType(int id);
    }
}
