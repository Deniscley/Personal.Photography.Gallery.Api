namespace Personal.Photography.Gallery.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
