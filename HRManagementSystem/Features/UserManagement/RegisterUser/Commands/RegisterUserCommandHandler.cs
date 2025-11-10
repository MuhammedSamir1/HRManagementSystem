using Microsoft.AspNetCore.Identity;

namespace HRManagementSystem.Features.UserManagement.RegisterUser.Commands
{
    public class RegisterUserCommandHandler : RequestHandlerBase<RegisterUserCommand, RequestResult<bool>, User, Guid>
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public RegisterUserCommandHandler(
            RequestHandlerBaseParameters<User, Guid> parameters,
            IPasswordHasher<User> passwordHasher
        ) : base(parameters)
        {
            _passwordHasher = passwordHasher;
        }

        public override async Task<RequestResult<bool>> Handle(RegisterUserCommand request, CancellationToken ct)
        {
            // تحويل الـ Command إلى كيان User
            var user = _mapper.Map<RegisterUserCommand, User>(request);

            // التحقق من وجود اسم المستخدم مسبقًا
            //var usernameExists = await _generalRepo.ExistsAsync<User>(u => u.UserName == request.UserName);

            //if (usernameExists)
            //    return RequestResult<bool>.Failure("Username already exists.", ErrorCode.Conflict);

            // تشفير كلمة المرور
            //user.Password = _passwordHasher.HashPassword(user, request.Password);

            // إضافة المستخدم
            var isAdded = await _generalRepo.AddAsync(user, ct);
            if (!isAdded)
                return RequestResult<bool>.Failure("User wasn't registered successfully!", ErrorCode.InternalServerError);

            return RequestResult<bool>.Success(isAdded, "User registered successfully!");
        }
    }
}
