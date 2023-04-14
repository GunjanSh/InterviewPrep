using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class PowerFunction_FastExponentiation
    {
        /// <summary>
        /// Return (a^b)%c
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <param name="C">The c.</param>
        /// <returns></returns>
        public static int pow(int A, int B, int C)
        {
            if (A == 0)
            {
                return 0;
            }

            if (B == 0)
            {
                return 1;
            }

            long halfPower = (pow(A, B / 2, C)+C) % C;
            
            if ((B & 1) == 0)
            {
                return (int)((halfPower%C * halfPower % C)+C) % C;
            }
            else
            {
                return (int)((halfPower % C * halfPower % C * A %C)+C) % C;
            }
        }

        /// <summary>
        /// Return (a^b)%c
        /// Handles negative numbers (A)
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <param name="C">The c.</param>
        /// <returns></returns>
        public static int pow2(int A, int B, int C)
        {
            if (A == 0)
            {
                return 0;
            }

            if (B == 0)
            {
                return 1;
            }

            // if (a < 0) {a%m = a%m + m} else { a%m = (a%m + m) % m}
            if (A < 0)
            {
                A = A + C;
            }

            long halfPower = pow(A, B / 2, C) ;

            if ((B & 1) == 0)
            {
                return (int)(halfPower % C * halfPower % C) % C;
            }
            else
            {
                return (int)(halfPower % C * halfPower % C * A % C) % C;
            }
        }
    }
}
