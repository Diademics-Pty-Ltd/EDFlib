using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Internal
{
    internal static class DataComparer
    {
        public static bool AreEqual(IReadOnlyList<double> data1, IReadOnlyList<double> data2, double epsilon)
        {
            if (data1.Count != data2.Count) return false;
            for (int i = 0; i < data1.Count; i++)
                if (Math.Abs(data1[i] - data2[i]) > epsilon) return false;
            return true;
        }
    }
}
