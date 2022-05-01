using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2ndWebApp.Models;
namespace _2ndWebApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }

    }
}
