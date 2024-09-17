using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private List<Inventory> _inventories;

    public InventoryRepository()
    {
        _inventories = new List<Inventory>()
        {
            new Inventory { Id = 1, Name = "Bike Seat", Quantity = 10, Price = 2  },
            new Inventory { Id = 2, Name = "Bike Body", Quantity = 10, Price = 15  },
            new Inventory { Id = 3, Name = "Bike Wheels", Quantity = 20, Price = 8  },
            new Inventory { Id = 4, Name = "Bike Pedals", Quantity = 20, Price = 1 },
        };
    }

    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

        return _inventories.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}
