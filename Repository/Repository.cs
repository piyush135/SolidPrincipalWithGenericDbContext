using SolidPrincipalWithGenericDbContext.DbContext;

namespace SolidPrincipalWithGenericDbContext.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDBContext _dbContext;

        public Repository(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbContext.GetByIdAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // Assuming QueryAsync with a simple query to fetch all documents/records
            return await _dbContext.QueryAsync<T>("SELECT * FROM TableName");
        }

        public async Task<IEnumerable<T>> QueryAsync(string query, object parameters = null)
        {
            return await _dbContext.QueryAsync<T>(query, parameters);
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.SaveAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            // The specific update logic might vary by database type
            await DeleteAsync(id); // Simplified example for replacing an entity
            await AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _dbContext.DeleteAsync<T>(id);
        }
    }
}
