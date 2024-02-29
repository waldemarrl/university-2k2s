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
	char ibuf[50], obuf[50];


	try
	{
		cout << "Enter number of messages: ";
		cin >> countOfMessages;
		if (countOfMessages > 1)
		{
			cout << "Ты зачем больше одного сообщения отправляешь? У тебя щас всё сломается, смотри\n\n";
			Sleep(2000);
		}


		for (int i = 1; i <= countOfMessages; ++i)
		{
			string obufstr = "Hello from ClientNPct " + to_string(i);
			strcpy_s(obuf, obufstr.c_str());


			// 2, 3.
			if (!CallNamedPipe(PIPE_NAME, obuf, sizeof(obuf), ibuf, sizeof(ibuf), &lp, NMPWAIT_WAIT_FOREVER))
				throw SetPipeError("CallNamedPipe: ", GetLastError());

			cout << "[OK] Sent message: " << ibuf << endl;
		}

	}
	catch (string ErrorPipeText)
	{
		cout << "\n[FATAL] " << ErrorPipeText;
		cout << "Доволен?\n\n";
	}

}
