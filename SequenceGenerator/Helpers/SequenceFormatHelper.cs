using System.Collections;

namespace SequenceGenerator.Helpers
{
    public static class SequenceFormatHelper
    {
        public static string Format(string seperator, ArrayList input)
        {
            var inputArray =  input.ToArray();
            return string.Join(seperator, inputArray);
        }
    }
}