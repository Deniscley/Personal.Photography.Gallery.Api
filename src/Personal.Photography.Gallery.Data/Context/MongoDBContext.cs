using MongoDB.Driver;

namespace Personal.Photography.Gallery.Data.Context
{
    public class MongoDBContext
    {
        public MongoClient _client;
        public IMongoDatabase _database;
        public MongoDBContext() 
        {
            _client = new MongoClient("mongodb://mongo:U4oaZbPdnbgVqaPLqHFL@containers-us-west-36.railway.app:5790");
            _database = _client.GetDatabase("PhotographyGallery");
        }
    }
}

