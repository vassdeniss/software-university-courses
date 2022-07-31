// ReSharper disable InconsistentNaming
namespace PetStore.Data.Models.Common
{
    public static class ProductValidationConstants
    {
        //Messages
        public const string NameIsRequired = "Product name is required!";
        public const string NameMinLengthMessage = "Product name must be at least 3 characters long!";
        public const string NameMaxLengthMessage = "Product name must be no more than 70 characters long!";

        public const int NameMinLength = 3;
        public const int NameMaxLength = 70;

        public const string PriceMinValue = "0";
        public const string PriceMaxValue = "79228162514264337593543950335";
    }
}
