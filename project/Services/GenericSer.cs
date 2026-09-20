
namespace project.Services;

using project.Helpers;

public class GenericSer<T> where T : class
{
    protected readonly List<T> _items;
    private readonly string _filePath;

    public GenericSer(string filePath)
    {
        _items = new List<T>();
        _filePath = filePath;

        try
        {
            var existingItems = FileStream.ReadContentFromFile<List<T>>(_filePath);
            if (existingItems != null)
            {
                _items.AddRange(existingItems);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while loading items from file.");
        }
    }








    public void Add(T item)
    {
        _items.Add(item);
        FileStream.WriteContentToFile(_filePath, _items);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        FileStream.WriteContentToFile(_filePath, _items);
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public void Save()
    {
        FileStream.WriteContentToFile(_filePath, _items);
    }

}