using MongoDB.Driver;

namespace Personal.Photography.Gallery.Data.Context
{
    public class MongoDBContext
    {
        public MongoClient _client;
        public IMongoDatabase _database;
        public MongoDBContext() 
        {
            _client = new MongoClient("");
            _database = _client.GetDatabase("");
        }
    }
}

