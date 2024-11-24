using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SolidPrincipalWithGenericDbContext.DbContext;
using SolidPrincipalWithGenericDbContext.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IDBContext>(provider =>
{
    var useSql = builder.Configuration.GetValue<bool>("UseSqlDatabase");

    if (useSql)
    {
        var dbContext = provider.GetRequiredService<DbContext>();
        return new SqlDbContext(dbContext);
    }
    else
    {
        var mongoDatabase = provider.GetRequiredService<IMongoDatabase>();
        return new NoSqlDbContext(mongoDatabase);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
