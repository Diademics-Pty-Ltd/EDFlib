using EDFlibCS.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        //private int _samplesInDataRecord;
        //private string _physicalDimension;
        //private string _prefilter;
        //private string _transducer;

        //// derived parameters
        //private double _bitValue;
        //private double _offset;

        public string Label => _label;


        public EdfSignalParameters(EdfReader edfReader, int signalIndex)
        {
            try
            {
                _ = DllHandler.getSignalLabel(edfReader.Obj, signalIndex, _bytes);
                _label = Encoding.ASCII.GetString(_bytes).Split(' ')[0];
            }
            catch(Exception)
            {
                ;
            }
        }


    }
}
