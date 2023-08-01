using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.OrderService.Controllers.Base;
using SparkSwim.OrderService.Models.Dto;
using SparkSwim.OrderService.OrderArticles.Commands.UpdateOrderArticle;

namespace SparkSwim.OrderService.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderArticleAdminController : BaseController
    {
        private readonly IMapper _mapper;

        public OrderArticleAdminController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPut("update")]
        public async Task<ActionResult>
            Update([FromBody] UpdateOrderArticleDto updateOrderArticleDto)
        {
            var command = _mapper.Map<UpdateOrderArticleCommand>(updateOrderArticleDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
