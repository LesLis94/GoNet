using System.ComponentModel.DataAnnotations;

namespace GoNet.WebApi.Contracts
{
    public record PlayerResponse(Guid id, string name, int cash);

    public record PlayerRequest(string name);

    public class PlayerInfo 
    {
        public int Cash { get; set; }

        public string Name { get; set; }

        public PlayerInfo (string name, int cash)
        {
            Cash = cash;
            Name = name;
        }
    };

}
