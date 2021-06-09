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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IDB _db;
        public CategoriesController(IDB db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories()
        {
            return _db.GetAllCategories();
        }
        [HttpGet]
        public ActionResult<Category> GetCategoryById(int id) {

            return _db.GetCategoryById(id);
        }

        [HttpGet]
        public IActionResult GetTop8Categories()
        {
            return Ok(_db.GetTop8Categories());
        }



    }
}
