using MongoDB.Bson;
using MongoDB.Driver;
using Personal.Photography.Gallery.Data.Context;
using Personal.Photography.Gallery.Domain.Entities;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.MongoDBRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Photography.Gallery.Data.Repositories.MongoDBRepositories
{
    public class GalleryMongoRepository : IGalleryMongoRepository
    {
        private MongoDBContext _context = new MongoDBContext();
        private IMongoCollection<Photograph> _collection;

        public GalleryMongoRepository()
        {
            _collection = _context._database.GetCollection<Photograph>("Gallery");
        }

        public async Task<List<Photograph>> GetAllPhotograph()
        {
            return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task InsertPhotograph(Photograph photograph)
        {
            await _collection.InsertOneAsync(photograph);
        }

        public async Task UpdatePhotograph(Photograph photograph)
        {
            var filter = Builders<Photograph>
                .Filter
                .Eq(s => s.Id, photograph.Id);

            await _collection.ReplaceOneAsync(filter, photograph);
        }

        public async Task DeletePhotograph(string id)
        {
            var filter = Builders<Photograph>.Filter.Eq(s => s.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
