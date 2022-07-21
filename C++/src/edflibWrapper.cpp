#pragma once
#include "EdfReaderImpl.h"

extern "C" {
#include "../inc/edflibWrapper.h"

	using namespace EDFlib;

	// open
	EDFLIB_API EdfReader CreateReader(const char* path, int readAnnotations)
	{
		return (EdfReader)new EdfReaderImpl(path, readAnnotations);
	}

	// header parsing
	EDFLIB_API int getHeaderSignalCount(EdfReader obj, int* pnSignalCount)
	{
		try
		{
			*pnSignalCount = ((EdfReaderImpl*)obj)->getHeaderSignalCount();
		}
		catch(std::exception ex)
		{

		}
		return 0;
	}

	EDFLIB_API int getHeaderDataRecordDuration(EdfReader obj, long long* pnDataRecordDuration)
	{
		try
		{
			*pnDataRecordDuration = ((EdfReaderImpl*)obj)->getHeaderDataRecordDuration();
		}
		catch (std::exception ex)
		{

		}
		return 0; 
	}

	// signal params parsing
	EDFLIB_API int getSignalLabel(EdfReader obj, int nSignalIndex, char* pLabel)
	{
		try
		{
			strcpy(pLabel, ((EdfReaderImpl*)obj)->getSignalLabel(nSignalIndex).c_str());
		}
		catch (std::exception ex)
		{

		}
		return 0;
	}

	EDFLIB_API int getSignalSamplesInDataRecord(EdfReader obj, int nSignalIndex, int* pnSamplesInDataRecord)
	{
		try
		{
			*pnSamplesInDataRecord =  ((EdfReaderImpl*)obj)->getSignalSamplesInDataRecord(nSignalIndex);
		}
		catch (std::exception ex)
		{

		}
		return 0;
	}

	// data reading
	EDFLIB_API int ReadPhysicalSamples(EdfReader obj, int nSignal, int nSampleCount, double* pdBuffer)
	{
		int nSamplesRead = -1;
		try
		{
			nSamplesRead = ((EdfReaderImpl*)obj)->ReadPhysicalSamples(nSignal, nSampleCount, pdBuffer);
		}
		catch (std::exception ex)
		{

		}
		return nSamplesRead;
	}

	EDFLIB_API int getSamplePosition(EdfReader obj, int nSignal, long long* pnPosition)
	{
		try
		{
			((EdfReaderImpl*)obj)->getSamplePosition(nSignal, pnPosition);
		}
		catch (std::exception ex)
		{

		}
		return 0;
	}

	EDFLIB_API int setSamplePosition(EdfReader obj, int nSignal, long long nPosition)
	{
		try
		{
			((EdfReaderImpl*)obj)->setSamplePosition(nSignal, nPosition);
		}
		catch (std::exception ex)
		{

		}
		return 0;
	}
		
}