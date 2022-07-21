using EDFlibCS.Internal;
using System;
using System.Collections.Generic;
using System.IO;

namespace EDFlibCS
{
    public class EdfHeader
    {
        private readonly bool _isReadOnly;
        private const double EdfLibTimeDimension = 10000000.0;
        private int _signalCount;
        private double _dataRecordDuration;

        private readonly List<EdfSignalParameters> _edfSignalParameters = new List<EdfSignalParameters>();

        public string? Filename { get; }
        public int SignalCount => _signalCount;
        public double DataRecordDuration => _dataRecordDuration;

        public List<EdfSignalParameters> SignalParameters => _edfSignalParameters;

        // for use with EdfReader objects
        public EdfHeader(EdfReader edfReader)
        {
            _isReadOnly = true;
            Filename = edfReader.Filename;
            _ = DllHandler.getHeaderSignalCount(edfReader.Obj, out _signalCount);
            _ = DllHandler.getHeaderDataRecordDuration(edfReader.Obj, out ulong duration);
            _dataRecordDuration = duration / EdfLibTimeDimension;
            for (int i = 0; i < _signalCount; i++)
                _edfSignalParameters.Add(new EdfSignalParameters(edfReader, this, i));
        }

        // for use with EdfWriter objects
        public EdfHeader(string path)
        {
            try
            {
                Filename = Path.GetFileName(path);
            }
            catch (Exception)
            {

            }
            _isReadOnly = false;
        }

        public void SetSignalCount(int signalCount)
        {
            if (_isReadOnly)
                return;// throw
            _signalCount = signalCount;
        }
    }
}
