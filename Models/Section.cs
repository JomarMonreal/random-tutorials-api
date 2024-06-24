namespace RandomTutorialsAPI.Models;

public class Section
{
    public int Id { get; set;}
    public required string Header { get;set;}
    public required Content [] Contents { get;set;}

}
