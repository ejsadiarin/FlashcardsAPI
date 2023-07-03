namespace FlashcardsAPI.DTOs;

public record struct FlashcardDto(
    int Id,
    string StackName,
    string Question,
    string Description
    );