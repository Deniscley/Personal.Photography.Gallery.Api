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
    public class ExhibitionsAppServices : IExhibitionsAppServices
    {
        private readonly IExhibitionsMongoRepository _exhibitionsMongoRepository;

        public ExhibitionsAppServices(IExhibitionsMongoRepository exhibitionsMongoRepository)
        {
            _exhibitionsMongoRepository = exhibitionsMongoRepository;
        }

        public async Task<List<Photograph>> GetAllPhotograph()
        {
            var response = await _exhibitionsMongoRepository.GetAllPhotograph();

            return response;
        }

        public Task InsertPhotograph(Photograph photograph)
        {
            var response = _exhibitionsMongoRepository.InsertPhotograph(photograph);

            return response;
        }

        public Task UpdatePhotograph(Photograph photograph)
        {
            var response = _exhibitionsMongoRepository.UpdatePhotograph(photograph);

            return response;
        }

        public Task DeletePhotograph(string id)
        {
            var response = _exhibitionsMongoRepository.DeletePhotograph(id);

            return response;
        }
    }
}
