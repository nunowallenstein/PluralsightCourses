﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2ndWebApp.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
