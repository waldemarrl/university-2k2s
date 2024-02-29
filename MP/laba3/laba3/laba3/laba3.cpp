// 3.cpp: определяет точку входа для консольного приложения.
//
#include <iostream>
#include <iomanip> 
#include "Salesman.h"
#define N 5

using namespace std;


int main()
{
	setlocale(LC_ALL, "rus");
	int d[N][N] = { //  0     1     2     3     4        
					{ INF,   10,   26,  INF,    5 },    //  0
					{   5,  INF,   20,   63,   79 },    //  1
					{   7,   15,  INF,   86,   54 },    //  2 
					{  22,   53,   20,  INF,   15 },    //  3
					{  98,   71,   52,   18,  INF } };  //  4  
	int r[N];   /// результат 
	int s = salesman(
		N,          /// [in]  кол-во городов 
		(int*)d,    /// [in]  массив [n*n] расстояний 
		r           /// [out] массив [n] маршрут 0 x x x x  

	);
	cout << "\n-- Задача коммивояжера -- ";
	cout << "\n-- количество  городов: " << N;
	cout << "\n-- матрица расстояний : ";

	for (int i = 0; i < N; i++)
	{
		cout << "\n";
		for (int j = 0; j < N; j++)

			if (d[i][j] != INF) cout << setw(3) << d[i][j] << " ";

			else cout << setw(3) << "INF" << " ";
	}

	cout << "\n-- оптимальный маршрут: ";
	for (int i = 0; i < N; i++)
		cout << r[i] + 1 << "-->";

	cout << 1;
	cout << "\n-- длина маршрута     : " << s << "\n";
	system("pause");
	return 0;

}