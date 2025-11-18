namespace HRManagementSystem.Common.Swagger
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ApiGroupAttribute : Attribute
    {
        public ApiGroupAttribute(string groupName, string? sectionName = null)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentException("Group name must be provided.", nameof(groupName));
            }

            GroupName = groupName.Trim();
            SectionName = string.IsNullOrWhiteSpace(sectionName) ? null : sectionName.Trim();
        }

        public string GroupName { get; }

        public string? SectionName { get; }
    }
}

