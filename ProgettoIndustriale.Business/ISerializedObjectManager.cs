namespace Ansaldo.Protocollo.Business;

public interface ISerializedObjectManager<T> where T : new()
{
    T Get(int id);

    T GetByKey(string key);

    int? GetIdByKey(string key);

    int Add(string key, T obj);

    bool Update(int id, string key, T obj);

    bool Delete(int id);
}