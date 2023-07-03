namespace FlashcardsAPI.Model;

public class Flashcards
{
    public int Id { get; set; }
    public int StackId { get; set; }
    public string StackName { get; set; }
    public string Questions { get; set; }
    public string Description { get; set; }
}