#include <iostream>
#include "Winsock2.h"
#include "Windows.h"
#include "ErrorMessage.h"
#pragma comment (lib, "WS2_32.lib")
#pragma warning(disable:4996)
#define PIPE_NAME L"\\\\.\\pipe\\Tube"
#define STOP "STOP"
#define CALLNP "Hello from ClientNPct 1"
using namespace std;






int main()
{
	setlocale(LC_ALL, "ru");
	HANDLE sH;	// дескриптор канала
	DWORD lp;
	char buf[50];

	try
	{
		// 1.
		if ((sH = CreateNamedPipe(
			PIPE_NAME,
			PIPE_ACCESS_DUPLEX,					// дуплексный канал 
			PIPE_TYPE_MESSAGE | PIPE_WAIT,		// сообщения|синхронный
			1, NULL, NULL,						// максимум 1 экземпляр
			INFINITE, NULL)) == INVALID_HANDLE_VALUE)
			throw SetPipeError("Create: ", GetLastError());

		if (!ConnectNamedPipe(sH, NULL))        // ожидать клиента   
			throw SetPipeError("Connect: ", GetLastError());




		while (true)
		{
			// 2. 
			if (ReadFile(sH, buf, sizeof(buf), &lp, NULL))
			{
				if (strcmp(buf, STOP) == 0)
					break;
				cout << "[OK] Received message: " << buf << endl;


				// 3.
				if (!WriteFile(sH, buf, sizeof(buf), &lp, NULL))
					throw SetPipeError("WriteFile: ", GetLastError());
				if (strcmp(buf, CALLNP) == 0)
					break;
			}
			else
				throw SetPipeError("ReadFile: ", GetLastError());
		}




		// 4.
		if (!DisconnectNamedPipe(sH))
			throw SetPipeError("Disconnect: ", GetLastError());
		if (!CloseHandle(sH))
			throw SetPipeError("Close: ", GetLastError());
	}
	catch (string ErrorPipeText)
	{
		cout << "\n[FATAL] " << ErrorPipeText;
	}

}