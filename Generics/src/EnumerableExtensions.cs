namespace Generics;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(
        this IEnumerable<T> source,
        int pageNumber,
        int pageSize)
    {
        if (pageNumber < 1)
            throw new ArgumentException("Page number must be greater than 0.");

        if (pageSize < 1)
            throw new ArgumentException("Page size must be greater than 0.");

        int start = (pageNumber - 1) * pageSize;
        int end = start + pageSize;
        int index = 0;

        foreach (T item in source)
        {
            if (index >= start && index < end)
            {
                yield return item;
            }

            if (index >= end)
                yield break;

            index++;
        }
    }

    public static T? FindById<T>(
        this IEnumerable<T> source,
        int id)
        where T : IHasId
    {
        foreach (T item in source)
        {
            if (item.Id == id)
                return item;
        }

        return default;
    }

    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(
        this IEnumerable<T> source)
        where T : IHasId
    {
        Dictionary<int, T> result = new();

        foreach (T item in source)
        {
            result.Add(item.Id, item);
        }

        return result;
    }
}