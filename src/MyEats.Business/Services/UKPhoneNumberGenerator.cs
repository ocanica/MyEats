using System;
using System.Text;

namespace MyEats.Business.Services
{
    public class UKPhoneNumberGenerator
    {
        public static string Generate(string prefix = "07")
        {
            Random random = new Random();
            StringBuilder number = new StringBuilder();
            
            number.Append(prefix);

            for (int i = 1; i <= 11 - prefix.Length; i++)
            {
                number.Append(random.Next(0, 9));
            }

            return number.ToString();
        }
    }
}
