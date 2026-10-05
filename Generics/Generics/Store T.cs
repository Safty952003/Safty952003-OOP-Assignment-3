namespace Generics;

public class Store<T> where T : IHasId
{
    private readonly List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public T? GetById(int id)
    {
        foreach (T item in items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return default;
    }

    public IEnumerable<T> GetAll()
    {
        foreach (T item in items)
        {
            yield return item;
        }
    }

    public void Remove(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == id)
            {
                items.RemoveAt(i);
                return;
            }
        }
    }
}