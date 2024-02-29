#include <iostream>
#include <iomanip> 
#include <time.h>
#include "Salesman.h"

#define SPACE(n) std::setw(n)<<" "
#define N 10

int sum(int x1, int x2) // суммирование с учетом бесконечности 
{
    return (x1 == INF || x2 == INF) ? INF : (x1 + x2);
};
int* firstpath(int n) // формирование 1го маршрута 0,1,2,..., n-1, 0
{
    int* rc = new int[n + 1]; rc[n] = 0;
    for (int i = 0; i < n; i++) rc[i] = i;
    return rc;
};
int* source(int n)   // формирование исходного массива 1,2,..., n-1
{
    int* rc = new int[n - 1];
    for (int i = 1; i < n; i++) rc[i - 1] = i;
    return rc;
};
void  copypath(int n, int* r1, const int* r2)  // копировать маршрут
{
    for (int i = 0; i < n; i++)  r1[i] = r2[i];
};
int distance(int n, int* r, const int* d)       // длина маршрута 
{
    int rc = 0;
    for (int i = 0; i < n - 1; i++) rc = sum(rc, d[r[i] * n + r[i + 1]]);
    return  sum(rc, d[r[n - 1] * n + 0]);    //+ последняя дуга (n-1,0) 
};
void indx(int n, int* r, const int* s, const short* ntx)
{
    for (int i = 1; i < n; i++)  r[i] = s[ntx[i - 1]];
}
int salesman(
    int n,         // [in]  количество городов 
    const int* d,  // [in]  массив [n*n] расстояний 
    int* r         // [out] массив [n] маршрут 0 x x x x 
)
{
    int* s = source(n), * b = firstpath(n), rc = INF, dist = 0;
    combi::permutation p(n - 1);
    int k = p.getfirst();
    while (k >= 0)  // цикл генерации перестановок
    {
        indx(n, b, s, p.sset);        // новый маршрут 
        if ((dist = distance(n, b, d)) < rc)
        {
            rc = dist; copypath(n, r, b);
        }
        k = p.getnext();
    };
    return rc;
}

//int main()
//{
//    setlocale(LC_ALL, "rus");
//    int r[N];
//        srand(time(0));
//
//        int m, n;
//
//        m = 10 + (rand() % 4);
//        n = 10 + (rand() % 4);
//        float** arr = new float* [m]; // создание динамического двумерного массива на m строк
//        for (int i(0); i < m; i++) // создание каждого одномерного массива в динамическом двумерном массиве, или иначе - создание столбцов размерность n
//            arr[i] = new float[n];
//        int f = 10;
//
//        int s = salesman(
//            f,          // [in]  количество городов 
//            (int*)arr,          // [in]  массив [n*n] расстояний 
//            r           // [out] массив [n] маршрут 0 x x x x  
//
//        );
//        //заполнение массива от -10 до 10
//        for (int i = 0; i < m; i++) {
//            for (int j = 0; j < n; j++) {
//                arr[i][j] = rand() % 300 - 10;
//            }
//        }
//        //вывод чисел
//        std::cout << "Array: " << std::endl;
//        for (int i = 0; i < m; i++) {
//            for (int j = 0; j < n; j++) {
//                std::cout << arr[i][j] << " ";
//            }
//            std::cout << std::endl;
//        }
//    std::cout << std::endl << "-- Задача коммивояжера -- ";
//    std::cout << std::endl << "-- количество  городов: " << N;
//    std::cout << std::endl << "-- матрица расстояний : ";
//    for (int i = 0; i < N; i++)
//    {
//        std::cout << std::endl;
//        for (int j = 0; j < N; j++)
//
//            if (arr[i][j] != INF) std::cout << std::setw(3) << arr[i][j] << " ";
//
//            else std::cout << std::setw(3) << "INF" << " ";
//    }
//    std::cout << std::endl << "-- оптимальный маршрут: ";
//    for (int i = 0; i < N; i++) std::cout << r[i] << "-->"; std::cout << 0;
//    std::cout << std::endl << "-- длина маршрута     : " << s;
//    std::cout << std::endl;
//    system("pause");
//    return 0;
//}
//

//-------------------------------------------------------

