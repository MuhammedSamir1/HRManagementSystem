namespace HRManagementSystem.Features.UserManagement.GetUserByNameAndPassword.Mapping
{
    public class GetUserByNameAndPasswordProfile : Profile
    {
        public GetUserByNameAndPasswordProfile()
        {
            CreateMap<User, GetUserByNameAndPasswordDto>()
                 .ForMember(dest => dest.userId,
                 opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Username,
                 opt => opt.MapFrom(src => src.UserName))
                 .ForMember(dest => dest.RoleName,
                 opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
