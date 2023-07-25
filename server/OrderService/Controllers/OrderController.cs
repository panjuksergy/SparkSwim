﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.OrderService.Models.Dto;
using SparkSwim.OrderService.Orders.Commands.CreateOrder;
using SparkSwim.OrderService.Orders.Commands.DeleteOrder;
using SparkSwim.OrderService.Orders.Commands.UpdateOrder;
using SparkSwim.OrderService.Orders.Queries.GetOrderDetails;
using SparkSwim.OrderService.Orders.Queries.GetOrdersList;

namespace SparkSwim.OrderService.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var query = new GetOrderListQuery() { UserId = UserId};
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<OrderDetailsVm>> Get(Guid id)
        {
            var query = new GetOrderDetailsQuery() 
            { 
                Id = id,
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto createOrderDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
            command.UserId = UserId;
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
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