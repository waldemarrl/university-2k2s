#include <iostream>
#include "Winsock2.h"
#include "Windows.h"
#include "ErrorMessage.h"
#pragma comment (lib, "WS2_32.lib")
#pragma warning(disable:4996)
#define PIPE_NAME L"\\\\.\\pipe\\Tube"
#define PIPE_NAME_LAN L"\\\\brruuuhhhh\\pipe\\Tube"	
#define STOP "STOP"
using namespace std;








int main()
{
	setlocale(LC_ALL, "ru");
	int countOfMessages = 0;
	HANDLE cH; // дескриптор канала
	DWORD lp;
	char buf[50];



	try
	{
		// 1.
		if ((cH = CreateFile(
			// для передачи в локальной сети: на сервере оставьте такой же локальный PIPE_NAME, 
			// а на клиента замените на его PIPE_NAME_LAN и введите в него имя своего серверного компа
			PIPE_NAME_LAN,								// [in] символическое имя канала 
			GENERIC_READ | GENERIC_WRITE,			// [in] чтение или запись в канал 
			FILE_SHARE_READ | FILE_SHARE_WRITE,		// [in] режим совместного использования
			NULL, OPEN_EXISTING, NULL,				// [in] атрибуты безопасности, флаги открытия канала
			NULL)) == INVALID_HANDLE_VALUE)
			throw SetPipeError("CreateFile: ", GetLastError());




		cout << "Enter number of messages: ";
		cin >> countOfMessages;
		for (int i = 1; i <= countOfMessages; ++i)
		{
			string obuf = "Hello from ClientNP " + to_string(i);

			// 2.
			if (!WriteFile(cH, obuf.c_str(), sizeof(obuf), &lp, NULL))
				throw SetPipeError("WriteFile: ", GetLastError());

			// 3.
			if (!ReadFile(cH, buf, sizeof(buf), &lp, NULL))
				throw SetPipeError("ReadFile: ", GetLastError());

			cout << "[OK] Sent message: " << buf << endl;
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
