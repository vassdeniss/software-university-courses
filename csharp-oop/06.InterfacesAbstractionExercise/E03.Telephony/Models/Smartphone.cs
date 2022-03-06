using E03.Telephony.Contracts;
using E03.Telephony.Exceptions;
using E03.Telephony.Validation;
using System;

namespace E03.Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Browse(string url)
        {
            if (!Validator.IsValidURL(url))
            {
                throw new ArgumentException
                    (ExceptionMessages.ArgumentExceptions.InvalidUrlException);
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!Validator.IsValidNumber(number))
            {
                throw new ArgumentException
                    (ExceptionMessages.ArgumentExceptions.InvalidPhoneNumberException);
            }

            if (Validator.IsSmartphoneNumber(number))
            {
                return $"Calling... {number}";
            }

            return string.Empty;
        }
    }
}
