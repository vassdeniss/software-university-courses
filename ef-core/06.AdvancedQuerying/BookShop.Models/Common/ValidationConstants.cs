namespace BookShop.Models.Common
{
    public static class ValidationConstants
    {
        // Category
        public const int MaxCategoryNameLength = 50;

        // Author
        public const int MaxAuthorFirstNameLength = 50;
        public const int MaxAuthorLastNameLength = 50;

        // Book
        public const int MaxBookTitleLength = 50;
        public const int MaxBookDescriptionLength = 1000;
    }
}
