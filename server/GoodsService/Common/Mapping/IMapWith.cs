using AutoMapper;

namespace SparkSwim.GoodsService.Common.Mapping;

public interface IMapWith<T>
{
    void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}