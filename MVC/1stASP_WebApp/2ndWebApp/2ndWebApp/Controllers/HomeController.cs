using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2ndWebApp.Models;
using _2ndWebApp.ViewModels;
namespace _2ndWebApp.Controllers
{
    public class HomeController : Controller
    {
        private  readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel 
            {
                PiesOfTheWeek=_pieRepository.PiesOfTheWeek 
            };

            return View(homeViewModel);
        }
    }
}
