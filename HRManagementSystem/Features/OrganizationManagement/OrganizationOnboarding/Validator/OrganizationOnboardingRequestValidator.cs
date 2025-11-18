using FluentValidation;

namespace HRManagementSystem.Features.OrganizationManagement.OrganizationOnboarding.Validator;

public class OrganizationOnboardingRequestValidator : AbstractValidator<OrganizationOnboardingRequestViewModel>
{
    public OrganizationOnboardingRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Organization name is required.")
            .MaximumLength(200);

        RuleFor(x => x.Currency)
            .NotNull().WithMessage("Currency is required.");

        RuleFor(x => x.Address)
            .NotNull().WithMessage("Address is required.");

        RuleFor(x => x.Companies)
            .NotNull().WithMessage("At least one company is required.")
            .Must(companies => companies is { Count: > 0 })
            .WithMessage("At least one company is required.");

        RuleFor(x => x.DefaultTimezone)
            .Must(BeValidTimeZone)
            .WithMessage("Default timezone must be a valid timezone id.");

        RuleForEach(x => x.Companies)
            .SetValidator(new CompanyRequestValidator());
    }

    private static bool BeValidTimeZone(string? timezoneId)
    {
        if (string.IsNullOrWhiteSpace(timezoneId))
            return true;

        return TimeZoneInfo.GetSystemTimeZones()
            .Any(z => z.Id.Equals(timezoneId, StringComparison.OrdinalIgnoreCase));
    }
}

public class CompanyRequestValidator : AbstractValidator<CompanyRequestViewModel>
{
    public CompanyRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
        RuleForEach(x => x.Branches).SetValidator(new BranchRequestValidator());
    }
}

public class BranchRequestValidator : AbstractValidator<BranchRequestViewModel>
{
    public BranchRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Code).NotEmpty();
        RuleForEach(x => x.Departments).SetValidator(new DepartmentRequestValidator());
    }
}

public class DepartmentRequestValidator : AbstractValidator<DepartmentRequestViewModel>
{
    public DepartmentRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleForEach(x => x.Teams).SetValidator(new TeamRequestValidator());
    }
}

public class TeamRequestValidator : AbstractValidator<TeamRequestViewModel>
{
    public TeamRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}

