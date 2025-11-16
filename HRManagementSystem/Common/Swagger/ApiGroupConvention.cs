using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;

namespace HRManagementSystem.Common.Swagger
{
    public sealed class ApiGroupConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var attribute = controller.ControllerType.GetCustomAttribute<ApiGroupAttribute>(inherit: true);

                if (attribute is not null && !string.IsNullOrWhiteSpace(attribute.GroupName))
                {
                    controller.ApiExplorer.GroupName = attribute.GroupName;
                }
                else
                {
                    controller.ApiExplorer.GroupName ??= controller.ControllerName;
                }
            }
        }
    }
}

