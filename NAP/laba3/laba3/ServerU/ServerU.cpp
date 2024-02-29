#include <iostream>
#include <clocale>
#include <ctime>

#include "ErrorMsgText.h"
#include "Winsock2.h"

#pragma warning(disable : 4996)
#pragma comment(lib, "WS2_32.lib")  

#define PORT 2000


int main()
{
    setlocale(LC_ALL, "rus");

    WSADATA wsaData;

    SOCKET  sS;
    SOCKADDR_IN serv;
    serv.sin_family = AF_INET;
    serv.sin_port = htons(PORT);
    serv.sin_addr.s_addr = INADDR_ANY;

    try {
        cout << "ServerU\n\n";

        if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0) {
            throw  SetErrorMsgText("Startup: ", WSAGetLastError());
        }
        if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET) {
            throw  SetErrorMsgText("socket: ", WSAGetLastError());
        }
        if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR) {
            throw  SetErrorMsgText("bind: ", WSAGetLastError());
        }
        //нет предварительного подключения 


        SOCKADDR_IN clnt;
        memset(&clnt, 0, sizeof(clnt));
        char ibuf[40000];
        int lc = sizeof(clnt), lb = 0, lobuf = 0;
        clock_t start, end;
        bool flag = true;

        while (true) {
            //потеря сообщений (функцию  Sleep(10) раскоментитьзакоментить)
            //std::cout << ' ';
            Sleep(100);
            if ((lb = recvfrom(sS, ibuf, sizeof(ibuf), NULL, (sockaddr*)&clnt, &lc)) == SOCKET_ERROR) { //получаем сообщение
                throw  SetErrorMsgText("recvfrom:", WSAGetLastError());
            }
            else {
                if (flag) {
                    flag = false;
                    start = clock();
                }
            }
 /*           if ((lobuf = sendto(sS, ibuf, strlen(ibuf) + 1, NULL, (sockaddr*)&clnt, lc)) == SOCKET_ERROR) {
                 throw SetErrorMsgText("sendto: ", WSAGetLastError());
             } */

            if (strcmp(ibuf, "") == 0) {
                end = clock();
                flag = true;
                cout << "\nTime for sendto and recvfrom: " << ((double)(end - start) / CLK_TCK) << " c\n\n";
            }
            else {
                cout << ibuf << endl;
            }
        }

        if (closesocket(sS) == SOCKET_ERROR) {
            throw  SetErrorMsgText("closesocket: ", WSAGetLastError());
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