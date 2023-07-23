using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.OrderService.OrderArticles.Commands.UpdateOrderArticle;

namespace SparkSwim.OrderService.Models.Dto
{
    public class UpdateOrderArticleDto : IMapWith<UpdateOrderArticleCommand>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderArticleDto, UpdateOrderArticleCommand>();
        }
    }
}
