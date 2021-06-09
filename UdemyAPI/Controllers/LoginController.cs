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
    public class LoginController : ControllerBase
    {
        IDB _db;

        public LoginController(IDB db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> login(UserModel user)
        {
            
            if (ModelState.IsValid)
            {
               var result = await _db.Login(user);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            else {
                return  BadRequest("Invalid data");
            }

        }

        //[HttpGet("Stream/Url/{*videoUrl}")]
        //public async Task<FileStreamResult> GetStreamFromUrlAsync(string videoUrl)
        //{
        //    var stream = await _streamingService.GetVideoByUrlAsync(videoUrl).ConfigureAwait(false);
        //    return new FileStreamResult(stream, "video/mp4");
        //}
        
    }
}
