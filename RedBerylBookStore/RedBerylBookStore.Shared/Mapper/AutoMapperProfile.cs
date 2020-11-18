namespace RedBerylBookStore.Common.Mapper
{
    using AutoMapper;
    using Shared.Domain;
    using BO = ServiceModels;
    using DO = DataModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, BO.User>().ReverseMap();

            CreateMap<BO.Book, DO.Book>().ReverseMap();

            CreateMap<BO.User, DO.User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.FirstName}.{src.LastName}"))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(des => des.Books, opt => opt.MapFrom(src => src.Books))
                .ReverseMap()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}