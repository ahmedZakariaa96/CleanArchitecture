namespace Application.Base.Shared
{
    public class RegularExpressions
    {
        public const string ArabicOnly = "^[\u0621-\u064A\u0660-\u0669 ]+$";
        public const string ArabicAndNumbers = "^[\u0621-\u064A\u0660-\u0669 0-9 ]+$";
        public const string EnglishOnly = "^[a-zA-Z ]+$";
        public const string EnglishAndNumbers = "^[a-zA-Z0-9 ]+$";
        public const string NumberOnly = "^[0-9]*$";
        public const string ArabicAndNumbersWithDashes = "^[\u0621-\u064A\u0660-\u0669 0-9_/-]+$";
        public const string Phone = "^01[0-2,5]{1}[0-9]{8}$";
        public const string TelePhone = "^(02|013|03|04|05|06|07|08|09)[0-9]{7,8}$";
        public const string NationalId = "^(2|3)[0-9][0-9][0-1][0-9][0-3][0-9](01|02|03|04|05|06|11|12|13|14|15|16|17|18|19|21|22|23|24|25|26|27|28|29|31|32|33|34|35|88)\\d\\d\\d\\d\\d$";
        public const string Linkedin = "http(s)?:\\/\\/([\\w]+\\.)?linkedin\\.com\\/in\\/[A-z0-9_-]+\\/?";
    }
}
