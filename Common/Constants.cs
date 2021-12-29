﻿namespace Common
{
    public  class Constants
    {

        #region Constructors

        public Constants()
        {

        }

        #endregion

        #region Constants

        public const string UserRoleTitle = "User";
        public const string AdminRoleTitle = "Admin";
        public const string CustomerRoleTitle = "Customer";
        public const string usp_SelectCountry = "usp_SelectCountry";
        public const string usp_InsertCountry = "usp_InsertCountry";
        public const string usp_UpdateCountry = "usp_UpdateCountry";
        public const string usp_DeleteCountry = "usp_DeleteCountry";
        public const string usp_GetStatesWithCountry = "usp_GetStatesWithCountry";
        public const string usp_GetCityWithStateCountry = "usp_GetCityWithStateCountry";
        public const string Country = "Country";        
        public const string Space = " ";
        public const string InsertedSuccesfully = "Saved Succesfully";
        public const string UpdatedSuccesfully = "Updated Succesfully";
        public const string DeletedSuccesfully = "Deleted Succesfully";
        public const string AlreadyExist = "Already Exist";
        public const string NotFound = "Not Found";
        public const string SomethingWentWrong = "Something went wrong while";
        public const string Saving = "Saving";
        public const string Updating = "Updating";
        public const string Deleting = "Deleting";
        //public const string State = "State";

        #endregion

        #region Enums 

        public enum Entity
        {
            Country,
            State,
            City,
            Category,
            Product
        }

        public enum CrudOperationType
        {
            Insert = 1,
            Update = 2,
            Delete = 3,
            ErrorOnInsert = 4,
            ErrorOnUpdate = 5,
            AlreadyExist = 6,
            Duplicate = 7
        } 

        #endregion

    }
}