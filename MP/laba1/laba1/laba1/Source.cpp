#include "Auxil.h"                            // ��������������� ������� 
#include <iostream>
#include <ctime>
using namespace std;

#define  CYCLE  1000000                       // ���������� ������  

int main()
{
	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0;
	setlocale(LC_ALL, "rus");
	for (int j = 1; j <= 10; j++) {
		auxil::start();
		// ����� ��������� 
		t1 = clock();                            // �������� ������� 
		for (int i = 0; i < CYCLE * j; i++)
		{
			av1 += (double)auxil::iget(-100, 100); // ����� ��������� ����� 
			av2 += auxil::dget(-100, 100);         // ����� ��������� ����� 
		}
		t2 = clock();                            // �������� ������� 
		cout << std::endl << "���������� ������:         " << CYCLE * j;
		cout << std::endl << "������� �������� (int):    " << av1 / CYCLE * j;
		cout << std::endl << "������� �������� (double): " << av2 / CYCLE;
		cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
		cout << std::endl << "                  (���):   "
			<< ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
		cout << std::endl;
	}

	/////////////////
	av1 = 10; av2 = 1;
	t1 = 0; t2 = 0;
	for (int i = 1; i <= 5; i++)
	{
		t1 = clock();
		for (int j = 1; j <= av1 *i; j++)
		{
			av2 = av2 * i;
		}
		t2 = clock();
		cout << av2;
		cout << std::endl << "���������� ������:         " << av1 * i;
		cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
		cout << std::endl << "                  (���):   " << ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
		cout << std::endl;
	}
	system("pause");
	return 0;
}