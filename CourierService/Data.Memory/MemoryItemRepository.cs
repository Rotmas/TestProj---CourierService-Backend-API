using Model;

namespace Data.Memory;

public class MemoryItemRepository : ItemRepository
{
    int LastItemId = 1;
    readonly Dictionary<int, Item> Items = new();

    public Task<Item> Get(int id)
        => Task.FromResult(Items[id]);

    public Task<int> Create(string description)
    {
        var itemId = LastItemId++;
        Items[itemId] = new Item { Description = description, Id = itemId };
        return Task.FromResult(itemId);
    }
}
