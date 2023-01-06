using Domain.Factors;
using Domain.Products;

namespace Domain.FactorRows;

public interface IFactorRowRepository
{
    Task DeleteFactorRowsByFactorAsync(Factor model);
    Task DeleteFactorRowsByProductAsync(Product model);
}
