namespace Domain.Products
{
    public interface IProductRepository
    {
        Task<Common.Paginations.PagedData<Product>> GetAllAsync(int pageNumber, int pageSize);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product model);
        Task UpdateAsync(Product model);
        Task DeleteAsync(int id);
        Task CommitAsync();
    }
}
