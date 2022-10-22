namespace Library.Data
{
    public class DataConstraints
    {
        public class LibraryUserConstraints
        {
            public const int MinUserNameLength = 5;
            public const int MaxUserNameLength = 20;

            public const int MinEmailLength = 10;
            public const int MaxEmailLength = 60;

            public const int MinPasswordLength = 5;
            public const int MaxPasswordLength = 20;
        }

        public class BookConstraints
        {
            public const int MinTitleLength = 10;
            public const int MaxTitleLength = 50;

            public const int MinAuthorLength = 5;
            public const int MaxAuthorLength = 50;

            public const int MinDescriptionLength = 5;
            public const int MaxDescriptionLength = 5000;

            public const int MaxUrlLength = 2048;

            public const string MinRatingLength = "0.00";
            public const string MaxRatingLength = "10.00";
            public const int RatingPrecision = 4;
            public const int RatingScale = 2;
        }

        public class CategoryConstraints
        {
            public const int MinNameLength = 5;
            public const int MaxNameLength = 50;
        }
    }
}
