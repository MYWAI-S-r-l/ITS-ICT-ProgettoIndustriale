#nullable disable
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ProgettoIndustriale.Type.Dto;

public class ApiCallsLogs
{

    public int Id { get; set; }
    //[JsonPropertyName("apiCallName")]
    public string ApiCallName { get; init; }
    //[JsonPropertyName("freq")]
    public string CallFrequency { get; init; }
    public DateTime LastSuccessfulRun { get; init; }

}