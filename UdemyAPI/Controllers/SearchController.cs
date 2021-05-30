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
    public class SearchController : ControllerBase
    {
        IDB _db;

        public SearchController(IDB db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Topic>> GetAllTopics()
        {
            if (_db.GetAllTopics().Count > 0) return _db.GetAllTopics();
            else return NotFound();
        }
        [HttpGet]
        public ActionResult<List<object>> SearchData(string s)
        {

            if (s == null)
            {
                return BadRequest();
            }
            else
            {
                 return _db.GetSomeCoursesByTitle(s);
               
            }


        }






    }
}
