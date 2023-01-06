using Common.Paginations;
using Data.Common;
using Domain.FactorRows;
using Domain.Factors;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class FactorRepository : IFactorRepository
{
    private readonly DatabaseContext _db;
    private readonly IFactorRowRepository _frr;

    public FactorRepository(DatabaseContext db, IFactorRowRepository frr)
    {
        _db = db;
        _frr = frr; 
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
            .OrderByDescending(x=>x.FactorNo)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        result.PageInfo.TotalCount = await _db.Factors.CountAsync();
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
        await _frr.DeleteFactorRowsByFactorAsync(model);
        _db.Attach(model);
        _db.Entry(model).State = EntityState.Modified;
        _db.FactorRows.AddRange(model.FactorRows);
        await CommitAsync();
    }
    public async Task DeleteAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        await _frr.DeleteFactorRowsByFactorAsync(entity);
        //foreach (var item in entity.FactorRows)
        //    _db.FactorRows.Remove(item);
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

