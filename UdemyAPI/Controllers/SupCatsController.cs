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
        public ActionResult<ICollection<SupCateg>> GetSupCategoryByCategoryId(int id)
        {
            List<SupCateg> supCategs = _db.GetSupCategoriesById(id);
            if (supCategs.Count > 0)
            {
                return supCategs;
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
