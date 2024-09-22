using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces;
public interface IInventoryRepository
{
    Task AddInventoryAsync(Inventory inventory);
    Task DeleteInventoryByIdAsync(int invId);
    Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
    Task UpdateInventoryAsync(Inventory inventory);
    Task<Inventory> ViewInventoryByIdAsync(int inventoryId);
}
