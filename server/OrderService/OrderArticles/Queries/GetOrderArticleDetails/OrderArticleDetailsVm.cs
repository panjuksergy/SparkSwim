using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.OrderService.Models;

namespace SparkSwim.OrderService.OrderArticles.Queries.GetOrderArticleDetails
{
    public class OrderArticleDetailsVm : IMapWith<OrderArticle>
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderArticle, OrderArticleDetailsVm>();
        }
    }
}
