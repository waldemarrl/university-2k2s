#include <iostream>
#include "Winsock2.h"
#include "Windows.h"
#include "ErrorMessage.h"
#pragma comment (lib, "WS2_32.lib")
#pragma warning(disable:4996)
#define PIPE_NAME L"\\\\.\\pipe\\Tube"
#define PIPE_NAME_LAN L"\\\\DESKTOP-8HNL9IM\\pipe\\Tube"	
#define STOP "STOP"
using namespace std;








int main()
{
	setlocale(LC_ALL, "ru");
	int countOfMessages = 0;
	HANDLE cH; // дескриптор канала
	DWORD lp;
	DWORD mode = PIPE_READMODE_MESSAGE;
	char ibuf[50] = "Hello from ClientNPt ";
	char obuf[50];


	try
	{
		// 1.
		if ((cH = CreateFile(
			PIPE_NAME,								// [in] символическое имя канала 
			GENERIC_READ | GENERIC_WRITE,			// [in] чтение или запись в канал 
			FILE_SHARE_READ | FILE_SHARE_WRITE,		// [in] режим совместного использования
			NULL, OPEN_EXISTING, NULL,				// [in] атрибуты безопасности, флаги открытия канала
			NULL)) == INVALID_HANDLE_VALUE)
			throw SetPipeError("CreateFile: ", GetLastError());

		if (!SetNamedPipeHandleState(cH, &mode, NULL, NULL))
			throw SetPipeError("SetNamedPipeHandleState: ", GetLastError());




		cout << "Enter number of messages: ";
		cin >> countOfMessages;
		for (int i = 1; i <= countOfMessages; ++i)
		{
			string obufstr = "Hello from ClientNPt " + to_string(i);
			strcpy_s(obuf, obufstr.c_str());


			// 2, 3.
			if (!TransactNamedPipe(cH, obuf, sizeof(obuf), ibuf, sizeof(ibuf), &lp, NULL))
				throw SetPipeError("TransactNamedPipe: ", GetLastError());

			cout << "[OK] Sent message: " << ibuf << endl;
		}

		if (!WriteFile(cH, STOP, sizeof(STOP), &lp, NULL))
			throw SetPipeError("WriteFile: ", GetLastError());


		// 4.
		if (!CloseHandle(cH))
			throw SetPipeError("Close: ", GetLastError());
	}
	catch (string ErrorPipeText)
	{
		cout << "\n[FATAL] " << ErrorPipeText;
	}

}
