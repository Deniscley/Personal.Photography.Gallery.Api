﻿using Personal.Photography.Gallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Photography.Gallery.Domain.Interfaces.Repositories.MongoDBRepositories
{
    public interface IGalleryMongoRepository
    {
        Task<List<Photograph>> GetAllPhotograph();
        Task InsertPhotograph(Photograph photograph);
        Task UpdatePhotograph(Photograph photograph);

        Task DeletePhotograph(string id);
    }
}
