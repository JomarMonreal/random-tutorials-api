namespace RandomTutorialsAPI.Models;

public class TagTutorialMapping{
    public int Id { get; set;}
    public required int TutorialId { get; set;}
    public required int TagId { get; set;}
}