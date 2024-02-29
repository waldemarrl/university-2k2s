#include <iostream>
#include <iomanip>
#include "LCS.h"
#include "LCH.h"
#include <ctime>

int main()
{
    setlocale(LC_ALL, "ru");
    clock_t t1 = 0, t2 = 0, t3 = 0, t4 = 0;
    char X[] = "HRWCYUJHRWCYUJHRWCYUJ", Y[] = "WLPCAUWLPCAUWLPCAU";
    std::cout << "-- расстояние Левенштейна -----" << std::endl;
    std::cout << std::endl << "-- вычисление длины для X и Y";
    std::cout << std::endl << "-- последовательность X: " << X;
    std::cout << std::endl << "-- последовательность Y: " << Y;
    t1 = clock();
    int s = lcs(
        sizeof(X) - 1,  // длина   последовательности  X   
        "HRWCYUJHRWCYUJHRWCYUJ",       // последовательность X
        sizeof(Y) - 1,  // длина   последовательности  Y
        "WLPCAUWLPCAUWLPCAU"       // последовательность Y
    );
    t2 = clock();
    char z[100] = "";
    char x[] = "HRWCYUJHRWCYUJHRWCYUJ", y[] = "WLPCAUWLPCAUWLPCAU";
    t3 = clock();
    int l = lcsd(x, y, z);
    t4 = clock();
    std::cout << std::endl << "-- длина LCS(рекурсия): " << s << std::endl;
    std::cout << "-- длина LCH(ДП): " << l << std::endl;
    std::cout << "-- LCS: " <<(t2 - t1) << std::endl;
    std::cout << "-- LCH: " << (t4 - t3) << std::endl;
    system("pause");
    return 0;
}
