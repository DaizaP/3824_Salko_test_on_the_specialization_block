using System.Text.RegularExpressions;

namespace Pet.Presenter
{
    internal class Validator
    {

        public static bool validName(string name)
        {
            string patternName = @"([А-ЯЁ][а-яё]+[\-\s]?){1,}";
            return Regex.Match(name, patternName).Success;

        }
        public static bool validBirthDate(string birthDate)
        {
            string patternBirthDate = @"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))";
            return Regex.Match(birthDate, patternBirthDate).Success;

        }
    }
}
