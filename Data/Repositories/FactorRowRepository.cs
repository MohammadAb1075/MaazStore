using Data.Common;
using Domain.FactorRows;
using Domain.Factors;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories;

public class FactorRowRepository : IFactorRowRepository
{
    private readonly DatabaseContext _db;
    public FactorRowRepository(DatabaseContext db)
    {
        _db = db;
    }
    public async Task DeleteFactorRowsByFactorAsync(Factor model)
    {
        var factorRows = await _db.FactorRows
                                .Where(x => x.FactorId.ToString() == model.Id.ToString())
                                .ToListAsync();
        _db.FactorRows.RemoveRange(factorRows);
    }

    public async Task DeleteFactorRowsByProductAsync(Product model)
    {
        var factorRows = await _db.FactorRows
                                .Where(x => x.ProductId == model.Id)
                                .ToListAsync();
        _db.FactorRows.RemoveRange(factorRows);
    }
}
