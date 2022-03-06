namespace E03.Telephony.Validation
{
    public static class Validator
    {
        public static bool IsValidURL(string value)
        {
            foreach (char c in value)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValidNumber(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsSmartphoneNumber(string value)
        {
            return value.Length == 10;
        }

        public static bool IsStationaryNumber(string value)
        {
            return value.Length == 7;
        }
    }
}
