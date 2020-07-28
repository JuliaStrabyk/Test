using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremisesTest.Models
{
    public class Equipment
    {
        public Guid equipmentId { get; set; }
        public string equipmentName { get; set; }
        public Guid roomId { get; set; }
        public Room rooms { get; set; }
    }
}
