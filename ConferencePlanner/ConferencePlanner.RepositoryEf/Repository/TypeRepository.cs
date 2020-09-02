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
    public class TypeRepository : ITypeRepository
    {
        private readonly untoldContext _untoldContext;
        public TypeRepository(untoldContext untoldContext)
        {
            //_dbContext = dbContext;
            _untoldContext = untoldContext;
        }
        public BindingList<TypeModel> GetConferenceType()
        {
            List<DictionaryConferenceType> types = _untoldContext.DictionaryConferenceType.ToList();

            List<TypeModel> typemodels = types.Select(t => new TypeModel() { TypeId =t.DictionaryConferenceTypeId, TypeName = t.ConferenceTypeName }).ToList();
            BindingList<TypeModel> typeslist = new BindingList<TypeModel>(typemodels);
            return typeslist;
        }
        public void UpdateType(TypeModel typeModel)
        {

            var typesconference = _untoldContext.DictionaryConferenceType.Find(typeModel.TypeId);
            typesconference.ConferenceTypeName = typeModel.TypeName;
            _untoldContext.SaveChanges();

        }

        public void InsertType(TypeModel typeModel)
        {
            //string commandText = "insert into DictionaryConferenceType values(@Id, @Name)";
            var types = new DictionaryConferenceType()
            {
                DictionaryConferenceTypeId = typeModel.TypeId,
                ConferenceTypeName = typeModel.TypeName
            };
            _untoldContext.DictionaryConferenceType.Add(types);
            _untoldContext.SaveChanges();

        }

        public void DeleteType(int id)
        {
            //string commandText = "delete from DictionaryConferenceType where DictionaryConferenceTypeId = @Id";
            var del = _untoldContext.DictionaryConferenceType.Find(id);
            _untoldContext.DictionaryConferenceType.Remove(del);
            _untoldContext.SaveChanges();
        }

        public TypeModel GetTypeById(int id)
        {
            //string commandText = "select DictionaryConferenceTypeId,ConferenceTypeName from DictionaryConferenceType where DictionaryConferenceTypeId = @Id";
            //DictionaryConferenceType types = _untoldContext.DictionaryConferenceType.Where(a => a.DictionaryConferenceTypeId == id).Select(a => a.DictionaryConferenceTypeId,a=>a.C);
            //DictionaryConferenceType types = _untoldContext.DictionaryConferenceType.Select(a => new DictionaryConferenceType() { DictionaryConferenceTypeId = a.DictionaryConferenceTypeId, ConferenceTypeName = a.ConferenceTypeName });
            var type = _untoldContext.DictionaryConferenceType.Find(id);
            TypeModel types = new TypeModel
            {
                TypeId = type.DictionaryConferenceTypeId,
                TypeName = type.ConferenceTypeName,
            };
            return types;
        }







    }
}
