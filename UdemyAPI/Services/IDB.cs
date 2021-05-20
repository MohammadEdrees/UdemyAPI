using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Models;

namespace UdemyAPI.Services
{
    public interface IDB
    {
        List<Category> GetAllCategories();

    }
}
