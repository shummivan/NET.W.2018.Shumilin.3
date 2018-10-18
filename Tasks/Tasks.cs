using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tasks_day3
{
    public class Tasks
    {
        #region Double to binary string
        /// <summary>
        /// Double value to binary string
        /// </summary>
        /// <param name="inTarget">Input number</param>
        /// <returns>String of bits</returns>
        public string DoubleToBinaryString(double inTarget)
        {
            #region Check 
            if (inTarget == double.MinValue)
            {
                return "1111111111101111111111111111111111111111111111111111111111111111";
            }
            if (inTarget == double.MaxValue)
            {
                return "0111111111101111111111111111111111111111111111111111111111111111";
            }
            if (double.IsNaN(inTarget))
            {
                return "1111111111111000000000000000000000000000000000000000000000000000";
            }
            if (inTarget == double.PositiveInfinity)
            {
                return "0111111111110000000000000000000000000000000000000000000000000000";
            }
            if (inTarget == double.NegativeInfinity)
            {
                return "1111111111110000000000000000000000000000000000000000000000000000";
            }
            #endregion

            long wholeLong = (long)inTarget;

            double divisionalDouble = inTarget - wholeLong;

            string[] temp = (inTarget.ToString()).Split(',');

            if(temp.Length == 2)
            {
                divisionalDouble = Convert.ToDouble(temp[1]) / Math.Pow(10,temp[1].Length);
            }

            string whole = DecimalToBinaryString(wholeLong);
            string divisional = CalcDivisional(divisionalDouble);

            string mantissa = (whole + divisional).Remove(0, 1);

            int shift = whole.Length - 1 + 1023;

            if (whole.Length == 0)
            {
                shift = 0;
            }            

            string exponent = DecimalToBinaryString(shift);

            return Assembly(inTarget, exponent,mantissa).Substring(0, 64);
        }

        /// <summary>
        /// Assembly bits
        /// </summary>
        /// <param name="inTarget">Input number</param>
        /// <param name="exponent">Exponent</param>
        /// <param name="mantissa">Mantissa</param>
        /// <returns>Assembled string</returns>
        private static string Assembly(double inTarget, string exponent, string mantissa)
        {
            string result = null;

            if (inTarget >= 0)
            {
                result += String.Join("", 0);
            }
            else
            {
                result += String.Join("", 1);
            }

            result += String.Join("", exponent);
            result += String.Join("", mantissa);

            return result;
        }

        /// <summary>
        /// Convert decimal to binary string
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>String of bit</returns>
        private static string DecimalToBinaryString(long number)
        {
            string temp = "";

            if(number < 0)
            {
                number = Math.Abs(number);
            }

            for (int i = 0; number > 0; i++)
            {
                temp += String.Join("", number % 2);
                number /= 2;
            }            

            return Reverse(temp);
        }

        /// <summary>
        /// Reverse string
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private static string Reverse(string temp)
        {
            char[] Arr = temp.ToCharArray();
            Array.Reverse(Arr);

            return new string(Arr);
        }

        /// <summary>
        /// Calculated divisional to bit
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>String of bits</returns>
        private static string CalcDivisional(double number)
        {
            int[] result = new int[53];

            for (int i = 0; i < 53; i++)
            {
                number = number * 2;

                if(number >= 1)
                {
                    number--;
                    result[i] = 1;
                }
                else
                {
                    result[i] = 0;
                }
            }

            return string.Join("", result); ;
        }

        /// <summary>
        /// Checking input params
        /// </summary>
        /// <param name="inTarget">Input number</param>
        //private static string CheckInputParams(double inTarget)
        //{

        //}

        #endregion

        #region GCD

        /// <summary>
        /// Calculated NOD of numbers
        /// </summary>
        /// <param name="arr">Input params</param>
        /// <returns>NOD</returns>
        public int EucklidNOD(params int[] arr)
        {
            CheckInputParams(arr);

            Stopwatch sw = new Stopwatch();

            sw.Start();

            int temp = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                temp = EucklidNOD(temp, arr[i]);
            }

            var elapsedTime = sw.Elapsed;

            return temp;
        }

        /// <summary>
        /// Calculated NOD of numbers
        /// </summary>
        /// <param name="num1">Number 1</param>
        /// <param name="num2">Number 2</param>
        /// <returns>NOD</returns>
        private static int EucklidNOD(int num1, int num2)
        {
            while (num1 != num2)
            {
                if (num1 > num2)
                {
                    num1 -= num2;
                }
                else
                {
                    num2 -= num1;
                }
            }
            return num1;
        }


        /// <summary>
        /// Checking input params
        /// </summary>
        /// <param name="arr">Array</param>
        private static void CheckInputParams(params int[] arr)
        {
            if(arr.Length < 2)
            {
                throw new ArgumentException();
            }
        }

        #endregion
    }
}
