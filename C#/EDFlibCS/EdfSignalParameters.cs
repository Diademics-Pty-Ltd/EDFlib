using EDFlibCS.Internal;
using System.Text;

namespace EDFlibCS
{
    public class EdfSignalParameters
    {
        private const int EdfMaxLabelLength = 17;
        private readonly byte[] _bytes = new byte[EdfMaxLabelLength];
        private readonly string _label;
        //private uint _samplesInFile;
        //private double _physicalMax;
        //private double _physicalMin;
        //private int _digitalMax;
        //private int _digitalMin;
        private int _samplesInDataRecord;
        //private string _physicalDimension;
        //private string _prefilter;
        //private string _transducer;

        //// derived parameters
        //private double _bitValue;
        //private double _offset;
        private double _samplingRate;

        public string Label => _label;
        public int SamplesInDataRecord => _samplesInDataRecord;
        public double SamplingRate => _samplingRate;

        public EdfSignalParameters(EdfReader edfReader, EdfHeader header, int signalIndex)
        {
            _ = DllHandler.getSignalLabel(edfReader.Obj, signalIndex, _bytes);
            var labelParts = Encoding.ASCII.GetString(_bytes).Split(' ');
            foreach (var part in labelParts)
                _label += part;
            _label = _label!.Split('\0')[0];
            _ = DllHandler.getSignalSamplesInDataRecord(edfReader.Obj, signalIndex, out _samplesInDataRecord);
            _samplingRate = _samplesInDataRecord / header.DataRecordDuration;
        }


    }
}