//int main()
//{
//    setlocale(LC_ALL, "rus");
//    int d[N][N] = {//0      1     2     3     4     5     6     7     8    9
//                    {0,    10,   INF,   30,   40,   50,   60,   70,   80,   90 },    //  0
//                    {10,    0,  100,  110,  120,  130,  140,  150,  160,  170 },    //  1
//                    {INF,  100,    0,  180,  190,  200,  210,  220,  230,  240 },    //  2 
//                    {30,  110,  180,    0,  250,  260,  INF,  280,  290,  299 },    //  3
//                    {40,  120,  190,  250,    0,   15,   25,   35,   45,   55 },    //  4
//                    {50,  130,  200,  260,   15,    0,   65,   75,   INF,   95 },    //  5
//                    {60,  140,  210,  INF,   25,   65,    0,  105,  115,  125 },    //  6
//                    {70,  150,  220,  280,   35,   75,  105,    0,  135,  145 },    //  7 
//                    {80,  160,  230,  290,   45,   INF,  115,  135,    0,  133 },    //  8
//                    {90,  170,  240,  299,   55,   95,  125,  145,  133,    0 },    //  9  
//    };  
//    int r[N];                     // результат 
//    int s = salesman(
//        N,          // [in]  количество городов 
//        (int*)d,          // [in]  массив [n*n] расстояний 
//        r           // [out] массив [n] маршрут 0 x x x x  
//
//    );
//    std::cout << std::endl << "-- Задача коммивояжера -- ";
//    std::cout << std::endl << "-- количество  городов: " << N;
//    std::cout << std::endl << "-- матрица расстояний : ";
//    for (int i = 0; i < N; i++)
//    {
//        std::cout << std::endl;
//        for (int j = 0; j < N; j++)
//
//            if (d[i][j] != INF) std::cout << std::setw(3) << d[i][j] << " ";
//
//            else std::cout << std::setw(3) << "INF" << " ";
//    }
//    std::cout << std::endl << "-- оптимальный маршрут: ";
//    for (int i = 0; i < N; i++) std::cout << r[i] << "-->"; std::cout << 0;
//    std::cout << std::endl << "-- длина маршрута     : " << s;
//    std::cout << std::endl;
//    system("pause");
//    return 0;
//}

//--------------------------------------

