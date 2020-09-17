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
    public class CategoryPepository : ICategoryRepository
    {
        private readonly untoldContext _untoldContext;
        public CategoryPepository(untoldContext untoldContext)
        {
            _untoldContext = untoldContext;
        }
        public void DeleteCategory(int CategoryId)
        {
            var Category = _untoldContext.DictionaryConferenceCategory.Where(c => c.DictionaryConferenceCategoryId == CategoryId).FirstOrDefault();
            _untoldContext.DictionaryConferenceCategory.Remove(Category);
            _untoldContext.SaveChanges();
        }

        public BindingList<CategoryModel> GetConferenceCategories()
        {
            List<DictionaryConferenceCategory> categories = _untoldContext.DictionaryConferenceCategory.ToList();
            List<CategoryModel> categoryModels = categories.Select(c => new CategoryModel()
            {
                ConferenceCategoryId = c.DictionaryConferenceCategoryId,
                ConferenceCategoryName = c.ConferenceCategoryName
            }).ToList();
            BindingList<CategoryModel> categoryModelsList = new BindingList<CategoryModel>(categoryModels);
            return categoryModelsList;
        }

        public void InsertCategory(CategoryModel Category)
        {
            var category = new DictionaryConferenceCategory()
            {
                DictionaryConferenceCategoryId = Category.ConferenceCategoryId,
                ConferenceCategoryName = Category.ConferenceCategoryName
            };

            _untoldContext.DictionaryConferenceCategory.Add(category);
            _untoldContext.SaveChanges();
        }

        public void UpdateCategory(CategoryModel Category)
        {
            var category = _untoldContext.DictionaryConferenceCategory.Find(Category.ConferenceCategoryId);
            category.ConferenceCategoryName = Category.ConferenceCategoryName;
            _untoldContext.SaveChanges();
        }
    }
}
