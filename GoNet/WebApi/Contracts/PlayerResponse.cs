using System.ComponentModel.DataAnnotations;
using GoNet.BL.Services.Abstract;
using System.Numerics;
using GoNet.Core.Models;
using GoNet.DataAccess.Abstract;

namespace GoNet.WebApi.Contracts
{
    public record PlayerResponse(Guid id, string name, int cash);

    public record PlayerRequest(string name);

    public class PlayerInfo 
    {
        public int Cash { get; set; }
        public string Name { get; set; }
        public List<ThingPlayerResponse> Things { get; set; } = [];

        public PlayerInfo (string name, int cash, List<ThingPlayer> things)
        {
            Cash = cash;
            Name = name;
           
            Things = things
               .Select(p => new ThingPlayerResponse(p.Id, p.Name))
               .ToList();
        }
    };

}
