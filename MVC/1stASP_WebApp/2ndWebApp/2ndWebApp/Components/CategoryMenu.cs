using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2ndWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using _2ndWebApp.ViewModels;
namespace _2ndWebApp.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {

            var categories = _categoryRepository.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }

    }
}
