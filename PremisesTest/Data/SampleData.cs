using System;
using System.Collections.Generic;
using System.Linq;
using PremisesTest.Models;
using System.Threading.Tasks;

namespace PremisesTest.Data
{
    public static class SampleData
    {
        public static void Initialize(PremisesContext context)
        {
            List<Room> roomList = new List<Room>();
            if (!context.Buildings.Any())
            {
                context.Buildings.AddRange(
                    new Building
                    {
                        buildingId = Guid.NewGuid(),
                        nameBuilding = "Здание 1",
                    },
                    new Building
                    {
                        buildingId = Guid.NewGuid(),
                        nameBuilding = "Здание 2",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
