using System.Text.Json;

namespace GoNet.Dto__DataTransferObject_
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
