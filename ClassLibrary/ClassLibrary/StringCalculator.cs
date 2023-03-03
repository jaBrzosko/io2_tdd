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
            return 0;
        }
    }
}