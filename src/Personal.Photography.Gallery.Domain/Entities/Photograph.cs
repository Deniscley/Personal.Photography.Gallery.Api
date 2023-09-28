using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Personal.Photography.Gallery.Domain.Entities
{
    public class Photograph
    {

        [BsonId]
        public string Id { get; set; }

        public string Filename { get; set; }

        public int PhotoNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Dimensions { get; set; }

        public string Base64Data { get; set; }

    }
}

