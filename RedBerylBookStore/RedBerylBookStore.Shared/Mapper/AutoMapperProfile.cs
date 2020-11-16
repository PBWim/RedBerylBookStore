namespace RedBerylBookStore.Common.Mapper
{
    using AutoMapper;
    using BO = ServiceModels;
    using DO = DataModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BO.User, DO.User>().ReverseMap();
        }
    }
}