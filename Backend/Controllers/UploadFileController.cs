using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        [HttpPost]
        public ActionResult BulkInsertAction()
        {
            dynamic content = null;
            using (StreamReader @reader = new StreamReader(Request.Form.Files[0].OpenReadStream()))
            {
                content = @reader.ReadToEnd();
                @reader.Close();
            }

            UploadFileModel data = JsonConvert.DeserializeObject<UploadFileModel>(content);

            try
            {
                using (var db = new AppDbContext())
                {
                    foreach (var element in data.devices)
                    {
                        db.Machines.Add(element);
                    }

                    db.SaveChanges();

                }
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
