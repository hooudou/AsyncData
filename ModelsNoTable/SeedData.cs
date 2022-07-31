
namespace AsyncData.ModelsNoTable;
public abstract class SeedData<T> where T : class, new()
{
    public abstract List<T> DataList { get;}
}