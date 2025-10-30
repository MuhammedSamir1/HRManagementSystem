using HRManagementSystem.Features.AuthManagement.Register.Commands;

namespace HRManagementSystem.Features.UserManagement.RegisterUser.Mapping
{
    public class RegisterUserProfile : Profile
    {
        public RegisterUserProfile()
        {
            CreateMap<RegisterUserCommand, User>();
        }
    }
}
