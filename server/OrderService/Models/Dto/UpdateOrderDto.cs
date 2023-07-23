using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.OrderService.Orders.Commands.UpdateOrder;

namespace SparkSwim.OrderService.Models.Dto
{
    public class UpdateOrderDto : IMapWith<UpdateOrderCommand>
    {
        public Guid OrderId { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>();
        }
    }
}
