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
            ViewData["Title"] = "لیست محصولات";
            var viewModel = new ProductListViewModel
            {
                Data = await _pr.GetAllAsync(pageNumber, pageSize)
            };
            return View(viewModel);
        }
        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Title"] = "ایجاد محصول جدید";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                await _pr.AddAsync(model);
                return RedirectToAction("Index");
                //return RedirectToAction("Create");
                //return view(model);
            }
            else
            {
                return View(model);
            }
        }

        #endregion

        #region Edit
        //[Route("id")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "ویرایش محصول";
            var model = await _pr.GetByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product model)
        {
            ViewData["Title"] = "ویرایش محصول";
            if (ModelState.IsValid)
            {
                await _pr.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _pr.DeleteAsync(id);
            return RedirectToAction("index");
        }
        #endregion
    }
}
