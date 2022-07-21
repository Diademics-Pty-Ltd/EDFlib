using System;
using System.Collections.Generic;
using System.Text;

namespace EDFlibCS.Internal
{
    internal class EdfPhysicalSignalReader
    {
        private readonly EdfReader _reader;
        private readonly int _signalIndex;
        private double _blockLength;
        private double[] _sampleBlock;

        public ulong CurrentSamplePosition { get; }
        public double CurrentTimePosition { get; }
        public double BlockLength
        {
            get => _blockLength;
            set
            {
                if (BlockLength != value)
                    Array.Resize(ref _sampleBlock, (int)(value * SignalParameters!.SamplingRate));
                _blockLength = value;
            }
        }

        private EdfSignalParameters? SignalParameters => _reader.Header.SignalParameters[_signalIndex];

        public EdfPhysicalSignalReader(EdfReader reader, int signalIndex, double blockLength = 1.0)
        { 
            _reader = reader;
            _signalIndex = signalIndex;
            _blockLength = blockLength;
            _sampleBlock = new double[(int)(_reader.Header.SignalParameters[signalIndex].SamplingRate * blockLength)];
        }

        public void GoToSamplePosition(ulong samplePosition)
        {
            _ = DllHandler.setSamplePosition(_reader.Obj, _signalIndex, samplePosition);
        }

        public void GoToTimePosition(double time)
        {
            if (time < 0.0) return; // throw
            ulong samplePosition = (ulong)(time * SignalParameters!.SamplingRate);
            _ = DllHandler.setSamplePosition(_reader.Obj, _signalIndex, samplePosition);
        }

        public IReadOnlyList<double>? ReadSamples()
        {
            int samples = DllHandler.ReadPhysicalSamples(_reader.Obj, _signalIndex, _sampleBlock.Length, _sampleBlock);
            if (samples == 0) return null;
            if (samples!=_sampleBlock.Length)
                Array.Resize(ref _sampleBlock, samples);
            return _sampleBlock;
        }
    }
}
