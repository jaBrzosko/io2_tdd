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
            {
                if (singleNumber < 0)
                    throw new ArgumentOutOfRangeException();
                else if (singleNumber > 1000)
                    return 0;
                return singleNumber;
            }

            var separated = numbers.Split('\n', ',');
            int a;
            int sum = 0;
            for(int i = 0; i < separated.Length;i++)
            {
                if (int.TryParse(separated[i], out a))
                {
                    if (a < 0)
                        throw new ArgumentOutOfRangeException();
                    else if (a > 1000)
                        continue;
                    sum += a;
                }
                else
                    return 0;
            }
            return sum;
        }

    }
}