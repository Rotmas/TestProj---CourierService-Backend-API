namespace Model;

public interface ItemRepository
{
    Task<int> Create(string description);
    Task<Item> Get(int id);
}