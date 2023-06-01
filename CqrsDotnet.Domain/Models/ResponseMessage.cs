using System.Text.Json.Serialization;

namespace CqrsDotnet.Domain.Models;

public class ResponseMessage
{
    [JsonPropertyName("message")]
    // ReSharper disable once UnusedMember.Global
    public string Message { get; set; } 

    public ResponseMessage(string message = "")
    { 
        Message = message;
    }
}
