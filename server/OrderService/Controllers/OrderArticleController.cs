using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.OrderService.Controllers.Base;
using SparkSwim.OrderService.Models.Dto;
using SparkSwim.OrderService.OrderArticles.Commands.CreateOrderArticle;
using SparkSwim.OrderService.OrderArticles.Queries.GetOrderArticleDetails;

namespace SparkSwim.OrderService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrderArticleController : BaseController
    {
        private readonly IMapper _mapper;

        public OrderArticleController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<OrderArticleDetailsVm>> Get(string id)
        {
            var query = new GetOrderArticleDetailsQuery() 
            { 
                Id = Guid.Parse(id),
                UserId = UserId 
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> 
            Create([FromBody] CreateOrderArticleDto createOrderArticleDto)
        {
            var command = _mapper.Map<CreateOrderArticleCommand>(createOrderArticleDto);
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }
    }
}
