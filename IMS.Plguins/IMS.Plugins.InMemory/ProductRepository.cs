using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class ProductRepository : IProductRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>()
        {
            new Product { Id = 1, Name = "Bike Seat", Quantity = 10, Price = 150  },
            new Product { Id = 2, Name = "Bike Body", Quantity = 10, Price = 15  },
        };
    }

    public Task AddProductAsync(Product product)
    {
        if (_products.Any(i => i.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return Task.CompletedTask;

        var maxId = _products.Max(i => i.Id);
        product.Id = maxId + 1;

        _products.Add(product);

        return Task.CompletedTask;
    }

    public Task DeleteProductByIdAsync(int invId)
    {
        var product = _products.FirstOrDefault(i => i.Id == invId);
        if (product is not null)
        {
            _products.Remove(product);
        }

        return Task.CompletedTask;
    }

    public async Task<Product> GetProductByIdAsync(int inventoryId)
    {
        return await Task.FromResult(_products.First(i => i.Id == inventoryId));
    }

    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_products);

        return _products.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task UpdateProductAsync(Product product)
    {
        if (_products.Any(i => i.Id != product.Id
            && i.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        var invToUpdate = _products.FirstOrDefault(i => i.Id == product.Id);
        if (invToUpdate is not null)
        {
            invToUpdate.Name = product.Name;
            invToUpdate.Quantity = product.Quantity;
            invToUpdate.Price = product.Price;
        }

        return Task.CompletedTask;
    }
}
