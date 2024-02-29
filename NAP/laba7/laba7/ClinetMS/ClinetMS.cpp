#include "Windows.h"
#include <iostream>
#include <string>
using namespace std;

string GetErrorMsgText(int code)
{

    string msgText;
    switch (code)
    {
    case WSAEINTR:  msgText = "Работа функции прервана";
        break;
    case WSAEACCES: msgText = "Разрешение отвергнуто";
        break;
    case WSAEFAULT: msgText = "Ошибочный адрес";
        break;
    case WSAEINVAL: msgText = "Ошибка в аргументе";
        break;
    case WSAEMFILE: msgText = "Слишком много файлов открыто";
        break;
    case WSAEWOULDBLOCK: msgText = "Ресурс временно недоступен";
        break;
    case WSAEINPROGRESS: msgText = "Операция в процессе развития";
        break;
    case WSAEALREADY: msgText = "Операция уже выполняется";
        break;
    case WSAENOTSOCK: msgText = "Сокет задан неправильно";
        break;
    case WSAEDESTADDRREQ: msgText = "Требуется адресс расположения";
        break;
    case WSAEMSGSIZE: msgText = "Сообщение слишком длинное";
        break;
    case WSAEPROTOTYPE: msgText = "Неправильный тип протокола для сокета";
        break;
    case WSAENOPROTOOPT: msgText = "Ошибка в опции протокола";
        break;
    case WSAEPROTONOSUPPORT: msgText = "Протокол не поддерживается";
        break;
    case WSAESOCKTNOSUPPORT: msgText = "Тип сокета не поддерживается";
        break;
    case WSAEOPNOTSUPP: msgText = "Операция не поддерживается";
        break;
    case WSAEPFNOSUPPORT: msgText = "Тип протоколов не поддерживается";
        break;
    case WSAEAFNOSUPPORT: msgText = "Тип адресов не поддерживается протоколом";
        break;
    case WSAEADDRINUSE: msgText = "Адрес уже используется";
        break;
    case WSAEADDRNOTAVAIL: msgText = "Запрошенный адрес не может быть использован";
        break;
    case WSAENETDOWN: msgText = "Сеть отключена";
        break;
    case WSAENETUNREACH: msgText = "Сеть не достежима";
        break;
    case WSAENETRESET: msgText = "Сеть разорвала соединение";
        break;
    case WSAECONNABORTED: msgText = "Программный отказ связи";
        break;
    case WSAECONNRESET: msgText = "Связь восстановлена";
        break;
    case WSAENOBUFS: msgText = "Не хватает памяти для буфферов";
        break;
    case WSAEISCONN: msgText = "Сокет уже подключен";
        break;
    case WSAENOTCONN: msgText = "Сокет не пожключен";
        break;
    case WSAESHUTDOWN: msgText = "Нельзя выолнить send: сокет завершил работу";
        break;
    case WSAETIMEDOUT: msgText = "Закончился отведенный интервал времени";
        break;
    case WSAECONNREFUSED: msgText = "Соединение отклонено";
        break;
    case WSAEHOSTDOWN: msgText = "Хост в неработоспособном состоянии";
        break;
    case WSAEHOSTUNREACH: msgText = "Нет маршрута для хоста";
        break;
    case WSAEPROCLIM: msgText = "Слишком много процессов";
        break;
    case WSASYSNOTREADY: msgText = "Сеть не доступна";
        break;
    case WSAVERNOTSUPPORTED: msgText = "Данная версия недоступна";
        break;
    case WSANOTINITIALISED: msgText = "Не выполнена инициализация WS2_32.DLL";
        break;
    case WSAEDISCON: msgText = "Выполняется отключение";
        break;
    case WSATYPE_NOT_FOUND: msgText = "Класс не найден";
        break;
    case WSAHOST_NOT_FOUND: msgText = "Хост не найден";
        break;
    case WSATRY_AGAIN: msgText = "Неавторизованный хост не найден";
        break;
    case WSANO_RECOVERY: msgText = "Неопределенная ошибка";
        break;
    case WSANO_DATA: msgText = "Не записи запрошенного типа";
        break;
    default: msgText = "Ошибка";
    };
    return msgText;
};
string SetErrorMsgText(string msgText, int code)
{
    return msgText + GetErrorMsgText(code);
};

int main()
{
    setlocale(LC_CTYPE, "Russian");

    HANDLE hM;
    DWORD wb;
    char wbuf[] = "Hello Mailslot";
    try
    {
        if ((hM = CreateFile(L"\\\\.\\mailslot\\Box",
            GENERIC_WRITE,
            FILE_SHARE_READ,
            NULL,
            OPEN_EXISTING,
            NULL, NULL)) == INVALID_HANDLE_VALUE)
            throw "CreateFileError";

        for (int i = 0; i <= 1000; i++)
        {
            if (!WriteFile(hM, wbuf, sizeof(wbuf), &wb, NULL))
                throw "ReadFileError";
            cout << wbuf << " " << i << endl;
        }
        CloseHandle(hM);
    }
    catch (string errorMsgText)
    {
        cout << endl << "WSAGetLastError: " << errorMsgText;
    }

    return 0;
}