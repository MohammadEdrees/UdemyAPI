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
        [HttpGet]
        public IActionResult GetTopicsInCategory(int id)
        {
            return Ok(_db.GetTopicsInCategory(id));
        }

        [HttpGet]
        public IActionResult GetTopicByTopicId(int Topicd)
        {
            Topic topic = _db.GetTopicByTopicId(Topicd);
                if (topic != null)
                    return Ok(topic);

            return BadRequest("Topic Id Is Wrong ");
            
        }

        [HttpDelete]
        public IActionResult DeleteStudentByHisId(int id)
        {
            if (id > 0)
            {
                Student student = _db.GetStudentById(id);
                if(student!=null)
                return Ok(_db.DeleteStudent(student));
            }
            return BadRequest("Error In Delete ");
        }



    }
}
