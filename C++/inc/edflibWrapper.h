#pragma once
// Check windows
#if _WIN32 || _WIN64
#ifdef _EXPORTING
#define DLLINTERFACE __declspec(dllexport) 
#else 
#define DLLINTERFACE __declspec(dllimport)
#endif
//#else // Linux / OS X
//#define DLLINTERFACE __attribute__((visibility("default")))
//#endif

#define EDFLIB_API DLLINTERFACE 

#pragma warning (disable:26454)
#pragma warning (disable:26451)

#if _WIN64
#if _DEBUG
#define ENVIRONMENT64D
#else 
#define ENVIRONMENT64
#endif
#else
#if _DEBUG
#define ENVIRONMENT32D
#else
#define ENVIRONMENT32
#endif
#endif
#endif

#ifdef __cplusplus
extern "C" {
#endif
#include "edflib.h"

typedef struct EdfReader_* EdfReader;

// open
extern EDFLIB_API EdfReader CreateReader(const char* path, int readAnnotations);

// header parsing
extern EDFLIB_API int getHeaderSignalCount(EdfReader obj, int* pnSignalCount);
extern EDFLIB_API int getHeaderDataRecordDuration(EdfReader obj, long long* pnSignalCount);

// signal params parsing
extern EDFLIB_API int getSignalLabel(EdfReader obj, int nSignalIndex, char* pLabel);
extern EDFLIB_API int getSignalSamplesInDataRecord(EdfReader obj, int nSignalIndex, int* pnSamplesInDataRecord);

// data reading
extern EDFLIB_API int ReadPhysicalSamples(EdfReader obj, int nSignal, int nSampleCount, double* pdBuffer);
extern EDFLIB_API int getSamplePosition(EdfReader obj, int nSignal, long long* pnPosition);
extern EDFLIB_API int setSamplePosition(EdfReader obj, int nSignal, long long nPosition);

#ifdef __cplusplus
} /* end extern "C" */
#endif
