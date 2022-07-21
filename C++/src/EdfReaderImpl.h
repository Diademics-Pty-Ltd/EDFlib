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

	public:
		EdfReaderImpl(const char* path, int readAnnotations = EDFLIB_DO_NOT_READ_ANNOTATIONS);
		int getHeaderSignalCount(void);
		long long getHeaderDataRecordDuration(void);
		std::string getSignalLabel(int nSignalIndex);
		int getSignalSamplesInDataRecord(int nSignalIndex);
		int ReadPhysicalSamples(int nSignal, int nSampleCount, double* buffer);
		void getSamplePosition(int nSignal, long long* pnPosition);
		void setSamplePosition(int nSignal, long long nPosition);
	};
}