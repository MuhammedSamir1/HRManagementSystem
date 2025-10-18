namespace HRManagementSystem.Common.Data.Enums
{
    public enum ErrorCode
    {
        //Generic
        None = 0,
        NotFound = 1,
        ValidationError = 2,
        Unauthorized = 3,
        Forbidden = 4,
        Conflict = 5,
        InternalServerError = 6,
        BadRequest = 7,



        //Organization
        OrganizationAlreadyExists = 100,
        OrganizationNotFound = 101,

    }
}
