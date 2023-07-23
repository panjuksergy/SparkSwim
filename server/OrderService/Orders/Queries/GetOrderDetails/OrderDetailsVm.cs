using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.OrderService.Models;

namespace SparkSwim.OrderService.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsCanceled { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>();
        }
    }
}
