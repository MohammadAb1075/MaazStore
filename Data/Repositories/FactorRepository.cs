using Common.Paginations;
using Data.Common;
using Domain.Factors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories;

public class FactorRepository : IFactorRepository
{
    private readonly DatabaseContext _db;

    public FactorRepository(DatabaseContext db)
    {
        _db = db;
    }
    public async Task<PagedData<Factor>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var result = new PagedData<Factor>
        {
            PageInfo = new PageInfo
            {
                PageSize = pageSize,
                PageNumber = pageNumber
            }
        };

        result.Data =
            await
            _db.Factors
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        result.PageInfo.TotalCount = await _db.Products.CountAsync();
        return result;
    }
    public async Task<Factor> GetByIdAsync(string id)
    {
        return await _db.Factors
                    .Where(p => p.Id.ToString() == id)
                    .FirstOrDefaultAsync();
    }
    public async Task CreateAsync(Factor model)
    {
        await _db.Factors.AddAsync(model);
        await CommitAsync();
    }
    public async Task UpdateAsync(Factor model)
    {
        _db.Set<Factor>().Attach(model);
        _db.Entry(model).State = EntityState.Modified;
        await CommitAsync();
    }
    public async Task DeleteAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        _db.Entry(entity).State = EntityState.Deleted;
        await CommitAsync();
    }
    public async Task CommitAsync()
    {
        await _db.SaveChangesAsync();
    }
    public Task<string> GetErrorsAsync()
    {
        throw new NotImplementedException();
    }
}

