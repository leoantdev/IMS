using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces;
public interface IViewInventoriesByNameUseCase
{
    Task<IEnumerable<Inventory>> ExecutyAsync(string name = "");
}