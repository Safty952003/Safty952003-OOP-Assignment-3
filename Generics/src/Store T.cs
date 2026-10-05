namespace Generics;

public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> items = new();

    public void Add(T item)
    {
        if (items.ContainsKey(item.Id))
        {
            throw new ArgumentException(
                $"An item with Id {item.Id} already exists.");
        }

        items.Add(item.Id, item);
    }

    public T? GetById(int id)
    {
        if (items.TryGetValue(id, out T? item))
        {
            return item;
        }

        return default;
    }

    public IEnumerable<T> GetAll()
    {
        foreach (T item in items.Values)
        {
            yield return item;
        }
    }

    public void Remove(int id)
    {
        items.Remove(id);
    }
}