namespace Domain.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Common.Paginations.PagedData<Product>> GetWithPaginationAsync(int pageNumber, int pageSize);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product model);
        Task UpdateAsync(Product model);
        Task DeleteAsync(int id);
        Task CommitAsync();
    }
}
