using Task.Models.Entites;

namespace Task.Models.Context
{
    public class Context : IContext
    {
 
        private static List<Item> _items = new List<Item>()
        {
            new Item { Id = 1, Name = "Math Homework", Description = "Solve 20 examples", IsCompleted = false }
        };

       
        public List<Item> Items => _items;


        public void AddItem(Item item)
        {
            
            var found = _items.Any(i => i.Id == item.Id);
            if (found)
                Console.WriteLine($"Item with Id {item.Id} already found");

            _items.Add(item);
        }


        public void DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null)
                _items.Remove(item);
        }

    }
}
