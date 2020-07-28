using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremisesTest.Data;
using PremisesTest.Models;

namespace Primes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly PremisesContext db;

        public BuildingController(PremisesContext context)
        {
            db = context;
        }

        // GET: api/Buildings
        [HttpGet]
        public IEnumerable<Building> GetBuilding()
        {
            return db.Buildings;
        }
        // POST: api/Buildings
        [HttpPost]
         public async Task<IActionResult> IndexAsync([FromBody] Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Buildings.Add(building);
            await db.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        //// POST: api/Buildings
        //[HttpPost]
        //[Route("api/buildings")]
        //public async Task<IActionResult> PostBuilding([FromBody] Building building)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //db.Buildings.Add(building);
        //    await db.SaveChangesAsync();
        //    return CreatedAtAction("GetBuilding", new { id = building.buildingId }, building);
        //}

        private bool BuildingExists(Guid id)
        {
            return db.Buildings.Any(e => e.buildingId == id);
        }

        //// GET: api/Buildings/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetBuilding([FromRoute] Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var building = await db.Buildings.FindAsync(id);

        //    if (building == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(building);
        //}
    }
}