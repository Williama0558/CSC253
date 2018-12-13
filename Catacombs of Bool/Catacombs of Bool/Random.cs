using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Catacombs_of_Bool
{
    // This is class that was created to be able to generate better random numbers. It works by inheriting from an abstract class provided by Microsoft called RandomNumberGenerator.
    // 
    class Random : RandomNumberGenerator
    {
        private RandomNumberGenerator RNG;

        public Random()
        {
            RNG = RandomNumberGenerator.Create();
        }

        // Method that is from the abstract class RandomNumberGenerator
        public override void GetBytes(byte[] buffer)
        {
            RNG.GetBytes(buffer);
        }

        // Method that gets a value from the bytes array to be used in calculation that will create a random number.
        public double NextDouble()
        {
            byte[] b = new byte[4];
            RNG.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        public int Next(int minValue, int maxValue)
        {
            // Gets a random integer that matches the specified criteria
            return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) + minValue;
        }

        public int Next()
        {
            // Gets a random integer if no value is provided
            return Next(0, Int32.MaxValue);
        }
    }
}
