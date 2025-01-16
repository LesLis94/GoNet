using System.ComponentModel.DataAnnotations;
using GoNet.Core.Models;

namespace GoNet.WebApi.Contracts
{
        public record ThingPlayerResponse(Guid id, string name);
}
