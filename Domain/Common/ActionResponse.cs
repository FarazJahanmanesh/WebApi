using Newtonsoft.Json;
using System.Xml;

namespace Domain.Common;
public class ActionResponse<T> : ActionResponse
{
    public ActionResponse()
    {
        Errors = new List<string>();
    }

    public T Data { get; set; }

}
public class ActionResponse : IActionResponse
{
    public ActionResponse()
    {
        Errors = new List<string>();
    }
    public int Status { get; set; }
    public string Message { get; set; }
    public ResponseStateEnum State { get; set; }
    public List<string> Errors { get; set; }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
    }
}

public interface IActionResponse
{
    int Status { get; set; }
    string Message { get; set; }
    ResponseStateEnum State { get; set; }
    List<string> Errors { get; set; }
}