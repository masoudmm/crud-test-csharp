using System.Text.RegularExpressions;

namespace CustomerCrud.Application.Common
{
    internal static partial class ValidationHelpers
    {
        [GeneratedRegex("^[0-9]{2}[- ]?[0-9]{2}[- ]?[0-9]{2}[- ]?[0-9]{3}$")]
        public static partial Regex DutchBankAccountNumberRegx();
    }
}