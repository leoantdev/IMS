﻿using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;
public class DeleteInventoryUseCase : IDeleteInventoryUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task ExecuteAsync(int invId)
    {
        await _inventoryRepository.DeleteInventoryByIdAsync(invId);
    }
}
