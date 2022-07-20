#include "EdfReaderImpl.h"

namespace EDFlib
{
	EdfReaderImpl::EdfReaderImpl(const char* path, int readAnnotations)
	{
		edfopen_file_readonly(path, &m_header, readAnnotations);

		for (int i = 0; i < m_header.edfsignals; i++)
		{
			std::vector<double> vdSampleBuffer;
			int nSampleRate = (int)((long long)(m_header.signalparam[i].smp_in_datarecord * EDFLIB_TIME_DIMENSION)/ m_header.datarecord_duration);
			vdSampleBuffer.resize(nSampleRate);
			m_vvdPhysicalSampleBuffer.push_back(vdSampleBuffer);
		}
	}

	int EdfReaderImpl::getHeaderSignalCount(void)
	{
		if (m_header.filetype < 0)return m_header.filetype; // throw
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

	void EdfReaderImpl::ReadPhysicalSamples(int nSignal, int nSampleCount, double* bufferOut)
	{
		if (nSignal > m_vvdPhysicalSampleBuffer.size())
			return; // should throw
		if (m_vvdPhysicalSampleBuffer[nSignal].size() != nSampleCount)
			m_vvdPhysicalSampleBuffer[nSignal].resize(nSampleCount);
		int nSamples = edfread_physical_samples(m_header.handle, nSignal, nSampleCount, &m_vvdPhysicalSampleBuffer[nSignal][0]);
		if (nSamples < m_vvdPhysicalSampleBuffer[nSignal].size())
			m_vvdPhysicalSampleBuffer.resize(nSamples);
		bufferOut = &m_vvdPhysicalSampleBuffer[nSignal][0];
	}
}