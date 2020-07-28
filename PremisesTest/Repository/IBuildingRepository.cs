using PremisesTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimesesTest.Repository
{
    public interface IBuildingRepository
    {
        Task<IEnumerable<Building>> GetAllAsync();
        Task<Building> GetAsync(Guid buildingId);
    }
}