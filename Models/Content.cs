namespace RandomTutorialsAPI.Models;

public class Content
{
    public int Id { get; set;}
    public required string Type { get;set;}
    public required Dictionary<string,string> Data {get;set;}
}