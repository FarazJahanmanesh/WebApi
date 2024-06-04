using Domain.Interfaces.Repositories;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;
public class UnitOfWork
{
    private ApplicationDbContext ApplicationDbContext { get; }
    public UnitOfWork()
	{

	}
    private IProductRepository _productRepository;
    public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(ApplicationDbContext);
}
