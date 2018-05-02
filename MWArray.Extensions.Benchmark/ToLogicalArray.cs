using MathWorks.MATLAB.NET.Arrays;
using MATLAB.NET.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWArray.Extensions.Benchmark
{
    public class ToLogicalArray
    {
        static int len;
        static int resultLen;

        static bool[] hundredThousandBoolArray;
        static bool[] milionBoolArray;
        static bool[] tenMilionBoolArray;
        static bool[] hundredMilionBoolArray;

        public static void Init(string[] args)
        {
            hundredThousandBoolArray = Enumerable.Range(0, 100000).Select(i => Convert.ToBoolean(i)).ToArray();
            milionBoolArray = Enumerable.Range(0, 1000000).Select(i => Convert.ToBoolean(i)).ToArray();
            tenMilionBoolArray = Enumerable.Range(0, 10000000).Select(i => Convert.ToBoolean(i)).ToArray();
            hundredMilionBoolArray = Enumerable.Range(0, 100000000).Select(i => Convert.ToBoolean(i)).ToArray();
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
        public static void HundredThousandBoolItemsArray()
        {
            len = hundredThousandBoolArray.Length;
            resultLen = MWArrayExtensions.ToArray<bool>(new MWLogicalArray(hundredThousandBoolArray as Array)).Length;
        }

        [Benchmark]
        public static void MilionBoolItemsArray()
        {
            len = milionBoolArray.Length;
            resultLen = MWArrayExtensions.ToArray<bool>(new MWLogicalArray(milionBoolArray as Array)).Length;
        }

        [Benchmark]
        public static void TenMilionBoolItemsArray()
        {
            len = tenMilionBoolArray.Length;
            resultLen = MWArrayExtensions.ToArray<bool>(new MWLogicalArray(tenMilionBoolArray as Array)).Length;
        }

        [Benchmark]
        public static void TenMilionBoolItemsArrayWithChangeToInt()
        {
            len = tenMilionBoolArray.Length;
            resultLen = MWArrayExtensions.ToArray<int>(new MWLogicalArray(tenMilionBoolArray as Array)).Length;
        }

        [Benchmark]
        public static void TenMilionBoolItemsArrayWithChangeToString()
        {
            len = tenMilionBoolArray.Length;
            resultLen = MWArrayExtensions.ToArray<string>(new MWLogicalArray(tenMilionBoolArray as Array)).Length;
        }

        [Benchmark]
        public static void HundredMilionBoolItemsArray()
        {
            len = hundredMilionBoolArray.Length;
            resultLen = MWArrayExtensions.ToArray<bool>(new MWLogicalArray(hundredMilionBoolArray as Array)).Length;
        }
    }
}
