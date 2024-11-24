using SolidPrincipalWithGenericDbContext.Model;
using SolidPrincipalWithGenericDbContext.Repository;
using System.Xml;

namespace SolidPrincipalWithGenericDbContext.Service
{
    public class ExampleService
    {
        private readonly IRepository<MyEntity> _repository;

        public ExampleService(IRepository<MyEntity> repository)
        {
            _repository = repository;
        }

        public async Task<MyEntity> GetEntityByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<MyEntity>> GetAllEntitiesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddEntityAsync(MyEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateEntityAsync(string id, MyEntity entity)
        {
            await _repository.UpdateAsync(id, entity);
        }

        public async Task DeleteEntityAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
