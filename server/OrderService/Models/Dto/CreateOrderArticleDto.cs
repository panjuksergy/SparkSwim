using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.OrderService.OrderArticles.Commands.CreateOrderArticle;

namespace SparkSwim.OrderService.Models.Dto
{
    public class CreateOrderArticleDto : IMapWith<CreateOrderArticleCommand>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderArticleDto, CreateOrderArticleCommand>();
        }
    }
}
