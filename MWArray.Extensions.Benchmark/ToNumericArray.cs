using MathWorks.MATLAB.NET.Arrays;
using MATLAB.NET.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWArray.Extensions.Benchmark
{
    public class ToNumericArray
    {
        static int len;
        static int resultLen;

        static int[] hundredThousandIntArray;
        static double[] hundredThousandDoubleArray;

        static int[] milionIntArray;
        static double[] milionDoubleArray;

        static int[] tenMilionIntArray;
        static double[] tenMilionDoubleArray;

        static int[] hundredMilionIntArray;
        static double[] hundredMilionDoubleArray;

        public static void Init(string[] args)
        {
            hundredThousandIntArray = Enumerable.Range(0, 100000).ToArray();
            hundredThousandDoubleArray = Enumerable.Range(0, 100000).Select(i => (double)i).ToArray();

            milionIntArray = Enumerable.Range(0, 1000000).ToArray();
            milionDoubleArray = Enumerable.Range(0, 1000000).Select(i => (double)i).ToArray();

            tenMilionIntArray = Enumerable.Range(0, 10000000).ToArray();
            tenMilionDoubleArray = Enumerable.Range(0, 10000000).Select(i => (double)i).ToArray();

            hundredMilionIntArray = Enumerable.Range(0, 100000000).ToArray();
            hundredMilionDoubleArray = Enumerable.Range(0, 100000000).Select(i => (double)i).ToArray();
        }

        public static void Check()
        {
            if (len != resultLen) throw new Exception("Result array doesn't have the right size.");
        }

        public static void Reset()
        {
            // Make sure that tests which don't produce anything don't end up using the previous result
            resultLen = 0;
        }


        [Benchmark]
        public static void HundredThousandIntItemsArray()
        {
            len = hundredThousandIntArray.Length;
            resultLen = MWArrayExtensions.ToArray<int>(new MWNumericArray(hundredThousandIntArray as Array)).Length;
        }

        [Benchmark]
        public static void MilionIntItemsArray()
        {
            len = milionIntArray.Length;
            resultLen = MWArrayExtensions.ToArray<int>(new MWNumericArray(milionIntArray as Array)).Length;
        }

        [Benchmark]
        public static void TenMilionIntItemsArray()
        {
            len = tenMilionIntArray.Length;
            resultLen = MWArrayExtensions.ToArray<int>(new MWNumericArray(tenMilionIntArray as Array)).Length;
        }

        [Benchmark]
        public static void TenMilionIntItemsArrayWitchChangeTypeToDouble()
        {
            len = tenMilionIntArray.Length;
            resultLen = MWArrayExtensions.ToArray<double>(new MWNumericArray(tenMilionIntArray as Array)).Length;
        }

        [Benchmark]
        public static void HundredMilionIntItemsArray()
        {
            len = hundredMilionIntArray.Length;
            resultLen = MWArrayExtensions.ToArray<int>(new MWNumericArray(hundredMilionIntArray as Array)).Length;
        }

        [Benchmark]
        public static void HundredThousandDoubleItemsArray()
        {
            len = hundredThousandDoubleArray.Length;
            resultLen = MWArrayExtensions.ToArray<double>(new MWNumericArray(hundredThousandDoubleArray as Array)).Length;
        }

        [Benchmark]
        public static void MilionDoubleItemsArray()
        {
            len = milionDoubleArray.Length;
            resultLen = MWArrayExtensions.ToArray<double>(new MWNumericArray(milionDoubleArray as Array)).Length;
        }

        [Benchmark]
        public static void TenMilionDoubleItemsArrayWithChangeTypeToInt()
        {
            len = tenMilionDoubleArray.Length;
            resultLen = MWArrayExtensions.ToArray<int>(new MWNumericArray(tenMilionDoubleArray as Array)).Length;
        }

        [Benchmark]
        public static void TenMilionDoubleItemsArray()
        {
            len = tenMilionDoubleArray.Length;
            resultLen = MWArrayExtensions.ToArray<double>(new MWNumericArray(tenMilionDoubleArray as Array)).Length;
        }

        [Benchmark]
        public static void HundredMilionDoubleItemsArray()
        {
            len = hundredMilionDoubleArray.Length;
            resultLen = MWArrayExtensions.ToArray<double>(new MWNumericArray(hundredMilionDoubleArray as Array)).Length;
        }
    }
}
