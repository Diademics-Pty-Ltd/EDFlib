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
			//std::string label = std::string(((EdfReaderImpl*)obj)->getSignalLabel(nSignalIndex).c_str());
			//for (int i = 0; i < 17; i++)
			//	pLabel[i] = label[i];
		}
		catch (std::exception ex)
		{

		}
		return 0;
	}


	// data reading
	EDFLIB_API int ReadPhysicalSamples(EdfReader obj, int nSignal, int nSamples, double* pdBuffer)
	{
		try
		{
			((EdfReaderImpl*)obj)->ReadPhysicalSamples(nSignal, nSamples, pdBuffer);
		}
		catch (std::exception ex)
		{

		}
		return 0;
	}
		
}