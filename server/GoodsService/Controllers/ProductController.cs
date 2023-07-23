using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Products.Queries.GetProduct;
using SparkSwim.GoodsService.Products.Queries.GetProductList;

namespace SparkSwim.GoodsService.Controllers;

[AllowAnonymous]
public class ProductController : BaseController
{
    [HttpGet("checkMe")]
    public ActionResult CheckMe()
    {
        return Ok();
    }
    
    [AllowAnonymous]
    [HttpGet("getAllProducts")]
    public async Task<ActionResult<ProductListVm>> GetAllProducts([FromBody] GetProductListQuery request)
    {
        var query = new GetProductListQuery
        {
            NumberFromToSkip = request.NumberFromToSkip,
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [AllowAnonymous]
    [HttpGet("product/{Id}")]
    public async Task<ActionResult<ProductVm>> GetProductWithoutDetailsById(string Id)
    {
        
        var query = new GetProductQuery
        {
            ProductId = Guid.Parse(Id)
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