using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    internal static class ExpectedValues
    {
        public const int TestGeneratorSignalCount = 14;
        public const double TestGeneratorDataRecordDuration = 1.0;
        public static readonly List<string> TestGeneratorSignalLabels = new List<string>()
        { 
            "squarewave",
            "ramp",
            "pulse1",
            "pulse2",
            "pulse3",
            "noise",
            "sine1Hz",
            "sine8Hz+DC",
            "sine8.1777Hz+",
            "sine8.5Hz",
            "sine15Hz",
            "sine17Hz",
            "sine50Hz",
            "DC01"
        };
        public static readonly List<int> TestGeneratorSignalSamplesInDataRecord = new List<int>()
        {
            200,
            200,
            200,
            256,
            217,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            1000
        };

    }
}
