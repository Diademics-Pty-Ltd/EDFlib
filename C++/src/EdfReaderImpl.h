#pragma once
#include "../inc/edflibWrapper.h"
#include <string>
#include <vector>

namespace EDFlib
{
	class EdfReaderImpl
	{
	private:
		struct edf_hdr_struct m_header;
		std::vector<std::vector<double>> m_vvdPhysicalSampleBuffer;

		void Error(int error)
		{
			if (error == 0)return;
			switch (error)
			{
			default:
				return;
			}
		}

	public:
		EdfReaderImpl(const char* path, int readAnnotations = EDFLIB_DO_NOT_READ_ANNOTATIONS);
		int getHeaderSignalCount(void);
		long long getHeaderDataRecordDuration(void);
		std::string getSignalLabel(int nSignalIndex);
		void ReadPhysicalSamples(int nSignal, int nSampleCount, double* buffer);
	};
}