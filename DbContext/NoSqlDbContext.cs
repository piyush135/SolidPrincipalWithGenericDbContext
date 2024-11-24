
using MongoDB.Driver;

namespace SolidPrincipalWithGenericDbContext.DbContext
{
    public class NoSqlDbContext : IDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public NoSqlDbContext(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<T> GetByIdAsync<T>(string id) where T : class
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            return await collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters = null) where T : class
        {
            // Simplified example; NoSQL databases often don't have query strings
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task SaveAsync<T>(T entity) where T : class
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            await collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync<T>(string id) where T : class
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            await collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        }
    }
}
