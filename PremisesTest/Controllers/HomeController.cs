using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremisesTest.Data;
using PremisesTest.Models;

namespace PremisesTest.Controllers
{
    public class HomeController : Controller
    {
        static List<Building> buildingList = new List<Building>();
        static List<Room> roomList = new List<Room>();
        static HomeController()
        {
            buildingList.Add(new Building { buildingId = Guid.NewGuid(), nameBuilding = "Здание 1" });
            buildingList.Add(new Building { buildingId = Guid.NewGuid(), nameBuilding = "Здание 2" });
            buildingList.Add(new Building { buildingId = Guid.NewGuid(), nameBuilding = "Здание 3" });
            buildingList.Add(new Building { buildingId = Guid.NewGuid(), nameBuilding = "Здание 4" });
            roomList.Add(new Room { roomId = Guid.NewGuid(), roomName = "Комната 1", Buildings=new Building { nameBuilding= "Здание 1" }} );
            roomList.Add(new Room { roomId = Guid.NewGuid(), roomName = "Комната 2", Buildings = new Building { nameBuilding = "Здание 1" }});
            roomList.Add(new Room { roomId = Guid.NewGuid(), roomName = "Комната 3", Buildings = new Building { nameBuilding = "Здание 2" }} );
            roomList.Add(new Room { roomId = Guid.NewGuid(), roomName = "Комната 4", Buildings=new Building { nameBuilding= "Здание 3" }});
        }
        private readonly PremisesContext db;

        public HomeController(PremisesContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(buildingList);
        }
        [HttpGet]
        [Route("Home/Data")]
        public string GetData()
        {
            return JsonConvert.SerializeObject(buildingList);
        }
        //public async Task<Message> GetAsync(Guid id)
        //{
        //    if (id == Guid.Empty)
        //    {
        //        return new Message();
        //    }
        //    return await db.Messages.FirstOrDefaultAsync(c => c.MessageId == id);
        //}
        //public async Task<IEnumerable<Message>> FindAsync(Expression<Func<Message, Boolean>> predicate)
        //{
        //    return await db.Messages.Where(predicate).Include(co => co.MessageEmails).Include(co => co.MessageFiles).ToListAsync();
        //}
        [HttpGet]
        [Route("Home/RowData")]
        public string GetRoom(Guid buildingGuid)
        {
            Room rooms = roomList.FirstOrDefault(x => x.buildingId == buildingGuid);
            return JsonConvert.SerializeObject(rooms);
        }
    }
}
