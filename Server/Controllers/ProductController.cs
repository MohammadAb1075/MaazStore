using Domain.Products;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    public class ProductController : Infrastructure.BaseController
    {
        #region field
        private ILogger<ProductController> _logger;
        private readonly IProductRepository _pr;
        private int pageSize = 5;
        #endregion

        #region Constructor
        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _pr = productRepository;
        }
        #endregion

        #region Get
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var viewModel = new ProductListViewModel
            {
                Data = await _pr.GetAllAsync(pageNumber, pageSize)
            };
            return View(viewModel);
        }
        #endregion
    }
}
