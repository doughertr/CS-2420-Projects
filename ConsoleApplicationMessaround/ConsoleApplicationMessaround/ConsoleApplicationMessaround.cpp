// ConsoleApplicationMessaround.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
using std::cout;
using std::endl;


void main()
{
	int* myIntPointer = new int[5];
	cout << *myIntPointer << endl;
	for (int i = 0; i < 5; i++) {
		cout << myIntPointer[i] << endl;
	}
	delete[] myIntPointer;
}

