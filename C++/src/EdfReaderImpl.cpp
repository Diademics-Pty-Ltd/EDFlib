#include "EdfReaderImpl.h"

namespace EDFlib
{
	EdfReaderImpl::EdfReaderImpl(const char* path, int readAnnotations)
	{
		edfopen_file_readonly(path, &m_header, readAnnotations);
	}

	int EdfReaderImpl::getHeaderSignalCount(void)
	{
		if (m_header.filetype < 0)return m_header.filetype; 
		return m_header.edfsignals;
	}

	long long EdfReaderImpl::getHeaderDataRecordDuration(void)
	{
		if (m_header.filetype < 0)return 0;// throw
		return m_header.datarecord_duration;
	}

	std::string EdfReaderImpl::getSignalLabel(int nSignalIndex)
	{
		if (m_header.filetype < 0) return std::string("error");
		return std::string(m_header.signalparam[nSignalIndex].label);
	}

	int EdfReaderImpl::getSignalSamplesInDataRecord(int nSignalIndex)
	{
		if (m_header.filetype < 0) return m_header.filetype;
		return m_header.signalparam[nSignalIndex].smp_in_datarecord;
	}

	int EdfReaderImpl::ReadPhysicalSamples(int nSignal, int nSampleCount, double* bufferOut)
	{
		int nSamplesRead = 0;
		try
		{
			nSamplesRead = edfread_physical_samples(m_header.handle, nSignal, nSampleCount, bufferOut);
		}
		catch (std::exception ex)
		{
			;
		}
		return nSamplesRead;
	}

	void EdfReaderImpl::getSamplePosition(int nSignal, long long* pnPosition)
	{
		if (m_header.filetype < 0) return;
		*pnPosition = edftell(m_header.handle, nSignal);
		return;
	}

	void EdfReaderImpl::setSamplePosition(int nSignal, long long nPosition)
	{
		if (m_header.filetype < 0) return;
		edfseek(m_header.handle, nSignal, nPosition, EDFSEEK_SET);
		return;
	}
}