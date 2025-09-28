namespace Core.Abstractions;

public abstract class DataModelBase : IDataModel
{
    public abstract string GetTableName();
}

public interface IDataModel
{
    string GetTableName();
}
