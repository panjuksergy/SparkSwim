namespace SparkSwim.GoodsService.Goods.Models;

public class ImagesProductModel
{
    public Guid ImageID { get; set; }
    public string ImageUrl { get; set; }
    public string? SecondImageUrl { get; set; }
    public Product Product { get; set; }
}