using Personal.Photography.Gallery.Domain.Entities;

namespace Personal.Photography.Gallery.Domain.Interfaces.Repositories.MongoDBRepositories
{
    public interface IProductMongoRepository
    {
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);

        Task<List<Product>> GetAllProducts();

        Task<Product> GetProductById(string id);
    }
}
