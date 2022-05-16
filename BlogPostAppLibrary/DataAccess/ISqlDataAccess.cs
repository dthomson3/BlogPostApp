namespace BlogPostAppLibrary.DataAccess;

public interface ISqlDataAccess
{
    List<T> LoadData<T, U>(string sql, U parameters);
    Task<List<T>> LoadDataAsync<T, U>(string sql, U parameters);
    object LoadSingleData<T>(string sql);
    Task<T> LoadSingleDataAsync<T>(string sql);
    Task SaveDataAsync<T>(string sql, T parameters);
}