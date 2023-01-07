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

        var viewModel = new ListViewModel<Factor>
        {
            Data = await _fr.GetWithPaginationAsync(pageNumber, pageSize)
        };
        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        Factor item = new Factor();
        item.FactorRows.Add(new FactorRow());
        ViewBag.ProductList = await GetProductsAsync();
        //var products = await GetProductsAsync();
        //ViewBag.ProductList = products
        //                         .Select(x => new {
        //                             Id = x.Id,
        //                             Name = x.Name,
        //                             UnitPrice = x.UnitPrice
        //                         }).ToList();

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Factor model)
    {
        model.FactorRows.RemoveAll(a => a.Quantity == 0 || a.IsDeleted == true);

        //foreach (var item in model.FactorRows.Where(x => x.Quantity == 0).ToList())
        //{
        //    model.FactorRows.Remove(item);
        //}
        foreach (var item in model.FactorRows)
        {
            var P = await _pr.GetByIdAsync(item.ProductId);
            item.Product = P;
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
        return RedirectToAction(nameof(Index));
        //return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var item = await _fr.GetByIdAsync(id);
        ViewBag.ProductList = await GetProductsAsync();
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Factor model)
    {
        model.FactorRows.RemoveAll(a => a.Quantity == 0 || a.IsDeleted == true);
        foreach (var item in model.FactorRows) 
        {
            var P = await _pr.GetByIdAsync(item.ProductId);
            item.Product = P;
        }

        //bool bolret = false;
        var errMessage = "";
        try
        {
            await _fr.UpdateAsync(model);
        }
        catch (Exception ex)
        {
            errMessage = errMessage + " " + ex.Message;
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        await _fr.DeleteAsync(id);
        return RedirectToAction("index");
        //return View();
    }


    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        var factor = await _fr.GetByIdAsync(id);
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
            Value = "$0",
            Text = "----انتخاب کنید----"
        };

        lstProducts.Insert(0, defItem);

        return lstProducts;
    }

    //private async Task<List<Product>> GetProductsAsync()
    //{
    //    var products = await _pr.GetAllAsync();
    //    return products;
    //}

}
