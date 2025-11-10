using HRManagementSystem.Features.Common.DeleteEntityCascade.Command;

namespace HRManagementSystem.Features.Common.DeleteEntityCascade.Mapping;

public sealed class DeleteCascadeProfile : Profile
{
    public DeleteCascadeProfile()
    {
        CreateMap(typeof(DeleteEntityCascadeViewModel<,>),
                typeof(DeleteEntityCascadeCommand<,>));
    }
}
