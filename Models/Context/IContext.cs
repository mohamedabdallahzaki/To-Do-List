using Task.Models.Entites;

public interface IContext
{
    List<Item> Items { get; }
    void AddItem(Item item);
    void DeleteItem(int id);
}
