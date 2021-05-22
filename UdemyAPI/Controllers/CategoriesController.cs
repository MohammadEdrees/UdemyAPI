using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Models;
using UdemyAPI.Services;
namespace UdemyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IDB _db;
        public CategoriesController(IDB db)
        {
            _db = db;
        }
        public List<Category> GetAllCategories()
        {
            return (_db.GetAllCategories());
        }
        //public void RegisterInstructor(Instructor s)
        //{
        //    _db.addInstructor(s);
        //}
        //Upload img with path 

    }
}
