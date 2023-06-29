using FlashcardsAPI.DTOs;
using FlashcardsAPI.Model;

namespace FlashcardsAPI.Service.FlashcardsAppService;

public interface IFlashcardsAppService
    {
    public void GetAllStacks() { get; set; }
    public void DisplayFlashcardsInStack() { get; set; }
}