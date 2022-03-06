using E03.Telephony.Contracts;
using E03.Telephony.Exceptions;
using E03.Telephony.Validation;
using System;

namespace E03.Telephony.Models
{
    public class Stationary : IDialable
    {
        public string Dial(string number)
        {
            if (!Validator.IsValidNumber(number))
            {
                throw new ArgumentException
                    (ExceptionMessages.ArgumentExceptions.InvalidPhoneNumberException);
            }

            if (Validator.IsStationaryNumber(number))
            {
                return $"Dialing... {number}";
            }

            return string.Empty;
        }
    }
}
