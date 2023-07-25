using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Products.Queries.GetProduct;
using SparkSwim.GoodsService.Products.Queries.GetProductList;

namespace SparkSwim.GoodsService.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProductController : BaseController
{
    [HttpGet("getAllProducts")]
    public async Task<ActionResult<ProductListVm>> GetAllProducts([FromBody] GetProductListQuery request)
    {
        var query = new GetProductListQuery
        {
            NumberFromToSkip = request.NumberFromToSkip,
            CountToGet = request.CountToGet,
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

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