namespace RandomTutorialsAPI.Models;

public class Tutorial
{
    public int Id { get; set;}
    public required int UserId { get;set;}
    public required string Title { get; set;}
    public required string Date { get; set;}
    public required string Description { get; set;}
    public required string ThumbnailImageUrl { get; set;}
    public required int Visibility { get;set;}
    public required string[] SectionsJSON { get;set;}
}