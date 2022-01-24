using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MovieAdded = "Movie successfully added.";
        public static string MovieUpdated = "Movie successfully updated.";
        public static string MovieDeleted = "Movie successfully deleted.";
        public static string MovieNotFound = "Movie not found.";
        public static string LastDateFinishTime = "You can rent it on ";
        public static string MovieAlreadyRented = "The movie is already rented. ";
        public static string MovieRentalSuccesfull = "Movie rental successful.  Rental end date is ";
        public static string MovieRentalCancalled = "The movie rental cancellation process is successful.";
        public static string MovieAlreadyAvailable = "The movie is already available for rent";

        public static string CategoryAdded = "Category successfully added.";
        public static string CategoryUpdated = "Category successfully updated.";
        public static string CategoryDeleted = "Category successfully deleted.";
        public static string CategoryNotFound = "Category not found.";

        public static string UserNotFound = "User not exist.";
        public static string UserAlreadyExist = "User already exist";
        public static string PasswordError = "Wrong Password";
        public static string SuccessfulLogin = "Login Successful";
        public static string UserRegistered = "User successfully registered";
        public static string AccesesTokenCreated = "Access Token successfully created";
        public static string AuthorizationDenied = "You are not authorized";

        public static string MovieNameAlreadyExists = "Movie already exist";
    }
}
