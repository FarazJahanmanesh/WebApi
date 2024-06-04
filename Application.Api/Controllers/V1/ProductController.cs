using Domain.Interfaces.Services;

namespace Application.Api.Controllers.V1;
public class ProductController : BaseController
{
	private readonly IProductService _productService;
	public ProductController(IProductService productService)
	{
        _productService = productService;
    }
}
