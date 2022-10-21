namespace Watchlist.Data.Models
{
    public class DataConstraints
    {
        public class UserConstraints
        {
            public const int MinUsernameLength = 5;
            public const int MaxUsernameLength = 20;

            public const int MinEmailLength = 10;
            public const int MaxEmailLength = 60;

            public const int MinPasswordLength = 5;
            public const int MaxPasswordLength = 20;
        }

        public class MovieConstraints
        {
            public const int MinTitleLength = 10;
            public const int MaxTitleLength = 50;

            public const int MinDirectorLength = 5;
            public const int MaxDirectorLength = 50;

            public const string MinRatingLength = "0.00";
            public const string MaxRatingLength = "10.00";
        }

        public class GenreConstraints
        {
            public const int MinNameLength = 5;
            public const int MaxNameLength = 50;
        }
    }
}
