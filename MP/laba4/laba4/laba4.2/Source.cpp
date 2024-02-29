#include "stdio.h"
#include <algorithm>
#include <iostream>
#include <ctime>
#include <iomanip>
#include "Levenshtein.h"
#define _rand(min, max) ( rand() % ((max) - (min) + 1) + (min) )


#define S1SIZE 150
#define S2SIZE 250
#define OUTPUTROWSIZE 20

using namespace std;

char cget() {
    char array[] = "qwertyuiopasdfghjklzxcvbnm";
    return array[(int)rand() % 26];
};

int main()
{
    setlocale(LC_ALL, "ru");
    char s1[S1SIZE] = "";
    char s2[S2SIZE] = "";
    for (int i = 0; i < S1SIZE; i++)
    {
        s1[i] = cget();
    }
    for (int i = 0; i < S2SIZE; i++)
    {
        s2[i] = cget();
    }


    for (int i = 0; i < S1SIZE / OUTPUTROWSIZE; i++)
    {
        for (int j = 0; j < OUTPUTROWSIZE; j++)
        {
            s1[j + i * OUTPUTROWSIZE];
        }
    }
    for (int i = 0; i < S2SIZE / OUTPUTROWSIZE; i++)
    {
        for (int j = 0; j < OUTPUTROWSIZE; j++)
        {
            s2[j + i * OUTPUTROWSIZE];
        }
    }

    clock_t t1 = 0, t2 = 0, t3, t4;
    double dividers[7] = { 1.0 / 25.0, 1.0 / 20.0, 1.0 / 15.0, 1.0 / 10.0, 1.0 / 5.0, 1.0 / 2.0, 1.0 };

    int  lx = sizeof(s1) - 1, ly = sizeof(s2) - 1;
    std::cout << std::endl << "-- расстояние Левенштейна -----" << std::endl;
    std::cout << std::endl << "--длина --- рекурсия -- дин.програм. ---" << std::endl;
    for (int i = 0; i < 7; i++)
    {
       /* t1 = clock(); levenshtein_r(lx * dividers[i], s1, ly * dividers[i], s2); t2 = clock();*/
        t3 = clock(); levenshtein(lx * dividers[i], s1, ly * dividers[i], s2); t4 = clock();
        std::cout << std::right << std::setw(2) << 1 << "/" << std::setw(2) << 1 / (double)dividers[i] << "        " << std::left << std::setw(10) << (t2 - t1)
            << "   " << std::setw(10) << (t4 - t3) << std::endl;
    }
}
