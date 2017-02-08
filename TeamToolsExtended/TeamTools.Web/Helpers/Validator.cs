namespace TeamTools.Web.Helpers
{
    public static class Validator
    {
        public static bool ValidateRange(string value, int min, int max)
        {
            bool isInRange = value.Length >= min && value.Length <= max;
            return isInRange;
        }
    }
}