namespace IMS.UseCases.Inventories.Interfaces;

public interface IViewInventoryByIdUseCase
{
    Task ExecuteAsync(int inventoryId);
}