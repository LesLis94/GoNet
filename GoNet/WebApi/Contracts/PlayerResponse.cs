namespace GoNet.WebApi.Contracts
{
    public record PlayerResponse(Guid id, string name, int cash);

    public record PlayerRequest(string name, int cash);

}
