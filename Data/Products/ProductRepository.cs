using Common.Paginations;
using Data.Common;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
namespace Data.Products;

public class ProductRepository : IProductRepository
{

    private readonly DatabaseContext _db;

    public ProductRepository(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var result =
            await
            _db.Products
            .ToListAsync();
        return result;
    }
    
    public async Task<PagedData<Product>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var result = new PagedData<Product>
        {
            PageInfo = new PageInfo
            {
                PageSize = pageSize,
                PageNumber = pageNumber
            }
        };

        result.Data = 
            await
            _db.Products
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        result.PageInfo.TotalCount = await _db.Products.CountAsync();
        return result;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Product model)
    {
        await _db.Products.AddAsync(model);
        await CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        _db.Entry(entity).State = EntityState.Deleted;
        await CommitAsync();
    }

    public async Task UpdateAsync(Product model)
    {
        _db.Set<Product>().Attach(model);
        _db.Entry(model).State = EntityState.Modified;
        await CommitAsync();
    }
    public async Task CommitAsync()
    {
        await _db.SaveChangesAsync();
    }
}
