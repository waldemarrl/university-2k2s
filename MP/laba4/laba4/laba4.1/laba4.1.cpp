#include <iostream>
#include <ctime>
#include <iomanip>
using namespace std;
#define _rand(min, max) ( rand() % ((max) - (min) + 1) + (min) )

int main()
{
	setlocale(LC_ALL, "rus");
	srand(time(NULL));
	char abc[25];
	char s1[300];
	char s2[250];

	for (int i = 97, n = 0; i <= 121; ++i, ++n)
	{
		abc[n] = (char)i;
	}
	cout << "S1 = ";
	for (int i = 1; i < 300; i++)
	{
		s1[i] = abc[_rand(0, 24)];
		if (i % 50 == 0)
			cout << "\n";
		cout << s1[i];
	}
	cout << endl;
	cout << "\nS2 =";
	for (int i = 1; i < 200; i++)
	{
		s2[i] = abc[_rand(0, 24)];
		if (i % 50 == 0)
			cout << "\n";
		cout << s2[i];
	}
	cout << "\n";

	system("pause");
	return 0;
}