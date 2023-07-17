using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Discounts.Commands.CreateDiscount;
using SparkSwim.GoodsService.Discounts.Commands.DeleteDiscount;
using SparkSwim.GoodsService.Discounts.Commands.UpdateDiscount;
using SparkSwim.GoodsService.Discounts.Queries.GetDiscount;
using SparkSwim.GoodsService.Discounts.Queries.GetDiscountsList;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Products.Commands.DeleteProduct;
using SparkSwim.GoodsService.Products.Commands.UpdateProduct;

namespace SparkSwim.GoodsService.Controllers;

[AllowAnonymous]
public class ProductAdminController : BaseController
{
    private readonly IMapper _mapper;
    public ProductAdminController(IMapper mapper) => _mapper = mapper;

    #region Products
    [AllowAnonymous]
    [HttpPost("createProduct")]
    public async Task<ActionResult<CreateProductCommand>> CreateProduct([FromBody] CreateProductDto createProductDto)
    {
        var command = _mapper.Map<CreateProductCommand>(createProductDto);
        var productId = await Mediator.Send(command);
        return Ok(productId);
    }
    
    [HttpPost("updateProduct")]
    public async Task<ActionResult<UpdateProductCommand>> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
    {
        var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpDelete("deleteProduct/{Id}")]
    public async Task<ActionResult<DeleteProductCommand>> DeleteProduct(Guid Id)
    {
        var command = new DeleteProductCommand
        {
            Id = Id,
        };
        await Mediator.Send(command);
        return Ok();
    }
    #endregion
    
    #region Discount
    [HttpGet("getAllDiscounts")]
    public async Task<ActionResult<DiscountListVm>> GetAllProducts([FromBody] GetDiscountListQuery request)
    {
        var vm = await Mediator.Send(request);
        return Ok(vm);
    }
    
    [HttpGet("getSimpleDiscount/{Id}")]
    public async Task<ActionResult<GetDiscountQuery>> GetSimpleDiscount(Guid Id)
    {
        var command = new GetDiscountQuery
        {
            DiscountId = Id
        };
        await Mediator.Send(command);
        return Ok();
    }

    [HttpDelete("deleteDiscount/{Id}")]
    public async Task<ActionResult<DeleteDiscountCommand>> DeleteDiscount(Guid Id)
    {
        var command = new DeleteProductCommand
        {
            Id = Id
        };
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("createDiscount")]
    public async Task<ActionResult<CreateDiscountCommand>> CreateDiscount(
        [FromBody] CreateDiscountDto createDiscountDto)
    {
        var command = _mapper.Map<CreateDiscountCommand>(createDiscountDto);
        var discountId = await Mediator.Send(command);
        return Ok(discountId);
    }
    
    [HttpPost("updateDiscount")]
    public async Task<ActionResult<UpdateDiscountCommand>> UpdateDiscount(
        [FromBody] UpdateDiscountDto updateDiscountDto)
    {
        var command = _mapper.Map<CreateDiscountCommand>(updateDiscountDto);
        var discountId = await Mediator.Send(command);
        return Ok(discountId);
    }
    
    #endregion
}