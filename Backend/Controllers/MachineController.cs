using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Machine> GetMachines()
        {
            using (var db = new AppDbContext())
            {
                return db.Machines.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Machine> GetMachine(int id)
        {
            using (var db = new AppDbContext())
            {
                var result =  db.Machines.FirstOrDefault(x => x.machineId == id);
                if (result == null)
                    return NotFound();

                return result;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMachine(int id)
        {
            using (var db = new AppDbContext())
            {
                var machine = db.Machines.FirstOrDefault(x => x.machineId == id);
                if (machine == null)
                    return NotFound();

                db.Machines.Remove(machine);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
