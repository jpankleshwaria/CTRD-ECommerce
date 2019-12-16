using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Constants
{
    public class ValidationMessages
    {
        public const string IsRequired = "{0} is required";
        public const string MaxLength = "{0} must be less than or equal to {1} characters";
        public const string MaxLengthDigits = "{0} must be less than or equal to {1} digits";
        public const string InvalidEmail = "Email address is not valid";
        public const string InvalidFormat = "Invalid {0} Format";
        public const string PleaseSelect = "Please select {0}";
        public const string ValidEmail = "Invalid Email Format";
        public const string InValidFormat = "Invalid {0} Format";
        public const string PleaseEnter = "Please enter {0}";
    }
}
