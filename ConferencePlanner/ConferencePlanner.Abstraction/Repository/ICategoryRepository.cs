using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ICategoryRepository
    {
        BindingList<CategoryModel> GetConferenceCategories();

        void InsertCategory(CategoryModel Category);
        void UpdateCategory(CategoryModel Category);
        void DeleteCategory(int CategoryId);
    }
}
