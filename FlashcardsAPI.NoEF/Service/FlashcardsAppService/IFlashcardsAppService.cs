using FlashcardsAPI.DTOs;
using FlashcardsAPI.Model;

namespace FlashcardsAPI.Service.FlashcardsAppService;

public interface IFlashcardsAppService
{
     Task CreateTablesIfNotExists();
     void GetAllStacks();
     void DisplayFlashcardsInStack();
}