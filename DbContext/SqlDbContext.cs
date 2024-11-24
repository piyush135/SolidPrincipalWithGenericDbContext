using Dapper;
using Microsoft.EntityFrameworkCore;
using SolidPrincipalWithGenericDbContext.Model;

namespace SolidPrincipalWithGenericDbContext.DbContext
{
    public class SqlDbContext : IDBContext
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

        public SqlDbContext(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<T> GetByIdAsync<T>(string id) where T : class
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters = null) where T : class
        {
            using (var connection = _dbContext.Database.GetDbConnection())
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                return await connection.QueryAsync<T>(query, parameters);
            }
        }

        public async Task SaveAsync<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(string id) where T : class
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
