using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.OrderService.Controllers.Base;
using SparkSwim.OrderService.Models.Dto;
using SparkSwim.OrderService.Orders.Commands.DeleteOrder;
using SparkSwim.OrderService.Orders.Commands.UpdateOrder;

namespace SparkSwim.OrderService.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderAdminController : BaseController
    {
        private readonly IMapper _mapper;

        public OrderAdminController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] UpdateOrderDto updateOrderDto)
        {
            var command = _mapper.Map<UpdateOrderCommand>(updateOrderDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("cancel/{id}")]
        public async Task<ActionResult> Cancel(Guid id)
        {
            var command = new CancelOrderCommand()
            {
                OrderId = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
