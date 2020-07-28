using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremisesTest.Data;
using PremisesTest.Models;

namespace PrimesesTest.Repository
{
    public class BuildingRepository: IBuildingRepository
    { 
            private PremisesContext db;
            public BuildingRepository(PremisesContext context)
            {
                this.db = context;
            }

        public async Task<IEnumerable<Building>> GetAllAsync()
        {
            var res = await db.Buildings.AsNoTracking().ToListAsync();
            return res;
        }
        //public IQueryable<Message> GetIQueryable()
        //{
        //    return db.Messages;
        //}
        public async Task<Building> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new Building();
            }
            return await db.Buildings.FirstOrDefaultAsync(c => c.buildingId == id);
        }
        //public async Task<IEnumerable<Message>> FindAsync(Expression<Func<Message, Boolean>> predicate)
        //{
        //    return await db.Messages.Where(predicate).Include(co => co.MessageEmails).Include(co => co.MessageFiles).ToListAsync();
        //}
        //public void Create(Message item)
        //{
        //    if (item != null) db.Messages.Add(item);
        //}

        //public void Update(Message item)
        //{
        //    if (item != null) db.Entry(item).State = EntityState.Modified;
        //}

        //public async Task Delete(Guid id)
        //{
        //    var val = await db.Messages.FirstOrDefaultAsync(x => x.MessageId == id);  //db.Messages.Find(id)
        //    if (val != null) db.Messages.Remove(val);
        //}

    }
}
