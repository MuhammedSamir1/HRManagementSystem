using System.Reflection;

namespace HRManagementSystem.Common.Swagger
{
    public static class ApiGroupDiscovery
    {
        public static IReadOnlyList<ApiGroup> Discover(Assembly assembly)
        {
            if (assembly is null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            return assembly
                .GetTypes()
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t)
                            && t.IsClass
                            && !t.IsAbstract)
                .Select(t => t.GetCustomAttribute<ApiGroupAttribute>(inherit: true))
                .Where(attr => attr is not null && !string.IsNullOrWhiteSpace(attr.GroupName))
                .Select(attr => attr!.GroupName.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
                .Select(name => new ApiGroup(name, $"{name} APIs"))
                .ToList();
        }
    }
}

