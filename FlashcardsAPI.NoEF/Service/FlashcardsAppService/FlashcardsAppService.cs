using FlashcardsAPI.Data;

namespace FlashcardsAPI.Service.FlashcardsAppService;

public class FlashcardsAppService : IFlashcardsAppService
{
    private readonly FlashcardsAppDataAccess _dataAccess;

    public FlashcardsAppService(FlashcardsAppDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task CreateTablesIfNotExists()
    {
        await FlashcardsAppDataAccess.CreateCommand();

    }
    
    public void GetAllStacks()
    {
        // var stacks = _dataAccessV
    }
    public void DisplayFlashcardsInStack()
    {
    }
    
    
}