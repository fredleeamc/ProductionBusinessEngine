using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class TextGenerator
    {
        /// <summary>
        /// The random
        /// </summary>
        static private Random rnd = new Random();

        /// <summary>
        /// The input1
        /// </summary>
        static private String input1 = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// The input2
        /// </summary>
        static private String input2 = "1234567890";
        /// <summary>
        /// The input3
        /// </summary>
        static private String input3 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// The input4
        /// </summary>
        static private String input4 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// The input5
        /// </summary>
        static private String input5 = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Gets the random.
        /// </summary>
        /// <returns></returns>
        public static Random GetRandom()
        {
            return rnd;
        }

        /// <summary>
        /// Randoms the int.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static int RandomInt(int size)
        {
            return rnd.Next(0, size);
        }

        /// <summary>
        /// Randoms the int.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static double RandomDouble(int size)
        {
            return rnd.NextDouble() * size + rnd.NextDouble();
        }

        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static string RandomString(int size)
        {            
            var chars = Enumerable.Range(0, size)
                .Select(x => input1[rnd.Next(0, input1.Length)]);
            return new string(chars.ToArray());
        }

        /// <summary>
        /// Randoms the numbers.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static string RandomNumbers(int size)
        {
            var chars = Enumerable.Range(0, size)
                .Select(x => input2[rnd.Next(0, input2.Length)]);
            return new string(chars.ToArray());
        }

        /// <summary>
        /// Randoms the chars.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static string RandomChars(int size)
        {
            var chars = Enumerable.Range(0, size)
                .Select(x => input3[rnd.Next(0, input3.Length)]);
            return new string(chars.ToArray());
        }

        /// <summary>
        /// Randoms the chars.
        /// </summary>
        /// <param name="minLength">The minimum length.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Randoms the names.
        /// </summary>
        /// <param name="minLength">The minimum length.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Randoms the names.
        /// </summary>
        /// <returns></returns>
        public static string RandomNames()
        {
            return RandomNames(8, 15);
        }
    }
}
