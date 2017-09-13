using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{
    public class TextGenerator
    {
        static private Random rnd = new Random();

        static private String input1 = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static private String input2 = "1234567890";
        static private String input3 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static private String input4 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static private String input5 = "abcdefghijklmnopqrstuvwxyz";

        public static Random getRandom()
        {
            return rnd;
        }

        public static int RandomInt(int size)
        {
            return rnd.Next(0, size);
        }

        public static string RandomString(int size)
        {            
            var chars = Enumerable.Range(0, size)
                .Select(x => input1[rnd.Next(0, input1.Length)]);
            return new string(chars.ToArray());
        }

        public static string RandomNumbers(int size)
        {
            var chars = Enumerable.Range(0, size)
                .Select(x => input2[rnd.Next(0, input2.Length)]);
            return new string(chars.ToArray());
        }

        public static string RandomChars(int size)
        {
            var chars = Enumerable.Range(0, size)
                .Select(x => input3[rnd.Next(0, input3.Length)]);
            return new string(chars.ToArray());
        }

        public static string RandomChars(int minLength, int size)
        {
            if (minLength == 0)
                minLength = 1;
            else if (minLength > size)
                minLength = size;

            int min = rnd.Next(minLength, size);
            var chars = Enumerable.Range(0, min)
                .Select(x => input3[rnd.Next(0, input3.Length)]);
            return new string(chars.ToArray());
        }

        public static string RandomNames(int minLength, int size)
        {
            if (minLength == 0)
                minLength = 1;
            else if (minLength > size)
                minLength = size;

            char capChar = input4[rnd.Next(0, input4.Length)];
            int min = rnd.Next(minLength, size);
            var chars = Enumerable.Range(0, min-1)
                .Select(x => input5[rnd.Next(0, input5.Length)]);
            StringBuilder sb = new StringBuilder();
            sb.Append(capChar);
            sb.Append(chars.ToArray());
            return sb.ToString();
        }

        public static string RandomNames()
        {
            return RandomNames(8, 15);
        }
    }
}
