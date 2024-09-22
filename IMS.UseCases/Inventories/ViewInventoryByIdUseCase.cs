using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;
public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public ViewInventoryByIdUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task ExecuteAsync(int inventoryId)
    {
        await _inventoryRepository.ViewInventoryByIdAsync(inventoryId);
    }
}
