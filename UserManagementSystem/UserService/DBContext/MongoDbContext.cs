using MongoDB.Driver;
using Common.Models;
using Microsoft.Extensions.Options;
namespace UserService.DBContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("Users");
            }
        }
    }       
}
