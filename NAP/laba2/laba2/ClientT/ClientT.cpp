#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <clocale>
#include <ctime>
#include "ErrorMsgText.h"
#include "Winsock2.h"                
#pragma comment(lib, "WS2_32.lib")   
using namespace std;


int main()
{
    setlocale(LC_ALL, "rus");

    WSADATA wsaData;
    SOCKET cC;
    SOCKADDR_IN serv;
    serv.sin_family = AF_INET;
    serv.sin_port = htons(2000);
    serv.sin_addr.s_addr = inet_addr("127.0.0.1");

    try {
        cout << "ClientT\n\n";

        if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0) {
            throw  SetErrorMsgText("Startup: ", WSAGetLastError());
        }
        if ((cC = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET) {
            throw  SetErrorMsgText("socket: ", WSAGetLastError());
        }
        //bind() нет привязки параметров 
        // сервер всегда имеет стандартные параметры чтобы клиенты могли обратится 
        // клиенту нету надобности иметь стандартных параметров
        if ((connect(cC, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR) { //сокет для соединения
            throw SetErrorMsgText("connect: ", WSAGetLastError());
        }

        clock_t start, end;
        char ibuf[50] = "server: принято ";
        int  libuf = 0, lobuf = 0;

        int countMessage;
        cout << "Number of messages: ";
        cin >> countMessage;

        start = clock(); 
        for (int i = 1; i <= countMessage; i++) {
            string obuf = "Client send sms " + to_string(i);

            if ((lobuf = send(cC, obuf.c_str(), strlen(obuf.c_str()) + 1, NULL)) == SOCKET_ERROR) { //отправляем
                throw SetErrorMsgText("send: ", WSAGetLastError());
            }

            if ((libuf = recv(cC, ibuf, sizeof(ibuf), NULL)) == SOCKET_ERROR) {//принимаем
                throw SetErrorMsgText("recv: ", WSAGetLastError());
            }

            cout << ibuf << endl;
        }
        end = clock();
        string obuf = "";

        if ((lobuf = send(cC, obuf.c_str(), strlen(obuf.c_str()) + 1, NULL)) == SOCKET_ERROR) {
            throw SetErrorMsgText("send: ", WSAGetLastError());
        }

        cout << "Time for send and recv: " << ((double)(end - start) / CLK_TCK) << " c" << endl;

        if (closesocket(cC) == SOCKET_ERROR) {
            throw SetErrorMsgText("closesocket: ", WSAGetLastError());
        }
        if (WSACleanup() == SOCKET_ERROR) {
            throw  SetErrorMsgText("Cleanup: ", WSAGetLastError());
        }
    }
    catch (string errorMsgText) {
        cout << endl << errorMsgText;
    }


    system("pause");
    return 0;
}