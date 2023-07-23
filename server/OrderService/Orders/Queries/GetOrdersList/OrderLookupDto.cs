using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.OrderService.Models;

namespace SparkSwim.OrderService.Orders.Queries.GetOrdersList
{
    public class OrderLookupDto : IMapWith<Order>
    {
        public DateTime CreationDate { get; set; }
        public bool IsCanceled { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>();
        }
    }
}
