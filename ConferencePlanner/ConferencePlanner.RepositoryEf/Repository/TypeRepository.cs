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

            List<TypeModel> typeModels = types.Select(t => new TypeModel() { 
                TypeId =t.DictionaryConferenceTypeId, 
                TypeName = t.ConferenceTypeName 
            }).ToList();
            
            BindingList<TypeModel> typesList = new BindingList<TypeModel>(typeModels);
            return typesList;
        }
        public void UpdateType(TypeModel typeModel)
        {

            DictionaryConferenceType type = _untoldContext
                .DictionaryConferenceType
                .FirstOrDefault(t => t.DictionaryConferenceTypeId == typeModel.TypeId);
            if (type == null)
            {
                return;
            }
            type.ConferenceTypeName = typeModel.TypeName;
            _untoldContext.SaveChanges();

        }

        public void InsertType(TypeModel typeModel)
        {
            
            DictionaryConferenceType type = new DictionaryConferenceType()
            {
                DictionaryConferenceTypeId = typeModel.TypeId,
                ConferenceTypeName = typeModel.TypeName
            };
            _untoldContext.DictionaryConferenceType.Add(type);
            _untoldContext.SaveChanges();

        }

        public void DeleteType(int id)
        {
            //string commandText = "delete from DictionaryConferenceType where DictionaryConferenceTypeId = @Id";
            DictionaryConferenceType type = _untoldContext.DictionaryConferenceType.FirstOrDefault(t => t.DictionaryConferenceTypeId == id);
            if (type == null)
            {
                return;
            }
            _untoldContext.DictionaryConferenceType.Remove(type);
            _untoldContext.SaveChanges();
        }

        public TypeModel GetTypeById(int id)
        {
            
            DictionaryConferenceType type = _untoldContext.DictionaryConferenceType.Where(t => t.DictionaryConferenceTypeId==id).FirstOrDefault();
            TypeModel typeModel = new TypeModel
            {
                TypeId = type.DictionaryConferenceTypeId,
                TypeName = type.ConferenceTypeName,
            };
            return typeModel;
        }

    }
}
