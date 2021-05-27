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
    public class TopicsController : ControllerBase
    {
        IDB _db;

        public TopicsController(IDB db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Topic>>GetAllTopics()
        {
            if (_db.GetAllTopics().Count > 0) return _db.GetAllTopics();
            else return NotFound();
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Topic>>GetTopicsBySupCatId(int supCatId)
        {
           List<Topic>Foundtopics = _db.GetTopicsBySupCategId(supCatId);
            if (Foundtopics.Count>0)
            {
                return Foundtopics;
            }
            else
            {
                return BadRequest();
            }
        }




    }
}
