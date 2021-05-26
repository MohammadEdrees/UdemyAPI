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
    public class AdminsController : ControllerBase
    {
        IDB _db;

        public AdminsController(IDB db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAllAdmins() 
        {
            if (_db.GetAllAdmins().Count > 0) return _db.GetAllAdmins();
            else return NotFound();
        }
    }
}
