namespace QuizaphFrontend.Services
{
    public static class HelperMethods
    {
        public static string SplitByCamelCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            var result = new System.Text.StringBuilder();
            foreach (char c in input)
            {
                if (char.IsUpper(c) && result.Length > 0)
                    result.Append(' ');
                result.Append(c);
            }
            return result.ToString();
        }
    }
}
