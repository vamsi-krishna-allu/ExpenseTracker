namespace CoreLibrary
{
    public class Validators
    {
        public static bool IsPasswordValid(string value)
        {
            if (value != null)
            {
                String password = value.ToString();
                if (password.Length < 6 || password.Length > 20)
                    return false;

                if (!password.Any(char.IsUpper))
                    return false;

                if (!password.Any(char.IsLower))
                    return false;

                if (password.Contains(' '))
                    return false;

                string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
                char[] specialCharacterArray = specialCharacters.ToCharArray();
                foreach (char ch in specialCharacterArray)
                {
                    if (password.Contains(ch))
                        return true;
                }
            }

            return false;
        }
    }
}