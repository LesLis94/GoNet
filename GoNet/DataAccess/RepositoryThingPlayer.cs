using System.Numerics;
using GoNet.BL.Services.Abstract;
using GoNet.Core.Abstract;
using GoNet.Core.Models;
using GoNet.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GoNet.DataAccess
{
    public class RepositoryThingPlayer : IRepositoryThingPlayer
    {
        private readonly DataContext _dbcontext;

        public RepositoryThingPlayer(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Delete(Guid id)
        {
            await _dbcontext.Things.Where(p => p.Id == id).ExecuteDeleteAsync();
        }
    }
}
