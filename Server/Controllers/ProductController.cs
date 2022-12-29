using Domain.Products;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Index(int page)
        {
            _logger.LogInformation($"Show Product List With Browser : {Request.Headers["User_Agent"]}");
            ViewData["Title"] = "Products";
      
            return View(result.ToList());
        }
    }
}
