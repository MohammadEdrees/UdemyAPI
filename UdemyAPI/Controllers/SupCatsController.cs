using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Services;
using UdemyAPI.Models;

namespace UdemyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SupCatsController : ControllerBase
    {
        IDB _db;

        public SupCatsController(IDB db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetSubCategoryById(int subCatId)
        {
            List<SupCateg> supCategs = _db.GetSupCategsById(subCatId);
            if (supCategs.Count > 0)
            {
                return Ok(supCategs);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public ActionResult<ICollection<SupCateg>> GetSupCategoryByCategoryId(int id)
        {
            List<SupCateg> supCategs = _db.GetSupCategoriesByCateogryId(id);
            if (supCategs.Count > 0)
            {
                return supCategs;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetSupCategoryByCategoryName(string CategoryName)
        {
            IEnumerable<SupCateg> supCategs = _db.supCategoriesByName(CategoryName);
            if (supCategs != null)
            {
                return Ok( supCategs );
            }
            else
            {
                return BadRequest("Something went Wrong");
            }
        }

    }
}
