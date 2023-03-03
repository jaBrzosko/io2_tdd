using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;
            if(int.TryParse(numbers, out int singleNumber))
                return singleNumber;
            if(numbers.Contains(","))
            {
                var separated = numbers.Split(',');
                if (separated.Length == 2 && int.TryParse(separated[0], out int a) && int.TryParse(separated[1], out int b))
                    return a + b;
            }

            return 0;
        }
    }
}