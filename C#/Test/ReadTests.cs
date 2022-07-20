using EDFlibCS;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ReadTests
    {
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
            string path = Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator);
            EdfReader edfReader = new EdfReader(path);

            // Act
            int signalCount = edfReader.Header.SignalCount;

            // Assert
            Assert.Equal(ExpectedValues.TestGeneratorSignalCount, signalCount);
        }

        [Fact]
        public void TestGenerator_FileDuration_MatchesKnown()
        {
            // Arrange
            string path = Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator);
            EdfReader edfReader = new EdfReader(path);

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
            string path = Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator);
            if(signalIndex ==5)
                path = Path.Combine(Directory.GetCurrentDirectory(), TestFilePaths.test_generator);
            EdfReader edfReader = new EdfReader(path);

            // Act
            string label = "";
            try
            { 
               label = edfReader.Header.SignalParameters[signalIndex].Label;
            }
            catch (Exception)
            {
                ;
            }
            // Assert
            Assert.Equal(ExpectedValues.TestGeneratorSignalLabels[signalIndex], label);
        }

        [Fact]
        public void TestFile_PhysicalRead_MatchesKnownTestFileValues()
        {

        }
    }
}
