using Domain.FactorRows;
using Domain.Factors;
using Domain.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Server.Models;

namespace Server.Controllers;

public class FactorController : Infrastructure.BaseController
{

    #region field
    private ILogger<ProductController> _logger;
    private readonly IProductRepository _pr;
    private readonly IFactorRepository _fr;
    private int pageSize = 5;
    #endregion


    #region Constructor
    public FactorController(ILogger<ProductController> logger, IFactorRepository factorRepository, IProductRepository productRepository)
    {
        _logger = logger;
        _fr = factorRepository;
        _pr = productRepository;
    }
    #endregion

    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1)
    { 
        ViewData["Title"] = "لیست فاکتور ها";
        var items = await _fr.GetWithPaginationAsync(pageNumber, pageSize);

        var viewModel = new ProductListViewModel
        {
            Data = await _pr.GetWithPaginationAsync(pageNumber, pageSize)
        };
        return View(viewModel);

    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        Factor item = new Factor();
        item.FactorRows.Add(new FactorRow());
        //item.FactorRows.Add(new Product(), new FactorRow());

        ViewBag.ProductList = await GetProductsAsync();
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Factor model)
    {
        foreach (var item in model.FactorRows.Where(x => x.Quantity == 0).ToList())
        {
            model.FactorRows.Remove(item);
        }

        //bool bolret = false;
        var errMessage = "";
        try
        {
            await _fr.CreateAsync(model);
        }
        catch (Exception ex)
        {
            errMessage = errMessage + " " + ex.Message;
        }
        //if (bolret == false)
        //{
        //    errMessage = errMessage + " " + _Repo.GetErrors();

        //    TempData["ErrorMessage"] = errMessage;
        //    ModelState.AddModelError("", errMessage);
        //    return View(item);
        //}
        //else
        //{
        //    TempData["SuccessMessage"] = "" + item.PoNumber + " Created Successfully";
        //    return RedirectToAction(nameof(Index));
        //}
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        var factor = await _fr.GetByIdAsync(id);

        ViewData["ProductList"] = await GetProductsAsync();
        return View(factor);
    }

    private async Task<List<SelectListItem>> GetProductsAsync()
    {
        var lstProducts = new List<SelectListItem>();

        var products = await _pr.GetAllAsync();

        lstProducts = products.Select(p => new SelectListItem()
        {
            //Value = p.Id.ToString(),
            Value = String.Join("$", new string[] { p.Id.ToString(), p.UnitPrice.ToString() }),
            Text = p.Name
        }).ToList();

        var defItem = new SelectListItem()
        {
            Value = "",
            Text = "----انتخاب کنید----"
        };

        lstProducts.Insert(0, defItem);

        return lstProducts;
    }

//    private async Task<List<Product>> GetProductsAsync()
//    {
//        var products = await _pr.GetAllAsync();
//        return products;
//    }

}
