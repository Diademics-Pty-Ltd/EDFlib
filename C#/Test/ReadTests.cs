using EDFlibCS;
using System;
using System.Collections.Generic;
using System.IO;
using Test.Internal;
using Xunit;

namespace Test
{
    public class ReadTests
    {
        const double SignalCompareEpsilon = .001;
        [Fact]
        public void TestGenerator_CTor_Success()
        {
            // Arrange
            string path = Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator);

            // Act
            EdfReader edfReader = new EdfReader(path);

            // Assert
            Assert.NotNull(edfReader);
        }

        [Fact]
        public void TestGenerator_SignalCount_MatchesKnown()
        {
            // Arrange
            EdfReader edfReader = new EdfReader(Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator));

            // Act
            int signalCount = edfReader.Header.SignalCount;

            // Assert
            Assert.Equal(ExpectedValues.TestGeneratorSignalCount, signalCount);
        }

        [Fact]
        public void TestGenerator_FileDuration_MatchesKnown()
        {
            // Arrange
            EdfReader edfReader = new EdfReader(Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator));

            // Act
            double dataRecordDuration = edfReader.Header.DataRecordDuration;

            // Assert
            Assert.Equal(ExpectedValues.TestGeneratorDataRecordDuration, dataRecordDuration);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void TestGenerator_ChannelLabels_MatchKnown(int signalIndex)
        {
            // Arrange
            EdfReader edfReader = new EdfReader(Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator));

            // Act
            string label = edfReader.Header.SignalParameters[signalIndex].Label;

            // Assert
            Assert.Equal(ExpectedValues.TestGeneratorSignalLabels[signalIndex], label);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void TestGenerator_SamplesInDataRecord_MatchKnown(int signalIndex)
        {
            // Arrange
            EdfReader edfReader = new EdfReader(Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator));

            // Act
            int samplesInDataRecord = edfReader.Header.SignalParameters[signalIndex].SamplesInDataRecord;

            // Assert
            Assert.Equal(ExpectedValues.TestGeneratorSignalSamplesInDataRecord[signalIndex], samplesInDataRecord);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void TestGenerator_SamplingRates_MatchKnown(int signalIndex)
        {
            // Arrange
            EdfReader edfReader = new EdfReader(Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator));

            // Act
            double samplingRate = edfReader.Header.SignalParameters[signalIndex].SamplingRate;

            // Assert
            Assert.Equal((double)ExpectedValues.TestGeneratorSignalSamplesInDataRecord[signalIndex], samplingRate);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void TestGenerator_PhysicalRead_MatchesKnownTestFileValues(int signalIndex)
        {
            // Arrange
            EdfReader edfReader = new EdfReader(Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator));

            // Act
            IReadOnlyList<double> data = DataReadHelpers.ReadAllPhysicalDataEdf(edfReader, signalIndex, 1.0);

            // Assert
            Assert.True(DataComparer.AreEqual(DataReadHelpers.ReadAllPhysicalGroundTruthTestGenerator(signalIndex), data, SignalCompareEpsilon));
        }
    }
}
