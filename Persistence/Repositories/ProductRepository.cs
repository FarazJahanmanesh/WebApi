using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;
public class ProductRepository: IProductRepository
{
	private readonly DbContext _dbContext;
	public ProductRepository(DbContext dbContext)
	{
		_dbContext = dbContext;
	}
}
