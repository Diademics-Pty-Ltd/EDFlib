using EDFlibCS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Test.Internal
{
    internal static class DataReadHelpers
    {
        private static readonly List<string> TestGeneratorFiles = new List<string>()
        {
            "test_generator_squarewave.txt",
            "test_generator_ramp.txt",
            "test_generator_pulse1.txt",
            "test_generator_pulse2.txt",
            "test_generator_pulse3.txt",
            "test_generator_noise.txt",
            "test_generator_sine1Hz.txt",
            "test_generator_sine8Hz_DC.txt",
            "test_generator_sine8_1777Hz_.txt",
            "test_generator_sine8_5Hz.txt",
            "test_generator_sine15Hz.txt",
            "test_generator_sine17Hz.txt",
            "test_generator_sine50Hz.txt",
            "test_generator_DC01.txt"
        };

        public static IReadOnlyList<double> ReadAllPhysicalDataEdf(EdfReader reader, int signalIndex, double blockLength)
        {
            List<double> data = new List<double>();
            IReadOnlyList<double> physicalData;
            while ((physicalData = reader.ReadPhysicalDataFromSingleSignal(signalIndex, blockLength:blockLength))!=null)
            {
                foreach(double datum in physicalData)
                    data.Add(datum);
            }
            return data;
        }

        public static IReadOnlyList<double> ReadAllPhysicalGroundTruthTestGenerator(int signalIndex)
        {
            List<double> data = new List<double>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), TestGeneratorFiles[signalIndex]);
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
                data.Add(Convert.ToDouble(line, CultureInfo.InvariantCulture));
            return data;
        }
    }
}
