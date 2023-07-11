using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Products.Commands.DeleteProduct;
using SparkSwim.GoodsService.Products.Commands.UpdateProduct;

namespace SparkSwim.GoodsService.Controllers;

public class ProductAdminController : BaseController
{
    private readonly IMapper _mapper;
    public ProductAdminController(IMapper mapper) => _mapper = mapper;
    
    [HttpPut("createProduct")]
    public async Task<ActionResult<CreateProductCommand>> CreateProduct([FromBody] CreateProductDto createProductDto)
    {
        var command = _mapper.Map<CreateProductCommand>(createProductDto);
        var productId = await Mediator.Send(command);
        return Ok(productId);
    }
    
    [HttpPost("updateProduct")]
    public async Task<ActionResult<CreateProductCommand>> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
    {
        var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpDelete("deleteProduct/{Id}")]
    public async Task<ActionResult<CreateProductCommand>> DeleteProduct(Guid Id)
    {
        var command = new DeleteProductCommand
        {
            Id = Id,
        };
        await Mediator.Send(command);
        return Ok();
    }
}