//int GetRandomNumbers(int min, int max)
//{
//    // Установить генератор случайных чисел
//    srand(time(NULL));
//
//    // Получить случайное число - формула
//    int num = min + rand() % (max - min + 1);
//
//    return num;
//}
//
//int main()
//{
//    int i0, i1, i2, i3, i4, i5, i6, i7, i8, i9;
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int a[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int b[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int c[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int d[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int e[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int f[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int g[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int k[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int o[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//
//    srand(time(NULL));
//    i0 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i1 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i2 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i3 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i4 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i5 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i6 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i7 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i8 = GetRandomNumbers(10, 300);
//    srand(time(NULL));
//    i9 = GetRandomNumbers(10, 300);
//
//    int p[N] = { i0, i1, i2, i3, i4, i5, i6, i7, i8, i9 };
//   
//
//    setlocale(LC_ALL, "rus");
//    int d[N][N] = { {a[N] }, {b[N]}, {c[N]}, {d[N]}, {e[N]}, {f[N]},{g[N]},{k[N]}, {o[N]}, {p[N]} };
// 
//    int r[N];                     // результат 
//    int s = salesman(
//        N,          // [in]  количество городов 
//        (int*)d,          // [in]  массив [n*n] расстояний 
//        r           // [out] массив [n] маршрут 0 x x x x  
//
//    );
//    std::cout << std::endl << "-- Задача коммивояжера -- ";
//    std::cout << std::endl << "-- количество  городов: " << N;
//    std::cout << std::endl << "-- матрица расстояний : ";
//    for (int i = 0; i < N; i++)
//    {
//        std::cout << std::endl;
//        for (int j = 0; j < N; j++)
//
//            if (d[i][j] != INF) std::cout << std::setw(3) << d[i][j] << " ";
//
//            else std::cout << std::setw(3) << "INF" << " ";
//    }
//    std::cout << std::endl << "-- оптимальный маршрут: ";
//    for (int i = 0; i < N; i++) std::cout << r[i] << "-->"; std::cout << 0;
//    std::cout << std::endl << "-- длина маршрута     : " << s;
//    std::cout << std::endl;
//    system("pause");
//    return 0;
//}
//-----------------------------------------------------------------------------

int GetRandomNumbers(int min, int max)
{
    // Установить генератор случайных чисел
    int num = 0;
    // Получить случайное число - формула
    num = min + rand() % (max - min + 1);

    return num;
}

int main()
{
    setlocale(LC_ALL, "rus");
    int i0 = GetRandomNumbers(10, 300);

    int i1 = GetRandomNumbers(10, 300);
     
    int i2 = GetRandomNumbers(10, 300);

    int i3 = GetRandomNumbers(10, 300);

    int i4 = GetRandomNumbers(10, 300);
     
    int i5 = GetRandomNumbers(10, 300);
     
    int i6 = GetRandomNumbers(10, 300);
     
    int i7 = GetRandomNumbers(10, 300);
     
    int i8 = GetRandomNumbers(10, 300);
     
    int i9 = GetRandomNumbers(10, 300);
     
    int i10 = GetRandomNumbers(10, 300);
     
    int i11 = GetRandomNumbers(10, 300);
     
    int i12 = GetRandomNumbers(10, 300);
     
    int i13 = GetRandomNumbers(10, 300);
     
    int i14 = GetRandomNumbers(10, 300);
     
    int i15 = GetRandomNumbers(10, 300);
     
    int i16 = GetRandomNumbers(10, 300);
     
    int i17 = GetRandomNumbers(10, 300);
     
    int i18 = GetRandomNumbers(10, 300);
     
    int i19 = GetRandomNumbers(10, 300);
    int i20 = GetRandomNumbers(10, 300);
     
    int i21 = GetRandomNumbers(10, 300);
     
    int i22 = GetRandomNumbers(10, 300);
     
    int i23 = GetRandomNumbers(10, 300);
     
    int i24 = GetRandomNumbers(10, 300);
     
    int i25 = GetRandomNumbers(10, 300);
     
    int i26 = GetRandomNumbers(10, 300);
     
    int i27 = GetRandomNumbers(10, 300);
     
    int i28 = GetRandomNumbers(10, 300);
     
    int i29 = GetRandomNumbers(10, 300);

    int i30 = GetRandomNumbers(10, 300);
     
    int i31 = GetRandomNumbers(10, 300);
     
    int i32 = GetRandomNumbers(10, 300);
     
    int i33 = GetRandomNumbers(10, 300);
     
    int i34 = GetRandomNumbers(10, 300);
     
    int i35 = GetRandomNumbers(10, 300);
     
    int i36 = GetRandomNumbers(10, 300);
     
    int i37 = GetRandomNumbers(10, 300);
     
    int i38 = GetRandomNumbers(10, 300);
     
    int i39 = GetRandomNumbers(10, 300);
     
    int i40 = GetRandomNumbers(10, 300);
     
    int i41= GetRandomNumbers(10, 300);
     
    int i42 = GetRandomNumbers(10, 300);
     
    int i43 = GetRandomNumbers(10, 300);
     
    int i44 = GetRandomNumbers(10, 300);
     
    int i45 = GetRandomNumbers(10, 300);
     
    int i46 = GetRandomNumbers(10, 300);
     
    int i47 = GetRandomNumbers(10, 300);
     
    int i48 = GetRandomNumbers(10, 300);
     
    int i49 = GetRandomNumbers(10, 300);
     
    int i50 = GetRandomNumbers(10, 300);
     
    int i51 = GetRandomNumbers(10, 300);
     
    int i52 = GetRandomNumbers(10, 300);
     
    int i53 = GetRandomNumbers(10, 300);
     
    int i54 = GetRandomNumbers(10, 300);
     
    int i55 = GetRandomNumbers(10, 300);
     
    int i56 = GetRandomNumbers(10, 300);
     
    int i57 = GetRandomNumbers(10, 300);
     
    int i58 = GetRandomNumbers(10, 300);
     
    int i59 = GetRandomNumbers(10, 300);
    int i60 = GetRandomNumbers(10, 300);
     
    int i61 = GetRandomNumbers(10, 300);
     
    int i62 = GetRandomNumbers(10, 300);
     
    int i63 = GetRandomNumbers(10, 300);
     
    int i64 = GetRandomNumbers(10, 300);
     
    int i65 = GetRandomNumbers(10, 300);
     
    int i66 = GetRandomNumbers(10, 300);
     
    int i67 = GetRandomNumbers(10, 300);
     
    int i68 = GetRandomNumbers(10, 300);
     
    int i69 = GetRandomNumbers(10, 300);
    int i70 = GetRandomNumbers(10, 300);
     
    int i71 = GetRandomNumbers(10, 300);
     
    int i72 = GetRandomNumbers(10, 300);
     
    int i73 = GetRandomNumbers(10, 300);
     
    int i74 = GetRandomNumbers(10, 300);
     
    int i75 = GetRandomNumbers(10, 300);
     
    int i76 = GetRandomNumbers(10, 300);
     
    int i77 = GetRandomNumbers(10, 300);
     
    int i78 = GetRandomNumbers(10, 300);
     
    int i79 = GetRandomNumbers(10, 300);
    int i80 = GetRandomNumbers(10, 300);
     
    int i81 = GetRandomNumbers(10, 300);
     
    int i82 = GetRandomNumbers(10, 300);
     
    int i83 = GetRandomNumbers(10, 300);
     
    int i84 = GetRandomNumbers(10, 300);
     
    int i85 = GetRandomNumbers(10, 300);
     
    int i86 = GetRandomNumbers(10, 300);
     
    int i87 = GetRandomNumbers(10, 300);
     
    int i88 = GetRandomNumbers(10, 300);
     
    int i89 = GetRandomNumbers(10, 300);
    int i90 = GetRandomNumbers(10, 300);
     
    int i91 = GetRandomNumbers(10, 300);
     
    int i92 = GetRandomNumbers(10, 300);
     
    int i93 = GetRandomNumbers(10, 300);
     
    int i94 = GetRandomNumbers(10, 300);
     
    int i95 = GetRandomNumbers(10, 300);
     
    int i96 = GetRandomNumbers(10, 300);
     
    int i97 = GetRandomNumbers(10, 300);
     
    int i98 = GetRandomNumbers(10, 300);

    int i99 = GetRandomNumbers(10, 300);
    int d[N][N] = {//0      1     2     3     4     5     6     7     8    9
                    { i0,   i1,  INF,   i3,   i4,   i5,   i6,   i7,   i8,   i9 },    //  0
                    {i10,  i11,  i12,  i13,  i14,  i15,  i16,  i17,  i18,  i19 },    //  1
                    {INF,  i21,  i22,  i23,  i24,  i25,  i26,  i27,  i28,  i29 },    //  2 
                    {i30,  i31,  i32,  i33,  i34,  i35,  i36,  i37,  i38,  i39 },    //  3
                    {i40,  i41,  i42,  i43,  i44,  i45,  i46,  i47,  i48,  i49 },    //  4
                    {i50,  i51,  i52,  i53,  i54,  i55,  i56,  i57,  INF,  i59 },    //  5
                    {i60,  i61,  i62,  INF,  i64,  i65,  i66,  i67,  i68,  i69 },    //  6
                    {i70,  i71,  i72,  i73,  i74,  i75,  i76,  i77,  i78,  i79 },    //  7 
                    {i80,  i81,  i82,  i83,  i84,  INF,  i86,  i87,  i88,  i89 },    //  8
                    {i90,  i91,  i92,  i93,  i94,  i95,  i96,  i97,  i98,  i99 },    //  9  
    };  
    int r[N];                     // результат 
    int s = salesman(
        N,          // [in]  количество городов 
        (int*)d,          // [in]  массив [n*n] расстояний 
        r           // [out] массив [n] маршрут 0 x x x x  

    );
    std::cout << std::endl << "-- Задача коммивояжера -- ";
    std::cout << std::endl << "-- количество  городов: " << N;
    std::cout << std::endl << "-- матрица расстояний : ";
    for (int i = 0; i < N; i++)
    {
        std::cout << std::endl;
        for (int j = 0; j < N; j++)

            if (d[i][j] != INF) std::cout << std::setw(3) << d[i][j] << " ";

            else std::cout << std::setw(3) << "INF" << " ";
    }
    std::cout << std::endl << "-- оптимальный маршрут: ";
    for (int i = 0; i < N; i++) std::cout << r[i] << "-->"; std::cout << 0;
    std::cout << std::endl << "-- длина маршрута     : " << s;
    std::cout << std::endl;
    system("pause");
    return 0;
}
