using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.OrderService.Orders.Commands.CreateOrder;

namespace SparkSwim.OrderService.Models.Dto
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>();
        }
    }
}
