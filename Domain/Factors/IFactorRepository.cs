namespace Domain.Factors;

public interface IFactorRepository
{
    Task<string> GetErrorsAsync();
    
    Task<Common.Paginations.PagedData<Factor>> GetWithPaginationAsync(int pageNumber, int pageSize);
    Task<Factor> GetByIdAsync(int id);
    Task CreateAsync(Factor model);
    Task UpdateAsync(Factor model);
    Task DeleteAsync(int id);
    Task CommitAsync();

}
