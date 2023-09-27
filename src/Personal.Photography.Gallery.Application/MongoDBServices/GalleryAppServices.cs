using Personal.Photography.Gallery.Domain.Entities;
using Personal.Photography.Gallery.Domain.Interfaces.MongoDBServices;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.MongoDBRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Photography.Gallery.Application.MongoDBServices
{
    public class GalleryAppServices : IGalleryAppServices
    {
        private readonly IGalleryMongoRepository _galleryMongoRepository;

        public GalleryAppServices(IGalleryMongoRepository galleryMongoRepository)
        {
            _galleryMongoRepository = galleryMongoRepository;
        }

        public async Task<List<Photograph>> GetAllPhotograph()
        {
            var response = await _galleryMongoRepository.GetAllPhotograph();

            return response;
        }

        public Task InsertPhotograph(Photograph photograph)
        {
            var response = _galleryMongoRepository.InsertPhotograph(photograph);

            return response;
        }

        public Task UpdatePhotograph(Photograph photograph)
        {
            var response = _galleryMongoRepository.UpdatePhotograph(photograph);

            return response;
        }

        public Task DeletePhotograph(string id)
        {
            var response = _galleryMongoRepository.DeletePhotograph(id);

            return response;
        }
    }
}
