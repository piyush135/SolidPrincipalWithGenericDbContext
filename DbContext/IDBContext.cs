namespace SolidPrincipalWithGenericDbContext.DbContext
{
    public interface IDBContext
    {
        Task<T> GetByIdAsync<T>(string id) where T : class;
        Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters = null) where T : class;
        Task SaveAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(string id) where T : class;
    }
}
