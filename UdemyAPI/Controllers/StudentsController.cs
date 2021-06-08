using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using UdemyAPI.Models;
using UdemyAPI.Services;


namespace UdemyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IDB _db;
        private static string ApiKey = "AIzaSyD0MQz8q3CFW16JRY11lHctKPSShXxhs7Q";
        private static string Bucket = "udemy-3c633.appspot.com";
        private static string AuthMail = "medoenoch@gmail.com";
        private static string Password = "newstart2020";
        
        public StudentsController(IDB db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            if (_db.GetAllStudents().Count > 0)
                return Ok(_db.GetAllStudents());
            return BadRequest(" There is no students yet ");

        }
        [HttpPost]
        public IActionResult StudentRegistration(Student s)
        {
            if (s == null)
                return BadRequest("Check Student data please");

            if (_db.GetStudentByMail(s.Mail) != null)
                return BadRequest("Mail is Exists Try another one"); 

            if (ModelState.IsValid)
            {

                 return Ok(_db.AddStudent(s));
            }
            else
            {
                return BadRequest("Values Are not ok");

            }

        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            Student foundStd =_db.GetStudentById(id);
            if (foundStd != null)
            {
                _db.RemoveStudent(foundStd);
                return Ok("Deleted Successful");
            }
            else
            {

                return BadRequest("Invalid Id");
            }
        }
        [HttpPut("{id}")]
        public IActionResult testEdit(int id,Student newS)
        {
            //DataBinding ["","",""]
            //Images
            
            if (id > 0)
            {
                Student OldStd = _db.GetStudentById(id);
                if (OldStd == null)
                   return NotFound($"Student Not Found you id is {id}");
                
                if(OldStd.StdId!=newS.StdId)
                    return BadRequest($"OldID is{OldStd.StdId}:NEWID is {newS.StdId}");
                else
                {
                 Student EditedStd =_db.EditStudent(OldStd, newS);
                  return Ok(EditedStd);
  
                }

            }
            else
            {
                return BadRequest("Some thing went wrong");
            }
        }

        //[HttpPost("UploadFile")]
        //public async Task<IActionResult> UploadFile( IFormFile file)
        //{
        //    string fName = file.FileName;
        //    string path = Path.Combine(_environment.ContentRootPath, "Images/" + file.FileName);
        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    return Ok(file.FileName);
        //}
         [HttpPost, DisableRequestSizeLimit]
        [RequestFormLimits(MultipartBodyLengthLimit = 204857600)]
        public async Task<IActionResult> Upload(IFormFile _file)
        {
            //  var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyD0MQz8q3CFW16JRY11lHctKPSShXxhs7Q"));
            // var a = await auth.SignInWithEmailAndPasswordAsync("medoenoch@gmail.com", "newstart2020");
            //var a = await auth.sig("medoenoch@gmail.com", "newstart2020");


            if (_file != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(_file.FileName);
                string extension = Path.GetExtension(_file.FileName);
                //save to db 
                // fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                fileName = fileName + extension;
                using (var fileStream = new FileStream(Path.Combine("Images/" + fileName), FileMode.Create))
                {
                    await _file.CopyToAsync(fileStream);
                }
                //-------------------------------------------------------------------
                //string path = Path.Combine("Images/", fileName);
                //only image
                //Vids
                //save to folder
                //save to cloud 
                //--------------------
                FileStream fs;
                // string path = Path.Combine("Images/",$"{fileName}");
                fs = new FileStream(Path.Combine("Images/" + fileName), FileMode.Open);
                //----
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthMail, Password);

                var cancellation = new CancellationTokenSource();

                var upload = new FirebaseStorage(Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken)
                        ,
                        ThrowOnCancel = true
                    }).Child("data")
                    .Child($"{_file.FileName}")
                    .PutAsync(fs, cancellation.Token);
                //--------------------------------------------

                var downloadUrl = await upload;
                string str = downloadUrl;
                var url = new Uri(str);

                return Ok(url);

            }
            else
            {
                return NotFound("Error");
            }  
         }
        /*
         
         String downloadUrl = await (await uploadTask.onComplete).ref.getDownloadURL();
          Firestore.instance.collection('images').add({"url": downloadUrl});
           }

         
         
         
         
         
         
         
         
         * 
         [HttpPost]
         [ValidateAntiForgeryToken]
         [RequestFormLimits(MultipartBodyLengthLimit = 204857600)]
         public async Task<IActionResult> Create([Bind("Id,Title,ImageFile")] ImageModel imageModel)
         {
             if (ModelState.IsValid)
             {

                 //save image to wwwroot/image
                 string wwwRootPath = hostEnvironment.WebRootPath;
                 string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                 string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                 imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                 string path = Path.Combine(wwwRootPath + "/images/", fileName);

                 using (var fileStream = new FileStream(path, FileMode.Create))
                 {
                     await imageModel.ImageFile.CopyToAsync(fileStream);
                 }
                 //insert record
                 _context.Add(imageModel);


        public ActionResult Create(Student std ,HttpPostedFileBase stdimg, HttpPostedFileBase stdcv)
        {
            if (ModelState.IsValid)
            {
                string filename = std.id.ToString() + "." + stdimg.FileName.Split('.')[1];
                stdimg.SaveAs(Server.MapPath("~/imges/") + filename);
                std.stdphoto = filename;
                string filename1 = std.id.ToString() + "." + stdcv.FileName.Split('.')[1];
                stdimg.SaveAs(Server.MapPath("~/imges/") + filename1);
                std.stdcv = filename1;
                StudentMoc.Addstudent(std);
                return RedirectToAction("index");
            }
            else
            {
                return View(std);
            }

            
            
            ?xml version="1.0" encoding="utf-8"?>
            <configuration>
            
              
             
              <system.webServer>
            	  <security>
            		  <requestFiltering>
            			  <requestLimits maxAllowedContentLength="204857600"/>
            		  </requestFiltering>
            	  </security>
              </system.webServer>
            
            
            </configuration>
            





         */
    }

}
