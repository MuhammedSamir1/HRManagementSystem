﻿namespace HRManagementSystem.Common.Data.Enums
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
        OrganizationWasNotDeleted = 102,
        // City 
        CityWasNotDeleted = 103,



        //Branch
        BranchNotFound = 200,
        BranchWasNotDeleted = 201,
        StateNotFound = 202,
        CountryNotFound = 203,
        StateAlreadyExists = 204,
        InvalidRequest = 205,
        StateHasCities = 206,
        NoBranchesFound = 202,




        //
        TeamNotFound = 300,
        TeamWasNotDeleted = 301,
        TeamAlreadyExists = 302,


    }
}
