using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("get_categories")]
        public IActionResult GetConferenceCategories()
        {
            BindingList<CategoryModel> categoryModels = _categoryRepository.GetConferenceCategories();
            return Ok(categoryModels);
        }

        [HttpPost]
        [Route("insert_category")]
        public IActionResult InsertCategory(CategoryModel categoryModel)
        {
            _categoryRepository.InsertCategory(categoryModel);
            return Ok();
        }


        [HttpPost]
        [Route("update_category")]
        public IActionResult UpdateCategory(CategoryModel categoryModel)
        {
            _categoryRepository.UpdateCategory(categoryModel);
            return Ok();
        }

        [HttpDelete]
        [Route("delete_category")]
        public IActionResult DeleteCategory(int CategoryId)
        {
            _categoryRepository.DeleteCategory(CategoryId);
            return Ok();
        }
    }
}
