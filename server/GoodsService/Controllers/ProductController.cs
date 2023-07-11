using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Products.Queries.GetProduct;
using SparkSwim.GoodsService.Products.Queries.GetProductList;

namespace SparkSwim.GoodsService.Controllers;

public class ProductController : BaseController
{
    [AllowAnonymous]
    [HttpGet("getAllProducts")]
    public async Task<ActionResult<ProductListVm>> GetAllProducts([FromBody] int numberToSkip)
    {
        var query = new GetProductListQuery
        {
            NumberFromToSkip = numberToSkip,
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [AllowAnonymous]
    [HttpGet("product/{Id}")]
    public async Task<ActionResult<ProductVm>> GetProductWithoutDetailsById(Guid Id)
    {
        var query = new GetProductQuery
        {
            ProductId = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [AllowAnonymous]
    [HttpGet("details/{Id}")]
    public async Task<ActionResult<ProductDetailsVm>> GetProductDetails(Guid Id)
    {
        var query = new GetProductDetailsQuery
        {
            ProductId = Id,
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
}